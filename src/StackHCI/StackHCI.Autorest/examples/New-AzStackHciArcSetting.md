### Example 1:
```powershell
New-AzStackHciArcSetting -ResourceGroupName "test-rg" -ClusterName "myCluster"
```

```output
Resource Group AggregateState
-------------- --------------
test-rg        Connected
```

This command creates arcSetting for a HCI cluster. The only arcSetting name allowed is "default" and that is provided by default. 
