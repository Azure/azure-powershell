#Requires -Modules platyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ArtifactFolder,
    [Parameter()]
    [string]$ModuleName
)

$ModuleFolder = Join-Path -Path $ArtifactFolder -ChildPath $ModuleName
$TempDocFolder = Join-Path -Path $ArtifactFolder -ChildPath $ModuleName'.Doc'
Copy-Item '.\help\*.md' -Destination $TempDocFolder -Force
Import-Module $ModuleFolder
New-ExternalHelp –Path $TempDocFolder -OutputPath $ModuleFolder -Force