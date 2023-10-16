### Example 1: Remove an Azure HDInsight gen2 cluster pool
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
Remove-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName
```

Remove an Azure HDInsight gen2 cluster pool.
