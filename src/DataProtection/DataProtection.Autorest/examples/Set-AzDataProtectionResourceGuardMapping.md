### Example 1: Enable MUA on backup vault (set resource guard mapping)
```powershell
$proxy = Set-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGuardId $resourceGuardARMId
$proxy | fl
```

```output
Description                  : 
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.DataProtection/backupVaults/m
                               ua-pstest-backupvault/backupResourceGuardProxies/DppResourceGuardProxy
LastUpdatedTime              : 2023-08-29T07:23:05.1111730Z
Name                         : DppResourceGuardProxy
ResourceGuardId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/hiaga-rg/providers/Microsoft.DataProtection/resourceGuard
                               s/mua-pstest-resguard
ResourceGuardOperationDetail : {Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.ResourceGuardOperationDetail,
                               Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.ResourceGuardOperationDetail}
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api40.SystemData
Type                         : Microsoft.DataProtection/vaults/backupResourceGuardProxies
```

This command creates the mapping between resource guard and backup vault, this prevent any unauthorized access over any of the critical operations, performed on the backup vault, protected by the resource guard.
Backup Admin needs to ensure to have reader access on the resource guard to Enable MUA on the backup vault. 
