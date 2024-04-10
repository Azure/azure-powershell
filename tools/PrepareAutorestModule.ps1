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

#This script will pack build artifacts under temporary folder "artifacts/tmp" and output Az.*.nupkg to "artifacts"

[CmdletBinding(DefaultParameterSetName="ModuleNameSet")]
param (
    [Parameter(Mandatory=$true)]
    [string]$RepoRoot,
    [Parameter(ParameterSetName="ModuleNameSet", Mandatory=$true)]
    [string]$ModuleRootName
)

<#
    for:
        src/Storage/Storage.Management
        src/Storage/Storage.Autorest
    ModuleRootName = Storage
    ParentModuleName = Storage.Management
    SubModuleName = Storage.Autorest
#>

function Get-OutdatedSubModule {
    param (
        [string]$SourceDirectory,
        [string]$GeneratedDirectory
    )
    $outdatedSubModule = @()
    $subModuleSource = Get-ChildItem -Path $SourceDirectory -Directory | Foreach-Object { $_.Name } | Where-Object { $_ -match "^*.Autorest$" }
    foreach ($subModule in $subModuleSource) {
        $generateInfoSource = Join-Path $SourceDirectory $subModule "generate-info.json"
        $generateInfoGenerated = Join-Path $GeneratedDirectory $subModule "generate-info.json"
        if (Test-Path $generateInfoGenerated) {
            continue
        } 
        $generateIdSource = (Get-Content -Path $generateInfoSource | ConvertFrom-Json).generate_Id
        $generateIdGenerated = (Get-Content -Path $generateInfoGenerated | ConvertFrom-Json).generate_Id
        if ($generateIdSource -eq $generateIdGenerated) {
            continue
        }
        $outDatedSubModule += $subModule
    }
    return $outDatedSubModule
}

function Invoke-SubModuleGeneration {
    param (
        [string]$GeneratedDirectory,
        [string]$GenerateLog
    )
    Set-Location -Path $GenerateDirectory
    npx autorest --max-memory-size=8192 >> $GenerateLog
    if ($lastexitcode -ne 0) {
        return $false
    } else {
        ./build-module.ps1
        return $true
    }
}

function Update-GeneratedSubModule {
    param (
        [string]$ModuleRootName,
        [string]$SubModuleName,
        [string]$SourceDirectory,
        [string]$GeneratedDirectory
    )
    $SourceDirectory = Join-Path $SourceDirectory $ModuleRootName $SubModuleName
    $GeneratedDirectory = Join-Path $GeneratedDirectory $ModuleRootName $SubModuleName
    #clean generated directory before update
    Get-ChildItem $GeneratedDirectory | Foreach-Object { Remove-Item -Path $_.FullName -Recurse -Force }
    # remove $sourceDirectory/generated/modules
    $localModulesPath = Join-Path $SourceDirectory 'generated' 'modules'
    if (Test-Path $localModulesPath) {
        Remove-Item -Path $localModulesPath -Recurse -Force
    }
    $subModuleNameTrimmed = $SubModuleName.split('.')[0]
    $fileToUpdate = @('generated', 'generate-info.json', "Az.$subModuleNameTrimmed.psd1", "Az.$subModuleNameTrimmed.psm1", "Az.$subModuleNameTrimmed.format.ps1xml", 'exports', 'internal', 'test-module.ps1', 'check-dependencies.ps1')
    # Copy from src/ to generated/ 
    $fileToUpdate | Foreach-Object {
        $moveFrom = Join-Path $SourceDirectory $_
        $moveTo = Join-Path $GeneratedDirectory $_
        Copy-Item -Path $moveFrom -Destination $moveTo -Recurse -Force
    }
    # regenerate csproj
    New-GeneratedFileFromTemplate -TemplateName 'Az.ModuleName.csproj' -GeneratedFileName "Az.$subModuleNameTrimmed.csproj" -GeneratedDirectory $GeneratedDirectory -ModuleRootName $ModuleRootName -SubModuleName $subModuleNameTrimmed
}

