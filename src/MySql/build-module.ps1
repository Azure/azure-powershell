# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
param([switch]$Isolated, [switch]$Run, [switch]$Test, [switch]$Docs, [switch]$Pack, [switch]$Code, [switch]$Release, [switch]$Debugger, [switch]$NoDocs)
$ErrorActionPreference = 'Stop'

if($PSEdition -ne 'Core') {
  Write-Error 'This script requires PowerShell Core to execute. [Note] Generated cmdlets will work in both PowerShell Core or Windows PowerShell.'
}

if(-not $Isolated -and -not $Debugger) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  $pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
  & "$pwsh" -NonInteractive -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated

  if($LastExitCode -ne 0) {
    # Build failed. Don't attempt to run the module.
    return
  }

  if($Test) {
    . (Join-Path $PSScriptRoot 'test-module.ps1')
    if($LastExitCode -ne 0) {
      # Tests failed. Don't attempt to run the module.
      return
    }
  }

  if($Docs) {
    . (Join-Path $PSScriptRoot 'generate-help.ps1')
    if($LastExitCode -ne 0) {
      # Docs generation failed. Don't attempt to run the module.
      return
    }
  }

  if($Pack) {
    . (Join-Path $PSScriptRoot 'pack-module.ps1')
    if($LastExitCode -ne 0) {
      # Packing failed. Don't attempt to run the module.
      return
    }
  }

  $runModulePath = Join-Path $PSScriptRoot 'run-module.ps1'
  if($Code) {
    . $runModulePath -Code
  } elseif($Run) {
    . $runModulePath
  } else {
    Write-Host -ForegroundColor Cyan "To run this module in an isolated PowerShell session, run the 'run-module.ps1' script or provide the '-Run' parameter to this script."
  }
  return
}

$binFolder = Join-Path $PSScriptRoot 'bin'
$objFolder = Join-Path $PSScriptRoot 'obj'

if(-not $Debugger) {
  Write-Host -ForegroundColor Green 'Cleaning build folders...'
  $null = Remove-Item -Recurse -ErrorAction SilentlyContinue -Path $binFolder, $objFolder

  if((Test-Path $binFolder) -or (Test-Path $objFolder)) {
    Write-Host -ForegroundColor Cyan 'Did you forget to exit your isolated module session before rebuilding?'
    Write-Error 'Unable to clean ''bin'' or ''obj'' folder. A process may have an open handle.'
  }

  Write-Host -ForegroundColor Green 'Compiling module...'
  $buildConfig = 'Debug'
  if($Release) {
    $buildConfig = 'Release'
  }
  dotnet publish $PSScriptRoot --verbosity quiet --configuration $buildConfig /nologo
  if($LastExitCode -ne 0) {
    Write-Error 'Compilation failed.'
  }

  $null = Remove-Item -Recurse -ErrorAction SilentlyContinue -Path (Join-Path $binFolder 'Debug'), (Join-Path $binFolder 'Release')
}

$dll = Join-Path $PSScriptRoot 'bin/Az.MySql.private.dll'
if(-not (Test-Path $dll)) {
  Write-Error "Unable to find output assembly in '$binFolder'."
}

# Load DLL to use build-time cmdlets
$null = Import-Module -Name $dll

$modulePaths = $dll
$customPsm1 = Join-Path $PSScriptRoot 'custom/Az.MySql.custom.psm1'
if(Test-Path $customPsm1) {
  $modulePaths = @($dll, $customPsm1)
}

$exportsFolder = Join-Path $PSScriptRoot 'exports'
if(Test-Path $exportsFolder) {
  $null = Get-ChildItem -Path $exportsFolder -Recurse -Exclude 'readme.md' | Remove-Item -Recurse -ErrorAction SilentlyContinue
}
$null = New-Item -ItemType Directory -Force -Path $exportsFolder

$internalFolder = Join-Path $PSScriptRoot 'internal'
if(Test-Path $internalFolder) {
  $null = Get-ChildItem -Path $internalFolder -Recurse -Exclude '*.psm1', 'readme.md' | Remove-Item -Recurse -ErrorAction SilentlyContinue
}
$null = New-Item -ItemType Directory -Force -Path $internalFolder

$psd1 = Join-Path $PSScriptRoot './Az.MySql.psd1'
$guid = Get-ModuleGuid -Psd1Path $psd1
$moduleName = 'Az.MySql'
$examplesFolder = Join-Path $PSScriptRoot 'examples'
$null = New-Item -ItemType Directory -Force -Path $examplesFolder

if($NoDocs) {
  Write-Host -ForegroundColor Green 'Creating exports...'
  Export-ProxyCmdlet -ModuleName $moduleName -ModulePath $modulePaths -ExportsFolder $exportsFolder -InternalFolder $internalFolder -ExcludeDocs
} else {
  Write-Host -ForegroundColor Green 'Creating exports and docs...'
  $moduleDescription = 'Microsoft Azure PowerShell: MySql cmdlets'
  $docsFolder = Join-Path $PSScriptRoot 'docs'
  if(Test-Path $docsFolder) {
    $null = Get-ChildItem -Path $docsFolder -Recurse -Exclude 'readme.md' | Remove-Item -Recurse -ErrorAction SilentlyContinue
  }
  $null = New-Item -ItemType Directory -Force -Path $docsFolder
  Export-ProxyCmdlet -ModuleName $moduleName -ModulePath $modulePaths -ExportsFolder $exportsFolder -InternalFolder $internalFolder -ModuleDescription $moduleDescription -DocsFolder $docsFolder -ExamplesFolder $examplesFolder -ModuleGuid $guid
}

Write-Host -ForegroundColor Green 'Creating format.ps1xml...'
$formatPs1xml = Join-Path $PSScriptRoot './Az.MySql.format.ps1xml'
Export-FormatPs1xml -FilePath $formatPs1xml

Write-Host -ForegroundColor Green 'Creating psd1...'
$customFolder = Join-Path $PSScriptRoot 'custom'
Export-Psd1 -ExportsFolder $exportsFolder -CustomFolder $customFolder -Psd1Path $psd1 -ModuleGuid $guid

Write-Host -ForegroundColor Green 'Creating test stubs...'
$testFolder = Join-Path $PSScriptRoot 'test'
$null = New-Item -ItemType Directory -Force -Path $testFolder
Export-TestStub -ModuleName $moduleName -ExportsFolder $exportsFolder -OutputFolder $testFolder

Write-Host -ForegroundColor Green 'Creating example stubs...'
Export-ExampleStub -ExportsFolder $exportsFolder -OutputFolder $examplesFolder

Write-Host -ForegroundColor Green '-------------Done-------------'
