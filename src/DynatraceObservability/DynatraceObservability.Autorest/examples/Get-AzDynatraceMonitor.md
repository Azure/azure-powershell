### Example 1: List all dynatrace monitors under a subsciption
```powershell
Get-AzDynatraceMonitor
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh01 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command lists all dynatrace monitors under a subsciption.

### Example 2: List all dynatrace monitors under the resource group
```powershell
Get-AzDynatraceMonitor -ResourceGroupName dyobrg
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh01 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command lists all dynatrace monitors under the resource group

### Example 3: Get a dynatrace monitor
```powershell
Get-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh01
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh01 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command gets a dynatrace monitor.

### Example 4: Get a dynatrace monitor by pipeline
```powershell
New-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh01 -Location eastus2euap -UserFirstName 'First' -UserLastName 'Last' -UserEmailAddress 'xxxx@microsoft.com' -PlanUsageType "COMMITTED" -PlanBillingCycle "Monthly" -PlanDetail "azureportalintegration_privatepreview@TIDhjdtn7tfnxcy" -SingleSignOnAadDomain "xxxx.onmicrosoft.com" | Get-AzDynatraceMonitor
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh01 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command gets a dynatrace monitor by pipeline.