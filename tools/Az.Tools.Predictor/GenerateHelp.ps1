#Requires -Modules platyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ArtifactFolder,
    [Parameter()]
    [string]$HelpFolder,
    [Parameter()]
    [string]$ModuleName
)

$ModuleFolder = Join-Path -Path $ArtifactFolder -ChildPath $ModuleName
Import-Module $ModuleFolder
New-ExternalHelp –Path $HelpFolder -OutputPath $ModuleFolder -Force -Debug