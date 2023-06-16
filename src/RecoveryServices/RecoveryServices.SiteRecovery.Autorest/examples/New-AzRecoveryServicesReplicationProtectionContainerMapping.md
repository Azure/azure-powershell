### Example 1: Create a new replication protection container mapping
```powershell
$policy=Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -PolicyName "A2APolicy"
$mappingInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AContainerMappingInput]::new()
$mappingInput.ReplicationScenario="ReplicateAzureToAzure"
$primaryfabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$primaryprotectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $primaryfabric -ProtectionContainer "A2AEastUSProtectionContainer"
$recoveryfabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
$recoveryprotectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $recoveryfabric -ProtectionContainer "demoProtectionContainer"
New-AzRecoveryServicesReplicationProtectionContainerMapping -MappingName "demomap" -PrimaryProtectionContainer $primaryprotectioncontainer -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -ProviderSpecificInput $mappingInput -Policy $policy -RecoveryProtectionContainer $recoveryprotectioncontainer
```

```output
Id                                                                                                                                                                                                                                                                                                 Location Name    Type
--                                                                                                                                                                                                                                                                                                 -------- ----    ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/A2AEastUSProtectionContainer/replicationProtectionContainerMappings/testmappingcmd			demomap	Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectionContainerMappings
```

Creates a New azure protection container mapping in a recovery services vault.