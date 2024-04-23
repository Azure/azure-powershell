---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringrpunbilledprefix
schema: 2.0.0
---

# Get-AzPeeringRpUnbilledPrefix

## SYNOPSIS
Lists all of the RP unbilled prefixes for the specified peering

## SYNTAX

```
Get-AzPeeringRpUnbilledPrefix -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Consolidate] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all of the RP unbilled prefixes for the specified peering

## EXAMPLES

### Example 1: List all unbilled prefixes for a peering
```powershell
Get-AzPeeringRpUnbilledPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Prefix      AzureRegion PeerASN
------      ----------- -------
2.16.0.0/13 West US 2   65010
23.0.0.0/12 West US 2   65010
...
```

Lists all the unbilled prefixes for a peering

## PARAMETERS

### -Consolidate
Flag to enable consolidation prefixes

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -PeeringName
The peering name.

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

### -ResourceGroupName
The Azure resource group name.

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
The Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IRpUnbilledPrefix

## NOTES

## RELATED LINKS
