#Requires -Modules platyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,
    [Parameter()]
    [Switch]$GenerateMamlHelp,
    [Parameter()]
    [string]$BuildConfig
)

Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"
$HelpFolders = Get-ChildItem "help" -Recurse -Directory | where { $_.FullName -like "*$BuildConfig*" }

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    if (!(Test-Path -Path "$PSScriptRoot\..\src\Package\Exceptions"))
    {
        New-Item -Path "$PSScriptRoot\..\src\Package" -Name "Exceptions" -ItemType Directory
    }

    $SuppressedExceptionsPath = "$PSScriptRoot\..\src\Package\Exceptions"
    $NewExceptionsPath = "$PSScriptRoot\..\src\Package"
    Copy-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\ValidateHelpIssues.csv" -Destination $SuppressedExceptionsPath
    New-Item -Path $NewExceptionsPath -Name ValidateHelpIssues.csv -ItemType File -Force | Out-Null
    Add-Content "$NewExceptionsPath\ValidateHelpIssues.csv" "Target,Description"
    $HelpFolders | foreach { Validate-MarkdownHelp $_ $SuppressedExceptionsPath $NewExceptionsPath }
    $Exceptions = Import-Csv "$NewExceptionsPath\ValidateHelpIssues.csv"
    if (($Exceptions | Measure-Object).Count -gt 0)
    {
        $Exceptions | ft
        throw "A markdown file containing the help for a cmdlet is incomplete. Please check the exceptions provided for more details."
    }
    else
    {
        Remove-Item -Path "$NewExceptionsPath\ValidateHelpIssues.csv" -Force   
    }
}

if ($GenerateMamlHelp)
{
    $HelpFolders | foreach { Generate-MamlHelp $_ }
}