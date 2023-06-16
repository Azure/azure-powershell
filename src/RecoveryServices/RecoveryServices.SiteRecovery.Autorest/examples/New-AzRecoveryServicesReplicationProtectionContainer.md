### Example 1: Create a replication protection container in a fabric.
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
$protectioncontainer=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AContainerCreationInput]::new()
$protectioncontainer.ReplicationScenario="ReplicateAzureToAzure"
New-AzRecoveryServicesReplicationProtectionContainer -Fabric $fabric -ProtectionContainerName "testcontainercmd" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProviderSpecificInput $protectioncontainer
```

```output
Id                                                                                                                                                                                                                                 Location Name             Type
--                                                                                                                                                                                                                                 -------- ----             ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Aprimaryfabric/replicationProtectionContainers/testcontainercmd          testcontainercmd Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
```

Creates a replication protection container in a fabric in a specific recovery services vault.