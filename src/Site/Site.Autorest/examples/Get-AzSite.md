### Example 1: Get a specific site by name at resource group scope
```powershell
Get-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

Get a specific Azure Edge Site at resource group scope.

### Example 2: Get a specific site by name at subscription scope
```powershell
Get-AzSite -Name "mysite-001" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

Get a specific Azure Edge Site at subscription scope.

### Example 3: List all sites in a subscription
```powershell
Get-AzSite -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

List all Azure Edge Sites across all resource groups in the specified subscription.

### Example 4: Get a site at service group scope
```powershell
Get-AzSite -Name "mysite-sg-001" -ServicegroupName "my-service-group"
```

Get an Azure Edge Site managed at the service group scope.

