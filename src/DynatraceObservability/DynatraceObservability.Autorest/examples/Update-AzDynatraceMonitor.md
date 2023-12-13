### Example 1: Update a dynatrace monitor
```powershell
Update-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh02 -Tag @{'key' = 'test'}
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh02 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command updates a dynatrace monitor.

### Example 2: Update a dynatrace monitor by pipeline
```powershell
Get-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh02 | Update-AzDynatraceMonitor -Tag @{'key' = 'test'}
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh02 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command updates a dynatrace monitor by pipeline.