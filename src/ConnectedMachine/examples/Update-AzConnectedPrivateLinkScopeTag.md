### Example 1: Update the tags of a private link scope
```powershell
PS C:\> $scope = Update-AzConnectedPrivateLinkScopeTag -ResourceGroupName $resourceGroupName -ScopeName $scopeName -Tag $tags2
```

```output
Name         Location    PublicNetworkAccess ProvisioningState 
----         --------    ------------------- ----------------- 
name         eastus2euap Disabled            Succeeded         
```

```powershell
PS C:\> $scope.Tag
```

Update the tags of a private link scope