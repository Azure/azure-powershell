### Example 1: List of upgradable versions for a given monitor resource
```powershell
Get-AzElasticDetailUpgradableVersion -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
CurrentVersion UpgradableVersion
-------------- -----------------
8.8.2          {}
```

List of upgradable versions for a given monitor resource.

### Example 2: List of upgradable versions for a given monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 | Get-AzElasticDetailUpgradableVersion
```

```output
CurrentVersion UpgradableVersion
-------------- -----------------
8.8.2          {}
```

List of upgradable versions for a given monitor resource via pipeline.
