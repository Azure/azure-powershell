### Example 1: Get specified PostgreSql configuration by name
```powershell
Get-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
```

```output
Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 4096  4096-2097151 system-default 4096
```

This cmdlet gets specified PostgreSql configuration by name.

### Example 2: List all configurations in specified PostgreSql server
```powershell
Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
```

```output
Name                                       Value                      AllowedValue
----                                       -----                      ------------
application_name                                                      [A-Za-z0-9._-]*
array_nulls                                on                         on,off
autovacuum                                 on                         on,off
autovacuum_analyze_scale_factor            0.1                        0-100
...
work_mem                                   4096                       4096-2097151
xmlbinary                                  base64                     base64,hex
xmloption                                  content                    content,document
intelligent_tuning                         off                        on,off
require_secure_transport                   on                         on,off
pgbouncer.enabled                          false                      true, false
```

This cmdlet lists all configurations in specified PostgreSql server.