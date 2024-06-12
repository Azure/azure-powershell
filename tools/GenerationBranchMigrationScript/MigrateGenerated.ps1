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

#find directories ends with .autorest
Get-ChildItem -Path $sourceFolderPath -Directory -Filter "*.Autorest" -Recurse | foreach-Object {
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
    
    #Write-Warning "$generatedModuleRootPath, $generatedSubModulePath, $sourceModuleRootPath, $sourceSubModulePath"

    if (-not (Test-Path $generatedModuleRootPath)) {
        New-Item -Path $generatedModuleRootPath -ItemType Directory -Force
    }

    $generateInfoPath = Join-Path $sourceSubModulePath 'generate-info.json'
    if (Test-Path $generateInfoPath) {
        Remove-Item $generateInfoPath -Force
    }
    New-GenerateInfoJson -GeneratedDirectory $sourceSubModulePath
    
    # Move files from src to generated
    $fileToMove = @('generated', 'generate-info.json', "Az.$subModuleNameTrimmed.psd1", "Az.$subModuleNameTrimmed.psm1", "Az.$subModuleNameTrimmed.format.ps1xml", 'exports', 'internal', "Az.$subModuleNameTrimmed.csproj", 'test-module.ps1', 'check-dependencies.ps1')
    $fileToMove | Foreach-Object {
        $fromPath = Join-Path $sourceSubModulePath $_
        $toPath = Join-Path $generatedSubModulePath $_
        if (-not (Test-Path $generatedSubModulePath)) {
            New-Item -Path $generatedSubModulePath -ItemType Directory -Force
        }
        #update content of sln
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
}

# Update references in src/Resources/Resources.Test/Resources.Test.csproj and src/Resources/Resources.sln
$resourcesTestCsprojPath = Join-Path $sourceFolderPath 'Resources' 'Resources.Test' 'Resources.Test.csproj'
$content = Get-Content $resourcesTestCsprojPath
$content = $content -replace "..\\..\\ManagedServiceIdentity\\ManagedServiceIdentity.Autorest\\Az.ManagedServiceIdentity.csproj", "..\..\..\generated\ManagedServiceIdentity\ManagedServiceIdentity.Autorest\Az.ManagedServiceIdentity.csproj"
$content = $content -replace "..\\..\\Purview\\Purview.Autorest\\Az.Purview.csproj", "..\..\..\generated\Purview\Purview.Autorest\Az.Purview.csproj"
$content = $content -replace "..\\..\\Purview\\Purviewdata.Autorest\\Az.Purviewdata.csproj", "..\..\..\generated\Purview\Purviewdata.Autorest\Az.Purviewdata.csproj"
$content | Set-Content $resourcesTestCsprojPath -force

$resourceSlnPath = Join-Path $sourceFolderPath 'Resources' 'Resources.sln'
$content = Get-Content $resourceSlnPath
$content = $content -replace "..\\ManagedServiceIdentity\\ManagedServiceIdentity.Autorest\\Az.ManagedServiceIdentity.csproj", "..\..\generated\ManagedServiceIdentity\ManagedServiceIdentity.Autorest\Az.ManagedServiceIdentity.csproj"
$content = $content -replace "..\\Monitor\\ActionGroup.Autorest\\Az.ActionGroup.csproj", "..\..\generated\Monitor\ActionGroup.Autorest\Az.ActionGroup.csproj"
$content = $content -replace "..\\Monitor\\ActivityLogAlert.Autorest\\Az.ActivityLogAlert.csproj", "..\..\generated\Monitor\ActivityLogAlert.Autorest\Az.ActivityLogAlert.csproj"
$content = $content -replace "..\\Monitor\\Autoscale.Autorest\\Az.Autoscale.csproj", "..\..\generated\Monitor\Autoscale.Autorest\Az.Autoscale.csproj"
$content = $content -replace "..\\Monitor\\DataCollectionRule.Autorest\\Az.DataCollectionRule.csproj", "..\..\generated\Monitor\DataCollectionRule.Autorest\Az.DataCollectionRule.csproj"
$content = $content -replace "..\\Monitor\\DiagnosticSetting.Autorest\\Az.DiagnosticSetting.csproj", "..\..\generated\Monitor\DiagnosticSetting.Autorest\Az.DiagnosticSetting.csproj"
$content = $content -replace "..\\Monitor\\MonitorWorkspace.Autorest\\Az.MonitorWorkspace.csproj", "..\..\generated\Monitor\MonitorWorkspace.Autorest\Az.MonitorWorkspace.csproj"
$content = $content -replace "..\\Monitor\\ScheduledQueryRule.Autorest\\Az.ScheduledQueryRule.csproj", "..\..\generated\Monitor\ScheduledQueryRule.Autorest\Az.ScheduledQueryRule.csproj"
$content = $content -replace "..\\Monitor\\MetricData.Autorest\\Az.Metricdata.csproj", "..\..\generated\Monitor\MetricData.Autorest\Az.Metricdata.csproj"
$content | Set-Content $resourceSlnPath -force


# <#
#     sync files from eng/archive-test branch to current branch
# #>

# #update content of src/Az.autorest.props
# $propsPath = Join-Path $sourceFolderPath 'Az.autorest.props'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/src/Az.autorest.props").Content > $propsPath

# #copy src/.props from eng/archive-test branch to current branch
# $readmeAzurePath = Join-Path $sourceFolderPath 'readme.azure.md'
# $readmeAzureNoProfilePath = Join-Path $sourceFolderPath 'readme.azure.noprofile.md'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/src/readme.azure.md").Content > $readmeAzurePath
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/src/readme.azure.noprofile.md").Content > $readmeAzureNoProfilePath

# #copy other scripts from eng/archive-test to current branch
# $ciFilterTaskPath = Join-Path $toolsFolderPath 'BuildPackagesTask' 'Microsoft.Azure.Build.Tasks' 'CIFilterTask.cs'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks/CIFilterTask.cs").Content > $ciFilterTaskPath
# $filesChangedTaskPath = Join-Path $toolsFolderPath 'BuildPackagesTask' 'Microsoft.Azure.Build.Tasks' 'FilesChangedTask.cs'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks/FilesChangedTask.cs").Content > $filesChangedTaskPath
# $buildModulesPath = Join-Path $toolsFolderPath 'BuildScripts' 'BuildModules.ps1'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/BuildScripts/BuildModules.ps1").Content > $buildModulesPath
# $createFilterMappingsPath = Join-Path $toolsFolderPath 'CreateFilterMappings.ps1'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/CreateFilterMappings.ps1").Content > $createFilterMappingsPath
# $executeCIStepPath = Join-Path $toolsFolderPath 'ExecuteCIStep.ps1'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/ExecuteCIStep.ps1").Content > $executeCIStepPath
# $prepareAutorestModulePath = Join-Path $toolsFolderPath 'PrepareAutorestModule.ps1'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/PrepareAutorestModule.ps1").Content > $prepareAutorestModulePath

# #copy build.proj from eng/archive-test to current branch
# $buildProjPath = Join-Path $RepoRoot 'build.proj'
# (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/build.proj").Content > $buildProjPath