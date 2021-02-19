---
external help file: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.dll-Help.xml
Module Name: Az.StreamAnalytics
ms.assetid: ECD0950F-2490-49E2-85E6-5FA2A59364E6
online version: https://docs.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticsquota
schema: 2.0.0
---

# Get-AzStreamAnalyticsQuota

## SYNOPSIS
Gets information about the Streaming Unit quota for a region.

## SYNTAX

```
Get-AzStreamAnalyticsQuota [-Location] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStreamAnalyticsQuota** cmdlet gets information about the Streaming Unit quota for a region.

## EXAMPLES

### EXAMPLE 1: Get information about the Streaming Unit quota for a region
```
PS C:\>Get-AzStreamAnalyticsQuota -Location "West US"
```

This command returns information about Streaming Unit quota and usage in the West US region.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies the name of an Azure region or data center location for which to get Streaming Unit quota information.
See http://azure.microsoft.com/en-us/regions/#serviceshttp://azure.microsoft.com/en-us/regions/#services for a list of supported Azure regions.

```yaml
Type: System.String
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.StreamAnalytics.Models.PSQuota

## NOTES

## RELATED LINKS

[Azure Stream Analytics Cmdlets](./Az.StreamAnalytics.md)


