param (
    [string]$MatrixKey,
    [string]$RepoRoot
)

$generateTargetsOutputFile = Join-Path $RepoRoot "artifacts" "generateTargets.json"
$generateTargets = Get-Content -Path $generateTargetsOutPutFile -Raw | ConvertFrom-Json
$moduleGroup = $generateTargets.$MatrixKey
Write-Host "##[group]Generating module group $MatrixKey"
foreach ($key in $moduleGroup.PSObject.Properties.Name | Sort-Object) {
    $values = $moduleGroup.$key -join ', '
    Write-Output "$key : $values"
}
Write-Host "##[endgroup]"
Write-Host
$sortedModuleNames = $moduleGroup.PSObject.Properties.Name | Sort-Object

$AutorestOutputDir = Join-Path $RepoRoot "artifacts" "autorest"
New-Item -ItemType Directory -Force -Path $AutorestOutputDir

$sourceDirectory = Join-Path $RepoRoot "src"
$generatedDirectory = Join-Path $RepoRoot "generated"
$buildScriptsModulePath = Join-Path $RepoRoot 'tools' 'BuildScripts' 'BuildScripts.psm1'
Import-Module $buildScriptsModulePath -Force

$results = @()

foreach ($moduleName in $sortedModuleNames) {
    Write-Host "=============================================================="
    Write-Host "Regenerating Module: $moduleName"
    $moduleStartTime = Get-Date
    $moduleResult = @{
        Module = $moduleName
        DurationSeconds = 0
        SubModules = @()
    }

    $subModuleNames = $moduleGroup.$moduleName
    foreach ($subModuleName in $subModuleNames) {
        Write-Host "Regenerating SubModule: $subModuleName"
        $subModuleStartTime = Get-Date
        $subModuleResult = @{
            SubModule = $subModuleName
            Status = "Success"
            DurationSeconds = 0
            Error = ""
        }

        try {
            $generateLog = Join-Path $AutorestOutputDir $moduleName "$subModuleName.log"
            if (Test-Path $generateLog) {
                Remove-Item -Path $generateLog -Recurse -Force
            }
            New-Item -ItemType File -Force -Path $generateLog
            
            if (-not (Update-GeneratedSubModule -ModuleRootName $moduleName -SubModuleName $subModuleName -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory -GenerateLog $generateLog -IsInvokedByPipeline $true)) {
                Write-Warning "Failed to regenerate module: $moduleName, sub module: $subModuleName"
                Write-Warning "log can be found at $generateLog"
                $subModuleResult.Status = "Failed"
                $subModuleResult.Error = "Update-GeneratedSubModule function returned false."
            }

        } catch {
            Write-Warning "Failed to regenerate module: $moduleName, sub module: $subModuleName"
            Write-Warning "Error message: $($_.Exception.Message)"
            $subModuleResult.Status = "Failed"
            $subModuleResult.Error = $_.Exception.Message
        } finally {
            $subModuleEndTime = Get-Date
            $subModuleResult.DurationSeconds = ($subModuleEndTime - $subModuleStartTime).TotalSeconds
            $moduleResult.SubModules += $subModuleResult
        }
    }
    $moduleEndTime = Get-Date
    $moduleResult.DurationSeconds = ($moduleEndTime - $moduleStartTime).TotalSeconds
    $results += $moduleResult
}

$ArtifactOutputDir = Join-Path $RepoRoot "artifacts"
Set-Location $RepoRoot

git add .
$patchPath = Join-Path $ArtifactOutputDir "changed-$MatrixKey.patch"
git diff --cached > $patchPath

$reportPath = Join-Path $ArtifactOutputDir "GenerationReport-$MatrixKey.json"
$results | ConvertTo-Json -Depth 5 | Out-File -FilePath $reportPath -Encoding utf8

Write-Host "Build report written to $reportPath"
