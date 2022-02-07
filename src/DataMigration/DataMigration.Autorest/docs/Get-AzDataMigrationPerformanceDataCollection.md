---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/get-azdatamigrationperformancedatacollection
schema: 2.0.0
---

# Get-AzDataMigrationPerformanceDataCollection

## SYNOPSIS
Collect performance data for given SQL Server instance(s)

## SYNTAX

### CommandLine (Default)
```
Get-AzDataMigrationPerformanceDataCollection -SqlConnectionStrings <String[]> [-NumberOfIterations <String>]
 [-OutputFolder <String>] [-PerfQueryIntervalInSec <String>] [-StaticQueryIntervalInSec <String>] [-PassThru]
 [<CommonParameters>]
```

### ConfigFile
```
Get-AzDataMigrationPerformanceDataCollection -ConfigFilePath <String> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Collect performance data for given SQL Server instance(s)

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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

### -PerfQueryIntervalInSec
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

### -StaticQueryIntervalInSec
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

