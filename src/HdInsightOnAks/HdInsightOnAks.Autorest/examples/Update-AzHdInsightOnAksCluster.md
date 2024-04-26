### Example 1: Update a cluster service config.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
$coreSiteConfigFile = New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"testvalue1"="111"}
$yarnComponentConfig = New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "hadoop-config" -File $coreSiteConfigFile
$yarnServiceConfigProfile = New-AzHdInsightOnAksClusterServiceConfigsProfileObject -ServiceName "yarn-service" -Config $yarnComponentConfig

Update-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -PoolName $clusterpoolName -Name $clusterName -ClusterProfileServiceConfigsProfile $yarnServiceConfigProfile
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Spark
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfile, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Add a key-value `"testvalue1"="111"` to the cluster config file `core-site.xml`.


### Example 2: Upgrade a cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
$hotfixObj = New-AzHdInsightOnAksClusterHotfixUpgradeObject -ComponentName Webssh -TargetBuildNumber 7 -TargetClusterVersion "1.1.1" -TargetOssVersion "0.4.2"
Update-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterUpgradeRequest $hotfixObj
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