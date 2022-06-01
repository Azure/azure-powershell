<#
    .SYNOPSIS
        The script to find examples in ".md" and analyze the examples by custom rules.
    .NOTES
        File Name: Measure-MarkdownOrScript.ps1
#>

#Requires -Modules PSScriptAnalyzer

[CmdletBinding(DefaultParameterSetName = "Markdown")]
param (
    [Parameter(Mandatory, HelpMessage = "Markdown searching paths. Empty for current path. Supports wildcard.", ParameterSetName = "Markdown")]
    [AllowEmptyString()]
    [string[]]$MarkdownPaths,
    [Parameter(Mandatory, HelpMessage = "PowerShell scripts searching paths. Empty for current path. Supports wildcard.", ParameterSetName = "Script")]
    [AllowEmptyString()]
    [string[]]$ScriptPaths,
    [Parameter(HelpMessage = "PSScriptAnalyzer custom rules paths. Empty for current path. Supports wildcard.")]
    [string[]]$RulePaths,
    [switch]$Recurse,
    [switch]$IncludeDefaultRules,
    [string]$OutputFolder = "./artifacts/StaticAnalysisResults/ExampleAnalysis",
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$AnalyzeScriptsInFile,
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$OutputScriptsInFile,
    [switch]$OutputResultsByModule,
    [switch]$CleanScripts
)

. $PSScriptRoot\utils.ps1

if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    $ScriptsByExampleFolder = "ScriptsByExample"
    $scaleTable = @()
    $missingTable = @()
    $deletePromptAndSeparateOutputTable = @()
}
$analysisResultsTable = @()

# Clean caches, remove files in "output" folder
if ($OutputScriptsInFile.IsPresent) {
    Remove-Item $OutputFolder\$ScriptsByExampleFolder -Recurse -ErrorAction SilentlyContinue
}
Remove-Item $OutputFolder\*.csv -Recurse -ErrorAction SilentlyContinue

# find examples in "help\*.md", output ".ps1"
if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    $null = New-Item -ItemType Directory -Path $OutputFolder\$ScriptsByExampleFolder -ErrorAction SilentlyContinue
    $MarkdownPath = Get-Content $MarkdownPaths
    Write-Output $MarkdownPath
    (Get-ChildItem $MarkdownPath) | foreach{
        Write-Output $_
        # Filter the .md of overview in /help
        if ($_ -cmatch ".*/help.*\.md" -and $_.BaseName -cmatch "^([A-Z][a-z]+)+-([A-Z][a-z0-9]*)+$") {
            Write-Output "Searching in file $($_.FullName) ..."
            $module = ($_ -split "/")[-3]
            $cmdlet = $_.BaseName
            $result = Measure-SectionMissingAndOutputScript $module $cmdlet $_.FullName `
                -OutputScriptsInFile:$OutputScriptsInFile.IsPresent `
                -OutputFolder $OutputFolder\$ScriptsByExampleFolder
            $scaleTable += $result.Scale
            $missingTable += $result.Missing
            $deletePromptAndSeparateOutputTable += $result.DeletePromptAndSeparateOutput
        }
    }
    if ($AnalyzeScriptsInFile.IsPresent) {
        $ScriptPaths = "$OutputFolder\$ScriptsByExampleFolder"
    }
    # Summarize searching results
    $scaleTable | Export-Csv "$OutputFolder\Scale.csv" -NoTypeInformation
    $missingTable | where {$_ -ne $null} | Export-Csv "$OutputFolder\Missing.csv" -NoTypeInformation
    $deletePromptAndSeparateOutputTable | where {$_ -ne $null} | Export-Csv "$OutputFolder\DeletingSeparating.csv" -NoTypeInformation
}


# Analyze scripts
if ($PSCmdlet.ParameterSetName -eq "Script" -or $AnalyzeScriptsInFile.IsPresent) {
    $analysisResultsTable = @()
    @() + (Get-Item $ScriptPaths) + (Get-ChildItem $ScriptPaths -Recurse:$Recurse.IsPresent -Attributes Directory) | foreach {
        $module = (Get-Item $_).Name
        $analysisResults = @()
        # read and analyze ".ps1" in \ScriptsByExample
        Get-ChildItem $_ -Attributes !Directory -Filter "*.ps1" -ErrorAction Stop | foreach {
            Write-Output "Analyzing file $($_.FullName) ..."
            $analysisResults += Get-ScriptAnalyzerResult $module $_.FullName $RulePaths -IncludeDefaultRules:$IncludeDefaultRules.IsPresent -ErrorAction Continue
        }
        if ($OutputResultsByModule.IsPresent -and (Get-ChildItem $_ -Attributes !Directory -Filter "*.ps1").Count -ne 0) {
            $analysisResults | Export-Csv "$OutputFolder\$module.csv" -NoTypeInformation
        }
        $analysisResultsTable += $analysisResults
    }
    # Summarize analysis results, output in Result.csv
    $analysisResultsTable | where {$_ -ne $null} | Export-Csv "$OutputFolder\Results-$(Get-Date -UFormat %s).csv" -NoTypeInformation
}

# Clean caches
if ($CleanScripts.IsPresent) {
    Remove-Item $ScriptPaths -Exclude *.csv -Recurse -ErrorAction Continue
}