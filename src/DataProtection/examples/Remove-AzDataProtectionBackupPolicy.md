### Example 1: Delete an existing policy
```powershell
PS C:\> $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
PS C:\> Remove-AzDataProtectionBackupPolicy -Name $policy[0].name -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"

```

this command deletes an existing policy.


