# e.g. .\CreateRegistryEntry.ps1 2.0.0 2016_07_11 2016_08_08 "Path to shared PS files" "Path to signed PS build artifacts"
[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$PSVersion,
[Parameter(Mandatory=$True, Position=1)]
[String]$LastRelease,
[Parameter(Mandatory=$True, Position=2)]
[String]$CurrentRelease,
[Parameter(Mandatory=$True, Position=3)]
[String]$PathToShared,
[Parameter(Mandatory=$True, Position=4)]
[String]$PathToBuildArtifacts
)

$PathToLastRelease = "$PathToShared\$($LastRelease)_PowerShell"
$PathToCurrentRelease = "$PathToShared\$($CurrentRelease)_PowerShell"

New-Item $PathToCurrentRelease -Type Directory > $null
New-Item "$PathToCurrentRelease\pkgs" -Type Directory > $null
Copy-Item "$PathToLastRelease\scripts" "$PathToCurrentRelease" -Recurse
Copy-Item "$PathToLastRelease\removewebpiReg.reg" "$PathToCurrentRelease"
Copy-Item "$PathToLastRelease\webpiReg.reg" "$PathToCurrentRelease"
Copy-Item "$PathToLastRelease\wpilauncher.exe" "$PathToCurrentRelease"

Copy-Item "$PathToBuildArtifacts\signed\AzurePowerShell.msi" "$PathToCurrentRelease"
Copy-Item "$PathToBuildArtifacts\src\Package\*.nupkg" "$PathToCurrentRelease\pkgs"

Rename-Item $PathToCurrentRelease\AzurePowerShell.msi azure-powershell.$PSVersion.msi

(Get-Content $PathToCurrentRelease\webpiReg.reg) -replace $LastRelease, $CurrentRelease | Set-Content $PathToCurrentRelease\webpiReg.reg
