### Example 1: Initiates reprotect to a already failover committed compute VM
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "abhinavVmProtected"
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "demoProtectionContainerA2A"
$pcmap=Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -MappingName "reversemap"
$reverseInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2ASwitchProtectionInput]::new()
$reverseInput.RecoveryResourceGroupId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/abhinav_test"
$reverseInput.ReplicationScenario="ReplicateAzureToAzure"
Invoke-AzRecoveryServicesReverseReplicationProtectedItem -ReplicatedProtectedItem $protectedItem -ProtectionContainerMapping $pcmap -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProviderSpecificDetail $reverseInput -LogStorageAccountId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.Storage/storageAccounts/a2areversestorage"
```

```output
Id                                                                                                                                                                                                 Location Name                                 Type
--                                                                                                                                                                                                 -------- ----                                 ----
/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationJobs/fb1f7364-164d-425b-aa05-c92ba47d93f9          fb1f7364-164d-425b-aa05-c92ba47d93f9 Microsoft.RecoveryServices/vaults/replicationJobs
```

Initiates reprotect to a already failover committed compute VM