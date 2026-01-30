### Example 1: Get the private DNS zone suffix for a location
```powershell
Get-AzPostgreSqlFlexibleServerPrivateDnsZoneSuffix -Location "East US"
```

```output
Location           : East US
PrivateDnsZoneSuffix : private.postgres.database.azure.com
Description        : Private DNS zone suffix for PostgreSQL Flexible Servers in East US
```

Retrieves the private DNS zone suffix for PostgreSQL Flexible Servers in the East US region.

### Example 2: Get private DNS zone suffix for a different region
```powershell
Get-AzPostgreSqlFlexibleServerPrivateDnsZoneSuffix -Location "West Europe"
```

```output
Location           : West Europe
PrivateDnsZoneSuffix : private.postgres.database.azure.com
Description        : Private DNS zone suffix for PostgreSQL Flexible Servers in West Europe
```

Retrieves the private DNS zone suffix for PostgreSQL Flexible Servers in the West Europe region.

