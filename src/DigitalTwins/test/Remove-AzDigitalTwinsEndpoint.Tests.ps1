$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDigitalTwinsEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDigitalTwinsEndpoint' {
    It 'Delete' {
        Remove-AzDigitalTwinsEndpoint -EndpointName $env.eventHubEndpointName -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $GetAzDigitalTwinsEndpointList = Get-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $GetAzDigitalTwinsEndpointList.Name | Should -Not -Contain $env.digitalTwins
    }

    It 'DeleteViaIdentity' {
        $GetAzdigitalTwinsEndpoint = Get-AzDigitalTwinsEndpoint -EndpointName $env.eventGridEndpointName -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        Remove-AzDigitalTwinsEndpoint -InputObject $GetAzdigitalTwinsEndpoint
        $GetAzDigitalTwinsEndpointList = Get-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $GetAzDigitalTwinsEndpointList.Name | Should -Not -Contain $env.digitalTwins
    }
}
