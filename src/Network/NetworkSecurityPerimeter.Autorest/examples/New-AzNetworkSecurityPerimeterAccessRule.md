### Example 1: Create NetworkSecurityPerimeter AccessRule - Inbound
```powershell
New-AzNetworkSecurityPerimeterAccessRule -Name access-rule-test-1 -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound'
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

Create NetworkSecurityPerimeter AccessRule - Inbound

### Example 2: Create NetworkSecurityPerimeter AccessRule - Outbound
```powershell
New-AzNetworkSecurityPerimeterAccessRule -Name access-rule-test-2 -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -EmailAddress @("test123@microsoft.com", "test321@microsoft.com") -Direction 'Outbound'
```

```output
AddressPrefix                : {}
Direction                    : Outbound
EmailAddress                 : {test123@microsoft.com, test321@microsoft.com}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1/accessRules/access-rule-test-2
Name                         : access-rule-test-2
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

Create NetworkSecurityPerimeter AccessRule - Outbound