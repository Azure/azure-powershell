### Example 1: Create a new Napster Organization with Single Sign-On
```powershell
New-AzNapsterOrganization -Name "napster-test3" -Location "eastus2euap" -ResourceGroupName "acctest0001" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId "09fffd7d-d000-4467-cc23-d82b97e9431d" -OfferDetailOfferId "napster_companion_api" -OfferDetailPlanId "napster_companion_api_feb_2026" -OfferDetailPlanName "Pay As You Go" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "touchcastinc1655995956899" -OfferDetailTermId "n7ja87drquhy" -PartnerPropertyApplication "dsaf" -SingleSignOnPropertyType "OpenId" -SingleSignOnPropertyState "Initial" -SingleSignOnPropertyAadDomain @("MicrosoftCustomerLed.onmicrosoft.com") -SingleSignOnPropertyUrl "https://companion-api.napsterai.dev/admin/ms-auth" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com"
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test3
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus2euap
MarketplaceSubscriptionId           : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus       : Subscribed
Name                                : napster-test3
OfferDetailOfferId                  : napster_companion_api
OfferDetailPlanId                   : napster_companion_api_feb_2026
OfferDetailPlanName                 : Pay As You Go
OfferDetailPublisherId              : touchcastinc1655995956899
OfferDetailTermId                   : n7ja87drquhy
OfferDetailTermUnit                 : P1M
PartnerPropertyApplication          : dsaf
ProvisioningState                   : Succeeded
ResourceGroupName                   : acctest0001
SingleSignOnPropertyAadDomain       : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyState           : Initial
SingleSignOnPropertyType            : OpenId
SingleSignOnPropertyUrl             : https://companion-api.napsterai.dev/admin/ms-auth
SystemDataCreatedAt                 : 5/3/2025 11:18:50 PM
SystemDataCreatedBy                 : yashikajain@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 5/3/2025 11:18:50 PM
SystemDataLastModifiedBy            : yashikajain@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : napster.companionapi/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : yashikajain@microsoft.com
```

This command creates a new Napster Companion API organization with Single Sign-On configured via OpenId, linked to the specified Azure Marketplace SaaS offer.

### Example 2: Create a new Napster Organization without Single Sign-On
```powershell
New-AzNapsterOrganization -Name "napster-test-basic" -Location "eastus2euap" -ResourceGroupName "acctest0001" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId "09fffd7d-d000-4467-cc23-d82b97e9431d" -OfferDetailOfferId "napster_companion_api" -OfferDetailPlanId "napster_companion_api_feb_2026" -OfferDetailPlanName "Pay As You Go" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "touchcastinc1655995956899" -OfferDetailTermId "n7ja87drquhy" -PartnerPropertyApplication "dsaf" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com"
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test-basic
Location                            : eastus2euap
MarketplaceSubscriptionId           : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus       : Subscribed
Name                                : napster-test-basic
OfferDetailOfferId                  : napster_companion_api
OfferDetailPlanId                   : napster_companion_api_feb_2026
OfferDetailPlanName                 : Pay As You Go
OfferDetailPublisherId              : touchcastinc1655995956899
OfferDetailTermId                   : n7ja87drquhy
OfferDetailTermUnit                 : P1M
PartnerPropertyApplication          : dsaf
ProvisioningState                   : Succeeded
ResourceGroupName                   : acctest0001
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : napster.companionapi/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserUpn                             : yashikajain@microsoft.com
```

This command creates a new Napster Companion API organization without Single Sign-On configuration.

