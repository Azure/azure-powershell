[CmdletBinding(DefaultParameterSetName="Default")]
param (
    [string]$RepoRoot = (Resolve-Path ("$PSScriptRoot/../../"))
)

$BuildScriptsModulePath = Join-Path $RepoRoot 'tools' 'BuildScripts' "BuildScripts.psm1"
Import-Module $BuildScriptsModulePath

$rootToParentMap = @{
    'Storage' = @('Storage.Management')
}
$generatedFolderPath = Join-Path $RepoRoot 'generated'
$sourceFolderPath = Join-Path $RepoRoot 'src'
$toolsFolderPath = Join-Path $RepoRoot 'tools'

# create $RepoRoot/generated
New-Item -Path $generatedFolderPath -ItemType Directory -Force

# find directories ends with .autorest 
Get-ChildItem -Path $sourceFolderPath -Directory -Filter "*.Autorest" -Recurse | where-Object {$_.FullName -match "^(?:(?!LiveTests).)*\.Autorest.*"} | Foreach-Object {
    $moduleRootName = $_.Parent.Name
    $subModuleName = $_.Name
    $subModuleNameTrimmed = $SubModuleName.split('.')[-2]
    $parentModuleName = $moduleRootName
    if ($moduleRootName -in $rootToParentMap.keys) {
        $parentModuleName = $rootToParentMap[$moduleRootName]
    }
    $generatedModuleRootPath = Join-Path $generatedFolderPath $moduleRootName
    $generatedSubModulePath = Join-Path $generatedModuleRootPath $subModuleName
    $sourceModuleRootPath = Join-Path $sourceFolderPath $moduleRootName
    $sourceSubModulePath = Join-Path $sourceModuleRootPath $subModuleName
    

    if (-not (Test-Path $generatedModuleRootPath)) {
        New-Item -Path $generatedModuleRootPath -ItemType Directory -Force
    }

    $generateInfoPath = Join-Path $sourceSubModulePath 'generate-info.json'
    if (Test-Path $generateInfoPath) {
        Remove-Item $generateInfoPath -Force
    }
    New-GenerateInfoJson -GeneratedDirectory $sourceSubModulePath

    # Remove those file no need to check in
    $fileToRemove = @('MSSharedLibKey.snk', 'build-module.ps1', 'create-model-cmdlets.ps1', 'export-surface.ps1', 'generate-help.ps1', 'generate-portal-ux.ps1', 'pack-module.ps1', 'run-module.ps1')
    $fileToRemove | Foreach-Object {
        $currentFilePath = Join-Path $sourceSubModulePath $_
        if (Test-Path $currentFilePath) {
            Remove-Item $currentFilePath -Force
        }
    }

    # Move files from src to generated
    $fileToMove = @('Properties', 'generated', 'generate-info.json', 'resources', "Az.$subModuleNameTrimmed.psd1", "Az.$subModuleNameTrimmed.psm1", "Az.$subModuleNameTrimmed.format.ps1xml", 'exports', 'internal', "Az.$subModuleNameTrimmed.csproj", 'test-module.ps1', 'check-dependencies.ps1')
    $fileToMove | Foreach-Object {
        $fromPath = Join-Path $sourceSubModulePath $_
        $toPath = Join-Path $generatedSubModulePath $_
        if (-not (Test-Path $generatedSubModulePath)) {
            New-Item -Path $generatedSubModulePath -ItemType Directory -Force
        }
        # update content of sln
        if ("Az.$subModuleNameTrimmed.csproj" -eq $_) {
            $slnPath = (Join-Path $sourceModuleRootPath "$moduleRootName.sln")
            dotnet sln $slnPath remove $fromPath
        }
        if (Test-Path $fromPath) {
            if ('generate-info.json' -eq $_) {
                Copy-Item $fromPath $toPath
            } else {
                Move-Item $fromPath $toPath
            }
            
        }
        if ("Az.$subModuleNameTrimmed.csproj" -eq $_) {
            $slnPath = (Join-Path $sourceModuleRootPath "$moduleRootName.sln")
            dotnet sln $slnPath add $toPath
        }
    }

    # Rename x.autorest/help -> x.autorest/docs
    $helpFolderPath = Join-Path $sourceSubModulePath "help"
    $docsFolderPath = Join-Path $sourceSubModulePath "docs"
    Move-Item $helpFolderPath $docsFolderPath

    # add .gitignore and .gitattributes to every *.Autorest
    $assetsPath = Join-Path $PSScriptRoot 'assets'
    Get-ChildItem $assetsPath | Foreach-Object { Copy-Item $_.FullName $sourceSubModulePath }
}

