### Example 1: Update an existing Organization
```powershell
Update-AzArizeAIOrganization -Name "test-cli-instance-4" -ResourceGroupName "QM_clitest_qumulo2_eastus" -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "arize-liftr-0" -OfferDetailPlanId "liftr-test-0" -OfferDetailPlanName "Liftr Test 0" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "arizeai1657829589668" -OfferDetailTermId "gmz7xq9ge3py" -Tag @{"TestName1" = "TestValue1"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/QM_clitest_qum
                                      ulo2_eastus/providers/arizeai.observabilityeval/organizations/test-instance-cli-1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           :
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test-instance-cli-1
OfferDetailOfferId                  : arize-liftr-0
OfferDetailPlanId                   : liftr-test-0
OfferDetailPlanName                 : Liftr Test 0
OfferDetailPublisherId              : arizeai1657829589668
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyDescription          :
ProvisioningState                   : Accepted
ResourceGroupName                   : QM_clitest_qumulo2_eastus
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 3/2/2025 1:48:39 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 3/2/2025 1:48:39 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                         "TestName1": "TestValue1"
                                      }
Type                                : arizeai.observabilityeval/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command updates the ArizeAI organization.

