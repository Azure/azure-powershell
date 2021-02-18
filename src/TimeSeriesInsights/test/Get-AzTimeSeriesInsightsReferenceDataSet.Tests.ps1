$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTimeSeriesInsightsReferenceDataSet.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzTimeSeriesInsightsReferenceDataSet' {
    It 'List' {
        $tsiDsList = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup
        $tsiDsList.Count | Should -Be 1
    }

    It 'Get' {
        $tsiDs = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -ReferenceDataSetName $env.referenceDataSet
        $tsiDs.Name | Should -be $env.referenceDataSet
    }

    It 'GetViaIdentity' {
        $tsiDs01 = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -ReferenceDataSetName $env.referenceDataSet
        $tsiDs = Get-AzTimeSeriesInsightsReferenceDataSet -InputObject $tsiDs01
        $tsiDs.Name | Should -be $env.referenceDataSet
    }
}
