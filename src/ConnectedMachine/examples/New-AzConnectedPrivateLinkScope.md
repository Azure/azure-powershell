### Example 1: Add a new private link scope in a subscription
```powershell
PS C:\> New-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName -PublicNetworkAccess "Enabled" -Location $location

Name        Location    PublicNetworkAccess ProvisioningState Tag
----        --------    ------------------- ----------------- ---
name1      eastus2euap Enabled             Succeeded         Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.PrivateLinkScopesReso…

```

PublicNetworkAccess should be either "Enabled" or "Disabled"

