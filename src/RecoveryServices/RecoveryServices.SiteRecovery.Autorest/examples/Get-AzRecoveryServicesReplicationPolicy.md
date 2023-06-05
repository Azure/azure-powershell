### Example 1: Get all replication policies in a recovery services vault
```powershell
Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Id                                                                                                                                                                            Location Name        Type
--                                                                                                                                                                            -------- ----        ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/demopolicy3          demopolicy3 Microsoft.RecoveryServices/vaults/replicationPolicies
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/demopolicy2          demopolicy2 Microsoft.RecoveryServices/vaults/replicationPolicies
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/demopolicy1          demopolicy1 Microsoft.RecoveryServices/vaults/replicationPolicies
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/A2APolicy            A2APolicy   Microsoft.RecoveryServices/vaults/replicationPolicies
```

Gets all the replication policies in the specified vault in the specified resource group.

### Example 2: Get info for a specific replication policy
```powershell
Get-AzRecoveryServicesReplicationPolicy -PolicyName "A2APolicy" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Id                                                                                                                                                                          Location Name      Type
--                                                                                                                                                                          -------- ----      ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/A2APolicy          A2APolicy Microsoft.RecoveryServices/vaults/replicationPolicies
```

Gets info for a specific replication policy by its name in the specified vault in the specified resource group.

