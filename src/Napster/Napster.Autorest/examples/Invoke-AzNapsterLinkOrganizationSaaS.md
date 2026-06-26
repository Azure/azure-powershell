### Example 1: Link a new SaaS to a Napster Organization
```powershell
Invoke-AzNapsterLinkOrganizationSaaS -Organizationname napster-test1 -ResourceGroupName acctest0001 -SubscriptionId 61641157-140c-4b97-b365-30ff76d9f82e -SaaSResourceId "/subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa"
```

```output
Id                            : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test1
MarketplaceSubscriptionId     : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus : Subscribed
Name                          : napster-test1
ProvisioningState             : Succeeded
ResourceGroupName             : acctest0001
SaaSResourceId                : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa
Type                          : napster.companionapi/organizations
```

This command links a new SaaS resource to the specified Napster organization.

