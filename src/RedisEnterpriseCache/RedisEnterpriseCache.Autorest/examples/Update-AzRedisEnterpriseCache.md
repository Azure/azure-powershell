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
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MaintenanceConfigurationMaintenanceWindow @(@{DayOfWeek="Monday"; StartHourUtc=6; Duration="PT8H"})
```

This command updates the maintenance window on the Redis Enterprise cache named MyCache to Mondays at 6:00 AM UTC for 8 hours.