$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'

if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTimeSeriesInsightsEventSource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzTimeSeriesInsightsEventSource' {
    It 'eventhub' {
        $eventHubSpaceName = $env.eventHubSpaceName02 
        $eventHubName = $env.eventHubName02
        $eventSourceResourceId = $env.eventHubName02_id
        $eventSharedAccessKey = $env.eventHubName02_key | ConvertTo-SecureString -AsPlainText -Force
        $environmentName = $env.rstrenv01
        $tsiEevntSourceName = $env.rstres01
        
        New-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -Name $tsiEevntSourceName -EnvironmentName $environmentName -Kind Microsoft.EventHub -ConsumerGroupName $env.resourceGroup -Location $env.location -KeyName RootManageSharedAccessKey -ServiceBusNameSpace $eventHubSpaceName -EventHubName $eventHubName -EventSourceResourceId $eventSourceResourceId -SharedAccessKey $eventSharedAccessKey
        $tsiEevntSource = Get-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -EnvironmentName $environmentName -Name $tsiEevntSourceName
        $tsiEevntSource.Name | Should -Be $tsiEevntSourceName
    }

    It 'iothub' {
        $ioTHubName = $env.iotHubName
        $iotSourceResourceId = $env.iotHubName_id
        $iotSharedAccessKey = $env.iotHubName_key | ConvertTo-SecureString -AsPlainText -Force
        $environmentName = $env.rstrenv02
        $tsiEevntSourceName = $env.rstres02

        New-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -Name $tsiEevntSourceName -EnvironmentName $environmentName -Kind Microsoft.IoTHub -ConsumerGroupName $env.resourceGroup -Location $env.location -KeyName RootManageSharedAccessKey -IoTHubName $ioTHubName -EventSourceResourceId $iotSourceResourceId -SharedAccessKey $iotSharedAccessKey
        $tsiEevntSource = Get-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -EnvironmentName $environmentName -Name $tsiEevntSourceName
        $tsiEevntSource.Name | Should -Be $tsiEevntSourceName
    }
}
