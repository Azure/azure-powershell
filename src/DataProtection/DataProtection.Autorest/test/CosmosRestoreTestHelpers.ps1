# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Test-only paths. CI executes copied artifact tests, whose directory depth is
# different from source tests. Never infer the checkout from a fixed parent count
# or use the ignored source-generation cache as the generated manifest authority.
function Get-CosmosRestoreTestPaths {
    param([Parameter(Mandatory)][string] $TestRoot)

    $directory = Get-Item -LiteralPath $TestRoot -ErrorAction Stop
    while ($null -ne $directory) {
        $repoRoot = $directory.FullName
        $sourceRoot = Join-Path $repoRoot 'src/DataProtection/DataProtection.Autorest'
        $generatedRoot = Join-Path $repoRoot 'generated/DataProtection/DataProtection.Autorest'
        if ((Test-Path -LiteralPath (Join-Path $repoRoot 'build.proj') -PathType Leaf) -and
            (Test-Path -LiteralPath (Join-Path $sourceRoot 'custom/Helpers/RestoreHelpers.ps1') -PathType Leaf) -and
            (Test-Path -LiteralPath (Join-Path $generatedRoot 'Az.DataProtection.psd1') -PathType Leaf)) {
            return [pscustomobject]@{
                RepoRoot = $repoRoot
                SourceRoot = $sourceRoot
                GeneratedRoot = $generatedRoot
                ArtifactRoot = Join-Path $repoRoot 'artifacts/Debug/Az.DataProtection/DataProtection.Autorest'
            }
        }
        $directory = $directory.Parent
    }
    throw 'Cannot find the Azure PowerShell checkout containing the canonical DataProtection source and generated manifest.'
}

function Assert-CosmosRestoreSourceCopy {
    param(
        [Parameter(Mandatory)][string] $SourcePath,
        [Parameter(Mandatory)][string] $ArtifactPath,
        [Parameter(Mandatory)][string] $RelativePath
    )

    $sourceText = [string](Get-Content -LiteralPath $SourcePath -Raw -ErrorAction Stop)
    $artifactText = [string](Get-Content -LiteralPath $ArtifactPath -Raw -ErrorAction Stop)
    # CI builds on Windows and reuses that artifact on Unix checkouts. JSON has
    # platform-native EOLs, unlike the explicit CRLF rule for PowerShell scripts.
    # Ignore CRLF versus LF only: retain case, whitespace and final-newline checks
    # so a genuinely stale script or manifest still fails before any assertions.
    if ($sourceText.Replace("`r`n", "`n") -cne $artifactText.Replace("`r`n", "`n")) {
        throw "Stale artifact source copy: $RelativePath. Refresh it in the main workflow before running this suite."
    }
}