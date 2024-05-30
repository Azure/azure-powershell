### Example 1: Fetch resource guard mapping.
```powershell
$mapping = Get-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId
$mapping | fl
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

This command gets the MUA setting (resource guard mapping with backup vault) for the backup vault. The output of this command is used to ensure whether MUA is enabled on the backup vault and to determine the underlying resource guard to protect the critical operations.
