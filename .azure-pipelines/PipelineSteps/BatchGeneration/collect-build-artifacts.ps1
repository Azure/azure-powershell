param (
    [string]$RepoRoot
)

$workspace = "$env:PIPELINE_WORKSPACE"
$artifactsRoot = Join-Path $RepoRoot "artifacts" "debug"
New-Item -ItemType Directory -Force -Path $artifactsRoot | Out-Null

$copiedModules = @{}

Get-ChildItem -Path $workspace -Directory | ForEach-Object {
    $artifactDebugPath = Join-Path $_.FullName "debug"

    if (Test-Path $artifactDebugPath) {
        Get-ChildItem -Path $artifactDebugPath -Directory | ForEach-Object {
            $moduleName = $_.Name

            if (-not $copiedModules.ContainsKey($moduleName)) {
                $destPath = Join-Path $artifactsRoot $moduleName
                Copy-Item -Path $_.FullName -Destination $destPath -Recurse
                $copiedModules[$moduleName] = $true
                Write-Host "Copied $moduleName from $artifactDebugPath"
            } else {
                Write-Host "Skipped $moduleName from $artifactDebugPath (already copied)"
            }
        }
    }
}

Get-ChildItem -Path $artifactsRoot -Directory | ForEach-Object {
    Write-Host " - $($_.Name)"
}
