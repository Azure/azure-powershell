### Example 1: List all tag rules set for a given monitor resource
```powershell
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog

Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command lists all tag rules set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource
```powershell
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'

Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource.

### Example 3: Get a tag rule set for a given monitor resource by pipeline
```powershell
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | Get-AzDatadogTagRule

Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource by pipeline.

