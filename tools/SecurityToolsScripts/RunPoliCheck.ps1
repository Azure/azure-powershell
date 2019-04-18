$repoRoot = "$PSScriptRoot/../.."
$poliCheck = (Get-Item -Path "$repoRoot/tools/SecurityTools/Microsoft.StaticAnalysis.PoliCheck*/tools/Policheck.exe" | Select-Object -First 1).FullName
$inputFilesTxt = "$repoRoot/artifacts/PoliCheck-InputFiles.txt"
(Get-ChildItem -Path "$repoRoot/artifacts/Debug" -Recurse -File -Exclude '*.dll','*.pdb').FullName | Out-File -FilePath $inputFilesTxt
$resultsFilename = "PoliCheck-Results.xml"
$resultsPath = "$workingDir/artifacts/$resultsFilename"
$fileExtensionsPath = "$workingDir/tools/PoliCheckFileExtensions.xml"

& "$poliCheck" /FL:"""$inputFilesTxt""" /T:9 /SEV:1 /FTPATH:$fileExtensionsPath /O:$resultsPath

$xml = [xml](Get-Content -Path $resultsPath -Raw)
$matchCount = ($xml.PLCKRR.Logs.ChildNodes | Where-Object { $_.Occurences -ne 0 } | Measure-Object).Count
if($matchCount -gt 0) {
  Write-Output "Match Count: $matchCount"
  Write-Error "Political correctness check failed. See failures in '$resultsFilename'."
}