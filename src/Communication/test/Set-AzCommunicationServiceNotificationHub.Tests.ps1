$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzCommunicationServiceNotificationHub.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzCommunicationServiceNotificationHub' {
    It 'LinkExpanded' {
        $returnedResourceId = Set-AzCommunicationServiceNotificationHub -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -ConnectionString $env.notificationHubConnectionString -ResourceId $env.notificationHubResourceId
        $returnedResourceId | Should -Be $env.notificationHubResourceId
    }

    It 'Link' {
        $returnedResourceId = Set-AzCommunicationServiceNotificationHub -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -LinkNotificationHubParameter @{ConnectionString=$env.notificationHubConnectionString; ResourceId=$env.notificationHubResourceId}
        $returnedResourceId | Should -Be $env.notificationHubResourceId
    }
}
