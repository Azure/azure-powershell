### Example 1: Create a new resource guard
```powershell
PS C:\> New-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "mua-rg" -Name "mua-resource-guard" -Location "centraluseuap"
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/mua-rg/providers/Microsoft.DataProtection/resourceGuards/mua-resource-guard                                                   centraluseuap mua-resource-guard
```

The above command is used to create a resource guard "mua-resource-guard" under resource group "mua-rg" in location "centraluseuap"

