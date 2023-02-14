### Example 1: Create a monitor resource
```powershell
<<<<<<< HEAD
New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -Sku "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com'
```

```output
=======
PS C:\> New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -SkuName "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
```

This command creates a monitor resource.


