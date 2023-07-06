### Example 1: Initate a failover of the replicated protected item
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtest"
$providerSpecificinput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AUnplannedFailoverInput]::new()
$providerSpecificinput.CloudServiceCreationOption="AutoCreateCloudService"
$providerSpecificinput.ReplicationScenario="ReplicateAzureToAzure"
Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover -ReplicatedProtectedItem $protectedItem -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -ProviderSpecificDetail $providerSpecificinput
```

```output
Id                                                                                                                                                                                                 Location Name                                 Type
--                                                                                                                                                                                                 -------- ----                                 ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationJobs/b620f8ea-c647-4fc6-8171-ea8ab212fdf8          b620f8ea-c647-4fc6-8171-ea8ab212fdf8 Microsoft.RecoveryServices/vaults/replicationJobs
```

Initates a failover of the replicated protected item in a recovery services vault