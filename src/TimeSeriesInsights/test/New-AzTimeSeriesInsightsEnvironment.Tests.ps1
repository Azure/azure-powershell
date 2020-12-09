$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTimeSeriesInsightsEnvironment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzTimeSeriesInsightsEnvironment' {
    It 'Gen1' {
        $kind = 'Gen1'
        $sku01 = 'S1'
        $sku02 = 'S2'
        $timeSpan = New-TimeSpan -Days 1 -Hours 1 -Minutes 25
        $capacity = 2
        
        New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.rstrenv02 -Kind $kind -Location $env.location -Sku $sku01 -DataRetentionTime $timeSpan -Capacity $capacity
        New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.rstrenv03 -Kind $kind -Location $env.location -Sku $sku02 -DataRetentionTime $timeSpan -Capacity $capacity
        
        $tsiEnv02 = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.rstrenv02
        $tsiEnv03 = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.rstrenv03
        $tsiEnv02.Name | Should -Be $env.rstrenv02
        $tsiEnv03.Name | Should -Be $env.rstrenv03
    }

    It 'Gen2' {
        $kind = 'Gen2'
        $sku = 'L1'
        $capacity = 2
        $timeSeriesIdProperty = @{name='cdc';type='string'}
        $staAccountName = $env.staaccountName01
        $staAccountKey  = $env.staaccountName01_key | ConvertTo-SecureString -AsPlainText -Force

        New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.rstrenv04 -Kind $kind -Location $env.location -Sku $sku -StorageAccountName $staAccountName -StorageAccountKey $staAccountKey -TimeSeriesIdProperty $timeSeriesIdProperty
        $tsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.rstrenv04
        $tsiEnv.Name | Should -Be $env.rstrenv04
    }
}
