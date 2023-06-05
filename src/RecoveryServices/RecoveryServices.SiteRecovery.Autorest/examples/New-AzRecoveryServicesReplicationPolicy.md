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