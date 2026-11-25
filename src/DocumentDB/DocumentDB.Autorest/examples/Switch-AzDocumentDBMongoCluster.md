### Example 1: Perform a planned switchover to a read replica
```powershell
Switch-AzDocumentDBMongoCluster -Name myReplica -ResourceGroupName myResourceGroup `
    -SourceCluster myCluster -Mode Switchover -PromoteOption Planned -Confirm
```

Promote a read replica to the primary role using `Planned`, which waits for the replica
to catch up with the primary before promotion to avoid data loss. `Switchover` changes
the original primary to a replica and maintains the replication link.

The required `-SourceCluster` value is checked against the replica's actual source;
promotion fails if they do not match. A source name uses the target subscription and
resource group. Use the source cluster's full resource ID if either is different.
`-Confirm` prompts for confirmation before promotion.

### Example 2: Force a switchover during disaster recovery
```powershell
Switch-AzDocumentDBMongoCluster -Name myReplica -ResourceGroupName myResourceGroup `
    -SourceCluster myCluster -Mode Switchover -PromoteOption Forced -Confirm
```

Force the replica to become the primary without waiting for it to catch up. Forced
promotion can lose data and should only be used for disaster recovery when that risk
is acceptable. The same source-cluster validation applies.
