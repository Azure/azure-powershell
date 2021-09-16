### Example 1: {{ Add title here }}
```powershell
PS C:\> $filter = New-AzLogzFilteringTagObject -Action 'Include' -Name 'Env' -Value "Prod"
PS C:\> New-AzLogzMonitorTagRule -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 -LogRuleFilteringTag $filter

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         lucas-rg-test
```

{{ Add description here }}

