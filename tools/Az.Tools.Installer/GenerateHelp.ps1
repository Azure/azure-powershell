#Requires -Modules platyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ArtifactFolder,
    [Parameter()]
    [string]$ModuleName
)

$ModuleFolder = Join-Path -Path $ArtifactFolder -ChildPath $ModuleName
$TempDocFolder = Join-Path -Path $ModuleFolder -ChildPath 'help'
Import-Module $ModuleFolder
New-MarkdownHelp -Module $ModuleName -OutputFolder $TempDocFolder -Force
New-ExternalHelp –Path $TempDocFolder -OutputPath $ModuleFolder -Force