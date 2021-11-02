---
external help file:
Module Name: Az.SignalR
online version: https://docs.microsoft.com/powershell/module/az.signalr/get-azwebpubsubusage
schema: 2.0.0
---

# Get-AzWebPubSubUsage

## SYNOPSIS
List resource usage quotas by location.

## SYNTAX

```
Get-AzWebPubSubUsage -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List resource usage quotas by location.

## EXAMPLES

### Example 1: List Web PubSub usage in east US region.
```powershell
PS C:\> Get-AzWebPubSubUsage -Location eastus | Format-List

CurrentValue       : 4
Id                 : /subscriptions/9caf2a1e-9c49-49b6-89a2-56bdec7e3f97/providers/Microsoft.SignalRService/locations/eastus/usages/FreeTierInstances
Limit              : 5
NameLocalizedValue : Free Tier SignalR Instances per subscription
NameValue          : FreeTierInstances
Unit               : Count

CurrentValue       : 225
Id                 : /subscriptions/9caf2a1e-9c49-49b6-89a2-56bdec7e3f97/providers/Microsoft.SignalRService/locations/eastus/usages/SignalRTotalUnits
Limit              : 1500
NameLocalizedValue : SignalRTotalUnits
NameValue          : SignalRTotalUnits
Unit               : Count
```

The example pipes the result of `Get-AzWebPubSubUsage -Location eastus` to `Format-list` to view the values of all the properties of the result.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
the location like "eastus"

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
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISignalRServiceUsage

## NOTES

ALIASES

## RELATED LINKS

