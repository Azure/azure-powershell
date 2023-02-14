### Example 1: Remove a SAP monitor by name
```powershell
<<<<<<< HEAD
Remove-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t02
=======
PS C:\> Remove-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t02

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a SAP monitor by name.

### Example 2: Remove a SAP monitor by object
```powershell
<<<<<<< HEAD
$sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t01
Remove-AzSapMonitor -InputObject $sap
=======
PS C:\> $sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t01
PS C:\> Remove-AzSapMonitor -InputObject $sap

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a SAP monitor by object.

