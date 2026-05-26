### Example 1: Enable threat advanced protection in a flexible server
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -State Enabled
```

```output
CreationTime                 : 3/22/2026 1:29:08 PM
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/advancedThreatProtectionSettings/Default
Name                         : Default
ResourceGroupName            : example-resource-group
State                        : Enabled
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/advancedThreatProtectionSettings
```

Enables threat advanced protection of an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Disable threat advanced protection in a server
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -State Disabled
```

```output
CreationTime                 : 3/22/2026 1:29:08 PM
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/advancedThreatProtectionSettings/Default
Name                         : Default
ResourceGroupName            : example-resource-group
State                        : Disabled
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/advancedThreatProtectionSettings
```

Disables threat advanced protection of an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.
