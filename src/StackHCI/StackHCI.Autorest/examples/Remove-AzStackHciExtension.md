### Example 1: 
```powershell
Remove-AzStackHciExtension -ResourceGroupName test-rg -ClusterName myCluster -ArcSettingName "default" -Name MicrosoftMonitoringAgent
```

Removes a particular extension under arcSettings of a cluster.

### Example 2: 
```powershell
Get-AzStackHciExtension -ResourceGroupName test-rg -ClusterName myCluster -ArcSettingName "default" | Remove-AzStackHciExtension
```

Another way to remove all of the extensions under acrSettings of a cluster. 

