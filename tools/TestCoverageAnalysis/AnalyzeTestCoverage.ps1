# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
        The script is used to perform test coverage calculation.

    .DESCRIPTION
        The script will calculate the test coverage for each module based on the raw data generated during test run.
        The test coverage will be calculated and displayed at cmdlet, parameterset and parameter levels.
#>

$repoRootDirectory = $PSScriptRoot | Split-Path | Split-Path
$artifactsDirectory = Join-Path -Path $repoRootDirectory -ChildPath "artifacts"
$debugDirectory = Join-Path -Path $artifactsDirectory -ChildPath "Debug"
$testCoverageRootDirectory = Join-Path -Path $artifactsDirectory -ChildPath "TestCoverageAnalysis"
$testCoverageRawDirectory = Join-Path -Path $testCoverageRootDirectory -ChildPath "Raw"
$testCoverageResultsDirectory = Join-Path -Path $testCoverageRootDirectory -ChildPath "Results"

$psCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")

$excludedModules = @(
    "Az.BareMetal",
    "Az.ChangeAnalysis",
    "Az.CloudService",
    "Az.Communication",
    "Az.Confluent",
    "Az.ConnectedNetwork",
    "Az.CustomLocation",
    "Az.CustomProviders",
    "Az.DataBox",
    "Az.Datadog",
    "Az.DigitalTwins",
    "Az.DiskPool",
    "Az.EdgeOrder",
    "Az.Elastic",
    "Az.HanaOnAzure",
    "Az.HealthBot",
    "Az.ImportExport",
    "Az.LabServices",
    "Az.Logz",
    "Az.ManagedServices",
    "Az.Maps",
    "Az.MariaDb",
    "Az.Marketplace",
    "Az.MonitoringSolutions",
    "Az.MySql",
    "Az.Portal",
    "Az.PostgreSql",
    "Az.ProviderHub",
    "Az.Purview",
    "Az.Quota",
    "Az.ResourceGraph",
    "Az.ResourceMover",
    "Az.SignalR",
    "Az.StreamAnalytics",
    "Az.Synapse",
    "Az.TimeSeriesInsights",
    "Az.Websites",
    "Az.WindowsIotServices"
)

if (-not (Test-Path -LiteralPath $testCoverageResultsDirectory -PathType Container))
{
    New-Item -Path $testCoverageRootDirectory -Name "Results" -ItemType Directory
}
Get-ChildItem -LiteralPath $testCoverageResultsDirectory -Filter "*.txt" | Remove-Item -Force

$accountModuleName = "Az.Accounts"
$accountModuleFullPath = Join-Path -Path $debugDirectory -ChildPath $accountModuleName | Join-Path -ChildPath "$accountModuleName.psd1"
Import-Module $accountModuleFullPath

$overallCmdletsCount = 0
$overallExecutedCmdletsCount = 0

$AzPSReportContent = [System.Text.StringBuilder]::new()
[void]$AzPSReportContent.AppendLine("Test coverage report for all modules :")
[void]$AzPSReportContent.AppendLine()

