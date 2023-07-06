### Example 1: Perform a test failover of the replicated protected item

```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtest"
$providerSpecificinput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2ATestFailoverInput]::new()
$providerSpecificinput.ReplicationScenario="ReplicateAzureToAzure"
$providerSpecificinput.CloudServiceCreationOption="AutoCreateCloudService"
Test-AzRecoveryServicesReplicationProtectedItemFailover -ReplicatedProtectedItem $protectedItem -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -ProviderSpecificDetail $providerSpecificinput -NetworkId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2avmrecoveryrg/providers/Microsoft.Network/virtualNetworks/testVmnetwork" -NetworkType "VmNetworkAsInput" -FailoverDirection "PrimaryToRecovery"
```

```output
Location Name             Type
-------- ----             ----
         replicatedvmtest Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectedItems
```

Performs a test failover of the replicated protected item