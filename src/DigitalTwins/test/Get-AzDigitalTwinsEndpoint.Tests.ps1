$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDigitalTwinsEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDigitalTwinsEndpoint' {
    It 'List' {
        $GetAzDigitalTwinsEndpointList = Get-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $GetAzDigitalTwinsEndpointList.Count | Should -Be 3
    }

    It 'Get' {
        $GetAzDigitalTwinsEndpoint = Get-AzDigitalTwinsEndpoint -EndpointName $env.eventHubEndpointName -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $GetAzDigitalTwinsEndpoint.Name | Should -Be $env.eventHubEndpointName
    }

    It 'GetViaIdentity' {
        $GetAzDigitalTwinsEndpointExample = Get-AzDigitalTwinsEndpoint -EndpointName $env.eventHubEndpointName -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $GetAzDigitalTwinsEndpoint = Get-AzDigitalTwinsEndpoint -InputObject $GetAzDigitalTwinsEndpointExample
        $GetAzDigitalTwinsEndpoint.Name | Should -Be $env.eventHubEndpointName
    }
}
