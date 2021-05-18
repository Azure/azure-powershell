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

$pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
if(-not $Isolated) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  & "$pwsh" -NonInteractive -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
  return
}

$exportsFolder = Join-Path $PSScriptRoot 'exports'
if(-not (Test-Path $exportsFolder)) {
  Write-Error "Exports folder '$exportsFolder' was not found."
}

$directories = Get-ChildItem -Directory -Path $exportsFolder
$hasProfiles = ($directories | Measure-Object).Count -gt 0
if(-not $hasProfiles) {
  $directories = Get-Item -Path $exportsFolder
}

$docsFolder = Join-Path $PSScriptRoot 'docs'
if(Test-Path $docsFolder) {
  $null = Get-ChildItem -Path $docsFolder -Recurse -Exclude 'readme.md' | Remove-Item -Recurse -ErrorAction SilentlyContinue
}
$null = New-Item -ItemType Directory -Force -Path $docsFolder -ErrorAction SilentlyContinue
$examplesFolder = Join-Path $PSScriptRoot 'examples'

$modulePsd1 = Get-Item -Path (Join-Path $PSScriptRoot './Az.ContainerInstance.psd1')
$modulePath = $modulePsd1.FullName
$moduleName = $modulePsd1.BaseName

# Load DLL to use build-time cmdlets
Import-Module -Name $modulePath
Import-Module -Name (Join-Path $PSScriptRoot './bin/Az.ContainerInstance.private.dll')
$instance = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Module]::Instance
# Module info is shared per profile
$moduleInfo = Get-Module -Name $moduleName

foreach($directory in $directories)
{
  if($hasProfiles) {
    Select-AzProfile -Name $directory.Name
  }
  # Reload module per profile
  Import-Module -Name $modulePath -Force

  $cmdletNames = Get-ScriptCmdlet -ScriptFolder $directory.FullName
  $cmdletHelpInfo = $cmdletNames | ForEach-Object { Get-Help -Name $_ -Full }
  $cmdletFunctionInfo = Get-ScriptCmdlet -ScriptFolder $directory.FullName -AsFunctionInfo

  $docsPath = Join-Path $docsFolder $directory.Name
  $null = New-Item -ItemType Directory -Force -Path $docsPath -ErrorAction SilentlyContinue
  $examplesPath = Join-Path $examplesFolder $directory.Name

  Export-HelpMarkdown -ModuleInfo $moduleInfo -FunctionInfo $cmdletFunctionInfo -HelpInfo $cmdletHelpInfo -DocsFolder $docsPath -ExamplesFolder $examplesPath
  Write-Host -ForegroundColor Green "Created documentation in '$docsPath'"
}

Write-Host -ForegroundColor Green '-------------Done-------------'