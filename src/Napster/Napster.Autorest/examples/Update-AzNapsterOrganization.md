### Example 1: Update tags on an existing Napster Organization
```powershell
Update-AzNapsterOrganization -Name "napster-test1" -ResourceGroupName "acctest0001" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -Tag @{"TestName1" = "TestValue1"}
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test1
IdentityType                        : None
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus2euap
MarketplaceSubscriptionId           : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus       : Subscribed
Name                                : napster-test1
OfferDetailOfferId                  : napster_companion_api
OfferDetailPlanId                   : napster_companion_api_feb_2026
OfferDetailPlanName                 : Pay As You Go
OfferDetailPublisherId              : touchcastinc1655995956899
OfferDetailTermId                   : n7ja87drquhy
OfferDetailTermUnit                 : P1M
PartnerPropertyApplication          : dsaf
ProvisioningState                   : Succeeded
ResourceGroupName                   : acctest0001
SystemDataCreatedAt                 : 5/1/2025 8:14:20 PM
SystemDataCreatedBy                 : yashikajain@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 5/1/2025 11:34:30 PM
SystemDataLastModifiedBy            : yashikajain@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName1": "TestValue1"
                                      }
Type                                : napster.companionapi/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserUpn                             : yashikajain@microsoft.com
```

This command updates the tags of an existing Napster organization.

