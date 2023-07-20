### Example 1: Create and associate private link traffic filter for the given deployment
```powershell
New-AzElasticPrivateLinkFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -Name PlFilter01 -PrivateEndpointName PrivateEndpoint01
```

Create and associate private link traffic filter for the given deployment.

### Example 2: Create and associate private link traffic filter for the given deployment via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | New-AzElasticPrivateLinkFilter -Name PlFilter02 -PrivateEndpointName PrivateEndpoint01
```

Create and associate private link traffic filter for the given deployment via pipeline.
