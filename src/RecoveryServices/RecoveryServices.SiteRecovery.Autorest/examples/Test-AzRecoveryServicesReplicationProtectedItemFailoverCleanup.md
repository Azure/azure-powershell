### Example 1: Clean the test failover of the replicated protected item

```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtest"
Test-AzRecoveryServicesReplicationProtectedItemFailoverCleanup -CleanupTestItem $protectedItem -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -Comment "failover cleanup"
```

```output
Location Name             Type
-------- ----             ----
         replicatedvmtest Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectedItems
```


Cleans the test failover of the replicated protected item