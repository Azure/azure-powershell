### Example 1: List all elastic monitors under a subscription
```powershell
PS C:\> Get-AzElasticMonitor

Name                           SkuName                         MonitoringStatus Location      ResourceGroupName
----                           -------                         ---------------- --------      -----------------
kk-elastictest02               ess-monthly-consumption_Monthly Enabled          westus2       kk-rg
kk-elastictest03               ess-monthly-consumption_Monthly Enabled          westus2       kk-rg
wusDeployValidate              ess-monthly-consumption_Monthly Enabled          westus2       poshett-rg
poshett-WestUS2-01             staging_Monthly                 Enabled          westus2       poshett-rg
hashahdemo01                   staging_Monthly                 Enabled          westus2       test-sub
```

This command lists all elastic monitors under a subscription.

### Example 2: List all elastic monitors under a resource group
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName azure-elastic-test

Name             SkuName                         MonitoringStatus Location ResourceGroupName
----             -------                         ---------------- -------- -----------------
elastic-portal01 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
elastic-portal02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
elastic-pwsh01   ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
elastic-pwsh02   ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
```

This command lists all elastic monitors under a resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh02

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
```

This command gets the properties of a specific monitor resource.

### Example 4: Get the properties of a specific monitor resource by pipeline
```powershell
PS C:\> New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -SkuName "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com' | Get-AzElasticMonitor

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
```

This command gets the properties of a specific monitor resource by pipeline.
