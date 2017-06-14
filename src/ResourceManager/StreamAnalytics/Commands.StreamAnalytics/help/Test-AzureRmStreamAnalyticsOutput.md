---
external help file: Microsoft.Azure.Commands.StreamAnalytics.dll-Help.xml
ms.assetid: F57C53E2-2873-441F-90E6-E6100418D519
online version: 
schema: 2.0.0
---

# Test-AzureRmStreamAnalyticsOutput

## SYNOPSIS
Tests the connection status of an output.

## SYNTAX

```
Test-AzureRmStreamAnalyticsOutput [-JobName] <String> [-Name] <String> [-ResourceGroupName] <String>
 [<CommonParameters>]
```

## DESCRIPTION
The **Test-AzureRmStreamAnalyticsOutput** cmdlet tests the ability of Stream Analytics to connect to an output.

## EXAMPLES

### EXAMPLE 1: Test the connection status of an output
```
PS C:\>Test-AzureRmStreamAnalyticsOutput -ResourceGroupName "StreamAnalytics-Default-West-US" -JobName "StreamingJob" -Name "Output"
```

This tests the connection status of the output Output in StreamingJob.

## PARAMETERS

### -JobName
Specifies the name of the Azure Stream Analytics job to which the desired Azure Stream Analytics output belongs.

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

### -Name
Specifies the name of the Azure Stream Analytics output to test.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group to which the Azure Stream Analytics output belongs.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Get-AzureRmStreamAnalyticsOutput](./Get-AzureRmStreamAnalyticsOutput.md)

[New-AzureRmStreamAnalyticsOutput](./New-AzureRmStreamAnalyticsOutput.md)

[Remove-AzureRmStreamAnalyticsOutput](./Remove-AzureRmStreamAnalyticsOutput.md)


