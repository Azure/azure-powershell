### Example 1: Create a new Organization in a Resource Group
```powershell
New-AzMongodbOrganization -Name "testorg5" -Location "East US 2" -ResourceGroupName "yashika-rg" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId  "61641157-140c-4b97-b365-30ff76d9f82e" -PartnerPropertyOrganizationName "testorg5" -PartnerPropertyOrganizationId "6825d3e6bb11bf624c2bbaef"  -OfferDetailOfferId "mongodb_atlas_azure_native_prod" -OfferDetailPlanId "private_plan" -OfferDetailPlanName "Pay as You Go (Free) (Private)" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "mongodb" -OfferDetailTermId "gmz7xq9ge3py" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com"
```

```output
Id                              : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/yashika-rg/providers/MongoDB.Atlas/organizations/testorg5
IdentityPrincipalId             :
IdentityTenantId                :
IdentityType                    :
IdentityUserAssignedIdentity    : {
                                  }
Location                        : East US 2
MarketplaceSubscriptionId       : 7c9656d5-bf22-4f97-dba3-783e05b079f8
MarketplaceSubscriptionStatus   : Subscribed
Name                            : testorg5
OfferDetailOfferId              : mongodb_atlas_azure_native_prod
OfferDetailPlanId               : private_plan
OfferDetailPlanName             : Pay as You Go (Free) (Private)
OfferDetailPublisherId          : mongodb
OfferDetailTermId               : gmz7xq9ge3py
OfferDetailTermUnit             : P1M
PartnerPropertyOrganizationId   : 68263def1158e05a95034cd7
PartnerPropertyOrganizationName : testorg5
PartnerPropertyRedirectUrl      : https://account.mongodb.com/account/reset/password?email=yashikajain%40microsoft.com&orgId=68263def1158e05a95034cd7&shouldRedirect=true
ProvisioningState               : Succeeded
ResourceGroupName               : yashika-rg
SystemDataCreatedAt             : 5/15/2025 7:17:14 PM
SystemDataCreatedBy             : yashikajain@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 5/15/2025 7:18:46 PM
SystemDataLastModifiedBy        : b059abce-70fd-4c8f-a117-96d2192e90e1
SystemDataLastModifiedByType    : Application
Tag                             : {
                                    "testName": "TestValue"
                                  }
Type                            : mongodb.atlas/organizations
UserCompanyName                 :
UserEmailAddress                : yashikajain@microsoft.com
UserFirstName                   :
UserLastName                    :
UserPhoneNumber                 :
UserUpn                         : yashikajain@microsoft.com
```

This command will create a new MongoDB Resource