# have to do it in another loop because csproj need to be all moved to /generated before add into sln
Get-ChildItem -Path $sourceFolderPath -Filter "*.Sln" -Recurse -File | foreach-Object {
    # update path of csproj references in sln files
    $slnPath = $_.FullName
    $pattern = "^\.\.\\\w+\\.*Autorest.*csproj$"
    $autorestCsproj = dotnet sln $slnPath list | where-object {$_ -match $pattern}
    foreach ($csproj in $autorestCsproj) {
        $pattern="^\.\.\\(?<path>.*)"
        if ($csproj -match $pattern) {
            $srcPath = Join-Path $sourceFolderPath $Matches["path"]
            $generatedPath = Join-Path $generatedFolderPath $Matches["path"]
            dotnet sln $slnPath remove $srcPath
            dotnet sln $slnPath add $generatedPath
        }
    }
}

# Update references in src/Resources/Resources.Test/Resources.Test.csproj and src/Resources/Resources.sln
$resourcesTestCsprojPath = Join-Path $sourceFolderPath 'Resources' 'Resources.Test' 'Resources.Test.csproj'
$content = Get-Content $resourcesTestCsprojPath
$content = $content -replace "..\\..\\ManagedServiceIdentity\\ManagedServiceIdentity.Autorest\\Az.ManagedServiceIdentity.csproj", "..\..\..\generated\ManagedServiceIdentity\ManagedServiceIdentity.Autorest\Az.ManagedServiceIdentity.csproj"
$content = $content -replace "..\\..\\Purview\\Purview.Autorest\\Az.Purview.csproj", "..\..\..\generated\Purview\Purview.Autorest\Az.Purview.csproj"
$content = $content -replace "..\\..\\Purview\\Purviewdata.Autorest\\Az.Purviewdata.csproj", "..\..\..\generated\Purview\Purviewdata.Autorest\Az.Purviewdata.csproj"
$content | Set-Content $resourcesTestCsprojPath -force

# $resourceSlnPath = Join-Path $sourceFolderPath 'Resources' 'Resources.sln'
# $content = Get-Content $resourceSlnPath
# $content = $content -replace "..\\ManagedServiceIdentity\\ManagedServiceIdentity.Autorest\\Az.ManagedServiceIdentity.csproj", "..\..\generated\ManagedServiceIdentity\ManagedServiceIdentity.Autorest\Az.ManagedServiceIdentity.csproj"
# $content = $content -replace "..\\Monitor\\ActionGroup.Autorest\\Az.ActionGroup.csproj", "..\..\generated\Monitor\ActionGroup.Autorest\Az.ActionGroup.csproj"
# $content = $content -replace "..\\Monitor\\ActivityLogAlert.Autorest\\Az.ActivityLogAlert.csproj", "..\..\generated\Monitor\ActivityLogAlert.Autorest\Az.ActivityLogAlert.csproj"
# $content = $content -replace "..\\Monitor\\Autoscale.Autorest\\Az.Autoscale.csproj", "..\..\generated\Monitor\Autoscale.Autorest\Az.Autoscale.csproj"
# $content = $content -replace "..\\Monitor\\DataCollectionRule.Autorest\\Az.DataCollectionRule.csproj", "..\..\generated\Monitor\DataCollectionRule.Autorest\Az.DataCollectionRule.csproj"
# $content = $content -replace "..\\Monitor\\DiagnosticSetting.Autorest\\Az.DiagnosticSetting.csproj", "..\..\generated\Monitor\DiagnosticSetting.Autorest\Az.DiagnosticSetting.csproj"
# $content = $content -replace "..\\Monitor\\MonitorWorkspace.Autorest\\Az.MonitorWorkspace.csproj", "..\..\generated\Monitor\MonitorWorkspace.Autorest\Az.MonitorWorkspace.csproj"
# $content = $content -replace "..\\Monitor\\ScheduledQueryRule.Autorest\\Az.ScheduledQueryRule.csproj", "..\..\generated\Monitor\ScheduledQueryRule.Autorest\Az.ScheduledQueryRule.csproj"
# $content = $content -replace "..\\Monitor\\MetricData.Autorest\\Az.Metricdata.csproj", "..\..\generated\Monitor\MetricData.Autorest\Az.Metricdata.csproj"
# $content | Set-Content $resourceSlnPath -force
