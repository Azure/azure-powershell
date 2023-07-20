### Example 1: Associate traffic filter for the given deployment
```powershell
$ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 | Where-Object Name -eq IpFilter01
Mount-AzElasticTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -RulesetId $ruleSet.Id
```

Associate traffic filter for the given deployment.

### Example 2: Associate traffic filter for the given deployment via pipeline
```powershell
$ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Where-Object Name -eq IpFilter02
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Mount-AzElasticTrafficFilter -RulesetId $ruleSet.Id
```

Associate traffic filter for the given deployment via pipeline.
