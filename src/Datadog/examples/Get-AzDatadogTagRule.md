### Example 1: List all tag rules set for a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog
```

```output
=======
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command lists all tag rules set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'
```

```output
=======
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource.

### Example 3: Get a tag rule set for a given monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | Get-AzDatadogTagRule
```

```output
=======
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | Get-AzDatadogTagRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource by pipeline.

