---
external help file: Microsoft.Azure.Commands.StreamAnalytics.dll-Help.xml
ms.assetid: B5914F65-CAF8-4647-BA78-49B65DD6D67A
online version: 
schema: 2.0.0
---

# Start-AzureRmStreamAnalyticsJob

## SYNOPSIS
Starts a Stream Analytics job.

## SYNTAX

```
Start-AzureRmStreamAnalyticsJob [-Name] <String> [[-OutputStartMode] <String>] [[-OutputStartTime] <DateTime>]
 [-ResourceGroupName] <String> [-PipelineVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmStreamAnalyticsJob** cmdlet asynchronously deploys and starts a Stream Analytics job in Azure.

## EXAMPLES

### EXAMPLE 1: Start a Stream Analytics job
```
PS C:\>Start-AzureRmStreamAnalyticsJob -ResourceGroupName "StreamAnalytics-Default-West-US" -Name "StreamingJob" -OutputStartMode "CustomTime" -OutputStartTime "2014-07-03T01:00Z"
```

This command starts the job StreamingJob and specifies that the output event stream should start at timestamp 2014-07-03T01:00Z.

## PARAMETERS

### -Name
Specifies the name of the Azure Stream Analytics job to start.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OutputStartMode
Specifies the start mode for the job.
Valid values are: 

- JobStartTime - This value indicates that the starting point of the output event stream should start when the job is started.
- CustomTime - This value indicates that the starting point of the output event stream should start at a custom time that is specified in the *OutputStartTime* parameter. 
 -- LastOutputEventTime - This value indicates that the starting point of the output event stream should start from the last event output time.

If the property is absent, the default is JobStartTime.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OutputStartTime
Specifies the output start time.
This value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or $Null to indicate that the output event stream will start whenever the streaming job is started.
This property must have a value if *OutputStartMode* is set to CustomTime.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group to which the Azure Stream Analytics job belongs.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PipelineVariable
Not Specified

```yaml
Type: String
Parameter Sets: (All)
Aliases: pv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Get-AzureRmStreamAnalyticsJob](./Get-AzureRmStreamAnalyticsJob.md)

[New-AzureRmStreamAnalyticsJob](./New-AzureRmStreamAnalyticsJob.md)

[Remove-AzureRmStreamAnalyticsJob](./Remove-AzureRmStreamAnalyticsJob.md)

[Stop-AzureRmStreamAnalyticsJob](./Stop-AzureRmStreamAnalyticsJob.md)


