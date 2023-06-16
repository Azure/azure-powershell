### Example 1: Remove a replication protection container in a fabric
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "demofabric"
$protectionConatiner=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "demoProtectionContainer"
Remove-AzRecoveryServicesReplicationProtectionContainer -ProtectionContainer $protectionConatiner -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

Removes a replication protection container using a protection container object fetched using fabric object in a recovery services vault.