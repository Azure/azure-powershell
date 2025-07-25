---
external help file: Az.StreamAnalytics-help.xml
Module Name: Az.StreamAnalytics
online version: https://learn.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticsquota
schema: 2.0.0
---

# Get-AzStreamAnalyticsQuota

## SYNOPSIS
Retrieves the subscription's current quota information in a particular region.

## SYNTAX

```
Get-AzStreamAnalyticsQuota -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves the subscription's current quota information in a particular region.

## EXAMPLES

### Example 1: Get information about the Streaming Unit quota for a region
```powershell
Get-AzStreamAnalyticsQuota -Location 'WestCentralUS'
```

```output
Name              Type
----              ----
StreamingUnits    Microsoft.StreamAnalytics/quotas
StreamingClusters Microsoft.StreamAnalytics/quotas
```

This command returns information about Streaming Unit quota and usage in the WestCentralUS region.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The region in which to retrieve the subscription's quota information.
You can find out which regions Azure Stream Analytics is supported in here: https://azure.microsoft.com/en-us/regions/

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota

## NOTES

## RELATED LINKS
