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
[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]$SubModuleName,
    [Parameter(Mandatory=$true)]
    [AllowEmptyString()]
    [string]$ModuleRootName
)
$BuildScriptsModulePath = Join-Path $PSScriptRoot "BuildScripts.psm1"
Import-Module $BuildScriptsModulePath

if (($null -eq $ModuleRootName) -or ('' -eq $ModuleRootName) -or ('$(root-module-name)' -eq $ModuleRootName)) {
    $ModuleRootName = $SubModuleName    
} elseif ($ModuleRootName -match "^Az\.(?<ModuleRootName>\w+)") {
    $ModuleRootName = $Matches["ModuleRootName"]
} else {
    
}

$RepoRoot = ($PSScriptRoot | Split-Path -Parent | Split-Path -Parent)
$SourceDirectory = Join-Path $RepoRoot 'src'
$GeneratedDirectory = Join-Path $RepoRoot 'generated'
$TemplatePath = Join-Path $PSScriptRoot "Templates"

$rootToParentMap = @{
    'Storage' = @('Storage.Management')
}
$parentModuleName = $ModuleRootName
if ($ModuleRootName -in $rootToParentMap.keys) {
    $parentModuleName = $rootToParentMap[$ModuleRootName]
}
$moduleRootPath = Join-Path $SourceDirectory $ModuleRootName
$parentModulePath = Join-Path $moduleRootPath $parentModuleName
$subModulePth = Join-Path $moduleRootPath $SubModuleName
$subModuleNameTrimmed = $SubModuleName.split('.')[-2]
<#
    create parent module for new module
#>
if (-not (Test-Path $parentModulePath)) {
    New-Item -ItemType Directory -Force -Path $parentModulePath
    <#
        create csproj for parent module if not existed
    #>
    New-GeneratedFileFromTemplate -TemplateName 'HandcraftedModule.csproj' -GeneratedFileName "Az.$parentModuleName.csproj" -GeneratedDirectory $parentModulePath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
    <#
        create AsemblyInfo.cs for parent module if not existed
    #>
    $propertiesPath = Join-Path $parentModulePath 'Properties'
    New-Item -ItemType Directory -Force -Path $propertiesPath
    New-GeneratedFileFromTemplate -TemplateName 'AssemblyInfo.cs' -GeneratedFileName "AssemblyInfo.cs" -GeneratedDirectory $propertiesPath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
    <#
        create psd1 for parent module if not existed
    #>
    New-GeneratedFileFromTemplate -TemplateName 'Module.psd1' -GeneratedFileName "Az.$ModuleRootName.psd1" -GeneratedDirectory $parentModulePath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
    <#
        create ChangeLog.md for parent module if not existed
    #>
    New-GeneratedFileFromTemplate -TemplateName 'ChangeLog.md' -GeneratedFileName "ChangeLog.md" -GeneratedDirectory $parentModulePath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
}
<#
    merge sub module to parent module psd1
#>
$parentModulePsd1Path = Join-Path $ParentModulePath "Az.$ModuleRootName.psd1"
if (Test-Path $parentModulePsd1Path) {
    $parentModuleMetadata = Import-LocalizedData -BaseDirectory $ParentModulePath -FileName "Az.$ModuleRootName.psd1"
} else {
    $parentModuleMetadata = Import-LocalizedData -BaseDirectory $TemplatePath -FileName 'Module.psd1'
}
$parentModuleMetadata.RequiredAssemblies = ($parentModuleMetadata.RequiredAssemblies + "$SubModuleName/bin/Az.$subModuleNameTrimmed.private.dll") | Select-Object -Unique
$parentModuleMetadata.FormatsToProcess = ($parentModuleMetadata.FormatsToProcess + "$SubModuleName/Az.$subModuleNameTrimmed.format.ps1xml") | Select-Object -Unique
$parentModuleMetadata.NestedModules = ($parentModuleMetadata.NestedModules + "$SubModuleName/Az.$subModuleNameTrimmed.psm1") | Select-Object -Unique
# these below properties will be set in PrivateData.PSData during New-ModuleManifest
if ($parentModuleMetadata.PrivateData -and $parentModuleMetadata.PSData) {
    $parentModuleMetadata.PrivateData.PSData.keys | ForEach-Object {
        $parentModuleMetadata.$_ = $parentModuleMetadata.PrivateData.PSData.$_
    }
    $null = $parentModuleMetadata.Remove('PrivateData')
}

$subMoudleMetadata = Import-LocalizedData -BaseDirectory $SubModulePath -FileName "Az.$subModuleNameTrimmed.psd1"

$subMoudleMetadata.FunctionsToExport | Where-Object { '*' -ne $_ } | ForEach-Object { $parentModuleMetadata.FunctionsToExport += $_ }
$parentModuleMetadata.FunctionsToExport = $parentModuleMetadata.FunctionsToExport | Select-Object -Unique

$subMoudleMetadata.AliasesToExport | Where-Object { '*' -ne $_ } | ForEach-Object { $parentModuleMetadata.AliasesToExport += $_ }
$parentModuleMetadata.AliasesToExport = $parentModuleMetadata.AliasesToExport | Select-Object -Unique

New-ModuleManifest -Path $parentModulePsd1Path @parentModuleMetadata

<#
    merge sub module csproj to parent module sln
#>
$slnPath = Join-Path $moduleRootPath "$ModuleRootName.sln"
if (-not (Test-Path $slnPath)) {
    dotnet new sln -n $ModuleRootName -o $moduleRootPath
    Join-Path $SourceDirectory 'Accounts' | Get-ChildItem -Filter "*.csproj" -File -Recurse | Where-Object { $_.FullName -notmatch '^*.test.csproj$' } | Foreach-Object {
        dotnet sln $slnPath add $_.FullName --solution-folder 'Accounts'
    }
}
dotnet sln $slnPath add (Join-Path $GeneratedDirectory $ModuleRootName $SubModuleName "Az.$subModuleNameTrimmed.csproj")
<#
    generate help markdown by platyPS
#>
<#
    move help from submodule to module root
#>