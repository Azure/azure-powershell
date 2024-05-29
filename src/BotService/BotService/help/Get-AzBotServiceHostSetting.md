---
external help file: Az.BotService-help.xml
Module Name: Az.BotService
online version: https://learn.microsoft.com/powershell/module/az.botservice/get-azbotservicehostsetting
schema: 2.0.0
---

# Get-AzBotServiceHostSetting

## SYNOPSIS
Get per subscription settings needed to host bot in compute resource such as Azure App Service

## SYNTAX

```
Get-AzBotServiceHostSetting [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get per subscription settings needed to host bot in compute resource such as Azure App Service

## EXAMPLES

### Example 1: Get
```powershell
Get-AzBotServiceHostSetting
```

```output
BotOpenIdMetadata OAuthUrl ToBotFromChannelOpenIdMetadataUrl ToBotFromChannelTokenIssuer ToBotFromEmulatorOpenIdMetadataUrl ToChannelFromBotLoginUrl ToChannelFromBotOAuthScope
----------------- -------- --------------------------------- --------------------------- ---------------------------------- ------------------------ --------------------------
```

Get per subscription settings needed to host bot in compute resource such as Azure App Service

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

### -SubscriptionId
Azure Subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20220615Preview.IHostSettingsResponse

## NOTES

## RELATED LINKS
