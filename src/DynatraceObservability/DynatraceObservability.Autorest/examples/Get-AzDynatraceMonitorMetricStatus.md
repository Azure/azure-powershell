### Example 1: get metric status
```powershell
Get-AzDynatraceMonitorMetricStatus -MonitorName dyob4hzw1d -ResourceGroupName dyobrg1lpgdr
```

```output
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.Compute/virtualMachines/vmName
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.Network/networkInterfaces/interfaceName
```

This command gets the Azure resource ids for which Dynatrace is polling metrics from given Azure monitor resource