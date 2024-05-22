### Example 1: Roll back the upgrade of a cluster
```powershell
Upgrade-AzHdInsightOnAksClusterManualRollback -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -UpgradeHistory /subscriptions/10e32bab-26da-4cc4-a441-52b318f824e6/resourceGroups/weidong-devrp/providers/Microsoft.HDInsight/clusterpools/weidongbugbash57/clusters/cluster202458152055/upgradeHistories/05_11_2024_06_41_26_AM-AKSPatchUpgrade
```

Roll back the upgrade of a cluster

