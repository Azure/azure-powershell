### Example 1: Update a site's description and labels
```powershell
$newLabels = @{
    "environment" = "updated"
    "version" = "2.0"
    "updated-by" = "admin"
}

Update-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Description "Updated site description" -Labels $newLabels
```

Update an existing Azure Edge Site's description and labels while preserving other properties.

### Example 2: Update only the display name
```powershell
Update-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Updated West Coast Site"
```

Perform a partial update to change only the display name while leaving all other properties unchanged.

### Example 3: Update a site using JSON configuration
```powershell
$jsonUpdate = @"
{
    "properties": {
        "displayName": "JSON Updated Site",
        "description": "Updated via JSON configuration",
        "labels": {
            "update-method": "json",
            "automation": "true"
        }
    }
}
"@

Update-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -JsonString $jsonUpdate
```

Update an Azure Edge Site using a JSON configuration for complex updates or automation scenarios.

### Example 4: Update a site at subscription scope
```powershell
Update-AzSite -Name "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Updated Global Site" -Description "Updated enterprise operations center"
```

Update an Azure Edge Site that exists at the subscription scope rather than within a specific resource group.

### Example 5: Update a site at service group scope
```powershell
Update-AzSite -Name "service-site-001" -ServicegroupName "my-service-group" -DisplayName "Updated Service Group Site" -Description "Updated service group managed site"
```

Update an Azure Edge Site that exists at the service group scope.

