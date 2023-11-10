### Example 1: Start a job in the flink cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
$flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
        -JarName "JarName" -EntryClass "com.microsoft.hilo.flink.job.streaming.SleepJob" `
        -JobJarDirectory "abfs://flinkjob@hilosa.dfs.core.windows.net/jars" `
        -FlinkConfiguration @{parallelism=1}
Start-AzHdInsightOnAksClusterJob -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterJob $flinkJobProperties
```

```output
Id                           : /providers/Microsoft.HDInsight/locations/WESTUS3/operationStatuses/0d1c65ea-bd83-4e70-87
                               a1-6eac9871416a*93BE3F5F38E851939A0189D16172AE096513F606F83B4B31C7549306E4C696F3
JobType                      : FlinkJob
Name                         : 0d1c65ea-bd83-4e70-87a1-6eac9871416a*93BE3F5F38E851939A0189D16172AE096513F606F83B4B31C75
                               49306E4C696F3
Property                     : {
                                 "jobType": "FlinkJob"
                               }
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :
```

Start a job in the flink cluster.
