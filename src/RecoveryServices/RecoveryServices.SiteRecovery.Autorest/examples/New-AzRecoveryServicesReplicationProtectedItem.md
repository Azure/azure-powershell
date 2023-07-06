### Example 1: Create a replication protected item

```powershell
$protectionInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AEnableProtectionInput]::new()
$protectionInput.FabricObjectId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/abhinav_test/providers/Microsoft.Compute/virtualMachines/a2avmtest"
$protectionInput.ReplicationScenario="ReplicateAzureToAzure"
$protectionInput.RecoveryResourceGroupId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2avmrecoveryrg"
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$pcmap=Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -MappingName "A2AprimaryToRecovery"
New-AzRecoveryServicesReplicationProtectedItem -ProtectionContainerMapping $pcmap -ReplicatedProtectedItemName "replicatedvmtest2" -ResourceGroupName "a2arecoveryrg" -resourceName "a2arecoveryvault" -ProviderSpecificDetail $protectionInput -LogStorageAccountId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/abhinav_test/providers/Microsoft.Storage/storageAccounts/a2aprimarycachestorage"
```

```output
Id                                                                                                                                                                                                 Location Name                                 Type
--                                                                                                                                                                                                 -------- ----                                 ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationJobs/5b71e458-9c1b-465e-be75-938d9fdacf4b          5b71e458-9c1b-465e-be75-938d9fdacf4b Microsoft.RecoveryServices/vaults/replicationJobs
```

Creates new replication protected item in a recovery services vault