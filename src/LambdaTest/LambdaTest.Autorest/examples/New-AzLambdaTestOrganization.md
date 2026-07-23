### Example 1:  Create a new Organization in a Resource Group with SSO
```powershell
New-AzLambdaTestOrganization -Name "test-cli-instance-3" -Location "Central US EUAP" -ResourceGroupName "abdul-test" -PartnerPropertyLicensesSubscribed 3 -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "lambdatest_liftr_testing" -OfferDetailPlanId "testing" -OfferDetailPlanName "testing_liftr" -OfferDetailTermUnit "P1Y" -OfferDetailPublisherId "lambdatestinc1584019832435" -OfferDetailTermId "o73usof6rkyy"  -SingleSignOnPropertyEnterpriseAppId "0b9873df-1629-4036-9360-5f2f65c0a0d3" -SingleSignOnPropertyAadDomain @("MicrosoftCustomerLed.onmicrosoft.com") -SingleSignOnPropertyType "Saml" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/abdul-test/providers/LambdaTest.HyperExecute/organizations/test-cli-instance-3
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : Central US EUAP
MarketplaceSubscriptionId           : 53c4986d-938d-432a-d5cb-292607600bf9
MarketplaceSubscriptionStatus       : Subscribed
Name                                : test-cli-instance-3
OfferDetailOfferId                  : lambdatest_liftr_testing
OfferDetailPlanId                   : testing
OfferDetailPlanName                 : testing_liftr
OfferDetailPublisherId              : lambdatestinc1584019832435
OfferDetailTermId                   : o73usof6rkyy
OfferDetailTermUnit                 : P1Y
PartnerPropertyLicensesSubscribed   : 3
ProvisioningState                   : Succeeded
ResourceGroupName                   : abdul-test
SingleSignOnPropertyAadDomain       : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyEnterpriseAppId : 0b9873df-1629-4036-9360-5f2f65c0a0d3
SingleSignOnPropertyState           :
SingleSignOnPropertyType            : Saml
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 4/11/2025 11:18:50 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 4/11/2025 11:18:50 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : lambdatest.hyperexecute/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will create a new LambdaTest Resource

### Example 1:  Create a new Organization in a Resource Group without SSO
```powershell
New-AzLambdaTestOrganization -Name "test-cli-instance-2" -PartnerPropertyLicensesSubscribed 3 -Location "Central US EUAP" -ResourceGroupName "abdul-test" -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "lambdatest_liftr_testing" -OfferDetailPlanId "testing" -OfferDetailPlanName "testing_liftr" -OfferDetailTermUnit "P1Y" -OfferDetailPublisherId "lambdatestinc1584019832435" -OfferDetailTermId "o73usof6rkyy" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/abdul-test/providers/LambdaTest.HyperExecute/organizations/test-cli-instance-2
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : Central US EUAP
MarketplaceSubscriptionId           : eb739d37-fe4c-4b00-cbd2-0f18663d624b
MarketplaceSubscriptionStatus       : Subscribed
Name                                : test-cli-instance-2
OfferDetailOfferId                  : lambdatest_liftr_testing
OfferDetailPlanId                   : testing
OfferDetailPlanName                 : testing_liftr
OfferDetailPublisherId              : lambdatestinc1584019832435
OfferDetailTermId                   : o73usof6rkyy
OfferDetailTermUnit                 : P1Y
PartnerPropertyLicensesSubscribed   : 3
ProvisioningState                   : Succeeded
ResourceGroupName                   : abdul-test
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 4/11/2025 11:03:53 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 4/11/2025 11:03:53 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : lambdatest.hyperexecute/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will create a new LambdaTest Resource without SSO