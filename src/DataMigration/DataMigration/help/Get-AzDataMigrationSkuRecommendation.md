---
external help file: Az.DataMigration-help.xml
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
Get-AzDataMigrationSkuRecommendation [-OutputFolder <String>] [-TargetPlatform <String>]
 [-TargetSqlInstance <String>] [-TargetPercentile <String>] [-ScalingFactor <String>] [-StartTime <String>]
 [-EndTime <String>] [-Overwrite] [-DisplayResult] [-ElasticStrategy] [-DatabaseAllowList <String>]
 [-DatabaseDenyList <String>] [-PassThru] [<CommonParameters>]
```

### ConfigFile
```
Get-AzDataMigrationSkuRecommendation -ConfigFilePath <String> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Gives SKU recommendations for Azure SQL offerings

## EXAMPLES

### Example 1: Run SKU Recommendation on given SQL Server using connection string
```powershell
Get-AzDataMigrationSkuRecommendation -DisplayResult
```

```output
Starting SKU recommendation...

Performing aggregation for instance AALAB03-2K8...
Aggregation complete. Calculating SKU recommendations...
Instance name: AALAB03-2K8
SKU recommendation: Azure SQL Managed Instance:
Compute: Gen5 - GeneralPurpose - 4 cores
Storage: 64 GB
Recommendation reasons:
        According to the performance data collected, we estimate that your SQL server instance has a requirement for 0.16 vCores of CPU. For greater flexibility, based on your scaling factor of 100.00%, we are making a recommendation based on 0.16 vCores. Based on all the other factors, including memory, storage, and IO, this is the smallest compute sizing that will satisfy all of your needs.
        This SQL Server instance requires 0.44 GB of memory, which is within this SKU's limit of 20.40 GB.
        This SQL Server instance requires 32.37 GB of storage for data files. We recommend provisioning 64 GB of storage, which is the closest valid amount that can be provisioned that meets your requirement.
        This SQL Server instance requires 0.00 MB/second of combined read/write IO throughput. This is a relatively idle instance, so IO latency is not considered.
        Assuming the database uses the Full Recovery Model, this SQL Server instance requires 1 IOPS for data and log files. 
        This is the most cost-efficient offering among all the performance eligible SKUs.


Finishing SKU recommendations...
Event and Error Logs Folder Path: C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs Run SKU Recommendation on given SQL Server using the connection string.

### Example 2: Run Run SKU Recommendation on given SQL Server using assessment config file
```powershell
Get-AzDataMigrationSkuRecommendation -ConfigFilePath "C:\Users\user\document\config.json"
```

```output
Starting SKU recommendation...

Performing aggregation for instance AALAB03-2K8...
Aggregation complete. Calculating SKU recommendations...
Instance name: AALAB03-2K8
SKU recommendation: Azure SQL Managed Instance:
Compute: Gen5 - GeneralPurpose - 4 cores
Storage: 64 GB
Recommendation reasons:
        According to the performance data collected, we estimate that your SQL server instance has a requirement for 0.16 vCores of CPU. For greater flexibility, based on your scaling factor of 100.00%, we are making a recommendation based on 0.16 vCores. Based on all the other factors, including memory, storage, and IO, this is the smallest compute sizing that will satisfy all of your needs.
        This SQL Server instance requires 0.44 GB of memory, which is within this SKU's limit of 20.40 GB.
        This SQL Server instance requires 32.37 GB of storage for data files. We recommend provisioning 64 GB of storage, which is the closest valid amount that can be provisioned that meets your requirement.
        This SQL Server instance requires 0.00 MB/second of combined read/write IO throughput. This is a relatively idle instance, so IO latency is not considered.
        Assuming the database uses the Full Recovery Model, this SQL Server instance requires 1 IOPS for data and log files. 
        This is the most cost-efficient offering among all the performance eligible SKUs.


Finishing SKU recommendations...
Event and Error Logs Folder Path: C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs Run SKU Recommendation on given SQL Server using the config file.

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
How to pass - "Database1 Database2" (Default: null)

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
How to pass - "Database1 Database2" (Default: null)

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
