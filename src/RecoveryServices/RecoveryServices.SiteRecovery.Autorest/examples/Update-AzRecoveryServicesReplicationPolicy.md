### Example 1: Update an Azure-To-Azure replication policy in a recovery services vault
```powershell
$policyDesc=Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -PolicyName "demoPolicy"
$policy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2APolicyCreationInput]::new()
$policy.AppConsistentFrequencyInMinute=240
$policy.CrashConsistentFrequencyInMinute=60
$policy.MultiVMSyncStatus='Enable'
$policy.RecoveryPointHistory=4320
$policy.ReplicationScenario="ReplicateAzureToAzure"
Update-AzRecoveryServicesReplicationPolicy -Policy $policyDesc -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ReplicationProviderSetting $policy
```

```output
Location Name       Type
-------- ----       ----
         demoPolicy Microsoft.RecoveryServices/vaults/replicationPolicies
```

Updates an Azure-To-Azure replication policy in the specified vault in the specified resource group.

### Example 1: Updating an existing Policy
```powershell
$providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HyperVReplicaAzurePolicyInput]::new()
$providerSpecificPolicy.ReplicationInterval = 5
$providerSpecificPolicy.RecoveryPointHistoryDuration = 10
$providerSpecificPolicy.ReplicationScenario = "ReplicateHyperVToAzure"
$policy = Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -PolicyName "replicapolicy2h2a"
Update-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -Policy $policy -ReplicationProviderSetting $providerSpecificPolicy
```

```output
Location Name              Type
-------- ----              ----
         replicapolicy2h2a Microsoft.RecoveryServices/vaults/replicationPolicies
```

Updates an the replication policy provided as parameter in the specified vault in the specified resource group.
