### Example 1: Detach traffic filter for the given deployment
```powershell
$ruleSet = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 | Where-Object Name -eq IpFilter01
Dismount-AzElasticTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -RulesetId $ruleSet.Id
```

Detach traffic filter for the given deployment.

### Example 2: Detach traffic filter for the given deployment via pipeline
```powershell
$ruleSet = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Where-Object Name -eq IpFilter02
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Dismount-AzElasticTrafficFilter -RulesetId $ruleSet.Id
```

Detach traffic filter for the given deployment via pipeline.
