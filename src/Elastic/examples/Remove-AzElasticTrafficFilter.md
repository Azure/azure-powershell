### Example 1: Detach and Delete traffic filter from the given deployment
```powershell
$ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 | Where-Object Name -eq IpFilter01
Remove-AzElasticTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -RulesetId $ruleSet.Id
```

Detach and Delete traffic filter from the given deployment

### Example 2: Detach and Delete traffic filter from the given deployment via pipeline
```powershell
$monitor = Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02
$ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 | Where-Object Name -eq IpFilter02
$monitor | Remove-AzElasticTrafficFilter -InputObject $monitor -RulesetId $ruleSet.Id
```

Detach and Delete traffic filter from the given deployment via pipeline