$allModules = Get-ChildItem -LiteralPath $debugDirectory -Filter "Az.*" -Directory -Name
foreach ($moduleName in $allModules)
{
    if ($moduleName -in $excludedModules)
    {
        continue
    }

    Write-Host "##[group]Calculating test coverage for module $moduleName"
    Write-Host "##[section]Start analyzing module $moduleName" -ForegroundColor Green

    $moduleCsvFullPath = Join-Path -Path $testCoverageRawDirectory -ChildPath "$moduleName.csv"
    if (-not (Test-Path $moduleCsvFullPath))
    {
        [void]$AzPSReportContent.AppendLine("  Module name: $moduleName has no test raw data found!")
        [void]$AzPSReportContent.AppendLine()
        continue
    }

    [void]$AzPSReportContent.AppendLine("  Module name: $moduleName")

    $AzPSModuleReportContent = [System.Text.StringBuilder]::new()
    [void]$AzPSModuleReportContent.AppendLine("Test coverage report for module $moduleName :")
    [void]$AzPSModuleReportContent.AppendLine()

    if ($moduleName -ne $accountModuleName)
    {
        $moduleFullPath = Join-Path -Path $debugDirectory -ChildPath $moduleName | Join-Path -ChildPath "$moduleName.psd1"
        Import-Module $moduleFullPath
    }

    Write-Host "##[section]Start calculating cmdlet ..." -ForegroundColor Green

    $module = Get-Module -Name $moduleName
    $moduleCmdlets = $module.ExportedCmdlets.Keys + $module.ExportedFunctions.Keys

    $totalCmdletsCount = $moduleCmdlets.Count
    $overallCmdletsCount += $totalCmdletsCount

    $rawCsv = Import-Csv -LiteralPath $moduleCsvFullPath | Select-Object * -Unique

    $csvGroupByCmdlet = $rawCsv | Select-Object -ExpandProperty CommandName -Unique | Sort-Object CommandName
    $totalExecutedCmdletsCount = $csvGroupByCmdlet.Count
    $overallExecutedCmdletsCount += $totalExecutedCmdletsCount

    Write-Host "##[section]Start calculating parameter set ..." -ForegroundColor Green

    $totalParameterSetsCount = 0
    $totalParametersCount = 0
    $moduleCmdlets | ForEach-Object {
        $cmdlet = Get-Command -Name $_
        $totalParameterSetsCount += $cmdlet.ParameterSets.Count

        $cmdletParams = $cmdlet.Parameters
        $cmdletParams.Keys | ForEach-Object {
            if ($_ -notin $psCommonParameters)
            {
                $totalParametersCount += $cmdletParams[$_].ParameterSets.Count
            }
        }
    }

    $csvGroupByParameterSet = $rawCsv | Select-Object CommandName, ParameterSetName -Unique | Sort-Object CommandName, ParameterSetName | Group-Object CommandName
    $totalExecutedParameterSetsCount = ($csvGroupByParameterSet | Measure-Object -Property Count -Sum).Sum

    [void]$AzPSModuleReportContent.AppendLine("Following cmdlets were executed :")
    $csvGroupByParameterSet | ForEach-Object {
        $_.Group | ForEach-Object {
            [void]$AzPSModuleReportContent.AppendLine("  -->  Cmdlet $($_.CommandName) with parameter set $($_.ParameterSetName) was tested")
        }
    }

    [void]$AzPSModuleReportContent.AppendLine()

    [void]$AzPSModuleReportContent.AppendLine("Following cmdlets were not executed :")
    $moduleCmdlets | Where-Object { $_ -notin $csvGroupByCmdlet } | ForEach-Object {
        [void]$AzPSModuleReportContent.AppendLine("  -->  $_")
    }

    Write-Host "##[section]Start calculating parameter ..." -ForegroundColor Green

    $csvGroupByParameter = $rawCsv | Select-Object CommandName, ParameterSetName, Parameters -Unique | Sort-Object CommandName, ParameterSetName, Parameters | Group-Object CommandName, ParameterSetName
    $totalExecutedParametersCount = 0
    $csvGroupByParameter | ForEach-Object {
        $executedParams = @()
        $_.Group | ForEach-Object {
            $executedParams += $_.Parameters -split "\*\*\*\s*"
        }
        $totalExecutedParametersCount += ($executedParams | Where-Object { $_ -and $_ -notin $psCommonParameters } | Select-Object -Unique).Count
    }

    $AzPSModuleReportContent.ToString() | Out-File -LiteralPath ([System.IO.Path]::Combine($testCoverageResultsDirectory, "$moduleName.txt")) -NoNewLine

    [void]$AzPSReportContent.AppendLine("  -->  By cmdlet: $(($totalExecutedCmdletsCount / $totalCmdletsCount).ToString("P0"))")
    [void]$AzPSReportContent.AppendLine("  -->  By parameter set: $(($totalExecutedParameterSetsCount / $totalParameterSetsCount).ToString("P0"))")
    [void]$AzPSReportContent.AppendLine("  -->  By parameter: $(($totalExecutedParametersCount / $totalParametersCount).ToString("P0"))")
    [void]$AzPSReportContent.AppendLine()

    Write-Host "##[section]Finished analyzing module $moduleName" -ForegroundColor Green
    Write-Host "##[endgroup]"
    Write-Host
}

[void]$AzPSReportContent.AppendLine("Total Azure PowerShell cmdlets coverage: $(($overallExecutedCmdletsCount / $overallCmdletsCount).ToString("P0"))")
$AzPSReportContent.ToString() | Out-File -LiteralPath ([System.IO.Path]::Combine($testCoverageResultsDirectory, "Azure PowerShell Test Coverage Report.txt")) -NoNewLine
