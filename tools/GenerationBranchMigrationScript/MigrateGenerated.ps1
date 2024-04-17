[CmdletBinding(DefaultParameterSetName="Default")]
param (
    [string]$RepoRoot = (Resolve-Path ("$PSScriptRoot/../../"))
)

$rootToParentMap = @{
    'Storage' = @('Storage.Management')
}
$generatedFolderPath = Join-Path $RepoRoot 'generated'
$sourceFolderPath = Join-Path $RepoRoot 'src'
$toolsFolderPath = Join-Path $RepoRoot 'tools'

# # create $RepoRoot/generated
# New-Item -Path $generatedFolderPath -ItemType Directory -Force

# #find directories ends with .autorest
# Get-ChildItem -Path $sourceFolderPath -Directory -Filter "*.Autorest" -Recurse | foreach-Object {
#     $moduleRootName = $_.Parent.Name
#     $subModuleName = $_.Name
#     $subModuleNameTrimmed = $SubModuleName.split('.')[-2]
#     $parentModuleName = $moduleRootName
#     if ($moduleRootName -in $rootToParentMap.keys) {
#         $parentModuleName = $rootToParentMap[$moduleRootName]
#     }
#     $generatedModuleRootPath = Join-Path $generatedFolderPath $moduleRootName
#     $generatedSubModulePath = Join-Path $generatedModuleRootPath $subModuleName
#     $sourceModuleRootPath = Join-Path $sourceFolderPath $moduleRootName
#     $sourceSubModulePath = Join-Path $sourceModuleRootPath $subModuleName
    
#     #Write-Warning "$generatedModuleRootPath, $generatedSubModulePath, $sourceModuleRootPath, $sourceSubModulePath"

#     if (-not (Test-Path $generatedModuleRootPath)) {
#         New-Item -Path $generatedModuleRootPath -ItemType Directory -Force
#     }
#     # Move files from src to generated
#     $fileToMove = @('generated', 'generate-info.json', "Az.$subModuleNameTrimmed.psd1", "Az.$subModuleNameTrimmed.psm1", "Az.$subModuleNameTrimmed.format.ps1xml", 'exports', 'internal', "Az.$subModuleNameTrimmed.csproj", 'test-module.ps1', 'check-dependencies.ps1')
#     $fileToMove | Foreach-Object {
#         $fromPath = Join-Path $sourceSubModulePath $_
#         $toPath = Join-Path $generatedSubModulePath $_
#         if (-not (Test-Path $generatedSubModulePath)) {
#             New-Item -Path $generatedSubModulePath -ItemType Directory -Force
#         }
#         #update content of sln
#         if ("Az.$subModuleNameTrimmed.csproj" -eq $_) {
#             $slnPath = (Join-Path $sourceModuleRootPath "$moduleRootName.sln")
#             dotnet sln $slnPath remove $fromPath
#         }
#         if (Test-Path $fromPath) {
#             Move-Item $fromPath $toPath
#         }
#         if ("Az.$subModuleNameTrimmed.csproj" -eq $_) {
#             $slnPath = (Join-Path $sourceModuleRootPath "$moduleRootName.sln")
#             dotnet sln $slnPath add $toPath
#         }
#     }
# }

#update content of src/Az.autorest.props
$propsPath = Join-Path $sourceFolderPath 'Az.autorest.props'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/src/Az.autorest.props").Content > $propsPath

#copy src/.props from eng/archive-test branch to current branch
$readmeAzurePath = Join-Path $sourceFolderPath 'readme.azure.md'
$readmeAzureNoProfilePath = Join-Path $sourceFolderPath 'readme.azure.noprofile.md'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/src/readme.azure.md").Content > $readmeAzurePath
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/src/readme.azure.noprofile.md").Content > $readmeAzureNoProfilePath

#copy other scripts from eng/archive-test to current branch
$ciFilterTaskPath = Join-Path $toolsFolderPath 'BuildPackagesTask' 'Microsoft.Azure.Build.Tasks' 'CIFilterTask.cs'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks/CIFilterTask.cs").Content > $ciFilterTaskPath
$filesChangedTaskPath = Join-Path $toolsFolderPath 'BuildPackagesTask' 'Microsoft.Azure.Build.Tasks' 'FilesChangedTask.cs'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/BuildPackagesTask/Microsoft.Azure.Build.Tasks/FilesChangedTask.cs").Content > $filesChangedTaskPath
$buildModulesPath = Join-Path $toolsFolderPath 'BuildScripts' 'BuildModules.ps1'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/BuildScripts/BuildModules.ps1").Content > $buildModulesPath
$createFilterMappingsPath = Join-Path $toolsFolderPath 'CreateFilterMappings.ps1'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/CreateFilterMappings.ps1").Content > $createFilterMappingsPath
$executeCIStepPath = Join-Path $toolsFolderPath 'ExecuteCIStep.ps1'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/ExecuteCIStep.ps1").Content > $executeCIStepPath
$prepareAutorestModulePath = Join-Path $toolsFolderPath 'PrepareAutorestModule.ps1'
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/eng/archive-test/tools/PrepareAutorestModule.ps1").Content > $prepareAutorestModulePath