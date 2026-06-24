#Requires -Version 7.0
<#
.SYNOPSIS
    Generates a preview-versioned copy of an AssemblyInfo.cs at build time.

.DESCRIPTION
    The compile-time half of the "preview overlay" pattern for assembly versions.

    main's release tooling rewrites the AssemblyVersion/AssemblyFileVersion literal in
    AssemblyInfo.cs on every release, while the Az.CosmosDB-preview branch needs a
    different version on the same line. Keeping the preview version in the checked-in
    AssemblyInfo.cs therefore produces a merge conflict on every merge from main.

    To avoid that, AssemblyInfo.cs is kept byte-identical to main and this script
    produces a copy with the version swapped to the preview value. PreviewAssemblyVersion.targets
    compiles the generated copy instead of the original, so the built assembly reports the
    preview version while the source stays conflict-free.

    The preview version is read from overlay.json (the single source of truth that main
    never sees), so module/assembly versions are defined in exactly one place.

.PARAMETER SourceAssemblyInfo
    Path to the checked-in AssemblyInfo.cs (kept aligned with main).

.PARAMETER OutputFile
    Path of the generated AssemblyInfo.cs (typically under obj/).

.PARAMETER OverlayJson
    Path to overlay.json containing modules.<ModuleName>.assemblyVersion.

.PARAMETER ModuleName
    Overlay module key to read the assembly version from. Defaults to Az.CosmosDB.

.EXAMPLE
    pwsh ./Generate-PreviewAssemblyInfo.ps1 -SourceAssemblyInfo Properties/AssemblyInfo.cs `
        -OutputFile obj/Debug/PreviewAssemblyInfo.cs -OverlayJson overlay.json
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string] $SourceAssemblyInfo,
    [Parameter(Mandatory = $true)][string] $OutputFile,
    [Parameter(Mandatory = $true)][string] $OverlayJson,
    [string] $ModuleName = 'Az.CosmosDB'
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path -LiteralPath $OverlayJson)) {
    throw "Overlay file not found: $OverlayJson"
}
if (-not (Test-Path -LiteralPath $SourceAssemblyInfo)) {
    throw "Source AssemblyInfo not found: $SourceAssemblyInfo"
}

$overlay = Get-Content -LiteralPath $OverlayJson -Raw | ConvertFrom-Json
$moduleEntry = $overlay.modules.$ModuleName
if ($null -eq $moduleEntry) {
    throw "Module '$ModuleName' not found in $OverlayJson"
}

$version = $moduleEntry.assemblyVersion
if ([string]::IsNullOrWhiteSpace($version)) {
    throw "assemblyVersion for module '$ModuleName' not found in $OverlayJson"
}

# Swap whatever version main currently carries for the preview version.
$content = Get-Content -LiteralPath $SourceAssemblyInfo -Raw
$content = [regex]::Replace($content, 'AssemblyVersion\("[^"]*"\)', "AssemblyVersion(""$version"")")
$content = [regex]::Replace($content, 'AssemblyFileVersion\("[^"]*"\)', "AssemblyFileVersion(""$version"")")

$outDir = Split-Path -Parent $OutputFile
if ($outDir -and -not (Test-Path -LiteralPath $outDir)) {
    New-Item -ItemType Directory -Force -Path $outDir | Out-Null
}

# Only write when the content actually changes so the file timestamp (and MSBuild
# incremental build) stays stable across no-op rebuilds.
$existing = if (Test-Path -LiteralPath $OutputFile) { Get-Content -LiteralPath $OutputFile -Raw } else { $null }
if ($existing -ne $content) {
    $utf8NoBom = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($OutputFile, $content, $utf8NoBom)
    Write-Host "Generated preview AssemblyInfo ($ModuleName $version): $OutputFile"
}
else {
    Write-Host "Preview AssemblyInfo up to date ($ModuleName $version): $OutputFile"
}
