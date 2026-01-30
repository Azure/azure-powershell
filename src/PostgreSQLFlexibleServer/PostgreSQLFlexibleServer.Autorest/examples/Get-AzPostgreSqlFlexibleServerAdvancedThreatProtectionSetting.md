### Example 1: Get advanced threat protection settings for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerAdvancedThreatProtectionSetting -ResourceGroupName "myresourcegroup" -ServerName "myserver"
```

```output
Name    State    CreationTime
----    -----    ------------
Default Enabled  2024-01-15T10:30:00.0000000Z
```

Gets the advanced threat protection settings for the specified PostgreSQL Flexible Server.

### Example 2: List advanced threat protection settings using List parameter set
```powershell
Get-AzPostgreSqlFlexibleServerAdvancedThreatProtectionSetting -ResourceGroupName "myresourcegroup" -ServerName "myserver"
```

```output
Name    State    CreationTime
----    -----    ------------
Default Disabled 2024-01-15T10:30:00.0000000Z
```

Lists the advanced threat protection settings for the specified PostgreSQL Flexible Server showing disabled state.

