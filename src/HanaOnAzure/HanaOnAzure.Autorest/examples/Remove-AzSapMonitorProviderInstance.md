### Example 1: Remove instance of SAP monitor by name
```powershell
Remove-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t02
```

This command removes instance of SAP monitor by name.

### Example 2: Remove instance of SAP monitor by object
```powershell
$sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t01
Remove-AzSapMonitorProviderInstance -InputObject $sapIns
```

This command removes instance of SAP monitor by object.

