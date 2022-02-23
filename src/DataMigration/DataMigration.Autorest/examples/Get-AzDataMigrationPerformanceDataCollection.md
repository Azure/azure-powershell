### Example 1: Run Performance Data Collection on given SQL Server using connection string
```powershell
PS C:\> Get-AzDataMigrationPerformanceDataCollection -SqlConnectionStrings "Data Source=AALAB03-2K8.REDMOND.CORP.MICROSOFT.COM;Initial Catalog=master;Integrated Security=False;User Id=dummyUserId;Password=dummyPassword" -NumberOfIterations 2

Connecting to the SQL server(s)...
Starting data collection...
Press the Enter key to stop the data collection at any time...

Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
UTC 2022-02-03 07:04:50, Server AALAB03-2K8:
        Performance data query iteration: 1 of 2, collected 349 data points.
UTC 2022-02-03 07:04:52, Server AALAB03-2K8:
        Collected static configuration data, and saved to C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment.
Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
UTC 2022-02-03 07:05:44, Server AALAB03-2K8:
        Performance data query iteration: 2 of 2, collected 347 data points.
UTC 2022-02-03 07:07:13, Server AALAB03-2K8:
        Aggregated 696 raw data points to 263 performance counters, and saved to C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment.
UTC 2022-02-03 07:07:16, Server AALAB03-2K8:
        Performance data query iteration: 1 of 2, collected 349 data points.

Event and Error Logs Folder Path: C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs Performance Data Collection on given SQL Server using the connection string.


### Example 2: Run Performance Data Collection on given SQL Server using assessment config file
```powershell
PS C:\> Get-AzDataMigrationAssessment -ConfigFilePath "C:\Users\user\document\config.json"

Connecting to the SQL server(s)...
Starting data collection...
Press the Enter key to stop the data collection at any time...

Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
UTC 2022-02-03 07:04:50, Server AALAB03-2K8:
        Performance data query iteration: 1 of 2, collected 349 data points.
UTC 2022-02-03 07:04:52, Server AALAB03-2K8:
        Collected static configuration data, and saved to C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment.
Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
UTC 2022-02-03 07:05:44, Server AALAB03-2K8:
        Performance data query iteration: 2 of 2, collected 347 data points.
UTC 2022-02-03 07:07:13, Server AALAB03-2K8:
        Aggregated 696 raw data points to 263 performance counters, and saved to C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment.
UTC 2022-02-03 07:07:16, Server AALAB03-2K8:
        Performance data query iteration: 1 of 2, collected 349 data points.

Event and Error Logs Folder Path: C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs Performance Data Collection on given SQL Server using the config file.


