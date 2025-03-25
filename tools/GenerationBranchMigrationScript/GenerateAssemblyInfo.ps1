[CmdletBinding(DefaultParameterSetName="Default")]
param (
    [string]$RepoRoot = (Resolve-Path ("$PSScriptRoot/../../"))
)

$BuildScriptsModulePath = Join-Path $PSScriptRoot '..' 'BuildScripts' "BuildScripts.psm1"
Import-Module $BuildScriptsModulePath

$rootToParentMap = @{
    'Storage' = @('Storage.Management')
}
$sourceFolderPath = Join-Path $RepoRoot 'src'
$toolsFolderPath = Join-Path $RepoRoot 'tools'

Get-ChildItem -Path $sourceFolderPath -Directory -Filter "*.Autorest" -Recurse | foreach-Object {
    $moduleRootName = $_.Parent.Name
    $subModuleName = $_.Name
    $subModuleNameTrimmed = $SubModuleName.split('.')[-2]
    $parentModuleName = $moduleRootName
    if ($moduleRootName -in $rootToParentMap.keys) {
        $parentModuleName = $rootToParentMap[$moduleRootName]
    }
    $sourceModuleRootPath = Join-Path $sourceFolderPath $moduleRootName
    $sourceParentModulePath = Join-Path $sourceModuleRootPath $parentModuleName
    $sourceSubModulePath = Join-Path $sourceModuleRootPath $subModuleName

    Write-Host "Importing $sourceParentModulePath/Az.$moduleRootName.psd1 ..." -ForegroundColor DarkGreen
    $metadata = Import-LocalizedData -BaseDirectory $sourceParentModulePath -FileName "Az.$moduleRootName.psd1"
    $moduleVersion = $metadata.ModuleVersion

    $propertiesFolderPath = Join-Path $sourceSubModulePath 'Properties'
    if (Test-Path $propertiesFolderPath) {
        Remove-Item $propertiesFolderPath -Force -Recurse
    }
    New-Item -ItemType Directory -Force -Path $propertiesFolderPath
    $assemblyInfoPath = Join-Path $propertiesFolderPath 'AssemblyInfo.cs'

    Write-Host "Creating $assemblyInfoPath ..." -ForegroundColor DarkGreen
    New-GeneratedFileFromTemplate -TemplateName 'AssemblyInfo.cs' -GeneratedFileName "AssemblyInfo.cs" -GeneratedDirectory $propertiesFolderPath -ModuleRootName $ModuleRootName -SubModuleName $subModuleNameTrimmed
    
    $assemblyInfo = Get-Content -Path $assemblyInfoPath
    If ($assemblyInfo -Match "0.1.0") {
        $assemblyInfo = $assemblyInfo -replace '0.1.0', $moduleVersion
    }
    $assemblyInfo | Set-Content $assemblyInfoPath -force
}