$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCommunicationService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCommunicationService' {
    It 'List' {
        $services = Get-AzCommunicationService
        $services.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $service = Get-AzCommunicationService -Name $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $service.Name | Should -Be $env.persistentResourceName
    }

    It 'List1' {
        $services = Get-AzCommunicationService -ResourceGroupName $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $CommunicationServiceInstance01 = Get-AzCommunicationService -ResourceGroupName $env.resourceGroup -Name $env.persistentResourceName
        $CommunicationServiceInstance = Get-AzCommunicationService -inputObject $CommunicationServiceInstance01
        $CommunicationServiceInstance.Name | Should -Be $env.persistentResourceName
    }
}
