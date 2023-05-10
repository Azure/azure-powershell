### Example 1: Fetch a resource guard with a particular Name
```powershell
Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "RGName" -Name "ResourceGuardName"
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/ResourceGuardName                                                   centraluseuap ResourceGuardName
```

Gets a resource guard under a resource group with name "ResourceGuardName"

### Example 2: Fetch all the resource guards under a resource group
```powershell
Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "RGName"
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name               Type
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----               ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard1                                                    centraluseuap rguard1  Microsoft.DataProtection/resourceGuards
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard2                                                   centraluseuap rguard2 Microsoft.DataProtection/resourceGuards
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard3                                                   centraluseuap rguard3 Microsoft.DataProtection/resourceGuards
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard4                                                   centraluseuap rguard4 Microsoft.DataProtection/resourceGuards
```

Gets all resource guards under a resource group

