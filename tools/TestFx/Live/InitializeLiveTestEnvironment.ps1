<#
.SYNOPSIS
    Installs the PowerShell version required by the live test pipeline.

.DESCRIPTION
    Windows PowerShell 5.1 is validated in place. Any other version is downloaded as the
    standalone archive (with its bundled .NET runtime) from the PowerShell GitHub releases,
    verified against the release SHA256 checksums and extracted into the agent temp directory.
    The resulting pwsh path is published as the LiveTestPwshPath pipeline variable.

    DesiredVersion accepts "5.1", "latest", a release line ("7.4" or "7.4.*") which resolves
    to the latest stable patch, or an exact version ("7.4.6").
#>
param(
    [Parameter(Mandatory, Position = 0)]
    [ValidatePattern('^(5\.1|latest|[0-9]+\.[0-9]+(\.[0-9]+|\.\*)?)$')]
    [string] $DesiredVersion
)

& (Join-Path -Path ($PSScriptRoot | Split-Path) -ChildPath "Utilities" | Join-Path -ChildPath "CommonUtility.ps1")

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

function Invoke-DownloadWithRetry {
    param(
        [Parameter(Mandatory)][string] $Uri,
        [Parameter(Mandatory)][string] $OutFile
    )

    $headers = @{ 'User-Agent' = 'azure-powershell-livetest' }
    if ($env:GITHUB_TOKEN -and $Uri.StartsWith('https://api.github.com/')) {
        $headers['Authorization'] = "Bearer $env:GITHUB_TOKEN"
    }
    for ($attempt = 1; $attempt -le 5; $attempt++) {
        try {
            Invoke-WebRequest -Uri $Uri -OutFile $OutFile -Headers $headers -TimeoutSec 180 -UseBasicParsing -ErrorAction Stop
            return
        }
        catch {
            if (Test-Path -LiteralPath $OutFile) { Remove-Item -LiteralPath $OutFile -Force }
            if ($attempt -eq 5) { throw }
            Write-Warning "Retrying download ($attempt/5): $Uri"
            Start-Sleep -Seconds (2 * $attempt)
        }
    }
}

function Resolve-PowerShellVersion {
    param(
        [Parameter(Mandatory)][string] $Version,
        [Parameter(Mandatory)][string] $WorkRoot
    )

    if ($Version -match '^[0-9]+\.[0-9]+\.[0-9]+$') {
        return $Version
    }

    $releasesPath = Join-Path -Path $WorkRoot -ChildPath 'powershell-releases.json'
    if ($Version -eq 'latest') {
        Invoke-DownloadWithRetry -Uri 'https://api.github.com/repos/PowerShell/PowerShell/releases/latest' -OutFile $releasesPath
        return (Get-Content -LiteralPath $releasesPath -Raw | ConvertFrom-Json).tag_name.TrimStart('v')
    }

    $releaseLine = $Version -replace '\.\*$', ''
    $tagPattern = "^v$([regex]::Escape($releaseLine))\.[0-9]+$"
    $versions = [System.Collections.Generic.List[version]]::new()
    for ($page = 1; $page -le 5; $page++) {
        Invoke-DownloadWithRetry -Uri "https://api.github.com/repos/PowerShell/PowerShell/releases?per_page=100&page=$page" -OutFile $releasesPath
        $releases = @(Get-Content -LiteralPath $releasesPath -Raw | ConvertFrom-Json)
        if ($releases.Count -eq 0) { break }
        $releases | Where-Object { -not $_.draft -and -not $_.prerelease -and $_.tag_name -match $tagPattern } | ForEach-Object {
            $versions.Add([version]$_.tag_name.Substring(1))
        }
        # Releases are returned newest first, so the latest patch is on the first page that matches.
        if ($versions.Count -gt 0) { break }
    }

    if ($versions.Count -eq 0) {
        throw "No stable PowerShell release found for $Version."
    }

    return ($versions | Sort-Object -Descending | Select-Object -First 1).ToString()
}

$winPSVersion = "5.1"
$isWinPSDesired = $DesiredVersion -eq $winPSVersion

Write-Host "Validating desired PowerShell version."

