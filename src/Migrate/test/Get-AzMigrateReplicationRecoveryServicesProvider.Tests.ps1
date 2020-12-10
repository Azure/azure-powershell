$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateReplicationRecoveryServicesProvider.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateReplicationRecoveryServicesProvider' {
    It 'List' {
        $output = Get-AzMigrateReplicationRecoveryServicesProvider -ResourceName $env.srsVaultName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
       $output = Get-AzMigrateReplicationRecoveryServicesProvider -FabricName $env.srsFabricName -ProviderName $env.srsProviderName -ResourceName $env.srsVaultName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }
}
