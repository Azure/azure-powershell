[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[String]$Folder,
[Parameter(ParameterSetName="Major", Mandatory=$True)]
[Switch]$Major,
[Parameter(ParameterSetName="Minor", Mandatory=$True)]
[Switch]$Minor,
[Parameter(ParameterSetName="Patch", Mandatory=$True)]
[Switch]$Patch
)

.\ASMIncrementVersion.ps1 $Folder $Major $Minor $Patch
.\ARMIncrementVersion.ps1 $Folder $Major $Minor $Patch
.\ARMSyncVersion.ps1 $Folder $Major $Minor $Patch
.\ARMIncrementVersion.ps1 "$PSScriptRoot\AzureRM" $Major $Minor $Patch