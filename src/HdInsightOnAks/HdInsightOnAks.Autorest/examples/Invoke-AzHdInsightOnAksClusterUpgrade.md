### Example 1: Upgrade a cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
$hotfixObj = New-AzHdInsightOnAksClusterHotfixUpgradeObject -ComponentName Webssh -TargetBuildNumber 7 -TargetClusterVersion "1.1.1" -TargetOssVersion "0.4.2"
Invoke-AzHdInsightOnAksClusterUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterUpgradeRequest $hotfixObj
```

```output
AccessProfileEnableInternalIngress          : False
AccessProfilePrivateLinkServiceId           : 
ApplicationLogStdErrorEnabled               : 
ApplicationLogStdOutEnabled                 : 
AuthorizationProfileGroupId                 : 
AuthorizationProfileUserId                  : 
AutoscaleProfileAutoscaleType               : 
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout : 
ClusterType                                 : 
ComputeProfileNode                          : 
ConnectivityEndpointBootstrapServerEndpoint : 
ConnectivityEndpointBrokerEndpoint          : 
ConnectivityProfileSsh                      : 
CoordinatorDebugEnable                      : 
CoordinatorDebugPort                        : 
CoordinatorDebugSuspend                     : 
CoordinatorHighAvailabilityEnabled          : 
DatabaseHost                                : 
DatabaseName                                : 
DatabasePasswordSecretRef                   : 
DatabaseUsername                            : 
DeploymentId                                : 
DiskStorageDataDiskSize                     : 0
...
```

Upgrade a cluster with type HotFix.

