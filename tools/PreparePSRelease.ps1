[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[String]$Folder,
[Parameter(ParameterSetName="Major")]
[Switch]$Major,
[Parameter(ParameterSetName="Minor")]
[Switch]$Minor,
[Parameter(ParameterSetName="Patch")]
[Switch]$Patch
)

.\ASMIncrementVersion.ps1 $Folder -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent
.\ARMIncrementVersion.ps1 $Folder -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent
.\ARMSyncVersion.ps1 $Folder
.\ARMIncrementVersion.ps1 "$PSScriptRoot\AzureRM" -Major $Major.IsPresent -Minor $Minor.IsPresent -Patch $Patch.IsPresent