### Example 1: Register Sql Migration Service on Self Hosted Integration Runtime
```powershell
PS C:\> $authKeys = Get-AzDataMigrationSqlMigrationServiceAuthKey -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS"
PS C:\> Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1

Start to register IR with key: IR@tyi97c5-gdby456-4673svs-yeh4@mysqlms@eastus@xp6/x892=
Integration Runtime registration is successful!
```

This command registers Sql Migration Service on Self Hosted Integration Runtime.

### Example 2: Install Integration Runtime and register a Sql Migration Service on it
```powershell
PS C:\> $authKeys = Get-AzDataMigrationSqlMigrationServiceAuthKey -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS"
PS C:\> Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1 -IntegrationRuntimePath "C:\Users\user\Downloads\IntegrationRuntime.msi"

Start Gateway installation
Succeed to install gateway
Start to register IR with key: IR@tyi97c5-gdby456-4673svs-yeh4@mysqlms@eastus@xp6/x892=
Integration Runtime registration is successful!
```

This command installs Integration Runtime and registers a Sql Migration Service on it.

