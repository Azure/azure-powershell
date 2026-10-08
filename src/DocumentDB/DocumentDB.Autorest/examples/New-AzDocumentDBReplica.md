### Example 1: Create a cross-region read replica of a mongo cluster
```powershell
New-AzDocumentDBReplica -Name myReplica -ResourceGroupName myResourceGroup -Location westus2 -SourceCluster myCluster
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myReplica   westus2  Succeeded
```

Create a cross-region read replica of a source mongo cluster. The replica inherits
its configuration and administrator credentials from the source, so no password is
supplied. A replica placed in a different region is created as a `GeoAsyncReplica`.
The source cluster must have the `GeoReplicas` preview feature enabled.
