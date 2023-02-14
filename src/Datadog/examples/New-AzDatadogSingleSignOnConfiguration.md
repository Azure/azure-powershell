### Example 1: Configures single-sign-on for Data monitor resource
```powershell
<<<<<<< HEAD
New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000
```

```output
=======
PS C:\> New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource.

### Example 2: Configures single-sign-on for Data monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId 00000000-0000-0000-0000-000000000000
```

```output
=======
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId 00000000-0000-0000-0000-000000000000

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource by pipeline.

