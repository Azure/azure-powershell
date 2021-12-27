---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/get-azdatamigrationassessment
schema: 2.0.0
---

# Get-AzDataMigrationAssessment

## SYNOPSIS
Runs assessment on given Sql Servers

## SYNTAX

### CommandLine (Default)
```
Get-AzDataMigrationAssessment -ConnectionStrings <String[]> [-OutputFolder <String>] [-Overwrite]
 [<CommonParameters>]
```

### ConfigFile
```
Get-AzDataMigrationAssessment -ConfigFilePath <String> [<CommonParameters>]
```

## DESCRIPTION
Runs assessment on given Sql Servers

## EXAMPLES

### Example 1:  Run SQL Assessment on given SQL Server using connection string
```powershell
PS C:\> Get-AzDataMigrationAssessment -ConnectionStrings "Data Source=LabServer.database.net;Initial Catalog=master;Integrated Security=False;User Id=User;Password=password" -OutputFolder "C:\AssessmentOutput" -Overwrite

Starting SQL assessment...
Progress: 100%; Issues Found: 100; Objects Assessed: 500/500; Status: Completed; Total time: 00:01:50.000.

Finishing SQL assessment...
Assessment report saved to C:\Users\user\AppData\Local\Microsoft\SqlAssessment\SqlAssessmentReport.json.
Event and Error Logs Folder Path: C:\Users\user\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs SQL Assessment on given SQL Server using the connection string.

### Example 2: Run SQL Assessment on given SQL Server using assessment config file
```powershell
PS C:\> Get-AzDataMigrationAssessment -ConfigFilePath "C:\Users\user\document\config.json"

Starting SQL assessment...
Progress: 100%; Issues Found: 100; Objects Assessed: 550/550; Status: Completed; Total time: 00:01:50.000.

Finishing SQL assessment...
Assessment report saved to C:\Users\user\AppData\Local\Microsoft\SqlAssessment\SqlAssessmentReport.json.
Event and Error Logs Folder Path: C:\Users\user\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs SQL Assessment on given SQL Server using assessment config file.

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

### -ConnectionStrings
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

### -OutputFolder
Output folder to store assessment report

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

### -Overwrite
Enable this parameter to overwrite the existing assessment report

```yaml
Type: System.Management.Automation.SwitchParameter
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

### System.Object

## NOTES

ALIASES

## RELATED LINKS

