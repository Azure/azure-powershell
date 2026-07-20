### Example 1: Link a SaaS resource to a NewRelic monitor
```powershell
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName "test-01" -ResourceGroupName "ps-test" -SaaSResourceId "/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-saas/providers/Microsoft.SaaS/resources/newrelic-saas-01"
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 9:15:20 AM     user1@outlook.com        User                         ps-test
```

Links a new SaaS resource to the NewRelic monitor organization

### Example 2: Link SaaS resource using a SaaS data object
```powershell
$saasData = @{
    SaaSResourceId = "/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-saas/providers/Microsoft.SaaS/resources/newrelic-saas-01"
}
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName "test-01" -ResourceGroupName "ps-test" -Body $saasData
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 9:15:20 AM     user1@outlook.com        User                         ps-test
```

Links a SaaS resource to the NewRelic monitor using a data object containing the SaaS resource ID

