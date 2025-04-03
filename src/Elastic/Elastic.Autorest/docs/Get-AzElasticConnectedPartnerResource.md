---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticconnectedpartnerresource
schema: 2.0.0
---

# Get-AzElasticConnectedPartnerResource

## SYNOPSIS
List of all active deployments that are associated with the marketplace subscription linked to the given monitor.

## SYNTAX

```
Get-AzElasticConnectedPartnerResource -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List of all active deployments that are associated with the marketplace subscription linked to the given monitor.

## EXAMPLES

### Example 1: List of all active deployments linked to the given monitor
```powershell
Get-AzElasticConnectedPartnerResource -ResourceGroupName elastic-rg-3eytki -MonitorName elastic-rhqz1v
```

```output
AccountId AccountName     AzureResourceId                                                                                                                 Location
--------- -----------     ---------------                                                                                                                 --------
4404219   Account 4404219 /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/elastic-rg-3eytki/PROVIDERS/MICROSOFT.ELASTIC/MONITORS/elastic-rhqz1v eastus
```

This command list of all active deployments that are associated with the marketplace subscription linked to the given monitor.

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

### -MonitorName
Monitor resource name

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
The name of the resource group.
The name is case insensitive.

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20240301.IConnectedPartnerResourcesListFormat

## NOTES

## RELATED LINKS

