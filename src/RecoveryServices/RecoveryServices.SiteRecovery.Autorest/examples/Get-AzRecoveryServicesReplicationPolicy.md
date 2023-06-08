### Example 1: List all replication policies in a recovery services vault(Azure to Azure)
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

### Example 3: List all replication policies in a recovery services vault (Hyper-V to Azure)
```powershell
Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault"
```
```output
Location Name              Type
-------- ----              ----
         replicapolicy4h2a Microsoft.RecoveryServices/vaults/replicationPolicies
         replicapolicy3h2a Microsoft.RecoveryServices/vaults/replicationPolicies
         replicapolicy2h2a Microsoft.RecoveryServices/vaults/replicationPolicies
         replicapolicyh2a  Microsoft.RecoveryServices/vaults/replicationPolicies
```

Gets all the replication policies in the specified vault in the specified resource group.

### Example 4: Get info for a specific replication policy (Hyper-V to Azure)
```powershell
Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -PolicyName "replicapolicyh2a"
```

```output
Location Name             Type
-------- ----             ----
         replicapolicyh2a Microsoft.RecoveryServices/vaults/replicationPolicies
```

Gets info for a specific replication policy by its name in the specified vault in the specified resource group.