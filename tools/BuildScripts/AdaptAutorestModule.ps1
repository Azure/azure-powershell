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

if ($SubModuleName -match "^Az\.(?<SubModuleName>\w+)") {
    $SubModuleName = $Matches["SubModuleName"]
}

if (($null -eq $ModuleRootName) -or ('' -eq $ModuleRootName) -or ('$(root-module-name)' -eq $ModuleRootName)) {
    $ModuleRootName = $SubModuleName    
} elseif ($ModuleRootName -match "^Az\.(?<ModuleRootName>\w+)") {
    $ModuleRootName = $Matches["ModuleRootName"]
} else {
    Write-Error "Invalid ModuleRootName: $ModuleRootName"
    Exit 1
}

$RepoRoot = ($PSScriptRoot | Split-Path -Parent | Split-Path -Parent)
$SourceDirectory = Join-Path $RepoRoot 'src'
$GeneratedDirectory = Join-Path $RepoRoot 'generated'
$TemplatePath = Join-Path $PSScriptRoot "Templates"

$rootToParentMap = @{
    'Storage' = 'Storage.Management'
}
$parentModuleName = $ModuleRootName
if ($ModuleRootName -in $rootToParentMap.keys) {
    $parentModuleName = $rootToParentMap[$ModuleRootName]
}

$subModuleNameTrimmed = $SubModuleName
$SubModuleName = "$SubModuleName.Autorest"
$moduleRootPath = Join-Path $SourceDirectory $ModuleRootName
$parentModulePath = Join-Path $moduleRootPath $parentModuleName
$subModulePath = Join-Path $moduleRootPath $SubModuleName
$slnPath = Join-Path $moduleRootPath "$ModuleRootName.sln"

Write-Host "Adapting $SubModuleName to $ModuleRootName ..." -ForegroundColor DarkGreen

<#
    create module root sln for new module
#>
if (-not (Test-Path $slnPath)) {
    Write-Host "Creating $slnPath ..." -ForegroundColor DarkGreen
    dotnet new sln -n $ModuleRootName -o $moduleRootPath
    Join-Path $SourceDirectory 'Accounts' | Get-ChildItem -Filter "*.csproj" -File -Recurse | Where-Object { $_.FullName -notmatch '^*.test.csproj$' } | Foreach-Object {
        dotnet sln $slnPath add $_.FullName --solution-folder 'Accounts'
    }
}

<#
    create parent module for new module
#>
if (-not (Test-Path $parentModulePath)) {
    Write-Host "New module detected, creating parent module $parentModulePath ..." -ForegroundColor DarkGreen
    New-Item -ItemType Directory -Force -Path $parentModulePath
    <#
        create csproj for parent module if not existed
    #>
    $parentModuleCsprojPath = Join-Path $parentModulePath "$parentModuleName.csproj"
    Write-Host "Creating $parentModuleCsprojPath ..." -ForegroundColor DarkGreen
    New-GeneratedFileFromTemplate -TemplateName 'HandcraftedModule.csproj' -GeneratedFileName "$parentModuleName.csproj" -GeneratedDirectory $parentModulePath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
    dotnet sln $slnPath add $parentModuleCsprojPath
    <#
        create AsemblyInfo.cs for parent module if not existed
    #>
    $propertiesPath = Join-Path $parentModulePath 'Properties'
    New-Item -ItemType Directory -Force -Path $propertiesPath
    Write-Host "Creating $propertiesPath/AssemblyInfo.cs ..." -ForegroundColor DarkGreen
    New-GeneratedFileFromTemplate -TemplateName 'AssemblyInfo.cs' -GeneratedFileName "AssemblyInfo.cs" -GeneratedDirectory $propertiesPath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
    <#
        create psd1 for parent module if not existed
    #>
    Write-Host "Creating $parentModulePath/Az.$ModuleRootName.psd1 ..." -ForegroundColor DarkGreen
    New-GeneratedFileFromTemplate -TemplateName 'Module.psd1' -GeneratedFileName "Az.$ModuleRootName.psd1" -GeneratedDirectory $parentModulePath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
    <#
        create ChangeLog.md for parent module if not existed
    #>
    Write-Host "Creating $parentModulePath/ChangeLog.md ..." -ForegroundColor DarkGreen
    New-GeneratedFileFromTemplate -TemplateName 'ChangeLog.md' -GeneratedFileName "ChangeLog.md" -GeneratedDirectory $parentModulePath -ModuleRootName $ModuleRootName -SubModuleName $parentModuleName
}
<#
    merge sub module to parent module psd1
