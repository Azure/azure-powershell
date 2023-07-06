### Example 1: Remove a replictaed protected item
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtest2"
Remove-AzRecoveryServicesReplicationProtectedItem -ProtectedItem $protectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

Removes a replicated protected item from a recovery services vault