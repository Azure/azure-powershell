---
external help file:
Module Name: Az.MarketplaceRpService
online version: https://docs.microsoft.com/en-us/powershell/module/az.marketplacerpservice/invoke-azmarketplacerpserviceofferprivatestorecollectionofferupsert
schema: 2.0.0
---

# Invoke-AzMarketplaceRpServiceOfferPrivateStoreCollectionOfferUpsert

## SYNOPSIS
Upsert an offer with multiple context details.

## SYNTAX

### OfferExpanded (Default)
```
Invoke-AzMarketplaceRpServiceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> [-ETag <String>] [-PlansContext <IContextAndPlansDetails[]>]
 [-PropertiesOfferId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Offer
```
Invoke-AzMarketplaceRpServiceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> -Payload <IMultiContextAndPlansPayload> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### OfferViaIdentity
```
Invoke-AzMarketplaceRpServiceOfferPrivateStoreCollectionOfferUpsert
 -InputObject <IMarketplaceRpServiceIdentity> -Payload <IMultiContextAndPlansPayload>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfferViaIdentityExpanded
```
Invoke-AzMarketplaceRpServiceOfferPrivateStoreCollectionOfferUpsert
 -InputObject <IMarketplaceRpServiceIdentity> [-OfferId <String>] [-ETag <String>]
 [-PlansContext <IContextAndPlansDetails[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Upsert an offer with multiple context details.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: Offer, OfferExpanded
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

### -ETag
The offer's eTag.

```yaml
Type: System.String
Parameter Sets: OfferExpanded, OfferViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.IMarketplaceRpServiceIdentity
Parameter Sets: OfferViaIdentity, OfferViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OfferId
The offer ID to update or delete

```yaml
Type: System.String
Parameter Sets: Offer, OfferExpanded, OfferViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
Payload object for upsert offer with multiple context and plans.
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.Api20220301.IMultiContextAndPlansPayload
Parameter Sets: Offer, OfferViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PlansContext
.
To construct, see NOTES section for PLANSCONTEXT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.Api20220301.IContextAndPlansDetails[]
Parameter Sets: OfferExpanded, OfferViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateStoreId
The store ID - must use the tenant ID

```yaml
Type: System.String
Parameter Sets: Offer, OfferExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesOfferId
The offer ID which contains the plans.

```yaml
Type: System.String
Parameter Sets: OfferExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.Api20220301.IMultiContextAndPlansPayload

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.IMarketplaceRpServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.Api20220301.IOffer

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMarketplaceRpServiceIdentity>: Identity Parameter
  - `[AdminRequestApprovalId <String>]`: The admin request approval ID to get create or update
  - `[CollectionId <String>]`: The collection ID
  - `[Id <String>]`: Resource identity path
  - `[OfferId <String>]`: The offer ID to update or delete
  - `[PrivateStoreId <String>]`: The store ID - must use the tenant ID
  - `[RequestApprovalId <String>]`: The request approval ID to get create or update

PAYLOAD <IMultiContextAndPlansPayload>: Payload object for upsert offer with multiple context and plans.
  - `[ETag <String>]`: The offer's eTag.
  - `[OfferId <String>]`: The offer ID which contains the plans.
  - `[PlansContext <IContextAndPlansDetails[]>]`: 
    - `[Context <String>]`: Plan's context, e.g. subscription ID, tenant ID.
    - `[PlanId <String[]>]`: List of plan IDs.

PLANSCONTEXT <IContextAndPlansDetails[]>: .
  - `[Context <String>]`: Plan's context, e.g. subscription ID, tenant ID.
  - `[PlanId <String[]>]`: List of plan IDs.

## RELATED LINKS

