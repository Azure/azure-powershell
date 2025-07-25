### Example 1: Get a list of cluster upgrade history.
```powershell
$resourceGroupName = "resourceGroupName"
$clusterPoolName = "clusterPoolName"
$clusterName = "clusterName"
Get-AzHdInsightOnAksClusterUpgradeHistory -ResourceGroupName $resourceGroupName -ClusterPoolName $clusterPoolName -ClusterName $clusterName
```

```output
Name                                   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                                   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
05_11_2024_06_41_26_AM-AKSPatchUpgrade
05_08_2024_08_48_28_AM-AKSPatchUpgrade
```

Get a list of cluster upgrade history.
