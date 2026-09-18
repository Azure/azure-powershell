### Example 1: List NetworkSecurityPerimeter Associations
```powershell
Get-AzNetworkSecurityPerimeterAssociation -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
Name                ResourceGroupName
----                -----------------
association-test-1  rg-test-1
association-test-2  rg-test-1
```

List NetworkSecurityPerimeter Associations

### Example 2: Get NetworkSecurityPerimeter Association by Name
```powershell
Get-AzNetworkSecurityPerimeterAssociation -Name association-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
AccessMode                   : Enforced
HasProvisioningIssue         : no
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/resourceAssociations/association-test-1
Name                         : association-test-1
PrivateLinkResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-2/providers/Microsoft.Sql
                               /servers/sql-server-test-1
ProfileId                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers/Microsoft.Netwo
                               rk/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/resourceAssociations
```

Get NetworkSecurityPerimeter Association by Name

### Example 3: Get NetworkSecurityPerimeter Association by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Get-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj
```

```output
AccessMode                   : Enforced
HasProvisioningIssue         : no
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/resourceAssociations/association-test-1
Name                         : association-test-1
PrivateLinkResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-2/providers
                                /Microsoft.Sql/servers/sql-server-test-1
ProfileId                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/resourceAssociations
```

Get NetworkSecurityPerimeter Association by Identity (using pipe)