### Example 1: List all the replication fabrics in a specified recovery services vault
```powershell
Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Location Name             Type
-------- ----             ----
         A2Ademo-EastUS   Microsoft.RecoveryServices/vaults/replicationFabrics
         A2Aprimaryfabric Microsoft.RecoveryServices/vaults/replicationFabrics
```

Lists details of all the replication fabrics in a specific recovery servivces vault.

### Example 2: Get a replication fabric using a fabric name
```powershell
Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
```

```output
Location Name             Type
-------- ----             ----
         A2Aprimaryfabric Microsoft.RecoveryServices/vaults/replicationFabrics
```

Gets details of a replication fabric using fabric name in a specific recovery services vault.

