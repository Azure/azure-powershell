### Example 1: Create Neon Organization
```powershell
New-AzNeonPostgresOrganization -Name "almasTestNeonPS6" -ResourceGroupName "NeonDemoRG" -Location "centraluseuap" -SubscriptionId "5d9a6cc3-4e60-4b41-be79-d28f0a01074e" -CompanyDetailBusinessPhone "+1234567890" -CompanyDetailCompanyName "DemoCompany" -CompanyDetailCountry "USA" -CompanyDetailDomain "demo.com" -CompanyDetailNumberOfEmployee 500 -CompanyDetailOfficeAddress "1234 Azure Ave" -MarketplaceDetailSubscriptionId "yxmkfivp" -MarketplaceDetailSubscriptionStatus "PendingFulfillmentStart" -OfferDetailOfferId "neon_test" -OfferDetailPlanId "neon_test_1" -OfferDetailPlanName "Neon Serverless Postgres - Free (Test_Liftr)" -OfferDetailPublisherId "neon1722366567200" -OfferDetailTermId "gmz7xq9ge3py" -OfferDetailTermUnit "P1M" -PartnerOrganizationPropertyOrganizationId "org12345" -PartnerOrganizationPropertyOrganizationName "PartnerOrg6" -SingleSignOnPropertyAadDomain @("partnerorg.com") -SingleSignOnPropertyEnterpriseAppId "app12345" -SingleSignOnPropertySingleSignOnState "Enable" -SingleSignOnPropertySingleSignOnUrl "https://sso.partnerorg.com" -UserDetailEmailAddress "khanalmas@microsoft.com" -UserDetailFirstName "Almas" -UserDetailLastName "Khan" -UserDetailPhoneNumber "+1234567890" -UserDetailUpn "khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com"
```

```output
CompanyDetailBusinessPhone                  : +1234567890
CompanyDetailCompanyName                    : DemoCompany
CompanyDetailCountry                        : USA
CompanyDetailDomain                         : demo.com
CompanyDetailNumberOfEmployee               : 500
CompanyDetailOfficeAddress                  : 1234 Azure Ave
Id                                          : /subscriptions/5d9a6cc3-4e60-4b41-be79-d28f0a01074e/resourceGroups/NeonDe
                                              moRG/providers/Neon.Postgres/organizations/almasTestNeonPS6
Location                                    : centraluseuap
MarketplaceDetailSubscriptionId             : cefab913-6de7-4a3b-d369-eae74ea379dc
MarketplaceDetailSubscriptionStatus         : Subscribed
Name                                        : almasTestNeonPS6
OfferDetailOfferId                          : neon_test
OfferDetailPlanId                           : neon_test_1
OfferDetailPlanName                         : Neon Serverless Postgres - Free (Test_Liftr)
OfferDetailPublisherId                      : neon1722366567200
OfferDetailTermId                           : gmz7xq9ge3py
OfferDetailTermUnit                         : P1M
PartnerOrganizationPropertyOrganizationId   : org-sweet-wind-32755039
PartnerOrganizationPropertyOrganizationName : PartnerOrg6
ProvisioningState                           : Succeeded
ResourceGroupName                           : NeonDemoRG
SingleSignOnPropertyAadDomain               : {partnerorg.com}
SingleSignOnPropertyEnterpriseAppId         : app12345
SingleSignOnPropertySingleSignOnState       : Enable
SingleSignOnPropertySingleSignOnUrl         : https://console.neon.tech/azure/sso/org-sweet-wind-32755039
SystemDataCreatedAt                         : 06-Nov-24 4:37:35 AM
SystemDataCreatedBy                         : khanalmas@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 06-Nov-24 4:38:37 AM
SystemDataLastModifiedBy                    : b41fa140-8cb4-43b1-a086-717c2f41909e
SystemDataLastModifiedByType                : Application
Tag                                         : {
                                              }
Type                                        : neon.postgres/organizations
UserDetailEmailAddress                      : khanalmas@microsoft.com
UserDetailFirstName                         : Almas
UserDetailLastName                          : Khan
UserDetailPhoneNumber                       : +1234567890
UserDetailUpn                               : khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com
```

This command will create a Neon Resource
