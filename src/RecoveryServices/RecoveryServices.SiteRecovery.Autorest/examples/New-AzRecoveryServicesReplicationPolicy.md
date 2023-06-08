### Example 1: Create an Azure-To-Azure replication policy in a recovery services vault
```powershell
$policy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2APolicyCreationInput]::new()
$policy.AppConsistentFrequencyInMinute=240
$policy.CrashConsistentFrequencyInMinute=60
$policy.MultiVMSyncStatus='Enable'
$policy.RecoveryPointHistory=4320
$policy.ReplicationScenario="ReplicateAzureToAzure"
New-AzRecoveryServicesReplicationPolicy -PolicyName "demopolicy1" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProviderSpecificInput $policy
```

```output
Location Name        Type
-------- ----        ----
         demopolicy1 Microsoft.RecoveryServices/vaults/replicationPolicies
```

Creates an Azure-To-Azure replication policy in the specified vault in the specified resource group.

### Example 2: Create an HyperV-To-Azure replication policy in a recovery services vault
```powershell
$providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HyperVReplicaAzurePolicyInput]::new()
$providerSpecificPolicy.ApplicationConsistentSnapshotFrequencyInHour = 3
$providerSpecificPolicy.RecoveryPointHistoryDuration = 10
$providerSpecificPolicy.ReplicationScenario = "ReplicateHyperVToAzure"
$providerSpecificPolicy.ReplicationInterval = 300
New-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -PolicyName "replicapolicy4h2a" -ProviderSpecificInput $providerSpecificPolicy
```

```output
Location Name              Type
-------- ----              ----
         replicapolicy4h2a Microsoft.RecoveryServices/vaults/replicationPolicies
```

Creates an HyperV to Azure replication policy in the specified vault in the specified resource group with the given parameters.