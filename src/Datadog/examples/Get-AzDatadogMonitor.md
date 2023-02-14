### Example 1: List all monitor resources under a subscription
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor
```

```output
=======
PS C:\> Get-AzDatadogMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command lists all monitor resources under a subscription.

### Example 2: List monitor resources under a resource group
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog
```

```output
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command lists all monitor resources under a resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog
```

```output
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command gets the properties of a specific monitor resource.

### Example 4: Get the properties of a specific monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitor
```

```output
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command gets the properties of a specific monitor resource by pipeline.
