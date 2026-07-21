---
external help file: Az.Napster-help.xml
Module Name: Az.Napster
online version: https://learn.microsoft.com/powershell/module/az.napster/invoke-aznapsterlatestorganizationlinkedsaas
schema: 2.0.0
---

# Invoke-AzNapsterLatestOrganizationLinkedSaaS

## SYNOPSIS
Returns the latest SaaS linked to the Napster organization of the underlying monitor.

## SYNTAX

### Latest (Default)
```
Invoke-AzNapsterLatestOrganizationLinkedSaaS -Organizationname <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### LatestViaIdentity
```
Invoke-AzNapsterLatestOrganizationLinkedSaaS -InputObject <INapsterIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Returns the latest SaaS linked to the Napster organization of the underlying monitor.

## EXAMPLES

### Example 1: Get the latest SaaS linked to a Napster Organization
```powershell
Invoke-AzNapsterLatestOrganizationLinkedSaaS -Organizationname napster-test1 -ResourceGroupName acctest0001 -SubscriptionId 61641157-140c-4b97-b365-30ff76d9f82e
```

```output
Id                            : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa
MarketplaceSubscriptionId     : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus : Subscribed
OfferDetailOfferId            : napster_companion_api
OfferDetailPlanId             : napster_companion_api_feb_2026
OfferDetailPlanName           : Pay As You Go
OfferDetailPublisherId        : touchcastinc1655995956899
OfferDetailTermId             : n7ja87drquhy
OfferDetailTermUnit           : P1M
SaaSResourceId                : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa
```

This command returns the most recent SaaS resource linked to the specified Napster organization.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.INapsterIdentity
Parameter Sets: LatestViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Organizationname
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: Latest
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
Parameter Sets: Latest
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
Type: System.String
Parameter Sets: Latest
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

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.INapsterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.ILatestLinkedSaaSResponse

## NOTES

## RELATED LINKS
