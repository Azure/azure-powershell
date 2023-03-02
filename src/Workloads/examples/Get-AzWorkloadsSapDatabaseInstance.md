### Example 1: {{ Add title here }}
```powershell
Get-AzWorkloadsSapDatabaseInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName ProvisioningState Location    Status  IPAddress DatabaseSid
---- ----------------- ----------------- --------    ------  --------- -----------
db0  DemoRGVIS         Succeeded         eastus2euap Running 10.0.0.6  XRT
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzWorkloadsSapDatabaseInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT -Name db0
```

```output
Name ResourceGroupName ProvisioningState Location    Status  IPAddress DatabaseSid
---- ----------------- ----------------- --------    ------  --------- -----------
db0  DemoRGVIS         Succeeded         eastus2euap Running 10.0.0.6  XRT
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}