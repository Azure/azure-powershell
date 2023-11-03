### Example 1: Add a new private link scope in a subscription
```powershell
New-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName -PublicNetworkAccess "Enabled" -Location $location
```

```output
Name        Location    PublicNetworkAccess ProvisioningState 
----        --------    ------------------- ----------------- 
name1      eastus2euap Enabled             Succeeded         

```

PublicNetworkAccess should be either "Enabled" or "Disabled"
