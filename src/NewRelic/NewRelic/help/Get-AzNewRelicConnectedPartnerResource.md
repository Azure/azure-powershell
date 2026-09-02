---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicconnectedpartnerresource
schema: 2.0.0
---

# Get-AzNewRelicConnectedPartnerResource

## SYNOPSIS
List active deployments associated with the marketplace subscription linked to a New Relic monitor.

## SYNTAX

```
Get-AzNewRelicConnectedPartnerResource -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists active deployments associated with the marketplace subscription linked to the specified New Relic monitor.

## EXAMPLES

### Example 1: List of all active deployments linked to the given monitor
```powershell
Get-AzNewRelicConnectedPartnerResource -MonitorName test-01 -ResourceGroupName group-test
```

```output
AccountId AccountName     AzureResourceId                                                                                                                 Location
--------- -----------     ---------------                                                                                                                 --------
4404219   Account 4404219 /SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/GROUP-TEST/PROVIDERS/NEWRELIC.OBSERVABILITY/MONITORS/TEST-01 eastus
```

This command list of all active deployments that are associated with the marketplace subscription linked to the given monitor.

## PARAMETERS

### -DefaultProfile

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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IConnectedPartnerResourcesListFormat

## NOTES

## RELATED LINKS
