### Example 1: List all azure resources associated with given identity.
```powershell
Get-AzUserAssignedIdentityAssociatedResource -ResourceGroupName azure-rg-test -Name uai-pwsh01
```

```output
Name             ResourceGroup     SubscriptionDisplayName               SubscriptionId                       ResourceType
----             -------------     -----------------------               --------------                       ------------
appServicej6ocml identity-xcsbyfid Visual Studio Enterprise Subscription 0336439f-0e9d-44ec-975e-62accb9b3901 microsoft.web/sites
default          test-resources    Visual Studio Enterprise Subscription 0336439f-0e9d-44ec-975e-62accb9b3901 microsoft.compute/virtualmachines
```

This command lists all azure resources associated with given identity.

### Example 2: List azure resources associated with given identity with OData expression that allows to filter by: name, type, resourceGroup, subscriptionId, subscriptionDisplayName
```powershell
Get-AzUserAssignedIdentityAssociatedResource -ResourceGroupName azure-rg-test -Name uai-pwsh01 `
    -Filter "type eq 'microsoft.compute/virtualmachines' and contains(name, 'default')"
```

```output
Name    ResourceGroup  SubscriptionDisplayName               SubscriptionId                       ResourceType
----    -------------  -----------------------               --------------                       ------------
default test-resources Visual Studio Enterprise Subscription 0336439f-0e9d-44ec-975e-62accb9b3901 microsoft.compute/virtualmachines
```

This command lists azure resources associated with given identity with OData expression that allows to filter by: name, type, resourceGroup, subscriptionId, subscriptionDisplayName
