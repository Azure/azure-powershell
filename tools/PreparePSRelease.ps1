# e.g. .\PreparePSRelease.ps1 9.10.11 "Spring 2018" -Patch
# 
[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$Version,
[Parameter(Mandatory=$True, Position=1)]
[String]$Release,
[Parameter(Mandatory=$False, Position=2)]
[String]$Folder,
[Parameter(ParameterSetName="Major")]
[Switch]$Major,
[Parameter(ParameterSetName="Minor")]
[Switch]$Minor,
[Parameter(ParameterSetName="Patch")]
[Switch]$Patch
)

$ErrorActionPreference = "Stop"
.\ASMIncrementVersion.ps1 $Folder -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent
.\ARMIncrementVersion.ps1 $Folder -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent
.\ARMSyncVersion.ps1 $Folder
.\ARMIncrementVersion.ps1 "$PSScriptRoot\..\src\Storage" -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent
.\ARMSyncVersion.ps1 "$PSScriptRoot\..\src\Storage"
.\ARMIncrementVersion.ps1 "$PSScriptRoot\AzureRM" -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent
.\CommonIncrementVersion.ps1 $Version $Folder
.\SetMsiVersion.ps1 $Version $Release $Folder 