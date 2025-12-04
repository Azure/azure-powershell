### Example 1: Remove a site at resource group scope
```powershell
Remove-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

Remove an Azure Edge Site at resource group scope. The command completes silently upon successful deletion.

### Example 2: Remove a site at subscription scope
```powershell
Remove-AzSite -Name "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

Remove an Azure Edge Site that exists at the subscription scope.

### Example 3: Remove a site at service group scope
```powershell
Remove-AzSite -Name "service-site-001" -ServicegroupName "my-service-group"
```

Remove an Azure Edge Site that exists at the service group scope.


