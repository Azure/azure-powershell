### Example 1: List the Datadog single sign-on resource for the given Monitor
```powershell
<<<<<<< HEAD
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog
```

```output
=======
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command lists the Datadog single sign-on resource for the given Monitor.

### Example 2: Gets the Datadog single sign-on resource for the given Monitor
```powershell
<<<<<<< HEAD
Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'
```

```output
=======
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command gets the Datadog single sign-on resource for the given Monitor.

### Example 3: Gets the Datadog single sign-on resource for the given Monitor by pipeline
```powershell
<<<<<<< HEAD
New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000 | Get-AzDatadogSingleSignOnConfiguration
```

```output
=======
PS C:\> New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000 | Get-AzDatadogSingleSignOnConfiguration

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
```

This command gets the Datadog single sign-on resource for the given Monitor by pipeline.
