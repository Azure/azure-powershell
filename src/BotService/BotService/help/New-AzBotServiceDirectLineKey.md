---
external help file: Az.BotService-help.xml
Module Name: Az.BotService
online version: https://learn.microsoft.com/powershell/module/az.botservice/new-azbotservicedirectlinekey
schema: 2.0.0
---

# New-AzBotServiceDirectLineKey

## SYNOPSIS
Regenerates secret keys and returns them for the DirectLine Channel of a particular BotService resource

## SYNTAX

```
New-AzBotServiceDirectLineKey -ChannelName <RegenerateKeysChannelName> -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String>] -Key <Key> -SiteName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Regenerates secret keys and returns them for the DirectLine Channel of a particular BotService resource

## EXAMPLES

### Example 1: Regenerate directLine Key
```powershell
New-AzBotServiceDirectLineKey -ChannelName 'DirectLineChannel' -ResourceGroupName botTest-rg -ResourceName botTest1 -Key key1 -SiteName siteName
```

Regenerates secret keys and returns them for the DirectLine Channel of a particular BotService resource.

## PARAMETERS

### -ChannelName
The name of the Channel resource for which keys are to be regenerated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.RegenerateKeysChannelName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Key
Determines which key is to be regenerated

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Key
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Bot resource group in the user subscription.

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

### -ResourceName
The name of the Bot resource.

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

### -SiteName
The site name

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
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20220615Preview.IBotChannel

## NOTES

## RELATED LINKS
