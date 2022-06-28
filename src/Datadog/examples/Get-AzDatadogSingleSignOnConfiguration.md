### Example 1: List the Datadog single sign-on resource for the given Monitor
```powershell
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command lists the Datadog single sign-on resource for the given Monitor.

### Example 2: Gets the Datadog single sign-on resource for the given Monitor
```powershell
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command gets the Datadog single sign-on resource for the given Monitor.

### Example 3: Gets the Datadog single sign-on resource for the given Monitor by pipeline
```powershell
New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000 | Get-AzDatadogSingleSignOnConfiguration
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command gets the Datadog single sign-on resource for the given Monitor by pipeline.
