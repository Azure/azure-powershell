### Example 1: Create a new Organization in a Resource Group
```powershell
New-AzMongoDBOrganization -Name "testorg7" -Location "East US 2" -ResourceGroupName "yashika-rg" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId  "61641157-140c-4b97-b365-30ff76d9f82e" -PartnerPropertyOrganizationName "testorg7" -PartnerPropertyOrganizationId "6805d3e6bb11bf624o2bbaef"  -OfferDetailOfferId "mongodb_atlas_azure_native_prod" -OfferDetailPlanId "private_plan" -OfferDetailPlanName "Pay as You Go (Free) (Private)" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "mongodb" -OfferDetailTermId "gmz7xq9ge3py" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com"
```

```output
Id                              : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/yashika-rg/providers/MongoDB.Atlas/organizations/t
                                  estorg7
IdentityPrincipalId             :
IdentityTenantId                :
IdentityType                    :
IdentityUserAssignedIdentity    : {
                                  }
Location                        : East US 2
MarketplaceSubscriptionId       : 113931fe-923b-4b41-c4ad-f72d5a179123
MarketplaceSubscriptionStatus   : Subscribed
Name                            : testorg7
OfferDetailOfferId              : mongodb_atlas_azure_native_prod
OfferDetailPlanId               : private_plan
OfferDetailPlanName             : Pay as You Go (Free) (Private)
OfferDetailPublisherId          : mongodb
OfferDetailTermId               : gmz7xq9ge3py
OfferDetailTermUnit             : P1M
PartnerPropertyOrganizationId   : 6831b60333ded45665ebdf84
PartnerPropertyOrganizationName : testorg7
PartnerPropertyRedirectUrl      : https://account.mongodb.com/account/reset/password?email=yashikajain%40microsoft.com&orgId=6831b60333ded45665ebdf84&s
                                  houldRedirect=true
ProvisioningState               : Succeeded
ResourceGroupName               : yashika-rg
SystemDataCreatedAt             : 5/24/2025 12:04:33 PM
SystemDataCreatedBy             : yashikajain@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 5/24/2025 12:06:13 PM
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

This command will create a new MongoDB Resource.

