### Example 1: Update the tags of a private link scope
```powershell
$scope = Update-AzConnectedPrivateLinkScopeTag -ResourceGroupName $resourceGroupName -ScopeName $scopeName -Tag $tags2

Name         Location    PublicNetworkAccess ProvisioningState
----         --------    ------------------- -----------------
name         eastus2euap Disabled            Succeeded

$scope.Tag
```

Update the tags of a private link scope