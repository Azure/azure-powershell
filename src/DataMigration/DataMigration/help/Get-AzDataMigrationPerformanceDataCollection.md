---
external help file: Az.DataMigration-help.xml
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/get-azdatamigrationperformancedatacollection
schema: 2.0.0
---

# Get-AzDataMigrationPerformanceDataCollection

## SYNOPSIS
Collect performance data for given SQL Server instance(s)

## SYNTAX

### CommandLine (Default)
```
Get-AzDataMigrationPerformanceDataCollection -SqlConnectionStrings <String[]> [-OutputFolder <String>]
 [-PerfQueryInterval <String>] [-StaticQueryInterval <String>] [-NumberOfIterations <String>] [-Time <Int64>]
 [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ConfigFile
```
Get-AzDataMigrationPerformanceDataCollection [-Time <Int64>] -ConfigFilePath <String> [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Collect performance data for given SQL Server instance(s)

## EXAMPLES

### Example 1: Run Performance Data Collection on given SQL Server using connection string
```powershell
Get-AzDataMigrationPerformanceDataCollection -SqlConnectionStrings "Data Source=AALAB03-2K8.REDMOND.CORP.MICROSOFT.COM;Initial Catalog=master;Integrated Security=False;User Id=dummyUserId;Password=dummyPassword" -NumberOfIterations 2
```

```output
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
Get-AzDataMigrationPerformanceDataCollection -ConfigFilePath "C:\Users\user\document\config.json"
```

```output
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

### Example 3: Run Performance Data Collection on given SQL Server that stops after a specified time
```powershell
Get-AzDataMigrationPerformanceDataCollection -ConfigFilePath "C:\Users\user\document\config.json" -Time 120
```

```output
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

This command runs Performance Data Collection on given SQL Server that stops after a specified time.

## PARAMETERS

### -ConfigFilePath
Path of the ConfigFile

```yaml
Type: System.String
Parameter Sets: ConfigFile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfIterations
Number of iterations of performance data collection to perform before persisting to file.
For example, with default values, performance data will be persisted every 30 seconds * 20 iterations = 10 minutes.
(Default: 20, Minimum: 2)

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputFolder
Folder which data and result reports will be written to/read from.

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PerfQueryInterval
Interval at which to query performance data, in seconds.
(Default: 30)

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlConnectionStrings
Sql Server Connection Strings

```yaml
Type: System.String[]
Parameter Sets: CommandLine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticQueryInterval
Interval at which to query and persist static configuration data, in seconds.
(Default: 3600)

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Time
Duration of time in seconds for which you want to collect performance data

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
