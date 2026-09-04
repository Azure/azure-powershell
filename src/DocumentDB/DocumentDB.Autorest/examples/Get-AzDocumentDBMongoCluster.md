### Example 1: Get a mongo cluster
```powershell
Get-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Get a single mongo cluster by name.

### Example 2: List the mongo clusters in a resource group
```powershell
Get-AzDocumentDBMongoCluster -ResourceGroupName myResourceGroup
```

```output
Name         Location ProvisioningState
----         -------- -----------------
myCluster    eastus2  Succeeded
otherCluster westus2  Succeeded
```

List all mongo clusters in a resource group.

### Example 3: List the mongo clusters in a subscription
```powershell
Get-AzDocumentDBMongoCluster
```

```output
Name         Location ProvisioningState
----         -------- -----------------
myCluster    eastus2  Succeeded
otherCluster westus2  Succeeded
```

List all mongo clusters in the current subscription.
