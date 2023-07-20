### Example 1: Delete traffic filter from the account
```powershell
$ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 | Where-Object Name -eq IpFilter03
Remove-AzElasticUnassociatedTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -RulesetId $ruleSet.Id
```

Delete traffic filter from the account.

### Example 2: Delete traffic filter from the account via pipeline
```powershell
$ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Where-Object Name -eq IpFilter04
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Remove-AzElasticUnassociatedTrafficFilter -RulesetId $ruleSet.Id
```

Delete traffic filter from the account via pipeline.
