### Example 1: Commit the failover of the replication protected item
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtest"
Invoke-AzRecoveryServicesCommitReplicationProtectedItemFailover -ReplicatedProtectedItem $protectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Id                                                                                                                                                                                                 Location Name                                 Type
--                                                                                                                                                                                                 -------- ----                                 ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationJobs/856257d3-5a8e-46ed-92c1-09890bfad34a          856257d3-5a8e-46ed-92c1-09890bfad34a Microsoft.RecoveryServices/vaults/replicationJobs
```

Commits the failover of the replication protected item in a recovery services vault.

