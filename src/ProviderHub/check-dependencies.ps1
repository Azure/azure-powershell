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
param([switch]$Isolated, [switch]$Accounts, [switch]$Pester, [switch]$Resources)
$ErrorActionPreference = 'Stop'

if(-not $Isolated) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  $pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
  & "$pwsh" -NoExit -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
  return
}

function DownloadModule ([bool]$predicate, [string]$path, [string]$moduleName, [string]$versionMinimum, [string]$requiredVersion) {
  if($predicate) {
    $module = Get-Module -ListAvailable -Name $moduleName
    if((-not $module) -or ($versionMinimum -and ($module | ForEach-Object { $_.Version } | Where-Object { $_ -ge [System.Version]$versionMinimum } | Measure-Object).Count -eq 0)) {
      $null = New-Item -ItemType Directory -Force -Path $path
      Write-Host -ForegroundColor Green "Installing local $moduleName module into '$path'..."
      if ($requiredVersion) {
        Find-Module -Name $moduleName -RequiredVersion $requiredVersion -Repository PSGallery | Save-Module -Path $path
      }elseif($versionMinimum) {
        Find-Module -Name $moduleName -MinimumVersion $versionMinimum -Repository PSGallery | Save-Module -Path $path
      } else {
        Find-Module -Name $moduleName -Repository PSGallery | Save-Module -Path $path
      }
    }
  }
}

$ProgressPreference = 'SilentlyContinue'
$all = (@($Accounts.IsPresent, $Pester.IsPresent) | Select-Object -Unique | Measure-Object).Count -eq 1

$localModulesPath = Join-Path $PSScriptRoot 'generated\modules'
if(Test-Path -Path $localModulesPath) {
  $env:PSModulePath = "$localModulesPath$([IO.Path]::PathSeparator)$env:PSModulePath"
}

DownloadModule -predicate ($all -or $Accounts) -path $localModulesPath -moduleName 'Az.Accounts' -versionMinimum '2.2.3'
DownloadModule -predicate ($all -or $Pester) -path $localModulesPath -moduleName 'Pester' -requiredVersion '4.10.1'

$tools = Join-Path $PSScriptRoot 'tools'
$resourceDir = Join-Path $tools 'Resources'
$resourceModule = Join-Path $HOME '.PSSharedModules\Resources\Az.Resources.TestSupport.psm1'

if ($Resources.IsPresent -and ((-not (Test-Path -Path $resourceModule)) -or $RegenerateSupportModule.IsPresent)) {
  Write-Host -ForegroundColor Green "Building local Resource module used for test..."
  Set-Location $resourceDir
  $null = autorest .\readme.md --use:@autorest/powershell@3.0.414 --output-folder=$HOME/.PSSharedModules/Resources
  $null = Copy-Item custom/* $HOME/.PSSharedModules/Resources/custom/
  Set-Location $HOME/.PSSharedModules/Resources
  $null = .\build-module.ps1
  Set-Location $PSScriptRoot
}