function New-GeneratedFileFromTemplate {
    Param(
        [string]
        $TemplateName,
        [string]
        $GeneratedFileName,
        [string]
        $GeneratedDirectory,
        [string]
        $ModuleRootName,
        [string]
        $SubModuleName
    )
    # TODO: replace this with actual template directory
    $TemplatePath = ""
    $templateFile = Join-Path $TemplatePath $TemplateName
    $GeneratedFile = Join-Path $GeneratedDirectory $GeneratedFileName

    $templateFile = Get-Content -Path $templateFile
    If ($templateFile -Match "{GUID}") {
        $templateFile = $templateFile -replace '{GUID}', (New-Guid).Guid
    }
    $templateFile = $templateFile -replace '{ModuleNamePlaceHolder}', $SubModuleName
    $templateFile = $templateFile -replace '{LowCaseModuleNamePlaceHolder}', $SubModuleName.ToLower()
    $templateFile = $templateFile -replace '{ModuleFolderPlaceHolder}', $SubModuleName
    $templateFile -replace '{RootModuleNamePlaceHolder}', $ModuleRootName
    Write-Host "Copying template: $TemplateName." -ForegroundColor Yellow
    $templateFile | Set-Content $GeneratedFile -force
}

function Add-SubModuleToParentModule {
    param (
        [string]$ModuleRootName,
        [string]$SubModuleName,
        [string]$SourceDirectory,
        [string]$GeneratedDirectory
    )
    # TODO: replace this with actual template directory
    $TemplatePath = ""
    $rootToParentMap = @{
        'Storage' = @('Storage.Management')
    }
    $parentModuleName = $ModuleRootName
    if ($ModuleRootName -in $rootToParentMap.keys) {
        $parentModuleName = $rootToParentMap[$ModuleRootName]
    }
    $moduleRootPath = Join-Path $SourceDirectory $ModuleRootName
    $parentModulePath = Join-Path $moduleRootPath $parentModuleName
    $subModuleNameTrimmed = $SubModuleName.split('.')[0]
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
 
    $subModulePath = Join-Path $SourceDirectory $ModuleRootName $SubModuleName
    $subMoudleMetadata = Import-LocalizedData -BaseDirectory $subModulePath -FileName "Az.$subModuleNameTrimmed.psd1"

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
}

<#
    TODO: add comment, add log
#>
$hadFailed = $false
$sourceDirectory = Join-Path $RepoRoot "src"
$generatedDirectory = Join-Path $RepoRoot "generated"
if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

$AutorestOutputDir = Join-Path $RepoRoot "artifacts" "autorest"
New-Item -ItemType Directory -Force -Path $AutorestOutputDir
$outdatedModuleMap = @{}
$moduleRootSource = Join-Path $sourceDirectory $ModuleRootName
$moduleRootGenerated = Join-Path $generatedDirectory $ModuleRootName
$outdatedSubModule = Get-OutdatedSubModule -SourceDirectory $moduleRootSource -GeneratedDirectory $moduleRootGenerated
# TODO: make this asynchronous
foreach ($subModuleName in $outdatedSubModule) {
    $outdatedModuleMap[$ModuleRootName] += $subModuleName
    $subModuleSourceDirectory = Join-Path $sourceDirectory $ModuleRootName $subModuleName
    $generatedLog = Join-Path $AutorestOutputDir $ModuleRootName $subModuleName
    $generated = Invoke-SubModuleGeneration -GenerateDirectory $subModuleSourceDirectory -GeneratedLog $generatedLog
    if (-not $generated) {
        $hadFailed = $true
        Write-Error "Failed to generate code for module: $ModuleRootName, $subModuleName"
        Write-Error "========= Start of error log for $ModuleRootName, $subModuleName ========="
        Write-Error "log can be found at $generatedLog"
        $generateLogDirectory | Get-Content | Foreach-Object { Write-Error $_ }
        Write-Error "========= End of error log for $ModuleRootName, $subModuleName"
    } else {
        $subModuleGeneratedDirectory = Join-Path $generatedDirectory $ModuleRootName $subModuleName
        if (-not (Test-Path $subModuleGeneratedDirectory)) {
            New-Item -ItemType Directory -Force -Path $subModuleGeneratedDirectory
        }
        Add-SubModuleToParentModule -ModuleRootName $ModuleRootName -SubModuleName $subModuleName -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory
        Update-GeneratedSubModule -ModuleRootName $ModuleRootName -SubModuleName $subModuleName -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory
    }
}

if ($hadFailed) {
    exit 1
}