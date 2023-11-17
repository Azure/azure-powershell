### Example 1: Gets the status of a session cluster instance.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
Get-AzHdInsightOnAksClusterInstanceView -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName
```

```output
Name            : default
ServiceStatuses : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ServiceStatus, Microsoft.Azure.PowerSh
                  ell.Cmdlets.HdInsightOnAks.Models.ServiceStatus, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnA
                  ks.Models.ServiceStatus, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Pre
                  view.ServiceStatus}
StatusMessage   :
StatusReady     : True
StatusReason    :
```

Gets the status of a session cluster instance.
