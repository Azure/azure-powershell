$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTimeSeriesInsightsEnvironment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzTimeSeriesInsightsEnvironment' {
    It 'UpdateStandard' {
        $environmentName = $env.tsiEnvName
        $tsiEnvStandard = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $newCapacity = $tsiEnvStandard.Capacity + 2
        Update-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName -Capacity $newCapacity -Sku $tsiEnvStandard.SkuName
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName
        $updatedTsiEnv.SkuCapacity | Should -Be $newCapacity
        
    }
    It 'UpdateStandardInputObject' {
        $environmentName = $env.tsiEnvName
        $tsiEnvStandard = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $newCapacity = $tsiEnvStandard.Capacity + 1
        Update-AzTimeSeriesInsightsEnvironment -InputObject $tsiEnvStandard -Capacity $newCapacity -Sku $tsiEnvStandard.SkuName
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName
        $updatedTsiEnv.SkuCapacity | Should -Be $newCapacity
    }

    It 'UpdateLongTerm' {
        $environmentName = $env.tsiEnvName01
        $tsiEnvLongTerm = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $newCapacity = $tsiEnvLongTerm.Capacity + 1
        Update-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName -Capacity $newCapacity -Sku $tsiEnvLongTerm.SkuName
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName
        $updatedTsiEnv.SkuCapacity | Should -Be $newCapacity
    }
    
    It 'UpdateLongTermInputObject' {
        $environmentName = $env.tsiEnvName01
        $tsiEnvLongTerm = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $newCapacity = $tsiEnvLongTerm.Capacity + 1
        Update-AzTimeSeriesInsightsEnvironment -InputObject $tsiEnvLongTerm  -Capacity $newCapacity -Sku $tsiEnvLongTerm.SkuName
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName 
        $updatedTsiEnv.SkuCapacity | Should -Be $newCapacity
    }
}
