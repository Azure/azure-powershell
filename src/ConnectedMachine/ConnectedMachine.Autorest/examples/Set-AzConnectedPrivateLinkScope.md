### Example 1: Set a private link scope in a subscription by name
```powershell
Set-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName -PublicNetworkAccess "Disabled" -Tag $tags -Location $location
```

```output
Name         Location    PublicNetworkAccess ProvisioningState
----         --------    ------------------- -----------------
name         eastus2euap Disabled            Succeeded         
```

Updates the PublicNetworkAccess to "Disable" and tags to $tags
