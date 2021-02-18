### Example 1: Remove a SAP monitor by name
```powershell
PS C:\> Remove-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t02

```

This command removes a SAP monitor by name.

### Example 2: Remove a SAP monitor by object
```powershell
PS C:\> $sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t01
PS C:\> Remove-AzSapMonitor -InputObject $sap

```

This command removes a SAP monitor by object.

