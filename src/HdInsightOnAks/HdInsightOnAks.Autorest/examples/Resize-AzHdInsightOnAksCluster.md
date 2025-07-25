### Example 1: Resize the number of working nodes in the cluster.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
$targetWorkerNodeCount = 6
$location = "west us 2"

Resize-AzHdInsightOnAksCluster `
    -ResourceGroupName $clusterResourceGroupName `
    -Location $location `
    -PoolName $clusterpoolName `
    -Name $clusterName `
    -TargetWorkerNodeCount $targetWorkerNodeCount
```

```output
ApplicationLogStdErrorEnabled               :
ApplicationLogStdOutEnabled                 :
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  :
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 :
ComputeProfileNode                          :
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
CoordinatorDebugPort                        :
CoordinatorDebugSuspend                     :
CoordinatorHighAvailabilityEnabled          :
DeploymentId                                :
FlinkProfileNumReplica                      :
HistoryServerCpu                            : 0
HistoryServerMemory                         : 0
...
```

Resize the number to 6 of working nodes in the cluster.
