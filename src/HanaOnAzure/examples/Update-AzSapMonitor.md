### Example 1: Update a SAP monitor by name
```powershell
Update-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01 -Tag @{'key'=1;'key2'=2; 'key3'=3}
```

```output
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This commands updates a SAP monitor by name.

### Example 2: Update a SAP monitor by object
```powershell
$sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t01
Update-AzSapMonitor -InputObject $sap -Tag @{'key'=1;'key2'=2; 'key3'=3}
```

```output
Location Name              Type
-------- ----              ----
westus2  ps-sapmonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This commands updates a SAP monitor by object.

