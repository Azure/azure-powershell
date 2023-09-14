### Example 1: Update a cluster service config.
```powershell
$coreSiteConfigFile = New-AzHdInsightOnAksClusterConfigFile -FileName "core-site.xml" -Value @{"testvalue1"="111"}
$yarnComponentConfig = New-AzHdInsightAksClusterServiceConfig -ComponentName "hadoop-config" -File $coreSiteConfigFile
$yarnServiceConfigProfile = New-AzHdInsightAksClusterServiceConfigsProfile -ServiceName "yarn-service" -Config $yarnComponentConfig

Update-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Location $location -PoolName $clusterpoolName -Name $clusterName -ClusterProfileServiceConfigsProfile $yarnServiceConfigProfile
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
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.NodeProfile, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.NodeProfile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Add a key-value `"testvalue1"="111"` to the cluster config file `core-site.xml`.
