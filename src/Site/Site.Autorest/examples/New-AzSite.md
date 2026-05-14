### Example 1: Create a new site at resource group scope with basic information
```powershell
New-AzSite -SiteName "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "West Coast Site" -Description "Primary site for west coast operations" -Country "US" -PostalCode "98101"
```

Create a new Azure Edge Site with basic information including display name, description, and address details.

### Example 2: Create a site with complete address information and labels
```powershell
$labels = @{
    "environment" = "production"
    "region" = "west"
    "owner" = "operations-team"
}

New-AzSite -SiteName "mysite-002" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Seattle Operations Center" -Description "Main operations site for Seattle region" -Country "US" -PostalCode "98101" -StateOrProvince "WA" -City "Seattle" -StreetAddress1 "123 Main St" -Labels $labels
```

Create a new Azure Edge Site with complete address information and custom labels for better organization and management.

### Example 3: Create a site at subscription scope
```powershell
New-AzSite -SiteName "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Global Operations Site" -Description "Enterprise-wide operations center" -Country "US" -PostalCode "10001"
```

Create a new Azure Edge Site at the subscription scope rather than within a specific resource group.

### Example 4: Create a site using JSON configuration
```powershell
$jsonConfig = @"
{
    "properties": {
        "displayName": "JSON Created Site",
        "description": "Site created via JSON configuration",
        "siteAddress": {
            "country": "CA",
            "postalCode": "K1A 0A6",
            "stateOrProvince": "ON",
            "city": "Ottawa",
            "streetAddress1": "100 Wellington St"
        },
        "labels": {
            "deployment-method": "json",
            "country": "canada"
        }
    }
}
"@

New-AzSite -SiteName "site-json-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -JsonString $jsonConfig
```

Create a new Azure Edge Site using a JSON configuration string for complex deployments or infrastructure-as-code scenarios.

### Example 5: Create a site at service group scope
```powershell
New-AzSite -SiteName "service-site-001" -ServicegroupName "my-service-group" -DisplayName "Service Group Site" -Description "Site managed at service group level" -Country "US" -PostalCode "78701"
```

Create a new Azure Edge Site at the service group scope.

