### Example 1: Promote a read replica to a primary mongo cluster
```powershell
Invoke-AzDocumentDBPromoteMongoCluster -Name myReplica -ResourceGroupName myResourceGroup -SourceCluster myCluster -Mode Switchover
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myReplica   westus2  Succeeded
```

Promote a cross-region read replica to a standalone primary mongo cluster with a
forced switchover. The `-SourceCluster` value is validated against the replica's
actual source and the command fails if they do not match. After the switchover the
former replica settles into the `Primary` role.
