### Example 1: Upgrade version for a monitor resource
```powershell
Update-AzElasticMonitorVersion -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 -Version 8.8.2
```

Upgrade version for a monitor resource.

### Example 2: Upgrade version for a monitor resource via JSON string
```powershell
$versionProps = @{
	version = "8.8.2"
}
$versionPropsJson = ConvertTo-Json -InputObject $versionProps
Update-AzElasticMonitorVersion -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 -JsonString $versionPropsJson
```

Upgrade version for a monitor resource via JSON string.

### Example 3: Upgrade version for a monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor03 | Update-AzElasticMonitorVersion -Version 8.8.2
```

Upgrade version for a monitor resource via pipeline.
