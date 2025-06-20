### Example 1: Update NetworkSecurityPerimeter
```powershell
Update-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1 -Tag @{'Owner'='user-test-1'}
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1
Location                     : eastus2euap
Name                         : nsp-test-1
PerimeterGuid                : 00000000-0000-0000-0000-000000000000
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                                 " Owner": "user-test-1"
                               }
Type                         : Microsoft.Network/networkSecurityPerimeters
```

Update NetworkSecurityPerimeter

### Example 2: Update NetworkSecurityPerimeter by Identity (using pipe)
```powershell
 $GETObj = Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
 Update-AzNetworkSecurityPerimeter -InputObject $GETObj -Tag @{'Owner'='user-test-2'}
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1
Location                     : eastus2euap
Name                         : nsp-test-1
PerimeterGuid                : 00000000-0000-0000-0000-000000000000
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                                 " Owner": "user-test-2"
                               }
Type                         : Microsoft.Network/networkSecurityPerimeters
```

Update NetworkSecurityPerimeter by Identity (using pipe)