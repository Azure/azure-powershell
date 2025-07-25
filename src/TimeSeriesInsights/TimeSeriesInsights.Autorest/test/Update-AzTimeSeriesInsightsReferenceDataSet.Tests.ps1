$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTimeSeriesInsightsReferenceDataSet.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzTimeSeriesInsightsReferenceDataSet' {
    It 'UpdateExpanded' {
        $key = 'rds01'
        $value = '001'
        $tag = @{$key=$value}
        $environmentName = $env.tsiEnvName
        $dataSetName = $env.referenceDataSet
        Update-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -Name $dataSetName -ResourceGroupName $env.ResourceGroup -Tag $tag
        $tsiDs = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -ResourceGroupName $env.ResourceGroup -ReferenceDataSetName $dataSetName
        $tsiDs.Tag.keys.Contains($key) | Should -BeTrue
        $tsiDs.Tag.Values.Contains($value) | Should -BeTrue
    }

    It 'UpdateViaIdentityExpanded' {
        $key = 'rds02'
        $value = '002'
        $tag = @{$key=$value}
        $environmentName = $env.tsiEnvName
        $dataSetName = $env.referenceDataSet
        $tsiDs = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup -ReferenceDataSetName $dataSetName
        Update-AzTimeSeriesInsightsReferenceDataSet -InputObject $tsiDs -Tag $tag
        $tsiDs = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -ResourceGroupName $env.ResourceGroup -ReferenceDataSetName $tsiDs.Name
        $tsiDs.Tag.keys.Contains($key) | Should -BeTrue
        $tsiDs.Tag.Values.Contains($value) | Should -BeTrue
    }
}
