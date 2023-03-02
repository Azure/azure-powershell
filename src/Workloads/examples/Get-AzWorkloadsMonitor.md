### Example 1: {{ Add title here }}
```powershell
Get-AzWorkloadsMonitor
```

```output
Name        ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----        ----------------- ------------------------------------- --------    -----------------
ad-ams-inst ad-ams-rg         ad-ams-mrg                            eastus2euap Deleting
ad-ams-tp   ad-ams-rg         sapmonrg-q2nti3                       eastus2euap Succeeded
ad-ams      ad-ams-rg         sapmonrg-u2mtiw                       eastus      Succeeded
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg
```

```output
Name        ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----        ----------------- ------------------------------------- --------    -----------------
ad-ams-inst ad-ams-rg         ad-ams-mrg                            eastus2euap Deleting
ad-ams-tp   ad-ams-rg         sapmonrg-q2nti3                       eastus2euap Succeeded
ad-ams      ad-ams-rg         sapmonrg-u2mtiw                       eastus      Succeeded
```

{{ Add description here }}


### Example 3: {{ Add title here }}
```powershell
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg -Name ad-ams
```

```output
Name   ResourceGroupName ManagedResourceGroupConfigurationName Location ProvisioningState
----   ----------------- ------------------------------------- -------- -----------------
ad-ams ad-ams-rg         sapmonrg-u2mtiw                       eastus   Succeeded
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}