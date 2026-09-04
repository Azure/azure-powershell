### Example 1: List the replicas of a mongo cluster
```powershell
Get-AzDocumentDBReplica -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myReplica   westus2  Succeeded
```

List the read replicas of a source mongo cluster.
