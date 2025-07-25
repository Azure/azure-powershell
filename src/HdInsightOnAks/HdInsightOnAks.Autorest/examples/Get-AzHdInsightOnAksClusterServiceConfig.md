### Example 1: Lists the config dump of all services running in cluster.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
Get-AzHdInsightOnAksClusterServiceConfig -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName
```

```output
ComponentName : flink-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : flink-conf.yaml
Path          :
ServiceName   : flink-operator
Type          : key-value

ComponentName : flink-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : log4j-console.properties
Path          :
ServiceName   : flink-operator
Type          : key-value

ComponentName : hadoop-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : core-site.xml
Path          :
ServiceName   : flink-operator
Type          : key-value

ComponentName : flink-client-configs
Content       :
CustomKey     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesCustomKe
                ys
DefaultKey    : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceConfigListResultPropertiesDefaultK
                eys
FileName      : flink-conf.yaml
Path          :
ServiceName   : flink-operator
Type          : key-value
```

Lists the config dump of all services running in a flink cluster.
