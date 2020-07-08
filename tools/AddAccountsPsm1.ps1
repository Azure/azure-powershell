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

<#
.SYNOPSIS
    Generate Az.Accounts.psm1 and add Az.Accounts.psm1 as RootModue in Az.Accounts.psd1.

.PARAMETER AccountsModuleFolder
    The folder for Az.Accounts module, e.g. C:\azure-powershell\artifacts\Debug\Az.Accounts

#>
param(
    [Parameter(Mandatory = $true)]
    [string]$AccountsModuleFolder
)

$script:TemplateLocation = "$PSScriptRoot\AzureRM.Example.psm1"

Import-Module "$PSScriptRoot\UpdateModules.psm1"
Import-Module "$PSScriptRoot\PublishModules.psm1"

$AccountsModuleFolder = $AccountsModuleFolder.Trim()

New-ModulePsm1 -ModulePath $AccountsModuleFolder -TemplatePath $script:TemplateLocation -IsRMModule -IsNetcore

$moduleName = (Get-Item -Path $AccountsModuleFolder).Name
$moduleManifest = $moduleName + ".psd1"
$moduleSourcePath = Join-Path -Path $AccountsModuleFolder -ChildPath $moduleManifest
$file = Get-Item $moduleSourcePath

Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name

if ($ModuleMetadata.RootModule) {
  Write-Output "Adding PSM1 dependency is skipped because root module is found"
} else {
  Write-Output "Adding PSM1 dependency to $moduleSourcePath"
  Add-PSM1Dependency -Path $moduleSourcePath 
}

Remove-ModuleDependencies -Path $moduleSourcePath
