#Requires -Modules platyPS

[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,

    [Parameter()]
    [Switch]$GenerateMamlHelp
)

Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"

$HelpFolders = Get-ChildItem "help" -Recurse -Directory | where { $_.FullName -like "*Debug*" -or $_.FullName -like "*Release*" }

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    New-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions" -Name NewValidateHelpExceptions.csv -ItemType File -Force | Out-Null

    Add-Content "$PSScriptRoot\HelpGeneration\Exceptions\NewValidateHelpExceptions.csv" "Module,Target,Description"

    $HelpFolders | foreach { Validate-MarkdownHelp $_ }

    $Exceptions = Import-Csv "$PSScriptRoot\HelpGeneration\Exceptions\NewValidateHelpExceptions.csv"
    
    if (($Exceptions | Measure-Object).Count -gt 0)
    {
        $Exceptions | ft
        throw "A markdown file containing the help for a cmdlet is incomplete. Please check the exceptions provided for more details."
    }

    Remove-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\NewValidateHelpExceptions.csv" -Force
}

if ($GenerateMamlHelp)
{
    $HelpFolders | foreach { Generate-MamlHelp $_ }
}