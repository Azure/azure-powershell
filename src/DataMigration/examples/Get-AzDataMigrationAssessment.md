### Example 1:  Run SQL Assessment on given SQL Server using connection string
```powershell
PS C:\> Get-AzDataMigrationAssessment -ConnectionStrings "Data Source=LabServer.database.net;Initial Catalog=master;Integrated Security=False;User Id=User;Password=password" -OutputFolder "C:\AssessmentOutput" -Overwrite

{{ Add output here }}
```

This command runs SQL Assessment on given SQL Server using the connection string.

### Example 2: Run SQL Assessment on given SQL Server using assessment config file
```powershell
PS C:\> Get-AzDataMigrationAssessment -ConfigFilePath "C:\Users\user\document\config.json"

{{ Add output here }}
```

This command runs SQL Assessment on given SQL Server using assessment config file.

