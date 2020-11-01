$repoRoot = "$PSScriptRoot/../.."
$binSkim = (Get-Item -Path "$repoRoot/tools/SecurityTools/Microsoft.CodeAnalysis.BinSkim*/tools/*/win-x64/BinSkim.exe" | Select-Object -First 1).FullName
$dllBaseFolder = "$repoRoot/artifacts/Debug"
$suppressions = @('Microsoft.Azure.DataLake.Store.dll','Microsoft.WindowsAzure.Storage.DataMovement.PowerShell.dll','Microsoft.Azure.Storage.DataMovement.dll')
$resultsPath = "$repoRoot/artifacts/BinSkim-Results.sarif"

# Renaming suppressed files since BinSkim has no file filtering support
$renamedDlls = Get-ChildItem -Path $dllBaseFolder -Include $suppressions -Recurse | ForEach-Object { Rename-Item -Path $_.FullName -NewName "$($_.BaseName).temp" -PassThru }
& "$binSkim" analyze "$dllBaseFolder/*.dll" -r -o $resultsPath --rich-return-code
$renamedDlls | ForEach-Object { Rename-Item -Path $_.FullName -NewName "$($_.BaseName).dll" }