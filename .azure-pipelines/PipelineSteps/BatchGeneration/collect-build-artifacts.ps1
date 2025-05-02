param (
    [string]$RepoRoot
)

$workspace = "$env:PIPELINE_WORKSPACE"
$artifactsRoot = Join-Path $RepoRoot "artifacts"
$debugArtifactDestPath = Join-Path $artifactsRoot "debug"
New-Item -ItemType Directory -Force -Path $debugArtifactDestPath | Out-Null

$copiedModules = @{}
$StaticAnalysisCopied = $false

Get-ChildItem -Path $workspace -Directory | ForEach-Object {
    $debugArtifactSrcPath = Join-Path $_.FullName "debug"
    $StaticAnalysisSrcDirectory = Join-Path $_.FullName 'StaticAnalysis'

    if (Test-Path $debugArtifactSrcPath) {
        Get-ChildItem -Path $debugArtifactSrcPath -Directory | ForEach-Object {
            $moduleName = $_.Name

            if (-not $copiedModules.ContainsKey($moduleName)) {
                $destPath = Join-Path $debugArtifactDestPath $moduleName
                Copy-Item -Path $_.FullName -Destination $destPath -Recurse
                $copiedModules[$moduleName] = $true
                Write-Host "Copied $moduleName from $debugArtifactSrcPath"
            } else {
                Write-Host "Skipped $moduleName from $debugArtifactSrcPath (already copied)"
            }
        }
    }

    if (Test-Path $StaticAnalysisSrcDirectory and -not $StaticAnalysisCopied) {
        $destPath = Join-Path $artifactsRoot 'StaticAnalysis'
        Copy-Item -Path $StaticAnalysisSrcDirectory -Destination $destPath -Recurse
        $StaticAnalysisCopied = $true
        Write-Host "Copied StaticAnalysis from $StaticAnalysisSrcDirectory"
    }
    
}

Get-ChildItem -Path $artifactsRoot -Directory | ForEach-Object {
    Write-Host "Artifact Directory - $($_.Name)"
}

Get-ChildItem -Path $debugArtifactDestPath -Directory | ForEach-Object {
    Write-Host "Debug Directory - $($_.Name)"
}
