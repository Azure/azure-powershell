#Requires -Modules @{ ModuleName = 'Microsoft.PowerShell.PlatyPS'; ModuleVersion = '1.0.2' }
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
New-MarkdownCommandHelp -ModuleInfo (Get-Module $ModuleName) -OutputFolder $TempDocFolder -Force -ExcludeDontShow
$cmdHelp = Import-MarkdownCommandHelp -Path (Join-Path $TempDocFolder $ModuleName '*-*.md')
# Export-MamlCommandHelp appends a '<ModuleName>' subfolder under -OutputFolder, so target the
# artifact folder; the help lands at $ArtifactFolder/<ModuleName>/, i.e. the module folder.
Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $ArtifactFolder -Force