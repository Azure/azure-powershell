### Example 1: lsit all HDInsight clusters in a pool.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
Get-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Flink
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

List all clusters in a pool.

### Example 2: Get a HDInsight cluster
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
Get-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName -Name $clusterName
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Flink
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Get a HDInsight cluster