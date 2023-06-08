### Example 1: Remove a replication policy
```powershell
$policy=Get-AzRecoveryServicesReplicationPolicy -PolicyName "demopolicy3" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
Remove-AzRecoveryServicesReplicationPolicy -Policy $policy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

Removes a specific replication policy in a specific recovery vault.

### Example 2: Remove a replication policy
```powershell
$policy = Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -PolicyName "replicapolicy4h2a"
Remove-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -Policy $policy
```

Removes a specific replication policy in a specific recovery vault.
