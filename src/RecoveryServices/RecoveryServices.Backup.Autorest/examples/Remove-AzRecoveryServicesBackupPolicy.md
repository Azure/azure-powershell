### Example 1: Remove a policy with its name
```powershell
 Remove-AzRecoveryServicesBackupPolicy -PolicyName "MyPolicy" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
```

This command deletes the specified backup policy.
