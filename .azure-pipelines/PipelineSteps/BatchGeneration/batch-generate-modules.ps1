param (
    [string]$MatrixKey,
    [string]$Target,
    [string]$RepoRoot,
    [string]$ArtifactRoot
)

Write-Host "Matrix Key: $MatrixKey"
Write-Host "Building targets: $Target"

$moduleGroup = $Target | ConvertFrom-Json

foreach ($moduleName in $moduleGroup.PSObject.Properties.Name) {
    $subModules = $moduleGroup.$moduleName
    Write-Host "Module Name: $moduleName"
    # Write-Host "SubModules: $($subModules -join ', ')"
    foreach ($subModule in $subModules) {
        Write-Host "  SubModule: $subModule"
    }
}

# $AutorestOutputDir = Join-Path $RepoRoot "artifacts" "autorest"
# New-Item -ItemType Directory -Force -Path $AutorestOutputDir

# $sourceDirectory = Join-Path $RepoRoot "src"
# # $buildModulesPath = Join-Path $RepoRoot 'tools' 'BuildScripts' 'BuildModules.ps1'
# $modules = $Target -split ','
# $results = @()

# foreach ($module in $modules) {
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
