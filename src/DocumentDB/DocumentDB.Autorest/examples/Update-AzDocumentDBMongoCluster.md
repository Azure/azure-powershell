### Example 1: Update the tags of a mongo cluster
```powershell
Update-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup -Tag @{ env = 'test'; owner = 'cli' }
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Update a mongo cluster to apply resource tags.

### Example 2: Enable the Mongo data API on a mongo cluster
```powershell
Update-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup -DataApiMode Enabled
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Enable the Mongo data API. The data API can only be toggled once the cluster is
provisioned and while public network access is enabled.
