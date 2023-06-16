### Example 1: Remove a replication protection container mapping
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "demoprotectioncontainerA2A"
$pcmapping=Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -MappingName "A2ARecoveryToPrimary"
Remove-AzRecoveryServicesReplicationProtectionContainerMapping -ProtectionContainerMapping $pcmapping -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

Removes a replication protection container mapping in a recovery services vault.