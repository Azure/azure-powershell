### Example 1: Create a dynatrace monitor
```powershell
New-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh02 -Location eastus2euap -UserFirstName 'Lucas' -UserLastName 'Yao' -UserEmailAddress 'v-diya@microsoft.com' -PlanUsageType "COMMITTED" -PlanBillingCycle "Monthly" -PlanDetail "azureportalintegration_privatepreview@TIDhjdtn7tfnxcy" -SingleSignOnAadDomain "mpliftrlogz20210811outlook.onmicrosoft.com"
```

```output
Name        ProvisioningState Location    MonitoringStatus SingleSignOnPropertyAadDomain
----        ----------------- --------    ---------------- -----------------------------
dyob-pwsh02 Succeeded         eastus2euap Enabled          {mpliftrlogz20210811outlook.onmicrosoft.com}
```

This command creates a dynatrace monitor.