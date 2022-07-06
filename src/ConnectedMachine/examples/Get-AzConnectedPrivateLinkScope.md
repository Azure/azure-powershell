### Example 1: List all private link scopes in a resource group
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName
```

```output
Name              Location    PublicNetworkAccess ProvisioningState
----              --------    ------------------- ----------------- 
name1 		eastus2euap Enabled             Succeeded 	 
name2		eastus2euap Disabled            Succeeded        
name3		eastus2euap Enabled             Succeeded         
```
Lists all private link scopes in a specified resource group

### Example 2: Get a private link scope in a resource group by name
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName
```

```output
Name         Location    PublicNetworkAccess ProvisioningState
----         --------    ------------------- -----------------
name1	     eastus2euap Enabled             Succeeded         
```
Gets a private link scope in a specified resource group by name