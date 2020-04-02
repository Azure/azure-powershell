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
        $eventHubSpaceName  = $env.rstr31
        $eventHubSpace = New-AzEventHubNamespace -Name $eventHubSpaceName -ResourceGroupName $env.resourceGroup -Location $env.location
        
        $eventHubName = $env.rstr32
        $eventHub = New-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubSpace.Name -Name $eventHubName 
        $eventHubKeys = Get-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubSpace.Name -AuthorizationRuleName RootManageSharedAccessKey
        $eventHubKey  = $eventHubKeys.PrimaryKey | ConvertTo-SecureString -AsPlainText -Force
        
        $environmentName = $env.rstrenv01
        $tsiEevntSourceName = $env.rstres01
        New-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -Name $tsiEevntSourceName -EnvironmentName $environmentName -Kind Microsoft.EventHub -ConsumerGroupName $env.resourceGroup -Location $env.location -KeyName RootManageSharedAccessKey -ServiceBusNameSpace $eventHubSpace.Name -EventHubName $eventHub.Name -EventSourceResourceId $eventHub.id -SharedAccessKey $eventHubKey
        $tsiEevntSource = Get-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -EnvironmentName $environmentName -Name $tsiEevntSourceName
        $tsiEevntSource.Name | Should -Be $tsiEevntSourceName
    }

    It 'iothub' {
        $iotHubName = $env.rstr33
        $iotHubSkuName = 'S1'
        $iotUnits = 100

        $iotHub = New-AzIotHub -ResourceGroupName $env.resourceGroup -Location $env.location -Name $iotHubName -SkuName $iotHubSkuName -Units $iotUnits
        $iotHubKeys = Get-AzIotHubKey -ResourceGroupName $env.resourceGroup -Name $iotHubName
        $iotHubKey  = $iotHubKeys[0].PrimaryKey | ConvertTo-SecureString -AsPlainText -Force

        $environmentName = $env.rstrenv02
        $tsiEevntSourceName = $env.rstres02
        New-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -Name $tsiEevntSourceName -EnvironmentName $environmentName -Kind Microsoft.IoTHub -ConsumerGroupName $env.resourceGroup -Location $env.location -KeyName RootManageSharedAccessKey -IoTHubName $iotHub.Name -EventSourceResourceId $iotHub.id -SharedAccessKey $iotHubKey
        $tsiEevntSource = Get-AzTimeSeriesInsightsEventSource -ResourceGroupName $env.resourceGroup -EnvironmentName $environmentName -Name $tsiEevntSourceName
        $tsiEevntSource.Name | Should -Be $tsiEevntSourceName
    }
}
