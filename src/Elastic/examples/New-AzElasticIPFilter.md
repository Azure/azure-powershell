### Example 1: Create and associate IP traffic filter for the given deployment
```powershell
New-AzElasticIPFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -Name IpFilter01 -IP 10.0.1.0/24
```

Create and associate IP traffic filter for the given deployment.

### Example 2: Create and associate IP traffic filter for the given deployment via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | New-AzElasticIPFilter -Name IpFilter02 -IP 10.0.2.0/24
```

Create and associate IP traffic filter for the given deployment via pipeline.
