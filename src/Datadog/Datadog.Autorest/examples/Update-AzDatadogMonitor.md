### Example 1: Update a monitor resource
```powershell
Update-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command updates a monitor resource.

### Example 2: Update a monitor resource by pipeline
```powershell
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitor -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command updates a monitor resource by pipeline.

