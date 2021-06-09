### Example 1: Configures single-sign-on for Data monitor resource
```powershell
PS C:\> New-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource.

### Example 2: Configures single-sign-on for Data monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName datadog -Name 'default' | New-AzDataDogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId 00000000-0000-0000-0000-000000000000

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource by pipeline.

