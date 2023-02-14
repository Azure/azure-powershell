### Example 1: Remove instance of SAP monitor by name
```powershell
<<<<<<< HEAD
Remove-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t02
=======
PS C:\> Remove-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t02

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes instance of SAP monitor by name.

### Example 2: Remove instance of SAP monitor by object
```powershell
<<<<<<< HEAD
$sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t01
Remove-AzSapMonitorProviderInstance -InputObject $sapIns
=======
PS C:\> $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t01
PS C:\> Remove-AzSapMonitorProviderInstance -InputObject $sapIns

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes instance of SAP monitor by object.

