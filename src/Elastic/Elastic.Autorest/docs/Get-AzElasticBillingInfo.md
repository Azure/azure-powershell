---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticbillinginfo
schema: 2.0.0
---

# Get-AzElasticBillingInfo

## SYNOPSIS
Get marketplace and organization info mapped to the given monitor.

## SYNTAX

### Get (Default)
```
Get-AzElasticBillingInfo -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticBillingInfo -InputObject <IElasticIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Get marketplace and organization info mapped to the given monitor.

## EXAMPLES

### Example 1: Get marketplace info mapped to the given monitor.
```powershell
Get-AzElasticBillingInfo -ResourceGroupName elastic-rg-3eytki -MonitorName elastic-rhqz1v
```

```output
MarketplaceSaaInfoBilledAzureSubscriptionId   : 11111111-2222-3333-4444-123456789101
MarketplaceSaaInfoMarketplaceResourceId       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/elastic-rg-3eytki/providers/Microsoft.SaaS/resources/AzElastic_11111111-2222-3333-4444-123456789102_elastic-rhqz1v
MarketplaceSaaInfoMarketplaceStatus           : Subscribed
MarketplaceSaaInfoMarketplaceSubscriptionId   : 00000000-0000-0000-0000-000000000000
MarketplaceSaaInfoMarketplaceSubscriptionName : AzElastic_11111111-2222-3333-4444-123456789102_elastic-rhqz1v
PartnerBillingEntityOrganizationId            : 11111111-2222-3333-4444-123456789103
PartnerBillingEntityOrganizationName          : 11111111-2222-3333-4444-123456789103
```

This command gets marketplace info mapped to the given monitor.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20240301.IBillingInfoResponse

## NOTES

## RELATED LINKS

