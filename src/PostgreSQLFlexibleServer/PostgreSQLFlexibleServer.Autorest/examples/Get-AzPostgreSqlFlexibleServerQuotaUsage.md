### Example 1: Get quota usage for a location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -Location "East US"
```

```output
Name         : PostgreSQL Flexible Servers
Location     : East US
CurrentValue : 5
Limit        : 20
Unit         : Count
Description  : Number of PostgreSQL Flexible Servers in East US region

Name         : Total Cores
Location     : East US
CurrentValue : 16
Limit        : 100
Unit         : Cores
Description  : Total vCore quota for PostgreSQL Flexible Servers

Name         : Storage
Location     : East US
CurrentValue : 512
Limit        : 65536
Unit         : GB
Description  : Total storage quota for PostgreSQL Flexible Servers
```

Retrieves quota usage information for PostgreSQL Flexible Servers in the East US region.

### Example 2: Get quota usage for a different location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -Location "West Europe"
```

```output
Name         : PostgreSQL Flexible Servers
Location     : West Europe
CurrentValue : 12
Limit        : 20
Unit         : Count
Description  : Number of PostgreSQL Flexible Servers in West Europe region

Name         : Total Cores
Location     : West Europe
CurrentValue : 48
Limit        : 100
Unit         : Cores
Description  : Total vCore quota for PostgreSQL Flexible Servers
```

Retrieves quota usage information for PostgreSQL Flexible Servers in the West Europe region.

