### Example 1: Update an existing Organization
```powershell
Update-AzLambdaTestOrganization -Name "test-cli-instance-1" -ResourceGroupName "abdul-test" -Tag @{"TestName1" = "TestValue1"}
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/abdul-test/providers/lambdatest.hyperexecute/organizations/test-cli-instance-1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        : None
IdentityUserAssignedIdentity        : {
                                      }
Location                            : Central US EUAP
MarketplaceSubscriptionId           : 87f5f36c-5cb3-4f1b-c9ea-f54f594f8b2c
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test-cli-instance-1
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
SingleSignOnPropertyState           : Initial
SingleSignOnPropertyType            : Saml
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 4/11/2025 8:14:20 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 4/11/2025 11:34:30 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName1": "TestValue1"
                                      }
Type                                : lambdatest.hyperexecute/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com

```

This command updates the LambdaTest organization.