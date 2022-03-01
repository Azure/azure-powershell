### Example 1: Register Sql Migration Service on Self Hosted Integration Runtime
```powershell
PS C:\> $authKeys = Get-AzDataMigrationSqlMigrationServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
PS C:\> Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1

Start to register IR with key: IR@abcd1-efgh2-jklmn3-opqr4@mysqlms@eastus@stuv5/wxyz6=
Integration Runtime registration is successful!
```

This command registers Sql Migration Service on Self Hosted Integration Runtime.

### Example 2: Install Integration Runtime and register a Sql Migration Service on it
```powershell
PS C:\> $authKeys = Get-AzDataMigrationSqlMigrationServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
PS C:\> Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1 -IntegrationRuntimePath "C:\Users\user\Downloads\IntegrationRuntime.msi"

Start Gateway installation
Succeed to install gateway
Start to register IR with key: IR@abcd1-efgh2-jklmn3-opqr4@mysqlms@eastus@stuv5/wxyz6=
Integration Runtime registration is successful!
```

This command installs Integration Runtime and registers a Sql Migration Service on it.

