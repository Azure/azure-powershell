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
param([switch]$Isolated)
$ErrorActionPreference = 'Stop'
<#
if($Isolated) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  $pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
  & "$pwsh" -NonInteractive -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
  return
}
#>

$ProgressPreference = 'SilentlyContinue'

$modulePsd1 = Get-Item -Path (Join-Path $PSScriptRoot './Az.Tools.Installer.psd1')
$modulePath = $modulePsd1.FullName
$moduleName = $modulePsd1.BaseName

Import-Module -Name Pester -MinimumVersion 4.0
Import-Module -Name $modulePath

$testFolder = Join-Path $PSScriptRoot 'test'
Invoke-Pester -Script @{Path = $testFolder } -OutputFile (Join-Path $testFolder "$moduleName-TestResults.xml")

Write-Host -ForegroundColor Green '-------------Done-------------'