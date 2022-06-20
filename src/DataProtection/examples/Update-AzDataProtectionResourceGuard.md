### Example 1: Update a resource guard
```powershell
PS C:\> $resourceGuard = Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "rgName" -Name "resGuardName"
PS C:\> $criticalOperations  = $resourceGuard.ResourceGuardOperation.VaultCriticalOperation
PS C:\> $operationsToBeExcluded = $criticalOperations | where { $_ -match "backupSecurityPIN/action" -or $_ -match "backupInstances/delete" }
PS C:\> Update-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "rgName" -Name $resourceGuard.Name -CriticalOperationExclusionList $operationsToBeExcluded
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/mua-rg/providers/Microsoft.DataProtection/resourceGuards/mua-resource-guard                                                   centraluseuap mua-resource-guard
```

The first command is used to fetch the resource guard to be updated. The second and third command is used to fecth the critical operations user want to update. 
The fourth command is used to exclude some critical operations from the resource guard