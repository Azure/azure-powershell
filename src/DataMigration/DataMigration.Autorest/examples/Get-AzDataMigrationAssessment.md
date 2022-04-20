### Example 1:  Run SQL Assessment on given SQL Server using connection string
```powershell
Get-AzDataMigrationAssessment -ConnectionString "Data Source=LabServer.database.net;Initial Catalog=master;Integrated Security=False;User Id=User;Password=password" -OutputFolder "C:\AssessmentOutput" -Overwrite
```

```output
Starting SQL assessment...
Progress: 100%; Issues Found: 100; Objects Assessed: 500/500; Status: Completed; Total time: 00:01:50.000.

Finishing SQL assessment...
Assessment report saved to C:\Users\user\AppData\Local\Microsoft\SqlAssessment\SqlAssessmentReport.json.
Event and Error Logs Folder Path: C:\Users\user\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs SQL Assessment on given SQL Server using the connection string.

### Example 2: Run SQL Assessment on given SQL Server using assessment config file
```powershell
Get-AzDataMigrationAssessment -ConfigFilePath "C:\Users\user\document\config.json"
```

```output
Starting SQL assessment...
Progress: 100%; Issues Found: 100; Objects Assessed: 550/550; Status: Completed; Total time: 00:01:50.000.

Finishing SQL assessment...
Assessment report saved to C:\Users\user\AppData\Local\Microsoft\SqlAssessment\SqlAssessmentReport.json.
Event and Error Logs Folder Path: C:\Users\user\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs SQL Assessment on given SQL Server using assessment config file. 

