### Example 1: {{ Add title here }}
```powershell
Get-AzDevCenterAdminSchedule -PoolName $env.poolName -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
```


### Example 2: {{ Add title here }}
```powershell
$schedule = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminSchedule -InputObject $schedule
```

