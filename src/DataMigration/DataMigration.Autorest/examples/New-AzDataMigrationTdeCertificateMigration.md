### Example 1: Run TDE certificate migration from a source SQL Server to a target Azure SQL Server.
```powershell
New-AzDataMigrationTdeCertificateMigration -SourceSqlConnectionString "data source=servername;user id=userid;password=;initial catalog=master;TrustServerCertificate=True" -TargetSubscriptionId "00000000-0000-0000-0000-000000000000" -TargetResourceGroupName "ResourceGroupName" -TargetManagedInstanceName "TargetManagedInstanceName" -NetworkSharePath "\\NetworkShare\Folder" -NetworkShareDomain "NetworkShare" -NetworkShareUserName "NetworkShareUserName" -NetworkSharePassword "NetworkSharePassword" -DatabaseName "TdeDb_0", "TdeDb_1", "TdeDb_2"
```

```output
Beginning TDE certificate migration
TdeDb_0: TDE certificate migrated successfully.
TdeDb_1: TDE certificate migrated successfully.
TdeDb_2: TDE certificate migrated successfully.
Certificate migration completed
```

This command runs TDE certificate migration from a source SQL Server to a target Azure SQL Server.