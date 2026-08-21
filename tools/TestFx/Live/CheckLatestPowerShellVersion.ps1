$ErrorActionPreference = "Stop"

$highestTestVersion = ${env:POWERSHELLLATEST}
if ([string]::IsNullOrWhiteSpace($highestTestVersion)) {
    Write-Warning "Environment variable POWERSHELLLATEST is not set."
    Write-Host "##vso[task.complete result=SucceededWithIssues;]POWERSHELLLATEST is not set."
    return
}

Write-Host "##[section]PowerShell Version Check"
Write-Host "Highest test version: $highestTestVersion"

# Query PowerShell GitHub releases for the latest stable version
$psReleasesApi = "https://api.github.com/repos/PowerShell/PowerShell/releases"

try {
    $releases = Invoke-RestMethod -Uri $psReleasesApi -TimeoutSec 30
}
catch {
    Write-Warning "Failed to query PowerShell releases: $_"
    Write-Host "##vso[task.complete result=SucceededWithIssues;]Could not reach PowerShell GitHub API."
    return
}

$highestAvailableVersion = $releases |
Where-Object { -not $_.prerelease -and $_.tag_name -match '^v(\d+\.\d+)\.\d+$' } |
ForEach-Object { $Matches[1] } |
Sort-Object { [System.Version]"$_.0" } -Descending |
Select-Object -First 1

Write-Host "Highest available stable version: $highestAvailableVersion"

if ([System.Version]"$highestAvailableVersion.0" -gt [System.Version]"$highestTestVersion.0") {
    Write-Warning "New PowerShell $highestAvailableVersion is available but not in the live test matrix (current highest: $highestTestVersion)."
    Write-Host "##vso[task.complete result=SucceededWithIssues;]New PowerShell version detected: $highestAvailableVersion"
}
else {
    Write-Host "##[section]No new PowerShell versions found. Test matrix is up to date."
}
