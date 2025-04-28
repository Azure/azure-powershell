param (
    [string]$MatrixKey,
    [string]$RepoRoot
)

Write-Host "Matrix Key: $MatrixKey"

$generateTargetsOutputFile = Join-Path $RepoRoot "artifacts" "generateTargets.json"
$generateTargets = Get-Content -Path $generateTargetsOutPutFile -Raw | ConvertFrom-Json

$moduleGroup = $generateTargets.$MatrixKey
$sortedModuleNames = $moduleGroup.PSObject.Properties.Name | Sort-Object

foreach ($moduleName in $sortedModuleNames) {
    $subModules = $moduleGroup.$moduleName
    Write-Host "Module Name: $moduleName"
    foreach ($subModule in $subModules) {
        Write-Host "  SubModule: $subModule"
    }
}

# $AutorestOutputDir = Join-Path $RepoRoot "artifacts" "autorest"
# New-Item -ItemType Directory -Force -Path $AutorestOutputDir

# $sourceDirectory = Join-Path $RepoRoot "src"
# # $buildModulesPath = Join-Path $RepoRoot 'tools' 'BuildScripts' 'BuildModules.ps1'
# $results = @()

# foreach ($module in $moduleGroup) {
#     $startTime = Get-Date
#     $result = @{
#         Module = $module
#         Status = "Success"
#         DurationSeconds = 0
#         Error = ""
#     }
#     try {
#         Write-Host "Building module: $module"
#         #TODO(Bernard) Remove log after test
#         if ($module -eq 'Communication') {
#             throw "Module '$module' is not allowed for this operation."
#         }
#         # & $buildModulesPath -TargetModule $module -ForceRegenerate -InvokedByPipeline
#         $moduleRootSource = Join-Path $sourceDirectory $ModuleRootName
#         $moduleRootGenerated = Join-Path $generatedDirectory $ModuleRootName
        
#     } catch {
#         Write-Warning "Failed to build module: $module"
#         $result.Status = "Failed"
#         $result.Error = $_.Exception.Message
#     } finally {
#         $endTime = Get-Date
#         $result.DurationSeconds = ($endTime - $startTime).TotalSeconds
#         $results += $result
#     }
# }

# git add .
# $patchPath = Join-Path $ArtifactRoot "changed.patch"
# git diff --cached > $patchPath

# $reportPath = Join-Path $ArtifactRoot "BuildReport-$MatrixKey.json"
# $results | ConvertTo-Json -Depth 3 | Out-File -FilePath $reportPath -Encoding utf8

# Write-Host "Build report written to $reportPath"
