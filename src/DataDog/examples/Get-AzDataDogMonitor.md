### Example 1: List all monitor resources under a subscription
```powershell
PS C:\> Get-AzDataDogMonitor

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command lists all monitor resources under a subscription.

### Example 2: List monitor resources under a resource group
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command lists all monitor resources under a resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name datadog

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command gets the properties of a specific monitor resource.

### Example 4: Get the properties of a specific monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name datadog | Get-AzDataDogMonitor

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command gets the properties of a specific monitor resource by pipeline.
