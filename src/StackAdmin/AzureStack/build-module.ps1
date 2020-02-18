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

$dll = Join-Path $PSScriptRoot 'bin\AzureStack.private.dll'
if(-not (Test-Path $dll)) {
  Write-Error "Unable to find output assembly in '$binFolder'."
}



Write-Host -ForegroundColor Green '-------------Done-------------'
