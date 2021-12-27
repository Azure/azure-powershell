### Example 1: Regenerate AuthKeys for a given Sql Migration Service
```powershell
PS C:\> New-AzDataMigrationSqlServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -KeyName AuthKey2

AuthKey1 AuthKey2                                                   KeyName
-------- --------                                                   -------
         IR@abcd7-efgh8-jklmn9-opqr10@mysqlms@eastus@stuv2/wxyz1=
```

This command regenerate the AuthKeys for a given Sql Migration Service. Here we have regenerated AuthKey2.

