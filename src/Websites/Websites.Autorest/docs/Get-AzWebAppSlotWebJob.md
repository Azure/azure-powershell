---
external help file:
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azwebappslotwebjob
schema: 2.0.0
---

# Get-AzWebAppSlotWebJob

## SYNOPSIS
List webjobs for a deployment slot.

## SYNTAX

```
Get-AzWebAppSlotWebJob -AppName <String> -ResourceGroupName <String> -SlotName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List webjobs for a deployment slot.

## EXAMPLES

### Example 1: List webjobs for a deployment slot
```powershell
Get-AzWebAppSlotWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01
```

```output
Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                  webjob-rg-test
appService-test01/slot01/slottriggeredjob-04                  webjob-rg-test
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
appService-test01/slot01/slotcontinuousjob-04                 webjob-rg-test
```

This command lists webjobs for a deployment slot.

## PARAMETERS

### -AppName
Site name.

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

### -ResourceGroupName
Name of the resource group to which the resource belongs.

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

### -SlotName
Name of the deployment slot.
If a slot is not specified, the API returns deployments for the production slot.

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
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IWebJob

## NOTES

ALIASES

## RELATED LINKS

