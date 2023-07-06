### Example 1: Change the recovery point of a failed over replication protected item.
```powershell
$providerSpecificinput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AApplyRecoveryPointInput]::new()
$providerSpecificinput.ReplicationScenario="ReplicateAzureToAzure"
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtestcheck"
Invoke-AzRecoveryServicesReplicationProtectedItemApplyRecoveryPoint -ReplicatedProtectedItem $protectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProviderSpecificDetail $providerSpecificinput -RecoveryPointId "/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/b00f40d0-4428-4324-a70c-2e72d2f32ee2"
```

```output
Id                                                                                                                                                                                                 Location Name                                 Type
--                                                                                                                                                                                                 -------- ----                                 ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationJobs/5b71e458-9c1b-465e-be75-938d9fdacf4b          5b71e458-9c1b-465e-be75-938d9fdacf4b Microsoft.RecoveryServices/vaults/replicationJobs
```

changes the recovery point of a failed over replication protected item in a recovery services vault.

