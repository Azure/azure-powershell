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
param([switch]$Isolated, [switch]$Live, [switch]$Record, [switch]$Playback, [switch]$RegenerateSupportModule)
$ErrorActionPreference = 'Stop'

if(-not $Isolated) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  $pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
  & "$pwsh" -NonInteractive -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
  return
}

$ProgressPreference = 'SilentlyContinue'
$baseName = $PSScriptRoot.BaseName
$requireResourceModule = (($baseName -ne "Resources") -and ($Record.IsPresent -or $Live.IsPresent))
. (Join-Path $PSScriptRoot 'check-dependencies.ps1') -Isolated -Accounts:$false -Pester -Resources:$requireResourceModule -RegenerateSupportModule:$RegenerateSupportModule
. ("$PSScriptRoot\test\utils.ps1")

if ($requireResourceModule) {
  # Load the latest Az.Accounts installed
  Import-Module -Name Az.Accounts -RequiredVersion (Get-Module -Name Az.Accounts -ListAvailable | Sort-Object -Property Version -Descending)[0].Version
  $resourceModulePSD = Get-Item -Path (Join-Path $HOME '.PSSharedModules\Resources\Az.Resources.TestSupport.psd1')
  Import-Module -Name $resourceModulePSD.FullName
}

$localModulesPath = Join-Path $PSScriptRoot 'generated\modules'
if(Test-Path -Path $localModulesPath) {
  $env:PSModulePath = "$localModulesPath$([IO.Path]::PathSeparator)$env:PSModulePath"
}

$modulePsd1 = Get-Item -Path (Join-Path $PSScriptRoot './Az.ContainerInstance.psd1')
$modulePath = $modulePsd1.FullName
$moduleName = $modulePsd1.BaseName

Import-Module -Name Pester
Import-Module -Name $modulePath

$TestMode = 'playback'
if($Live) {
  $TestMode = 'live'
}
if($Record) {
  $TestMode = 'record'
}
try {
  if ($TestMode -ne 'playback') {
    setupEnv
  }
  $testFolder = Join-Path $PSScriptRoot 'test'
  Invoke-Pester -Script @{ Path = $testFolder } -EnableExit -OutputFile (Join-Path $testFolder "$moduleName-TestResults.xml")
}
Finally
{
  if ($TestMode -ne 'playback') {
    cleanupEnv
  }
}

Write-Host -ForegroundColor Green '-------------Done-------------'