if ($isWinPSDesired) {
    powershell -NoLogo -NoProfile -NonInteractive -Command "(Get-Variable -Name PSVersionTable).Value"
    Write-Host "##[section]Desired Windows Powershell version $DesiredVersion has been installed."
    return
}

$tempRoot = if ($env:AGENT_TEMPDIRECTORY) { $env:AGENT_TEMPDIRECTORY } else { [System.IO.Path]::GetTempPath() }
$workRoot = Join-Path -Path $tempRoot -ChildPath 'livetest-pwsh'
New-Item -Path $workRoot -ItemType Directory -Force | Out-Null

$resolvedVersion = Resolve-PowerShellVersion -Version $DesiredVersion -WorkRoot $workRoot
Write-Host "##[section]Installing PowerShell version $resolvedVersion (requested $DesiredVersion) from GitHub releases."

if ($IsWindows) {
    $platform = 'win'
    $extension = 'zip'
    $pwshExecutable = 'pwsh.exe'
}
elseif ($IsMacOS) {
    $platform = 'osx'
    $extension = 'tar.gz'
    $pwshExecutable = 'pwsh'
}
elseif ($IsLinux) {
    $platform = 'linux'
    $extension = 'tar.gz'
    $pwshExecutable = 'pwsh'
}
else {
    throw "Unsupported operating system."
}

$architecture = [System.Runtime.InteropServices.RuntimeInformation]::OSArchitecture.ToString().ToLowerInvariant()
if ($architecture -notin 'x64', 'arm64') {
    throw "Unsupported PowerShell architecture: $architecture"
}

$archiveName = "powershell-$resolvedVersion-$platform-$architecture.$extension"
if ($platform -eq 'win') {
    $archiveName = "PowerShell-$resolvedVersion-$platform-$architecture.$extension"
}

$releaseUri = "https://github.com/PowerShell/PowerShell/releases/download/v$resolvedVersion"
$archivePath = Join-Path -Path $workRoot -ChildPath $archiveName
$hashesPath = Join-Path -Path $workRoot -ChildPath "hashes-$resolvedVersion.sha256"
$pwshRoot = Join-Path -Path $workRoot -ChildPath $resolvedVersion

Invoke-DownloadWithRetry -Uri "$releaseUri/$archiveName" -OutFile $archivePath
Invoke-DownloadWithRetry -Uri "$releaseUri/hashes.sha256" -OutFile $hashesPath

$hashPattern = "^([0-9a-fA-F]{64})\s+\*?$([regex]::Escape($archiveName))$"
$expectedHashes = @(Get-Content -LiteralPath $hashesPath | ForEach-Object {
    if ($_ -cmatch $hashPattern) { $Matches[1] }
})
if ($expectedHashes.Count -ne 1) {
    throw "Expected exactly one SHA256 checksum for $archiveName."
}
if ((Get-FileHash -LiteralPath $archivePath -Algorithm SHA256).Hash -ne $expectedHashes[0]) {
    throw "SHA256 checksum mismatch for $archiveName."
}

if (Test-Path -LiteralPath $pwshRoot) {
    Remove-Item -LiteralPath $pwshRoot -Recurse -Force
}
New-Item -Path $pwshRoot -ItemType Directory -Force | Out-Null

if ($extension -eq 'zip') {
    Expand-Archive -LiteralPath $archivePath -DestinationPath $pwshRoot
}
else {
    tar -xzf $archivePath -C $pwshRoot
    if ($LASTEXITCODE -ne 0) { throw "Failed to extract $archiveName." }
}

$pwshPath = Join-Path -Path $pwshRoot -ChildPath $pwshExecutable
if (-not $IsWindows) {
    chmod +x $pwshPath
    if ($LASTEXITCODE -ne 0) { throw "Failed to mark $pwshPath as executable." }
}

$actualVersion = & $pwshPath -NoLogo -NoProfile -NonInteractive -Command '$PSVersionTable.PSVersion.ToString()'
if ($LASTEXITCODE -ne 0 -or "$actualVersion".Trim() -ne $resolvedVersion) {
    throw "Expected PowerShell $resolvedVersion, got '$actualVersion' (exit code $LASTEXITCODE)."
}

Write-Host "##vso[task.setvariable variable=LiveTestPwshPath]$pwshPath"
Write-Host "##[section]Desired PowerShell version $resolvedVersion has been installed at $pwshPath."
