### Example 1: Get the latest SaaS linked to a Napster Organization
```powershell
Invoke-AzNapsterLatestOrganizationLinkedSaaS -Organizationname napster-test1 -ResourceGroupName acctest0001 -SubscriptionId 61641157-140c-4b97-b365-30ff76d9f82e
```

```output
Id                            : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa
MarketplaceSubscriptionId     : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus : Subscribed
OfferDetailOfferId            : napster_companion_api
OfferDetailPlanId             : napster_companion_api_feb_2026
OfferDetailPlanName           : Pay As You Go
OfferDetailPublisherId        : touchcastinc1655995956899
OfferDetailTermId             : n7ja87drquhy
OfferDetailTermUnit           : P1M
SaaSResourceId                : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa
```

This command returns the most recent SaaS resource linked to the specified Napster organization.

