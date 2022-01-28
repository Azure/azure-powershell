### Example 1: Remove the specified Intergration Runtime Node for a Sql Migration Service
```powershell
PS C:\> Remove-AzDataMigrationSqlServiceNode -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -NodeName "WIN-AKLAB" | Select *

Name       Node
----       ----
default-ir {}
```

This command removes the specified Intergration Runtime Node for the given Sql Migration Service.

