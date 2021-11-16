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
Import-Module $ModuleFolder
New-MarkdownHelp -Module $ModuleName -OutputFolder $TempDocFolder
New-ExternalHelp –Path $TempDocFolder -OutputPath $ModuleFolder