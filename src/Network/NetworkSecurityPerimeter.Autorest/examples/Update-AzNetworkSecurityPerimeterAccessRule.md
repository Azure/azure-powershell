### Example 1: Update NetworkSecurityPerimeter AccessRule
```powershell
Update-AzNetworkSecurityPerimeterAccessRule -Name access-rule-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -ProfileName profile-test-1  -AddressPrefix @('10.10.0.0/24')
```

```output
AddressPrefix                : {10.10.0.0/24}
Direction                    : Inbound
EmailAddress                 : {}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1/accessRules/access-rule-test-1
Name                         : access-rule-test-1
NetworkSecurityPerimeter     : {}
PhoneNumber                  : {}
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
ServiceTag                   :
Subscription                 : {}
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/profiles/accessRules
```

Update NetworkSecurityPerimeter AccessRule

### Example 2: Update NetworkSecurityPerimeter AccessRule by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name access-rule-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -ProfileName profile-test-1
Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -AddressPrefix @('10.0.0.0/16')
```

```output
AddressPrefix                : {10.10.0.0/16}
Direction                    : Inbound
EmailAddress                 : {}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1/accessRules/access-rule-test-1
Name                         : access-rule-test-1
NetworkSecurityPerimeter     : {}
PhoneNumber                  : {}
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
ServiceTag                   :
Subscription                 : {}
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/profiles/accessRules
```

Updates a NetworkSecurityPerimeterAccessRule by identity (using pipe)