### Example 1: {{ Add title here }}
```powershell
PS C:\> $ft = New-AzElasticFilteringTagObject -Action Include -Name key -Value '1'
PS C:\> New-AzElasticTagRule -ResourceGroupName lucas-elastic-test -MonitorName elastic-pwsh02 -Name default -LogRuleFilteringTag $ft

Name    Type
----    ----
default microsoft.elastic/monitors/tagrules
```

{{ Add description here }}

