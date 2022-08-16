### Example 1: Get the AuthKeys for a given Sql Migration Service
```powershell
Get-AzDataMigrationSqlServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
```

```output
AuthKey1                                                 AuthKey2
--------                                                 --------
IR@abcd1-efgh2-jklmn3-opqr4@mysqlms@eastus@stuv5/wxyz6=  IR@abcd6-efgh5-jklmn4-opqr3@mysqlms@eastus@stuv2/wxyz1=
```

This command gets the AuthKeys for a given Sql Migration Service.



