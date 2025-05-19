### Example 1: Get all Organizations in a Resource Group
```powershell
Get-AzMongodbOrganization -ResourceGroupName yashika-rg
```

```output
Location       Name         SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------       ----         -------------------   -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
East US 2      mongodbtest1 5/15/2025 11:44:53 AM yashikajain@microsoft.com User                    5/15/2025 11:46:09 AM    b059abce-70fd-4c8f-a117-96d2192e90e1 Application                  yashika-rg
East US 2 EUAP mongodbtest2 5/15/2025 6:25:00 PM  yashikajain@microsoft.com User                    5/15/2025 6:28:02 PM     b059abce-70fd-4c8f-a117-96d2192e90e1 Application                  yashika-rg
```

This command will get all organization details for all resources in a resoure group in a given subscription.

### Example 2: Get a specific Organization in a Resource Group
```powershell
Get-AzMongodbOrganization -ResourceGroupName yashika-rg -Name mongodbtest1
```

```output
Id                              : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/yashika-rg/providers/mongodb.atlas/organizations/m
                                  ongodbtest1
IdentityPrincipalId             :
IdentityTenantId                :
IdentityType                    :
IdentityUserAssignedIdentity    : {
                                  }
Location                        : East US 2
MarketplaceSubscriptionId       : 05bc2cd6-e3a6-4169-d25e-514b34e0bae2
MarketplaceSubscriptionStatus   : Subscribed
Name                            : mongodbtest1
OfferDetailOfferId              : mongodb_atlas_azure_native_prod
OfferDetailPlanId               : private_plan
OfferDetailPlanName             : Pay as You Go (Free) (Private)
OfferDetailPublisherId          : mongodb
OfferDetailTermId               : gmz7xq9ge3py
OfferDetailTermUnit             : P1M
PartnerPropertyOrganizationId   : 6825d3e6bb11bf624c2baaed
PartnerPropertyOrganizationName : mongodbtest-org1
PartnerPropertyRedirectUrl      : https://account.mongodb.com/account/reset/password?email=yashikajain%40microsoft.com&orgId=6825d3e6bb11bf624c2baaed&s
                                  houldRedirect=true
ProvisioningState               : Succeeded
ResourceGroupName               : yashika-rg
SystemDataCreatedAt             : 5/15/2025 11:44:53 AM
SystemDataCreatedBy             : yashikajain@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 5/15/2025 11:46:09 AM
SystemDataLastModifiedBy        : b059abce-70fd-4c8f-a117-96d2192e90e1
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : mongodb.atlas/organizations
UserCompanyName                 :
UserEmailAddress                : yashikajain@microsoft.com
UserFirstName                   :
UserLastName                    :
UserPhoneNumber                 :
UserUpn                         : yashikajain@microsoft.com
```

This command will get details of an organization for a resource name in a given subscription.

