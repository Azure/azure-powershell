#Requires -Modules platyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,
    [Parameter()]
    [Switch]$GenerateMamlHelp,
    [Parameter()]
    [string]$BuildConfig,
    [Parameter()]
    [string]$FilteredModules
)

$ResourceManagerFolders = Get-ChildItem -Directory -Path "$PSScriptRoot\..\src" | Where-Object { $_.Name -ne 'lib' -and $_.Name -ne 'Package' -and $_.Name -ne 'packages' } | Where-Object { (Get-ChildItem -Directory -Path $_ -Filter *.psd1).Count -ne 0 }
Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"

.($PSScriptRoot + "\PreloadToolDll.ps1")
$UnfilteredHelpFolders = Get-ChildItem -Include 'help' -Path "$PSScriptRoot\..\artifacts" -Recurse -Directory | where { $_.FullName -like "*$BuildConfig*" -and (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) }

$FilteredHelpFolders = $UnfilteredHelpFolders
if (![string]::IsNullOrEmpty($FilteredModules))
{
    $FilteredModulesList = $FilteredModules -split ';'
    $FilteredHelpFolders = @()
    foreach ($HelpFolder in $UnfilteredHelpFolders)
    {
        if (($FilteredModulesList | where { $HelpFolder -like "*\$($_)\*" }) -ne $null)
        {
            $FilteredHelpFolders += $HelpFolder
        }
    }
}

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    $SuppressedExceptionsPath = "$PSScriptRoot\StaticAnalysis\Exceptions"
    if (!(Test-Path -Path $SuppressedExceptionsPath))
    {
        New-Item -Path "$PSScriptRoot\..\artifacts" -Name "Exceptions" -ItemType Directory
    }

    $Exceptions = @()
    foreach ($ServiceFolder in $ResourceManagerFolders)
    {
        $HelpFolder = (Get-ChildItem -Path $ServiceFolder.FullName -Filter "help" -Recurse -Directory)
        if ($HelpFolder -eq $null)
        {
            $Exceptions += $ServiceFolder.Name
        }
    }

    if ($Exceptions.Count -gt 0)
    {
        $Services = $Exceptions -Join ", "
        throw "No help folder found in the following services: $Services"
    }

    $NewExceptionsPath = "$PSScriptRoot\..\artifacts\StaticAnalysisResults"
    if (!(Test-Path -Path $NewExceptionsPath))
    {
        New-Item -Path "$PSScriptRoot\..\artifacts" -Name "StaticAnalysisResults" -ItemType Directory
    }
    
    Copy-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\ValidateHelpIssues.csv" -Destination $SuppressedExceptionsPath
    New-Item -Path $NewExceptionsPath -Name ValidateHelpIssues.csv -ItemType File -Force | Out-Null
    Add-Content "$NewExceptionsPath\ValidateHelpIssues.csv" "Target,Description"
    $FilteredHelpFolders | foreach { Test-AzMarkdownHelp $_.FullName $SuppressedExceptionsPath $NewExceptionsPath }
    $Exceptions = Import-Csv "$NewExceptionsPath\ValidateHelpIssues.csv"
    if (($Exceptions | Measure-Object).Count -gt 0)
    {
        $Exceptions | Format-List
        throw "A markdown file containing the help for a cmdlet is incomplete. Please check the exceptions provided for more details."
    }
    else
    {
        New-Item -Path $NewExceptionsPath -Name NoHelpIssues -ItemType File -Force | Out-Null
        Remove-Item -Path "$SuppressedExceptionsPath\ValidateHelpIssues.csv" -Force
        Remove-Item -Path "$NewExceptionsPath\ValidateHelpIssues.csv" -Force
    }
}

# We need to define new version of module instead of hardcode here
$GeneratedModuleListPath = [System.IO.Path]::Combine($PSScriptRoot, "GeneratedModuleList.txt")
$GeneratedModules = Get-Content $GeneratedModuleListPath
if ($GenerateMamlHelp)
{
    foreach ($HelpFolder in $FilteredHelpFolders)
    {
        $ModuleName = "" 
        if($HelpFolder -match "(?s)artifacts\\$BuildConfig\\(?<module>.+)\\help")
        {
            $ModuleName = $Matches["module"]
        }
        if($HelpFolder -match "(?s)artifacts/$BuildConfig/(?<module>.+)/help")
        {
            $ModuleName = $Matches["module"]
        }
        if($GeneratedModules -notcontains $ModuleName)
        {
            New-AzMamlHelp $HelpFolder.FullName

        }
    }
}
