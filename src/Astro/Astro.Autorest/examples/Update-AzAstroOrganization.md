### Example 1: Update a Organization
```powershell
Update-AzAstroOrganization -Name UT.7.test -ResourceGroupName astro-user -UserUpn example@microsoft.com -PartnerOrganizationPropertyOrganizationId cccccccc -PartnerOrganizationPropertyWorkspaceId dddddddd -PartnerOrganizationPropertyWorkspaceName eeeeeee -PartnerOrganizationPropertyOrganizationName kkkkkkkkkkkk -SingleSignOnPropertyEnterpriseAppId llllllll -SingleSignOnPropertyAadDomain MicrosoftCustomerLed.onmicrosoft.com
```

```output
Id                                          : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/astro-user/providers/Astronomer.Astro/organizations/UT.7.test
IdentityPrincipalId                         : 
IdentityTenantId                            : 
IdentityType                                : None
IdentityUserAssignedIdentity                : {
                                              }
Location                                    : eastus
MarketplaceSubscriptionId                   : ffffffffffff
MarketplaceSubscriptionStatus               : Unsubscribed
Name                                        : UT.7.test
OfferDetailOfferId                          : gggggggggggg
OfferDetailPlanId                           : hhhhhhhhhhhhh
OfferDetailPlanName                         : jjj
OfferDetailPublisherId                      : iiiiiiiiiiii
OfferDetailTermId                           : aaaaa
OfferDetailTermUnit                         : Monthly
PartnerOrganizationPropertyOrganizationId   : cccccccc
PartnerOrganizationPropertyOrganizationName : kkkkkkkkkkkk
PartnerOrganizationPropertyWorkspaceId      : dddddddd
PartnerOrganizationPropertyWorkspaceName    : eeeeeee
ProvisioningState                           : Succeeded
ResourceGroupName                           : astro-user
SingleSignOnPropertyAadDomain               : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyEnterpriseAppId         : llllllll
SingleSignOnPropertyProvisioningState       : 
SingleSignOnPropertySingleSignOnState       : Enable
SingleSignOnPropertySingleSignOnUrl         : https://account.astronomer.io/login?connection=waad-liftr-1111122222333334444455555&org-id=1111122222333334444455555
SystemDataCreatedAt                         : 8/5/2024 9:37:41 AM
SystemDataCreatedBy                         : example@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 8/5/2024 9:40:46 AM
SystemDataLastModifiedBy                    : example@microsoft.com
SystemDataLastModifiedByType                : User
Tag                                         : {
                                              }
Type                                        : astronomer.astro/organizations
UserEmailAddress                            : example@microsoft.com
UserFirstName                               : user
UserLastName                                : test
UserPhoneNumber                             : 11111111111
UserUpn                                     : example@microsoft.com
```

This command updates a Organization.

