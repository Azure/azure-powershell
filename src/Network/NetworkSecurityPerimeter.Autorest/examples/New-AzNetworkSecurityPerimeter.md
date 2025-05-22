### Example 1: Create NetworkSecurityPerimeter
```powershell
New-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1 -Location eastus2euap
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
Tag                          : { }
Type                         : Microsoft.Network/networkSecurityPerimeters
```

Create NetworkSecurityPerimeter
