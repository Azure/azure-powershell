### Example 1: Get spring cloud's linker configuration list
```powershell
Get-AzServiceLinkerConfigurationForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -ResourceGroupName servicelinker-test-group -LinkerName postgresql_linker |fl
```

```output
Name  : AZURE_POSTGRESQL_POSTGRESQL_NOVNET_CONNECTIONSTRING
Value : Server=test.postgres.database.azure.com;Database=testdb;Port=543 
        2;Ssl Mode=Require;User Id=testuser@test;Password=password;   

```

Get Linker's configuration list
