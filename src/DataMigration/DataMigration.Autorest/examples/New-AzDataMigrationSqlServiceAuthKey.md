### Example 1: Regenerate AuthKeys for a given Sql Migration Service
```powershell
New-AzDataMigrationSqlServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -KeyName AuthKey2
```

```output
AuthKey1 AuthKey2                    KeyName
-------- --------                    -------
         IR*********************yz6=
```

This command regenerate the AuthKeys for a given Sql Migration Service. Here we have regenerated AuthKey2.

