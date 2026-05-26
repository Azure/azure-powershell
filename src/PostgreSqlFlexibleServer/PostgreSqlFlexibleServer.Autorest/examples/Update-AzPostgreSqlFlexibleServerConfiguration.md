### Example 1: Update a configurations (also known as server parameter) in a flexible server
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlFlexibleServerConfiguration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name max_connections -Value 450 -Source user-override 
=======
Update-AzPostgreSqlFlexibleServerConfiguration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name max_connections -Value 450 -Source user-override 
>>>>>>> 15f018d78f3a5ebd1cabcfc830b54ee117a67146
```

```output
AllowedValue                 : 25-5000
DataType                     : Integer
DefaultValue                 : 859
Description                  : Sets the maximum number of concurrent connections.
DocumentationLink            : https://www.postgresql.org/docs/18/runtime-config-connection.html#GUC-MAX-CONNECTIONS
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/configurations/max_connections
IsConfigPendingRestart       : True
IsDynamicConfig              : False
IsReadOnly                   : False
Name                         : max_connections
ResourceGroupName            : example-resource-group
Source                       : user-override
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/configurations
Unit                         : 
Value                        : 450
```

Updates a configuration (also known as server parameter) in an Azure Database for PostgreSQL flexible server with configuration name, configuration value, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context. If the the configuration is static (`IsDynamicConfig` is `False`), changing its value requires a restart of the PostgreSQL database engine for the change to take effect. `IsConfigPendingRestart` set to `True` means that the currently show value is not in effect until the database engine is restarted.
