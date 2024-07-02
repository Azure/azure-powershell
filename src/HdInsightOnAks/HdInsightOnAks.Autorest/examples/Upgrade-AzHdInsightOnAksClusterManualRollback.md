### Example 1: Roll back the upgrade of a cluster
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "cluster"
Upgrade-AzHdInsightOnAksClusterManualRollback -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -UpgradeHistory /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/weidong-devrp/providers/Microsoft.HDInsight/clusterpools/weidongbugbash57/clusters/cluster202458152055/upgradeHistories/05_11_2024_06_41_26_AM-AKSPatchUpgrade
```

Roll back the upgrade of a cluster

