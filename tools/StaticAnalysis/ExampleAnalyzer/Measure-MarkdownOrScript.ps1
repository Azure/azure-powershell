<#
    .SYNOPSIS
        The script to find examples in ".md" and analyze the examples by custom rules.
    .PARAMETER MarkdownPaths
    Markdown searching paths. Empty for current path. Supports wildcard.
    .PARAMETER ScriptPaths
    PowerShell script searching paths. Empty for current path. Supports wildcard.
    .PARAMETER RulePaths
    PSScriptAnalyzer custom rules paths. Empty for current path. Supports wildcard.
    .PARAMETER Recurse
    To search files recursively in the folders.
    .PARAMETER IncludeDefaultRules
    To analyze default rules provided by PSScriptAnalyzer.
    .PARAMETER OutputFolder
    Folder path storing output files.
    .PARAMETER SkipAnalyzing
    To skip analyzing step. Only extracting example codes from markdowns to the temp script.
    .PARAMETER NotCleanScripts
    Do not clean the temp script.
    .NOTES
        File Name: Measure-MarkdownOrScript.ps1
#>

#Requires -Modules PSScriptAnalyzer

[CmdletBinding(DefaultParameterSetName = "Markdown")]
param (
    [Parameter(Mandatory, ParameterSetName = "Markdown")]
    [AllowEmptyString()]
    [string[]]$MarkdownPaths,
    [Parameter(Mandatory, ParameterSetName = "Script")]
    [AllowEmptyString()]
    [string[]]$ScriptPaths,
    [string[]]$RulePaths,
    [switch]$Recurse,
    [switch]$IncludeDefaultRules,
    [string]$OutputFolder = "$PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleAnalysis",
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$SkipAnalyzing,
    [switch]$NotCleanScripts
)

. $PSScriptRoot\utils.ps1

$analysisResultsTable = @()
$codeMap = @()
$totalLine = 1

$tempScript = "TempScript.ps1"
$tempScriptMap = "TempScript.Map.csv"
$TempScriptPath = "$OutputFolder\$tempScript"
$TempScriptMapPath = "$OutputFolder\$tempScriptMap"

# Clean caches, remove files in "output" folder
Remove-Item $TempScriptPath -ErrorAction SilentlyContinue
Remove-Item $TempScriptMapPath -ErrorAction SilentlyContinue
Remove-Item $PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleIssues.csv -ErrorAction SilentlyContinue
Remove-Item $OutputFolder -ErrorAction SilentlyContinue
# Create output folder and temp script
$null = New-Item -ItemType Directory -Path $OutputFolder -ErrorAction SilentlyContinue
$null = New-Item -ItemType File  $TempScriptPath

# Find examples in "help\*.md", output ".ps1"
if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    # When the input $MarkdownPaths is the path of txt file contained markdown paths
    if ((Test-Path $MarkdownPaths -PathType Leaf) -and $MarkdownPaths.EndsWith(".txt")) {
        $MarkdownPath = Get-Content $MarkdownPaths | Where-Object { $_.StartsWith("src") -and (Test-Path $_) }
    }
    # When the input $MarkdownPaths is the path of a folder
    else {
        $MarkdownPath = $MarkdownPaths
    }
    foreach ($_ in Get-ChildItem $MarkdownPath -Recurse:$Recurse) {
        # Filter the .md of overview in "\help\"
        if (((Get-Item -Path $_.FullName).Directory.Name -eq "help" -or (Get-Item -Path $_.FullName).Directory.Name -eq "docs") -and $_.FullName -cmatch ".*\.md" -and $_.BaseName -cmatch "^[A-Z][a-z]+-([A-Z][a-z0-9]*)+$") {
            if ((Get-Item -Path $_.FullName).Directory.Parent.Name -eq "netcoreapp3.1") {
                continue
            }
            # Skip Az.Tools.* modules as they may not comply with Az convention
            if (($_.FullName -cmatch "Az\.Tools\.")) {
                Write-Debug "Skipping $($_.FullName)"
                continue
            }
            Write-Output "Searching in file $($_.FullName) ..."
            if ((Get-Item -Path $_.FullName).Directory.Parent.Parent.Name -ne "src") {
                $module = (Get-Item -Path $_.FullName).Directory.Parent.Parent.Name
            }
            else {
                $module = (Get-Item -Path $_.FullName).Directory.Parent.Name
            }
            $cmdlet = $_.BaseName
            $result = Measure-SectionMissingAndOutputScript $module $cmdlet $_.FullName `
                -TempScriptPath $TempScriptPath `
                -TotalLine $totalLine
            $analysisResultsTable += $result.Errors
            $codeMap += $result.CodeMap
            $totalLine = $result.TotalLine
        }
    }
    $codeMap | Export-Csv $TempScriptMapPath -NoTypeInformation
}

# Analyze scripts
if ($PSCmdlet.ParameterSetName -eq "Script" -or !$SkipAnalyzing) {
    if ($PSCmdlet.ParameterSetName -eq "Script") {
        $codeMap = Merge-Scripts -ScriptPaths $ScriptPaths -Recurse:$Recurse -TempScriptPath $TempScriptPath
        $codeMap | Export-Csv $TempScriptMapPath -NoTypeInformation
    }
    # Read and analyze ".ps1" in \ScriptsByExample
    Write-Output "Analyzing file ..."
    $analysisResultsTable += Get-ScriptAnalyzerResult -ScriptPath $TempScriptPath -RulePaths $RulePaths -IncludeDefaultRules:$IncludeDefaultRules -CodeMap $codeMap -ErrorAction Continue

    # Summarize analysis results, output in Result.csv
    if ($analysisResultsTable) {
        $analysisResultsTable | Where-Object { $_ -ne $null } | Export-Csv "$PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleIssues.csv" -NoTypeInformation
    }
}

# Clean caches
if (-not $NotCleanScripts) {
    Remove-Item $OutputFolder -Recurse -ErrorAction SilentlyContinue
}
