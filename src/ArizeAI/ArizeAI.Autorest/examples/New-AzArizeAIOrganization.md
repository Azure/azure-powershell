### Example 1: Create a new Organization in a Resource Group
```powershell
New-AzArizeAIOrganization -Name "test-cli-instance-4" -Location "East US" -ResourceGroupName "QM_clitest_qumulo2_eastus" -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "arize-liftr-0" -OfferDetailPlanId "liftr-test-0" -OfferDetailPlanName "Liftr Test 0" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "arizeai1657829589668" -OfferDetailTermId "gmz7xq9ge3py" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output

Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/QM_clitest_qum
                                      ulo2_eastus/providers/ArizeAi.ObservabilityEval/organizations/test-cli-instance-4
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus
MarketplaceSubscriptionId           : fc35d936-3b89-41f8-8110-a24b56826c37
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test-cli-instance-4
OfferDetailOfferId                  : arize-liftr-0
OfferDetailPlanId                   : liftr-test-0
OfferDetailPlanName                 : Liftr Test 0
OfferDetailPublisherId              : arizeai1657829589668
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 :
PartnerPropertyDescription          :
ProvisioningState                   : Succeeded
ResourceGroupName                   : QM_clitest_qumulo2_eastus
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 3/2/2025 1:54:01 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 3/2/2025 3:05:11 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : arizeai.observabilityeval/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will create a new Pinecone Resource

