### Example 1: Get a job list for a cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
Get-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName
```

```output
Id                                                                                                                                                                      Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt Syste                                                                                                                                             ---- ------------------- ------------------- ----------------------- ------------------------ ----- 
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/ps-test-pool/clusters/flinkcluster/jobs/job1
```

Get a job list for a cluster.
