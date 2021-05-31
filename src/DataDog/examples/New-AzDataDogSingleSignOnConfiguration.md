### Example 1: Configures single-sign-on for Data monitor resource
```powershell
PS C:\> New-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName lucasdatadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId xxxxxxxxxxxxxxxx-8be89db12e58

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource.

### Example 2: Configures single-sign-on for Data monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName azure-rg-datadog -MonitorName lucasdatadog -Name 'default' | New-AzDataDogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId xxxxxxxxxxxxxxxx-8be89db12e58

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command configures single-sign-on for Data monitor resource by pipeline.

