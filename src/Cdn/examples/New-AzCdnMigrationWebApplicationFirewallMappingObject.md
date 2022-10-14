### Example 1: Create an in-memory object for MigrationWebApplicationFirewallMapping.
```powershell
New-AzCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId wafId1 -MigratedToId wafId2
```

```output
MigratedFromId MigratedToId
-------------- ------------
wafId1         wafId2
```

Create an in-memory object for MigrationWebApplicationFirewallMapping.


### Example 2: Create an in-memory object for MigrationWebApplicationFirewallMappings.
```powershell
$waf1 = New-AzCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId wafId1 -MigratedToId wafId2
$waf2 = New-AzCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId wafId11 -MigratedToId wafId22

$wafs = @($waf1, $waf2)
$wafs 
```
MigratedFromId MigratedToId
-------------- ------------
wafId1         wafId2
wafId11        wafId22
```output