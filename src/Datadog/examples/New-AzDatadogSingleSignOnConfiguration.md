### Example 1: Configures single-sign-on for Data monitor resource
```powershell
New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource.

### Example 2: Configures single-sign-on for Data monitor resource by pipeline
```powershell
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId 00000000-0000-0000-0000-000000000000
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource by pipeline.

