$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRecoveryServicesReplicationPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzRecoveryServicesReplicationPolicy' {
    It 'Delete' {
        $providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HyperVReplicaAzurePolicyInput]::new()
        $providerSpecificPolicy.ApplicationConsistentSnapshotFrequencyInHour = 3
        $providerSpecificPolicy.RecoveryPointHistoryDuration = 10
        $providerSpecificPolicy.ReplicationScenario = "ReplicateHyperVToAzure"
        $providerSpecificPolicy.ReplicationInterval = 300
        New-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName -PolicyName $env.asrRemovePolicyCreation -ProviderSpecificInput $providerSpecificPolicy
        $temp2 = Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName
        $policy = Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName -PolicyName $env.asrRemovePolicyCreation
        Remove-AzRecoveryServicesReplicationPolicy -ResourceName $env.asrResourceName -ResourceGroupName $env.asrResourceGroup -Policy $policy
        $temp1 = Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName
        $obj = $temp2.Count - $temp1.Count
        $obj | Should -Be 1
    }
}
