### Example 1: List all monitor resources under a subscription
```powershell
PS C:\> Get-AzDatadogMonitor

Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command lists all monitor resources under a subscription.

### Example 2: List monitor resources under a resource group
```powershell
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog

Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command lists all monitor resources under a resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog

Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command gets the properties of a specific monitor resource.

### Example 4: Get the properties of a specific monitor resource by pipeline
```powershell
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitor

Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command gets the properties of a specific monitor resource by pipeline.
