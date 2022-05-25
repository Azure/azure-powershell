### Example 1: Get the Azure Lighthouse Marketplace registration definition offer details
```powershell
Get-AzManagedServicesMarketplaceDefinition -MarketplaceIdentifier marketplace_test.managed_offer.managed_plan1.1.0.1 | Format-List Id, PlanProduct, PlanPublisher, PlanName, PlanVersion
```

```output
Id            : /providers/Microsoft.ManagedServices/marketplaceRegistrationDefinitions/marketplace_test.managed_offer.managed_plan1.1.0.1
PlanProduct   : managed_offer
PlanPublisher : marketplace_test
PlanName      : managed_plan1
PlanVersion   : 1.0.1
```

Gets the Azure Lighthouse Marketplace registration definition offer details.