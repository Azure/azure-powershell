### Example 1: List all the protection containers in a recovery services vault
```powershell
Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Location Name                          Type
-------- ----                          ----
         A2AWestUSProtectionContainer  Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
         A2AEastUSProtectionContainer  Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
         A2AEastUSProtectionContainer2 Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
```

Lists all the protection containers in a specific recovery services vault

### Example 2: List all the protection container in a specific fabric in a recovery services vault
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric
```

```output
Location Name                          Type
-------- ----                          ----
         A2AEastUSProtectionContainer  Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
         A2AEastUSProtectionContainer2 Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
```

Lists all the protection container in a specific fabric in a specific recovery services vault

### Example 3: Get a protection conatiner in a specific fabric in a recovery services vault
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer2"
```

```output
Location Name                          Type
-------- ----                          ----
         A2AEastUSProtectionContainer2 Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers
```

Gets a specific protection conatiner in a specific fabric in a recovery services vault