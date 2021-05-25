### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId xxxxxxxxxxxxxxxx-8be89db12e58

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default' | New-AzDataDogSingleSignOnConfiguration -SingleSignOnState Disable -EnterpriseAppId xxxxxxxxxxxxxxxx-8be89db12e58

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

{{ Add description here }}

