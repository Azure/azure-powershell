$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDigitalTwinsEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDigitalTwinsEndpoint' {
    It 'CreateEventHub' {
        $NewAzDigitalTwinsEndpoint = New-AzDigitalTwinsEndpoint -EndpointName $env.eventHubEndpointName -EndpointType $env.eventHubEndpointType -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins -ConnectionStringPrimaryKey $env.eventHubConnectionStringPrimaryKey
        $NewAzDigitalTwinsEndpoint.Name | Should -Be $env.eventHubEndpointName
    }

    It 'CreateEventGrid' {
        $NewAzDigitalTwinsEndpoint = New-AzDigitalTwinsEndpoint -EndpointName $env.eventGridEndpointName -EndpointType $env.eventGridEndpointType -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins -TopicEndpoint $env.eventGridTopEndPoint -AccessKey1 $env.eventGridAccessKey1
        $NewAzDigitalTwinsEndpoint.Name | Should -Be $env.eventGridEndpointName
    }

    It 'CreateServiceBus' {
        $NewAzDigitalTwinsEndpoint = New-AzDigitalTwinsEndpoint -EndpointName $env.serviceBusEndpointName -EndpointType $env.serviceBusEndpointType -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins -PrimaryConnectionString $env.serviceBusPrimaryConnectionString
        $NewAzDigitalTwinsEndpoint.Name | Should -Be $env.serviceBusEndpointName
    }
}
