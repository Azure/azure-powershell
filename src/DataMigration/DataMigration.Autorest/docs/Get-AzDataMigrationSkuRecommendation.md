---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/get-azdatamigrationskurecommendation
schema: 2.0.0
---

# Get-AzDataMigrationSkuRecommendation

## SYNOPSIS
Gives SKU recommendations for Azure SQL offerings

## SYNTAX

### CommandLine (Default)
```
Get-AzDataMigrationSkuRecommendation [-DatabaseAllowList <String>] [-DatabaseDenyList <String>]
 [-DisplayResult] [-ElasticStrategy] [-EndTime <String>] [-OutputFolder <String>] [-Overwrite]
 [-ScalingFactor <String>] [-StartTime <String>] [-TargetPercentile <String>] [-TargetPlatform <String>]
 [-TargetSqlInstance <String>] [-PassThru] [<CommonParameters>]
```

### ConfigFile
```
Get-AzDataMigrationSkuRecommendation -ConfigFilePath <String> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Gives SKU recommendations for Azure SQL offerings

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

### -DatabaseAllowList
Optional.
Space separated list of names of databases to be allowed for SKU recommendation consideration while excluding all others.
Only set one of the following or neither: databaseAllowList, databaseDenyList.
(Default: null)

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

### -DatabaseDenyList
Optional.
Space separated list of names of databases to not be considered for SKU recommendation.
Only set one of the following or neither: databaseAllowList, databaseDenyList.
(Default: null)

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

### -DisplayResult
Optional.
Whether or not to print the SKU recommendation results to the console.
(Default: true)

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

### -ElasticStrategy
Optional.
Whether or not to use the elastic strategy for SKU recommendations based on resource usage profiling.
(Default: false)

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

### -EndTime
Optional.
UTC end time of performance data points to consider during aggregation, in YYYY-MM-DD HH:MM format.
Only used for baseline (non-elastic) strategy.
(Default: all data points collected will be considered)

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
The value here must be the same as the one used in PerfDataCollection

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
Optional.
Whether or not to overwrite any existing SKU recommendation reports.
(Default: true)

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

### -ScalingFactor
Optional.
Scaling (comfort) factor used during SKU recommendation.
For example, if it is determined that there is a 4 vCore CPU requirement with a scaling factor of 150%, then the true CPU requirement will be 6 vCores.
(Default: 100)

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

### -StartTime
Optional.
UTC start time of performance data points to consider during aggregation, in YYYY-MM-DD HH:MM format.
Only used for baseline (non-elastic) strategy.
(Default: all data points collected will be considered)

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

### -TargetPercentile
Optional.
Percentile of data points to be used during aggregation of the performance data.
Only used for baseline (non-elastic) strategy.
(Default: 95)

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

### -TargetPlatform
Optional.
Target platform for SKU recommendation: either AzureSqlDatabase, AzureSqlManagedInstance, AzureSqlVirtualMachine, or Any.
If Any is selected, then SKU recommendations for all three target platforms will be evaluated, and the best fit will be returned.
(Default: Any)

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

### -TargetSqlInstance
Optional.
Name of the SQL instance that SKU recommendation will be targeting.
(Default: outputFolder will be scanned for files created by the PerfDataCollection action, and recommendations will be provided for every instance found)

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

