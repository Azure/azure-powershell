$repoRootDirectory = $PSScriptRoot | Split-Path | Split-Path
$artifactsDirectory = Join-Path -Path $repoRootDirectory -ChildPath "artifacts"
$debugDirectory = Join-Path -Path $artifactsDirectory -ChildPath "Debug"
$statsAnalysisRootDirectory = Join-Path -Path $artifactsDirectory -ChildPath "TestCoverageAnalysis"
$statsAnalysisRawDirectory = Join-Path -Path $statsAnalysisRootDirectory -ChildPath "Raw"
$statsAnalysisResultsDirectory = Join-Path -Path $statsAnalysisRootDirectory -ChildPath "Results"

$psCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")

$excludedModules = @(
    "Az.BareMetal",
    "Az.ChangeAnalysis",
    "Az.CloudService",
    "Az.Communication",
    "Az.Confluent",
    "Az.ConnectedNetwork",
    "Az.CostManagement",
    "Az.CustomLocation",
    "Az.CustomProviders",
    "Az.DataBox",
    "Az.Databricks",
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
    "Az.ManagedServiceIdentity",
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
    "Az.VMware",
    "Az.Websites",
    "Az.WindowsIotServices"
)

if (-not (Test-Path -LiteralPath $statsAnalysisResultsDirectory -PathType Container))
{
    New-Item -Path $statsAnalysisRootDirectory -Name "Results" -ItemType Directory
}
Get-ChildItem -LiteralPath $statsAnalysisResultsDirectory -Filter "*.txt" | Remove-Item -Force

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

    Write-Host "Starting analyzing module $moduleName" -ForegroundColor Green

    $moduleCsvFullPath = Join-Path -Path $statsAnalysisRawDirectory -ChildPath "$moduleName.csv"
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

    $module = Get-Module -Name $moduleName
    $moduleCmdlets = $module.ExportedCmdlets.Keys + $module.ExportedFunctions.Keys

    $totalCmdletsCount = $moduleCmdlets.Count
    $overallCmdletsCount += $totalCmdletsCount

    $rawCsv = Import-Csv -LiteralPath $moduleCsvFullPath | Select-Object * -Unique

    $csvGroupByCmdlet = $rawCsv | Select-Object -ExpandProperty CommandName -Unique | Sort-Object CommandName
    $totalExecutedCmdletsCount = $csvGroupByCmdlet.Count
    $overallExecutedCmdletsCount += $totalExecutedCmdletsCount

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

    $csvGroupByParameter = $rawCsv | Select-Object CommandName, ParameterSetName, Parameters -Unique | Sort-Object CommandName, ParameterSetName, Parameters | Group-Object CommandName, ParameterSetName
    $totalExecutedParametersCount = 0
    $csvGroupByParameter | ForEach-Object {
        $executedParams = @()
        $_.Group | ForEach-Object {
            $executedParams += $_.Parameters -split "\*\*\*\s*"
        }
        $totalExecutedParametersCount += ($executedParams | Where-Object { $_ -and $_ -notin $psCommonParameters } | Select-Object -Unique).Count
    }

    $AzPSModuleReportContent.ToString() | Out-File -LiteralPath ([System.IO.Path]::Combine($statsAnalysisResultsDirectory, "$moduleName.txt")) -NoNewLine

    [void]$AzPSReportContent.AppendLine("  -->  By cmdlet: $(($totalExecutedCmdletsCount / $totalCmdletsCount).ToString("P0"))")
    [void]$AzPSReportContent.AppendLine("  -->  By parameter set: $(($totalExecutedParameterSetsCount / $totalParameterSetsCount).ToString("P0"))")
    [void]$AzPSReportContent.AppendLine("  -->  By parameter: $(($totalExecutedParametersCount / $totalParametersCount).ToString("P0"))")
    [void]$AzPSReportContent.AppendLine()

    Write-Host "Finished analyzing module $moduleName" -ForegroundColor Green
    Write-Host
}

[void]$AzPSReportContent.AppendLine("Total Azure PowerShell cmdlets coverage: $(($overallExecutedCmdletsCount / $overallCmdletsCount).ToString("P0"))")
$AzPSReportContent.ToString() | Out-File -LiteralPath ([System.IO.Path]::Combine($statsAnalysisResultsDirectory, "Azure PowerShell Test Coverage Report.txt")) -NoNewLine
