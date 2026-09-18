### Example 1: List NetworkSecurityPerimeters in ResourceGroup
```powershell
Get-AzNetworkSecurityPerimeter -ResourceGroupName rg-test-1
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus2euap nsp-test-1  rg-test-1
eastus2euap nsp-test-2  rg-test-1
eastus2euap nsp-test-3  rg-test-1
```

List NetworkSecurityPerimeters in ResourceGroup

### Example 2: List NetworkSecurityPerimeters in Subscription
```powershell
Get-AzNetworkSecurityPerimeter
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus2euap nsp-test-1  rg-test-1
eastus2euap nsp-test-2  rg-test-1
eastus2euap nsp-test-3  rg-test-1
eastus2euap nsp-test-4  rg-test-2
eastus2euap nsp-test-5  rg-test-2
```

List NetworkSecurityPerimeters in Subscription

### Example 3: Get NetworkSecurityPerimeter by Name
```powershell
Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
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

Get NetworkSecurityPerimeter by Name

### Example 4: Get NetworkSecurityPerimeter by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
Get-AzNetworkSecurityPerimeter -InputObject $GETObj
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

Get NetworkSecurityPerimeter by Identity (using pipe)