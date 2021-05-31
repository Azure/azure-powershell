### Example 1: List all tag rules set for a given monitor resource
```powershell
PS C:\> Get-AzDataDogTagRule -ResourceGroupName azure-rg-datadog -MonitorName lucasdatadog

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

This command lists all tag rules set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource
```powershell
PS C:\> Get-AzDataDogTagRule -ResourceGroupName azure-rg-datadog -MonitorName lucasdatadog -Name 'default'

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource.

### Example 3: Get a tag rule set for a given monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogTagRule -ResourceGroupName azure-rg-datadog -MonitorName lucasdatadog -Name 'default' | Get-AzDataDogTagRule

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource by pipeline.

