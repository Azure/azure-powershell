### Example 1: List a cluster pool available upgrade.
```powershell
Get-AzHdInsightOnAksClusterPoolAvailableUpgrade -ResourceGroupName PStestGroup -ClusterPoolName hilo-pool
```

```output
Name            SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----            ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
AKSPatchUpgrade
NodeOsUpgrade
```

List a cluster pool available upgrade.
