### Example 1: Create NetworkSecurityPerimeter Association
```powershell
$profileId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers/Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1'
$privateLinkResourceId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-2/providers/Microsoft.Sql/servers/sql-server-test-1'
New-AzNetworkSecurityPerimeterAssociation -Name association-test-1 -SecurityPerimeterName nsp-test-1 -ResourceGroupName rg-test-1 -AccessMode Learning -ProfileId $profileId -PrivateLinkResourceId $privateLinkResourceId
```

```output
AccessMode                   : Learning
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

Create NetworkSecurityPerimeter Association
