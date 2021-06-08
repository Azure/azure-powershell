### Example 1: List the datadog single sign-on resource for the given Monitor
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName datadog

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command lists the datadog single sign-on resource for the given Monitor.

### Example 2: Gets the datadog single sign-on resource for the given Monitor
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName datadog -Name 'default'

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command gets the datadog single sign-on resource for the given Monitor.

### Example 3: Gets the datadog single sign-on resource for the given Monitor by pipeline
```powershell
PS C:\> New-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000 | Get-AzDataDogSingleSignOnConfiguration

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command gets the datadog single sign-on resource for the given Monitor by pipeline.
