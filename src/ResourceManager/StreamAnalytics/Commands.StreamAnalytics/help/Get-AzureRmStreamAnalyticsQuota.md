---
external help file: Microsoft.Azure.Commands.StreamAnalytics.dll-Help.xml
ms.assetid: ECD0950F-2490-49E2-85E6-5FA2A59364E6
online version: 
schema: 2.0.0
---

# Get-AzureRmStreamAnalyticsQuota

## SYNOPSIS
Gets information about the Streaming Unit quota for a region.

## SYNTAX

```
Get-AzureRmStreamAnalyticsQuota [-Location] <String> [-PipelineVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmStreamAnalyticsQuota** cmdlet gets information about the Streaming Unit quota for a region.

## EXAMPLES

### EXAMPLE 1: Get information about the Streaming Unit quota for a region
```
PS C:\>Get-AzureRmStreamAnalyticsQuota -Location "West US"
```

This command returns information about Streaming Unit quota and usage in the West US region.

## PARAMETERS

### -Location
Specifies the name of an Azure region or data center location for which to get Streaming Unit quota information.
See http://azure.microsoft.com/en-us/regions/#serviceshttp://azure.microsoft.com/en-us/regions/#services for a list of supported Azure regions.

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

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.StreamAnalytics.Models.PSQuota, Microsoft.Azure.Commands.StreamAnalytics]]            Microsoft.Azure.Commands.StreamAnalytics.Models.PSQuota

## NOTES

## RELATED LINKS

[Azure Stream Analytics Cmdlets](./AzureRM.StreamAnalytics.md)


