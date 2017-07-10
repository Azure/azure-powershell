---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmDataLakeAnalyticsJobPipeline

## SYNOPSIS
Gets a Data Lake Analytics Job pipeline or pipelines.

## SYNTAX

### All In Account (Default)
```
Get-AzureRmDataLakeAnalyticsJobPipeline [-Account] <String> [-SubmittedAfter <DateTimeOffset>]
 [-SubmittedBefore <DateTimeOffset>] [<CommonParameters>]
```

### Specific Job Pipeline
```
Get-AzureRmDataLakeAnalyticsJobPipeline [-Account] <String> [-PipelineId] <Guid>
 [-SubmittedAfter <DateTimeOffset>] [-SubmittedBefore <DateTimeOffset>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDataLakeAnalyticsJobPipeline** gets a specified Azure Data Lake Analytics Job pipeline or a list of pipelines.

## EXAMPLES

### Example 1: Get a specified pipeline
```
PS C:\>Get-AzureRmDataLakeAnalyticsJobPipeline -Account "contosoadla" -PipelineId 83cb7ad2-3523-4b82-b909-d478b0d8aea3
```

This command gets the specified pipeline with id '83cb7ad2-3523-4b82-b909-d478b0d8aea3' in account 'contosoadla'.

### Example 2: Get a list of all pipelines in the account
```
PS C:\>Get-AzureRmDataLakeAnalyticsJobPipeline -AccountName "contosoadla"
```

This command gets a list of all pipelines in the account "contosoadla"

## PARAMETERS

### -Account
Name of the Data Lake Analytics account name under which want to retrieve the job pipeline.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PipelineId
ID of the specific job pipeline to return information for.

```yaml
Type: Guid
Parameter Sets: Specific Job Pipeline
Aliases: Id

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -SubmittedAfter
An optional filter which returns job pipeline(s) only submitted after the specified time.```yaml
Type: DateTimeOffset
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubmittedBefore
An optional filter which returns job pipeline(s) only submitted before the specified time.```yaml
Type: DateTimeOffset
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Guid

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.DataLakeAnalytics.Models.PSJobPipelineInformation, Microsoft.Azure.Commands.DataLakeAnalytics, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.DataLakeAnalytics.Models.PSJobPipelineInformation

## NOTES

## RELATED LINKS

