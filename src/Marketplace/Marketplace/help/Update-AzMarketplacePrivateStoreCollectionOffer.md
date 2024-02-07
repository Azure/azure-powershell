---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/update-azmarketplaceprivatestorecollectionoffer
schema: 2.0.0
---

# Update-AzMarketplacePrivateStoreCollectionOffer

## SYNOPSIS
Update or add an offer to a specific collection of the private store.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> [-ETag <String>] [-IconFileUri <Hashtable>] [-Plan <IPlan[]>]
 [-SpecificPlanIdLimitation <String[]>] [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityPrivateStoreExpanded
```
Update-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> [-ETag <String>] [-IconFileUri <Hashtable>] [-Plan <IPlan[]>]
 [-SpecificPlanIdLimitation <String[]>] [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityPrivateStore
```
Update-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> -Payload <IOffer> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityCollectionExpanded
```
Update-AzMarketplacePrivateStoreCollectionOffer -OfferId <String> -CollectionInputObject <IMarketplaceIdentity>
 [-ETag <String>] [-IconFileUri <Hashtable>] [-Plan <IPlan[]>] [-SpecificPlanIdLimitation <String[]>]
 [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityCollection
```
Update-AzMarketplacePrivateStoreCollectionOffer -OfferId <String> -CollectionInputObject <IMarketplaceIdentity>
 -Payload <IOffer> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMarketplacePrivateStoreCollectionOffer -InputObject <IMarketplaceIdentity> [-ETag <String>]
 [-IconFileUri <Hashtable>] [-Plan <IPlan[]>] [-SpecificPlanIdLimitation <String[]>]
 [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update or add an offer to a specific collection of the private store.

## EXAMPLES

### EXAMPLE 1
```
Update-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId 8c7a91db-cd41-43b6-af47-2e869654126d -OfferId "aumatics.azure_managedservices" -SpecificPlanIdLimitation $null
```

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityPrivateStore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionInputObject
Identity Parameter
To construct, see NOTES section for COLLECTIONINPUTOBJECT properties and create a hash table.

```yaml
Type: IMarketplaceIdentity
Parameter Sets: UpdateViaIdentityCollectionExpanded, UpdateViaIdentityCollection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ETag
Identifier for purposes of race condition

```yaml
Type: String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityCollectionExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconFileUri
Icon File Uris

```yaml
Type: Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityCollectionExpanded, UpdateViaIdentityExpanded
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
Type: IMarketplaceIdentity
Parameter Sets: UpdateViaIdentityExpanded
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
Type: String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityPrivateStore, UpdateViaIdentityCollectionExpanded, UpdateViaIdentityCollection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
The privateStore offer data structure.
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: IOffer
Parameter Sets: UpdateViaIdentityPrivateStore, UpdateViaIdentityCollection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Plan
Offer plans
To construct, see NOTES section for PLAN properties and create a hash table.

```yaml
Type: IPlan[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityCollectionExpanded, UpdateViaIdentityExpanded
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
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateStoreInputObject
Identity Parameter
To construct, see NOTES section for PRIVATESTOREINPUTOBJECT properties and create a hash table.

```yaml
Type: IMarketplaceIdentity
Parameter Sets: UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityPrivateStore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificPlanIdLimitation
Plan ids limitation for this offer

```yaml
Type: String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityCollectionExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateSuppressedDueIdempotence
Indicating whether the offer was not updated to db (true = not updated).
If the allow list is identical to the existed one in db, the offer would not be updated.

```yaml
Type: SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateStoreExpanded, UpdateViaIdentityCollectionExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

COLLECTIONINPUTOBJECT \<IMarketplaceIdentity\>: Identity Parameter
  \[AdminRequestApprovalId \<String\>\]: The admin request approval ID to get create or update
  \[CollectionId \<String\>\]: The collection ID
  \[Id \<String\>\]: Resource identity path
  \[OfferId \<String\>\]: The offer ID to update or delete
  \[PrivateStoreId \<String\>\]: The store ID - must use the tenant ID
  \[RequestApprovalId \<String\>\]: The request approval ID to get create or update

INPUTOBJECT \<IMarketplaceIdentity\>: Identity Parameter
  \[AdminRequestApprovalId \<String\>\]: The admin request approval ID to get create or update
  \[CollectionId \<String\>\]: The collection ID
  \[Id \<String\>\]: Resource identity path
  \[OfferId \<String\>\]: The offer ID to update or delete
  \[PrivateStoreId \<String\>\]: The store ID - must use the tenant ID
  \[RequestApprovalId \<String\>\]: The request approval ID to get create or update

PAYLOAD \<IOffer\>: The privateStore offer data structure.
  \[ETag \<String\>\]: Identifier for purposes of race condition
  \[IconFileUri \<IOfferPropertiesIconFileUris\>\]: Icon File Uris
    \[(Any) \<String\>\]: This indicates any property can be added to this object.
  \[Plan \<List\<IPlan\>\>\]: Offer plans
    \[Accessibility \<String\>\]: Plan accessibility
  \[SpecificPlanIdsLimitation \<List\<String\>\>\]: Plan ids limitation for this offer
  \[UpdateSuppressedDueIdempotence \<Boolean?\>\]: Indicating whether the offer was not updated to db (true = not updated).
If the allow list is identical to the existed one in db, the offer would not be updated.

PLAN \<IPlan\[\]\>: Offer plans
  \[Accessibility \<String\>\]: Plan accessibility

PRIVATESTOREINPUTOBJECT \<IMarketplaceIdentity\>: Identity Parameter
  \[AdminRequestApprovalId \<String\>\]: The admin request approval ID to get create or update
  \[CollectionId \<String\>\]: The collection ID
  \[Id \<String\>\]: Resource identity path
  \[OfferId \<String\>\]: The offer ID to update or delete
  \[PrivateStoreId \<String\>\]: The store ID - must use the tenant ID
  \[RequestApprovalId \<String\>\]: The request approval ID to get create or update

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.marketplace/update-azmarketplaceprivatestorecollectionoffer](https://learn.microsoft.com/powershell/module/az.marketplace/update-azmarketplaceprivatestorecollectionoffer)

