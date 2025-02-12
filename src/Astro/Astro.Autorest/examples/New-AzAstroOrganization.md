### Example 1: Create a Astro organization
```powershell
New-AzAstroOrganization -Name UT.7.test -ResourceGroupName astro-user -Location eastus -MarketplaceSubscriptionId 11111111-2222-3333-4444-123456789101 -OfferDetailOfferId astro -OfferDetailPlanId astro-paygo -OfferDetailPublisherId astronomer1 -OfferDetailPlanName 'Monthly Pay-As-You-Go' -OfferDetailTermId abcdefghijkl -OfferDetailTermUnit Monthly -UserEmailAddress example@microsoft.com -UserFirstName user -UserLastName test -UserUpn example@microsoft.com -PartnerOrganizationPropertyWorkspaceName aaa -PartnerOrganizationPropertyOrganizationName bbb -SingleSignOnPropertyAadDomain MicrosoftCustomerLed.onmicrosoft.com
```

```output
Id                                          : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/astro-user/providers/Astronomer.Astro/organizations/UT.2.test
IdentityPrincipalId                         : 
IdentityTenantId                            : 
IdentityType                                : 
IdentityUserAssignedIdentity                : {
                                              }
Location                                    : eastus
MarketplaceSubscriptionId                   : 11111111-2222-3333-4444-123456789102
MarketplaceSubscriptionStatus               : Subscribed
Name                                        : UT.7.test
OfferDetailOfferId                          : astro
OfferDetailPlanId                           : astro-paygo
OfferDetailPlanName                         : Monthly Pay-As-You-Go 
OfferDetailPublisherId                      : astronomer1
OfferDetailTermId                           : abcdefghijkl
OfferDetailTermUnit                         : Monthly
PartnerOrganizationPropertyOrganizationId   : 1111122222333334444455555
PartnerOrganizationPropertyOrganizationName : bbb
PartnerOrganizationPropertyWorkspaceId      : 1111122222333334444455555
PartnerOrganizationPropertyWorkspaceName    : aaa
ProvisioningState                           : Succeeded
ResourceGroupName                           : astro-user
SingleSignOnPropertyAadDomain               : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyEnterpriseAppId         : 
SingleSignOnPropertyProvisioningState       : 
SingleSignOnPropertySingleSignOnState       : Enable
SingleSignOnPropertySingleSignOnUrl         : https://account.astronomer.io/login?connection=waad-liftr-1111122222333334444455555&org-id=1111122222333334444455555
SystemDataCreatedAt                         : 8/5/2024 9:37:41 AM
SystemDataCreatedBy                         : example@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 8/5/2024 9:40:46 AM
SystemDataLastModifiedBy                    : 11111111-2222-3333-4444-123456789103
SystemDataLastModifiedByType                : Application
Tag                                         : {
                                              }
Type                                        : astronomer.astro/organizations
UserEmailAddress                            : example@microsoft.com
UserFirstName                               : user
UserLastName                                : test
UserPhoneNumber                             : 11111111111
UserUpn                                     : example@microsoft.com
```

This command creates a Astro organization.

