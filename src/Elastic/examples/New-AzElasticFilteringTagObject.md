### Example 1: Create a in-memory object for FilteringTag used when creating tag rules
```powershell
<<<<<<< HEAD
$ft = New-AzElasticFilteringTagObject -Action Include -Name key -Value '1'
New-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02 -LogRuleFilteringTag $ft
```

```output
=======
PS C:\> $ft = New-AzElasticFilteringTagObject -Action Include -Name key -Value '1'
PS C:\> New-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02 -LogRuleFilteringTag $ft

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    Type
----    ----
default microsoft.elastic/monitors/tagrules
```

This command creates a in-memory object for FilteringTag used when creating tag rules

