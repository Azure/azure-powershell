### Example 1: Update a monitor resource
```powershell
<<<<<<< HEAD
Update-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
=======
PS C:\> Update-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog -Tag @{'key1'='value1'; 'key2'='value2'}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command updates a monitor resource.

### Example 2: Update a monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitor -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitor -Tag @{'key1'='value1'; 'key2'='value2'}
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command updates a monitor resource by pipeline.

