### Example 1: Update a Neon Resource
```powershell
Update-AzNeonPostgresOrganization -Name "almasTestNeonPS8" -ResourceGroupName "NeonDemoRG" -SubscriptionId "5d9a6cc3-4e60-4b41-be79-d28f0a01074e" `
-CompanyDetailBusinessPhone "+1234567890" `
-CompanyDetailCompanyName "DemoCompany" `
-CompanyDetailCountry "USA" `
-CompanyDetailDomain "demo.com" `
-CompanyDetailNumberOfEmployee 500 `
-CompanyDetailOfficeAddress "1234 Azure Ave" `
-PartnerOrganizationPropertyOrganizationId "org12345" `
-PartnerOrganizationPropertyOrganizationName "PartnerOrg8" `
-SingleSignOnPropertyAadDomain @("partnerorg.com") `
-SingleSignOnPropertyEnterpriseAppId "app12345" `
-SingleSignOnPropertySingleSignOnState "Enable" `
-SingleSignOnPropertySingleSignOnUrl "https://sso.partnerorg.com" `
-Tag @{environment="production"} `
-UserDetailEmailAddress "khanalmas@microsoft.com" `
-UserDetailFirstName "Almas" `
-UserDetailLastName "Khan" `
-UserDetailPhoneNumber "+1234567890" `
-UserDetailUpn "khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com"

```

```output

CompanyDetailBusinessPhone                  : +1234567890
CompanyDetailCompanyName                    : DemoCompany
CompanyDetailCountry                        : USA
CompanyDetailDomain                         : demo.com
CompanyDetailNumberOfEmployee               : 500
CompanyDetailOfficeAddress                  : 1234 Azure Ave
Id                                          : /subscriptions/5d9a6cc3-4e60-4b41-be79-d28f0a01074e/resourceGroups/NeonDe
                                              moRG/providers/Neon.Postgres/organizations/almasTestNeonPS8
Location                                    : centraluseuap
MarketplaceDetailSubscriptionId             : 44e2e61d-8456-4c6a-dd0a-acc4edaa729b
MarketplaceDetailSubscriptionStatus         : Subscribed
Name                                        : almasTestNeonPS8
OfferDetailOfferId                          : neon_test
OfferDetailPlanId                           : neon_test_1
OfferDetailPlanName                         : Neon Serverless Postgres - Free (Test_Liftr)
OfferDetailPublisherId                      : neon1722366567200
OfferDetailTermId                           : gmz7xq9ge3py
OfferDetailTermUnit                         : P1M
PartnerOrganizationPropertyOrganizationId   : org-tiny-silence-85146383
PartnerOrganizationPropertyOrganizationName : PartnerOrg8
ProvisioningState                           : Succeeded
ResourceGroupName                           : NeonDemoRG
SingleSignOnPropertyAadDomain               : {partnerorg.com}
SingleSignOnPropertyEnterpriseAppId         : app12345
SingleSignOnPropertySingleSignOnState       : Enable
SingleSignOnPropertySingleSignOnUrl         : https://console.neon.tech/azure/sso/org-tiny-silence-85146383
SystemDataCreatedAt                         : 06-Nov-24 4:49:42 AM
SystemDataCreatedBy                         : khanalmas@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 06-Nov-24 4:53:15 AM
SystemDataLastModifiedBy                    : khanalmas@microsoft.com
SystemDataLastModifiedByType                : User
Tag                                         : {
                                                "environment": "production"
                                              }
Type                                        : neon.postgres/organizations
UserDetailEmailAddress                      : khanalmas@microsoft.com
UserDetailFirstName                         : Almas
UserDetailLastName                          : Khan
UserDetailPhoneNumber                       : +1234567890
UserDetailUpn                               : khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com

```

This command will update a Neon Postgres organization resource
