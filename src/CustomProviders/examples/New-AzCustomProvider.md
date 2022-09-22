### Example 1: Create a custom provider
```powershell
New-AzCustomProvider -ResourceGroupName myRG -Name Namespace.Type -Location "West US 2" -ResourceType @{Name="CustomRoute1"; Endpoint="https://www.contoso.com/"}
```

```output
Location  Name             Type
--------  ----             ----
West US 2 Namespace.Type   Microsoft.CustomProviders/resourceproviders
```

Create a custom resource provider

### Example 2: Create a custom provider with associations
```powershell
New-AzCustomProvider -ResourceGroupName myRG -Name Namespace2.Type -Location "West US 2" -ResourceType @{Name="CustomRoute1"; Endpoint="https://www.contoso.com/"}, @{Name="Associations"; Endpoint="https://contoso.com/myService"; RoutingType="Proxy,Cache,Extension"}
```

```output
Location  Name             Type
--------  ----             ----
West US 2 Namespace2.Type   Microsoft.CustomProviders/resourceproviders
```

Create a custom provider, with a route for Custom provider associations.

