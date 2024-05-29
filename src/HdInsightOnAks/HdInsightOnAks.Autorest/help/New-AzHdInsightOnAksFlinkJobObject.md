---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksFlinkJobObject
schema: 2.0.0
---

# New-AzHdInsightOnAksFlinkJobObject

## SYNOPSIS
Create an object as a parameter for submitting cluster work

## SYNTAX

```
New-AzHdInsightOnAksFlinkJobObject -Action <String> -JobName <String> [-Arg <String>] [-EntryClass <String>]
 [-FlinkConfiguration <IFlinkJobPropertiesFlinkConfiguration>] [-JarName <String>] [-JobJarDirectory <String>]
 [-SavePointName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an object as a parameter for submitting cluster work

## EXAMPLES

### Example 1: Create an object as a parameter for submitting cluster work.
```powershell
 $flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
        -JarName "JarName" -EntryClass "com.microsoft.hilo.flink.job.streaming.SleepJob" `
        -JobJarDirectory "abfs://flinkjob@hilosa.dfs.core.windows.net/jars" `
        -FlinkConfiguration @{parallelism=1}
```

```output
Id Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
-- ---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ----

```

Create an object as a parameter for submitting cluster work.

## PARAMETERS

### -Action
The reference name of the secret to be used in service configs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Arg
A string property representing additional JVM arguments for the Flink job.
It should be space separated value.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntryClass
A string property that specifies the entry class for the Flink job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkConfiguration
Additional properties used to configure Flink jobs.
It allows users to set properties such as parallelism and jobSavePointDirectory.
It accepts additional key-value pairs as properties, where the keys are strings and the values are strings as well.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IFlinkJobPropertiesFlinkConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JarName
A string property that represents the name of the job JAR

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobJarDirectory
A string property that specifies the directory where the job JAR is located.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobName
Name of job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SavePointName
A string property that represents the name of the savepoint for the Flink job

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterJob

## NOTES

## RELATED LINKS

