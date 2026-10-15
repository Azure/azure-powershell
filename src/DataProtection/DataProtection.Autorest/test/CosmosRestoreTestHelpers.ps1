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