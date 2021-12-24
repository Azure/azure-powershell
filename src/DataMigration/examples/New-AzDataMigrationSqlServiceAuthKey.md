### Example 1: Regenerate AuthKeys for a given Sql Migration Service
```powershell
PS C:\> New-AzDataMigrationSqlServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -KeyName AuthKey2

AuthKey1 AuthKey2                                                   KeyName
-------- --------                                                   -------
         IR@tyi97c5-gdby456-4673svs-yeh4@mysqlms@eastus@xp6/x892=
```

This command regenerate the AuthKeys for a given Sql Migration Service. Here we have regenerated AuthKey2.

