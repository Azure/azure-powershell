### Example 1: Get all SAP monitors under a subscription
```powershell
<<<<<<< HEAD
Get-AzSapMonitor
```

```output
=======
PS C:\> Get-AzSapMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Type
-------- ----              ----
westus2  ps-sapmonitor-t01 Microsoft.HanaOnAzure/sapMonitors
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets SAP monitors under a subscription.

### Example 2: Get a SAP monitor by name
```powershell
<<<<<<< HEAD
Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01
```

```output
=======
PS C:\> Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets a SAP monitor by name.

### Example 3: Get a SAP monitor by object
```powershell
<<<<<<< HEAD
$sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01
Get-AzSapMonitor -InputObject $sap
```

```output
=======
PS C:\> $sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01
PS C:\> Get-AzSapMonitor -InputObject $sap

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets a SAP monitor by object.

### Example 4: Get a SAP monitor by pipeline
```powershell
<<<<<<< HEAD
@{Id='/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.HanaOnAzure/sapMonitors/ps-spamonitor-t01'} | Get-AzSapMonitor
```

```output
=======
PS C:\> @{Id='/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.HanaOnAzure/sapMonitors/ps-spamonitor-t01'} | Get-AzSapMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
```

This command gets a SAP monitor by pipeline.



