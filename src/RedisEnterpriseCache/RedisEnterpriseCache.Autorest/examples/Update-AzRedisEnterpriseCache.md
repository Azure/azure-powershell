### Example 1: Update Redis Enterprise cache
```powershell
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MinimumTlsVersion "1.2" -Tag @{"tag1" = "value1"}
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command updates the minimum TLS version and adds a tag to the Redis Enterprise cache named MyCache.

### Example 2: Update maintenance window on a Redis Enterprise cache
```powershell
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MaintenanceConfigurationMaintenanceWindow @(@{Type="Weekly"; ScheduleDayOfWeek="Monday"; StartHourUtc=6; Duration="PT10H"}, @{Type="Weekly"; ScheduleDayOfWeek="Thursday"; StartHourUtc=6; Duration="PT10H"})
```

This command updates the maintenance windows on the Redis Enterprise cache named MyCache to Mondays and Thursdays at 6:00 AM UTC for 10 hours. At least 2 maintenance windows are required.