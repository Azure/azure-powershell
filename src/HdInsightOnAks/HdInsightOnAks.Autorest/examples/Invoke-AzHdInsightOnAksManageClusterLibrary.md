### Example 1: Install maven library to cluster.
```powershell
$libObj=New-AzHdInsightOnAksClusterMavenLibraryObject -GroupId "com.azure.resourcemanager" -Name "azure-resourcemanager-hdinsight-containers" -Version "1.0.0-beta.2" -Remark "Maven lib"
Invoke-AzHdInsightOnAksManageClusterLibrary -ResourceGroupName hilocli-test -ClusterPoolName hilopoolwus3 -ClusterName cluster2024521155147  -Action Install -Library $libObj -AsJob
```

```output
Id     Name            PSJobTypeName   State         HasMoreData     Location             Command
--     ----            -------------   -----         -----------     --------             -------
1      Invoke-AzHdIns…                 Running       True            localhost            Invoke-AzHdInsightOnAksM…
```

Install azure-resourcemanager-hdinsight-containers library to the cluster.

### Example 2: Uninstall pypi library to cluster.
```powershell
$libObj=New-AzHdInsightOnAksClusterPyPiLibraryObject -Name pandas -Version 2.2.2 
Invoke-AzHdInsightOnAksManageClusterLibrary -ResourceGroupName hilocli-test -ClusterPoolName hilopoolwus3 -ClusterName cluster2024521155147  -Action Uninstall -Library $libObj -AsJob
```

```output
Id     Name            PSJobTypeName   State         HasMoreData     Location             Command
--     ----            -------------   -----         -----------     --------             -------
1      Invoke-AzHdIns…                 Running       True            localhost            Invoke-AzHdInsightOnAksM…
```

Uninstall the pandas library on the cluster.

