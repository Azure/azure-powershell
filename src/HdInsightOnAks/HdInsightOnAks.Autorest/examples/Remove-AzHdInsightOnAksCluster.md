### Example 1: Remove an Azure HDInsight cluster
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
$clusterName = "yourcluster"
Remove-AzHdInsightOnAksCluster `
    -Name $clusterName `
    -PoolName $clusterpoolName `
    -ResourceGroupName $clusterResourceGroupName `
```

```output

```

Remove an Azure HDInsight cluster.
