### Example 1: Update details of a replicated protected item
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$replicatedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtest"
$providerSpecificinput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AUpdateReplicationProtectedItemInput]::new()
$providerSpecificinput.ReplicationScenario="ReplicateAzureToAzure"
Update-AzRecoveryServicesReplicationProtectedItem -ReplicatedProtectedItem $replicatedItem -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -ProviderSpecificDetail $providerSpecificinput
```

```output
Location Name             Type
-------- ----             ----
         replicatedvmtest Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectedItems
```

Updates some details of a replicated protected item in a recovery services vault