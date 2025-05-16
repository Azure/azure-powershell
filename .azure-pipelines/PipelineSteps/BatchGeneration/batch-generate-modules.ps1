param (
    [string]$MatrixKey,
    [string]$RepoRoot,
    [string]$CommitTitle
)

$generationTargetsOutputFile = Join-Path $RepoRoot "artifacts" "generationTargets.json"
$generationTargets = Get-Content -Path $generationTargetsOutPutFile -Raw | ConvertFrom-Json
$moduleGroup = $generationTargets.$MatrixKey
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
        Status = "Success"
        Changed = "No"
        SubModules = @()
    }

    $subModuleNames = $moduleGroup.$moduleName
    foreach ($subModuleName in $subModuleNames) {
        Write-Host "Regenerating SubModule: $subModuleName"
        $subModuleStartTime = Get-Date
        $subModuleResult = @{
            MatrixKey = $MatrixKey
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
            # TODO(Bernard) Remove exception for EmailService.Autorest after test
            if ($subModuleName -eq "EmailService.Autorest") {
                throw "Something went wrong"
            }
            if (-not (Update-GeneratedSubModule -ModuleRootName $moduleName -SubModuleName $subModuleName -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory -GenerateLog $generateLog -IsInvokedByPipeline $true)) {
                Write-Warning "Failed to regenerate module: $moduleName, sub module: $subModuleName"
                Write-Warning "log can be found at $generateLog"
                $moduleResult.Status = "Failed"
                $subModuleResult.Status = "Failed"
                $subModuleResult.Error = "Update-GeneratedSubModule function returned false."
            }

        } catch {
            Write-Warning "Failed to regenerate module: $moduleName, sub module: $subModuleName"
            Write-Warning "Error message: $($_.Exception.Message)"
            $moduleResult.Status = "Failed"
            $subModuleResult.Status = "Failed"
            $subModuleResult.Error = $_.Exception.Message
        } finally {
            $subModuleEndTime = Get-Date
            $subModuleResult.DurationSeconds = ($subModuleEndTime - $subModuleStartTime).TotalSeconds
            $moduleResult.SubModules += $subModuleResult
        }
    }

    Set-Location $RepoRoot
    $srcFolderModuleRelativePath = ".\src\$moduleName"
    $generatedFolderModuleRelativePath = ".\generated\$moduleName"
    $diffSrc = git diff --name-only HEAD -- $srcFolderModuleRelativePath
    $diffGenerated = git diff --name-only HEAD -- $generatedFolderModuleRelativePath
    $diff = $diffSrc -or $diffGenerated
    if ($diff) {
        Write-Host "Changes detected in $moduleName, adding change log"
        $moduleResult.Changed = "Yes"
        $changeLogPath = Join-Path $RepoRoot "src" $moduleName $moduleName "ChangeLog.md"
        $changeLogContent = Get-Content $changeLogPath
        $newChangeLogEntry = "* Autorest Upgration: $CommitTitle"
        
        $index = $changeLogContent.IndexOf("## Upcoming Release")
        if ($index -ge 0) {
            $newChangeLogContent = $changeLogContent[0..$index] + $newChangeLogEntry + $changeLogContent[($index + 1)..($changeLogContent.Count - 1)]
            Set-Content $changelogPath -Value $newChangeLogContent
            $moduleResult.Changed = "Yes, Change Log Updated"
            Write-Host "New change log entry added to $changeLogPath"
        } else {
            $moduleResult.Changed = "Yes, Change Log Not Updated"
            Write-Host "Can not find '## Upcoming Release'"
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
