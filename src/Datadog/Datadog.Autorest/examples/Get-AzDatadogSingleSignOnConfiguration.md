### Example 1: List the Datadog single sign-on resource for the given Monitor
```powershell
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog

Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command lists the Datadog single sign-on resource for the given Monitor.

### Example 2: Gets the Datadog single sign-on resource for the given Monitor
```powershell
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'

Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command gets the Datadog single sign-on resource for the given Monitor.

### Example 3: Gets the Datadog single sign-on resource for the given Monitor by pipeline
```powershell
PS C:\> New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000 | Get-AzDatadogSingleSignOnConfiguration

Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command gets the Datadog single sign-on resource for the given Monitor by pipeline.
