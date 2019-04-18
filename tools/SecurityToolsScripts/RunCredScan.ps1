$repoRoot = "$PSScriptRoot/../.."
$credScanTools = (Get-Item -Path "$repoRoot/tools/SecurityTools/Microsoft.Azure.CredentialScanner*/tools" | Select-Object -First 1).FullName
$credScan = (Get-Item -Path "$credScanTools/CredentialScanner.exe" | Select-Object -First 1).FullName
$resultsName = 'CredScan-Results'
$resultsDirWithName = "$repoRoot/artifacts/$resultsName"
$suppressionsPath = "$repoRoot/tools/CredScanSuppressions.json"

& "$credScan" -I src -S "$credScanTools/Searchers/buildsearchers.xml","$credScanTools/Searchers/pwdsearchers.xml" -O $resultsDirWithName -f sarif -Sp $suppressionsPath -Ve 1

# https://microsoft.sharepoint.com/teams/CESecEngineering/CredScan/CredScan%20Wiki/Tool%20Exit%20Code.aspx
if($LastExitCode -eq 4) {
  exit 0
} elseif($LastExitCode -ne 0) {
  Write-Output "CredScan Error Code: $LastExitCode"
  Write-Error "Credential scanning failed. See failures in '$resultsName-matches.sarif'."
}