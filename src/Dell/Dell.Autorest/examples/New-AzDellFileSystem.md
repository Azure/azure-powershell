### Example 1: Create a Dell filesystem resource
```powershell
New-AzDellFileSystem -Name biswadeep-test-rss -ResourceGroupName biswadeep-test-rg -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37 -Location "eastus" -DelegatedSubnetId "/subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/pp-test/providers/Microsoft.Network/virtualNetworks/dell-test/subnets/default" -DelegatedSubnetCidr "10.0.0.0/24" -UserEmail "dummy@example.com" -DellReferenceNumber "12345" -EncryptionType "Microsoft-managed keys (MMK)" -MarketplaceOfferId "dell-managed-powerscale-for-azure" -MarketplacePlanId "plus1" -MarketplacePublisherId "dellemc" -MarketplacePlanName "Plus Plan" -MarketplaceTermUnit "P1Y" -MarketplaceSubscriptionId "00000000-0000-0000-0000-000000000000" -Tag @{"bypassPartner"="true"}
```

```output
CapacityCurrent                              :
CapacityIncremental                          :
CapacityMax                                  :
CapacityMin                                  :
DelegatedSubnetCidr                          : 10.0.0.0/24
DelegatedSubnetId                            : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/pp-te
                                               st/providers/Microsoft.Network/virtualNetworks/dell-test/subnets/default
DellReferenceNumber                          : 12345
EncryptionIdentityPropertyIdentityResourceId :
EncryptionIdentityPropertyIdentityType       :
EncryptionKeyUrl                             :
EncryptionType                               : Microsoft-managed keys (MMK)
FileSystemId                                 : PartnerBypassed
Id                                           : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/biswa
                                               deep-test-rg/providers/Dell.Storage/filesystems/biswadeep-test-rss
IdentityPrincipalId                          :
IdentityTenantId                             :
IdentityType                                 :
IdentityUserAssignedIdentity                 : {
                                               }
Location                                     : eastus
MarketplaceEndDate                           :
MarketplaceOfferId                           : dell-managed-powerscale-for-azure
MarketplacePlanId                            : plus1
MarketplacePlanName                          : Plus Plan
MarketplacePrivateOfferId                    :
MarketplacePublisherId                       : dellemc
MarketplaceSubscriptionId                    : 44ca4cc4-327f-4490-d051-2d2a6242a886
MarketplaceSubscriptionStatus                : Subscribed
MarketplaceTermUnit                          : P1Y
Name                                         : biswadeep-test-rss
OneFsUrl                                     :
ProvisioningState                            : Succeeded
ResourceGroupName                            : biswadeep-test-rg
SmartConnectFqdn                             :
SystemDataCreatedAt                          : 7/23/2026 5:39:14 AM
SystemDataCreatedBy                          : dummy@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 7/23/2026 5:39:14 AM
SystemDataLastModifiedBy                     : dummy@example.com
SystemDataLastModifiedByType                 : User
Tag                                          : {
                                                 "bypassPartner": "true"
                                               }
Type                                         : dell.storage/filesystems
UserEmail                                    :
```

Creates a new Dell filesystem resource with networking configuration.

### Example 2: Create a Dell filesystem resource using a JSON file
```powershell
New-AzDellFileSystem -Name biswadeep-test-rss-2 -ResourceGroupName biswadeep-test-rg -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37 -JsonFilePath ".\examples\dell-filesystem.json"
```

```output
CapacityCurrent                              :
CapacityIncremental                          :
CapacityMax                                  :
CapacityMin                                  :
DelegatedSubnetCidr                          : 10.0.0.0/24
DelegatedSubnetId                            : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/pp-te
                                               st/providers/Microsoft.Network/virtualNetworks/dell-test/subnets/default
DellReferenceNumber                          : 12345
EncryptionIdentityPropertyIdentityResourceId :
EncryptionIdentityPropertyIdentityType       :
EncryptionKeyUrl                             :
EncryptionType                               : Microsoft-managed keys (MMK)
FileSystemId                                 : PartnerBypassed
Id                                           : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/biswa
                                               deep-test-rg/providers/Dell.Storage/filesystems/biswadeep-test-rss-2
IdentityPrincipalId                          :
IdentityTenantId                             :
IdentityType                                 :
IdentityUserAssignedIdentity                 : {
                                               }
Location                                     : eastus
MarketplaceEndDate                           :
MarketplaceOfferId                           : dell-managed-powerscale-for-azure
MarketplacePlanId                            : plus1
MarketplacePlanName                          : Plus Plan
MarketplacePrivateOfferId                    :
MarketplacePublisherId                       : dellemc
MarketplaceSubscriptionId                    : d52f9ff3-853c-4c5b-dd90-f08126e3b187
MarketplaceSubscriptionStatus                : Subscribed
MarketplaceTermUnit                          : P1Y
Name                                         : biswadeep-test-rss-2
OneFsUrl                                     :
ProvisioningState                            : Succeeded
ResourceGroupName                            : biswadeep-test-rg
SmartConnectFqdn                             :
SystemDataCreatedAt                          : 7/23/2026 6:03:31 AM
SystemDataCreatedBy                          : dummy@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 7/23/2026 6:03:31 AM
SystemDataLastModifiedBy                     : dummy@example.com
SystemDataLastModifiedByType                 : User
Tag                                          : {
                                                 "bypassPartner": "true"
                                               }
Type                                         : dell.storage/filesystems
UserEmail                                    :
```

Creates a Dell filesystem resource from a JSON file. See `dell-filesystem.json` in the examples folder for the expected JSON format.

