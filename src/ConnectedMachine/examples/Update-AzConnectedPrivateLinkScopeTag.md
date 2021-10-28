### Example 1: Update the tags of a private link scope
```powershell
PS C:\> Update-AzConnectedPrivateLinkScopeTag -ResourceGroupName $resourceGroupName -ScopeName $scopeName -Tag $tags2

Name         Location    PublicNetworkAccess ProvisioningState Tag
----         --------    ------------------- ----------------- ---
name         eastus2euap Disabled            Succeeded         Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.PrivateLinkScopesRes…

```

Update the tags of a private link scope