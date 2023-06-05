### Example 1: Remove a replication policy
```powershell
$policy=Get-AzRecoveryServicesReplicationPolicy -PolicyName "demopolicy3" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
Remove-AzRecoveryServicesReplicationPolicy -Policy $policy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

Removes a specific replication policy in a specific recovery vault.

