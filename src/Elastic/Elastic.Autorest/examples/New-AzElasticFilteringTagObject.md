### Example 1: Create a in-memory object for FilteringTag used when creating tag rules
```powershell
PS C:\> $ft = New-AzElasticFilteringTagObject -Action Include -Name key -Value '1'
PS C:\> New-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02 -LogRuleFilteringTag $ft

Name    Type
----    ----
default microsoft.elastic/monitors/tagrules
```

This command creates a in-memory object for FilteringTag used when creating tag rules

