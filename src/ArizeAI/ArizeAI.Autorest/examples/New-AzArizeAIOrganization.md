### Example 1: Create a new Organization in a Resource Group
```powershell
New-AzArizeAIOrganization -Name "test2" -Location "East US" -ResourceGroupName "yashika-rg-arize" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -OfferDetailOfferId "arize-liftr-0" -OfferDetailPlanId "liftr-test-0" -OfferDetailPlanName "Liftr Test 0" -OfferDetailPublisherId "arizeai1657829589668" -OfferDetailTermId "gmz7xq9ge3py" -OfferDetailTermUnit "P1M" -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com" -PartnerPropertyDescription "testing"
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/yashika-rg-arize/providers/ArizeAi
                                      .ObservabilityEval/organizations/test2
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           : 510f30b4-4ea5-46dc-db9c-ebd229760534
MarketplaceSubscriptionStatus       : Subscribed
Name                                : test2
OfferDetailOfferId                  : arize-liftr-0
OfferDetailPlanId                   : liftr-test-0
OfferDetailPlanName                 : Liftr Test 0
OfferDetailPublisherId              : arizeai1657829589668
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyDescription          : testing
ProvisioningState                   : Succeeded
ResourceGroupName                   : yashika-rg-arize
SingleSignOnPropertyAadDomain       : 
SingleSignOnPropertyEnterpriseAppId : 
SingleSignOnPropertyState           : 
SingleSignOnPropertyType            : 
SingleSignOnPropertyUrl             : 
SystemDataCreatedAt                 : 7/9/2025 9:04:42 AM
SystemDataCreatedBy                 : yashikajain@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 7/9/2025 9:04:42 AM
SystemDataLastModifiedBy            : yashikajain@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : arizeai.observabilityeval/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserFirstName                       : 
UserLastName                        : 
UserPhoneNumber                     : 
UserUpn                             : yashikajain@microsoft.com
```

This command will create a new Pinecone Resource

