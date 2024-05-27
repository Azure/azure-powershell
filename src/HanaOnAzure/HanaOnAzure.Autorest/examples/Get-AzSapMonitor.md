### Example 1: Get all SAP monitors under a subscription
```powershell
Get-AzSapMonitor
```

```output
Location Name              Type
-------- ----              ----
westus2  ps-sapmonitor-t01 Microsoft.HanaOnAzure/sapMonitors
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets SAP monitors under a subscription.

### Example 2: Get a SAP monitor by name
```powershell
Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01
```

```output
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets a SAP monitor by name.

### Example 3: Get a SAP monitor by object
```powershell
$sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01
Get-AzSapMonitor -InputObject $sap
```

```output
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets a SAP monitor by object.

### Example 4: Get a SAP monitor by pipeline
```powershell
@{Id='/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.HanaOnAzure/sapMonitors/ps-spamonitor-t01'} | Get-AzSapMonitor
```

```output
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets a SAP monitor by pipeline.