#>
$parentModulePsd1Path = Join-Path $ParentModulePath "Az.$ModuleRootName.psd1"
Write-Host "Merging metadata of $SubModulePath/Az.$subModuleNameTrimmed.psd1 to $parentModulePsd1Path ..." -ForegroundColor DarkGreen
if (Test-Path $parentModulePsd1Path) {
    $parentModuleMetadata = Import-LocalizedData -BaseDirectory $ParentModulePath -FileName "Az.$ModuleRootName.psd1"
} else {
    $parentModuleMetadata = Import-LocalizedData -BaseDirectory $TemplatePath -FileName 'Module.psd1'
}
$parentModuleMetadata.RequiredAssemblies = (@($parentModuleMetadata.RequiredAssemblies) + "$SubModuleName/bin/Az.$subModuleNameTrimmed.private.dll") | Select-Object -Unique
$parentModuleMetadata.FormatsToProcess = (@($parentModuleMetadata.FormatsToProcess) + "$SubModuleName/Az.$subModuleNameTrimmed.format.ps1xml") | Select-Object -Unique
$parentModuleMetadata.NestedModules = (@($parentModuleMetadata.NestedModules) + "$SubModuleName/Az.$subModuleNameTrimmed.psm1") | Select-Object -Unique
# these below properties will be set in PrivateData.PSData during New-ModuleManifest
if ($parentModuleMetadata.PrivateData -and $parentModuleMetadata.PrivateData.PSData) {
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

# Update module version in submodule AssemblyInfo.cs with parent module version
$moduleVersion = $parentModuleMetadata.ModuleVersion
$assemblyInfoPath = Join-Path $subModulePath 'Properties' 'AssemblyInfo.cs'
if (Test-Path $assemblyInfoPath) {
    (Get-Content $assemblyInfoPath -Raw) -replace "0.1.0.0", $moduleVersion | Set-Content $assemblyInfoPath -Force
}


<#
    merge temporary sub module csproj to parent module sln (for platyPS help markdown generation)
        1. delete submodule csproj
        2. create temporary submodule csproj pointing src/moduleroot/submodule
        3. add temporary submodule csproj to src/moduleroot/sln
        4. build src/moduleroot/sln
        5. generate help
        6. restore submodule csproj, delete temporary submodule csproj from src/moduleroot/sln
#>
# For existing submodule "Az.$subModuleNameTrimmed.csproj" is already in sln, remove it before add temporary csproj
$csprojName = "Az.$subModuleNameTrimmed.csproj"
$existingCsprojPath = dotnet sln $slnPath list | Where-Object {
    $_ -match ".*$csprojName$"
}
if ($existingCsprojPath) {
    $location = Get-Location
    Set-Location $moduleRootPath
    dotnet sln $slnPath remove $existingCsprojPath
    Set-Location $location
}

try{
    $subModuleCsprojPath = Join-Path $subModulePath $csprojName
    $tempCsprojPath = Join-Path $subModulePath 'tmpCsproj'
    Move-Item $subModuleCsprojPath $tempCsprojPath -Force
    New-GeneratedFileFromTemplate -TemplateName 'Az.ModuleName.csproj' -GeneratedFileName $csprojName -GeneratedDirectory $subModulePath -ModuleRootName $ModuleRootName -SubModuleName $subModuleNameTrimmed

    dotnet sln $slnPath add $subModuleCsprojPath
    Write-Host "Building $slnPath ..." -ForegroundColor DarkGreen
    dotnet build $slnPath
    <#
        generate help markdown by platyPS
    #>

    Write-Host "Refreshing help markdown ..." -ForegroundColor DarkGreen
    $job = start-job {
        param(
            [string]$RepoRoot,
            [string]$ModuleRootName,
            [string]$ParentModuleName,
            [string]$SubModuleName,
            [string]$SubModuleNameTrimmed
        )

        $resolveScriptPath = Join-Path $RepoRoot 'tools' 'ResolveTools' 'Resolve-Psd1.ps1'
        $artifacts = Join-Path $RepoRoot 'artifacts'
        $artifactAccountPsd1Path = Join-Path $artifacts 'Debug' "Az.Accounts" "Az.Accounts.psd1"
        Import-Module $artifactAccountPsd1Path
        $artifactPsd1Path = Join-Path $artifacts 'Debug' "Az.$ModuleRootName" "Az.$ModuleRootName.psd1"
        $parentModulePath = Join-Path $RepoRoot 'src' $ModuleRootName $ParentModuleName

        $assemblyToRemove = "YamlDotNet.dll"
        $psd1Data = Import-PowerShellDataFile -Path $artifactPsd1Path
        if ($psd1Data.ContainsKey('RequiredAssemblies') -and $psd1Data.RequiredAssemblies -contains $assemblyToRemove) {
            $psd1Data.RequiredAssemblies = $psd1Data.RequiredAssemblies | Where-Object { $_ -ne $assemblyToRemove }
            Update-ModuleManifest -Path $artifactPsd1Path -RequiredAssemblies $psd1Data.RequiredAssemblies
        }

        Import-Module $artifactPsd1Path
        Import-Module platyPS
        $helpPath = Join-Path $parentModulePath 'help'
        $subModuleHelpPath = Join-Path $RepoRoot 'src' $ModuleRootName $SubModuleName 'docs'

        # Clean up the help folder and remove the help files which are not exported by the module.
        $moduleMetadata = Get-Module "Az.$ModuleRootName"
        $exportedCommands = $moduleMetadata.ExportedCommands.Values | Where-Object {$_.CommandType -ne 'Alias'} | ForEach-Object { $_.Name}

        if (-Not (Test-Path $helpPath)) {
            New-Item -Type Directory $helpPath -Force
        }
        Get-ChildItem $subModuleHelpPath -Filter *-*.md | Copy-Item -Destination (Join-Path $helpPath $_.Name) -Force
        Write-Host "Refreshing help markdown files under: $helpPath ..."
        Update-MarkdownHelpModule -Path $helpPath -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow
        foreach ($helpFile in (Get-ChildItem $helpPath -Filter "*-*.md" -Recurse)) {
            $cmdeltName = $helpFile.Name.Replace(".md", "")
            if ($exportedCommands -notcontains $cmdeltName)
            {
                Write-Host "Redundant help markdown detected, removing $helpFile ..."
                Remove-Item $helpFile.FullName -Force
            }
        }
        & $resolveScriptPath -ModuleName $ModuleRootName -ArtifactFolder $artifacts -Psd1Folder $parentModulePath
    } -ArgumentList $RepoRoot, $ModuleRootName, $parentModuleName, $SubModuleName, $subModuleNameTrimmed
    $job | Wait-Job | Receive-Job
    $job | Remove-Job
} finally {
    if (Test-Path $tempCsprojPath) {
        Move-Item $tempCsprojPath $subModuleCsprojPath -Force
    }
}

<#
    merge actual sub module csproj to parent module sln
#>
$existingCsprojPath = dotnet sln $slnPath list | Where-Object {
    $_ -match ".*$csprojName$"
}
if ($existingCsprojPath) {
    $generatedCsprojPath = Join-Path "..\..\generated\$ModuleRootName\" $existingCsprojPath
    (Get-Content $slnPath).Replace($existingCsprojPath, $generatedCsprojPath) | Set-Content $slnPath -force
}

<#
    Create or refresh generate-info.json for submodule
#>
New-GenerateInfoJson -GeneratedDirectory $subModulePath