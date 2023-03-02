### Example 1: {{ Add title here }}
```powershell
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT -Name app0
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

{{ Add description here }}

