### Example 1: List all configurations (also known as server parameters) in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerConfiguration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
Name                                DataType        Value                AllowedValue         DefaultValue         Source          Description
----                                --------        -----                ------------         ------------         ------          -----------
allow_alter_system                  Boolean         on                   on,off               on                   system-default  Allows running the ALTER SYSTEM command. Can be s…
allow_in_place_tablespaces          Boolean         off                  on,off               off                  system-default  Allows tablespaces directly inside pg_tblspc, for…
allow_system_table_mods             Boolean         off                  on,off               off                  system-default  Allows modifications of the structure of system t…
...
wal_writer_flush_after              Integer         128                  0-2147483647         128                  system-default  Amount of WAL written out by WAL writer that trig…
work_mem                            Integer         4096                 4096-2097151         4096                 system-default  Sets the maximum memory to be used for query work…
xmlbinary                           Enumeration     base64               base64,hex           base64               system-default  Sets how binary values are to be encoded in XML.
xmloption                           Enumeration     content              content,document     content              system-default  Sets whether XML data in implicit parsing and ser…
zero_damaged_pages                  Boolean         off                  on,off               off                  system-default  Continues processing past damaged page headers. D…
```

Lists all configurations (also known as server parameters) in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one configuration (also known as server parameter) in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerConfiguration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name work_mem
```

```output
Name                                DataType        Value                AllowedValue         DefaultValue         Source          Description
----                                --------        -----                ------------         ------------         ------          -----------
work_mem                            Integer         4096                 4096-2097151         4096                 system-default  Sets the maximum memory to be used for query work…
```

Gets one configuration (also known as server parameter) in an Azure Database for PostgreSQL flexible server with configuration name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 3: Get one configuration (also known as server parameter) corresponding to specific resource identifier
```powershell
$ID = "/subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/configurations/work_mem"
Get-AzPostgreSqlFlexibleServerConfiguration -InputObject $ID
```

```output
Name                                DataType        Value                AllowedValue         DefaultValue         Source          Description
----                                --------        -----                ------------         ------------         ------          -----------
work_mem                            Integer         4096                 4096-2097151         4096                 system-default  Sets the maximum memory to be used for query work…
```

Gets one configuration (also known as server parameter) in an Azure Database for PostgreSQL flexible server with the specific resource identifier of the configuration, explicitly passed as an argument.
