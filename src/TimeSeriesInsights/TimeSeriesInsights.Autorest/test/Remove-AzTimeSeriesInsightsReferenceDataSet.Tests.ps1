$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTimeSeriesInsightsReferenceDataSet.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzTimeSeriesInsightsReferenceDataSet' {
    It 'Delete' {
        $kind = 'Gen1'
        $sku01 = 'S1'
        $timeSpan = New-TimeSpan -Days 1 -Hours 1 -Minutes 25
        $capacity = 2
        $environmentName = $env.rstrenv05
        $tsiDsName = 'removeds003'
        $mykeyproperties = @{ "name" = "device01"; "type" = "Double"}
        New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName -Kind $kind -Location $env.location -Sku $sku01 -DataRetentionTime $timeSpan -Capacity $capacity
        New-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -Name $tsiDsName -ResourceGroupName $env.resourceGroup -Location $env.location -DataStringComparisonBehavior Ordinal -KeyProperty $mykeyproperties
 
        Remove-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -Name $tsiDsName -ResourceGroupName $env.resourceGroup
        $tsiDsList = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup
        $tsiDsList.Name | Should -not -contain $tsiDsName

    }
    It 'DeleteViaIdentity' {
        $environmentName = $env.rstrenv05
        $tsiDsName = 'removeds002'
        $mykeyproperties = @{ "name" = "device01"; "type" = "Double"}
        $tsiDs = New-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -Name $tsiDsName -ResourceGroupName $env.resourceGroup -Location $env.location -DataStringComparisonBehavior Ordinal -KeyProperty $mykeyproperties
        Remove-AzTimeSeriesInsightsReferenceDataSet -InputObject $tsiDs
        $tsiDsList = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup
        $tsiDsList.Name | Should -not -contain $tsiDsName
    }
}
