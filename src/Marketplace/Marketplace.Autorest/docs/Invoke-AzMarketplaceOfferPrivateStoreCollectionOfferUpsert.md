---
external help file:
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/invoke-azmarketplaceofferprivatestorecollectionofferupsert
schema: 2.0.0
---

# Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert

## SYNOPSIS
Upsert an offer with multiple context details.

## SYNTAX

### OfferExpanded (Default)
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> [-ETag <String>] [-PlansContext <IContextAndPlansDetails[]>]
 [-PropertiesOfferId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Offer
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> -Payload <IMultiContextAndPlansPayload> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### OfferViaIdentity
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -InputObject <IMarketplaceIdentity>
 -Payload <IMultiContextAndPlansPayload> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### OfferViaIdentityCollection
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionInputObject <IMarketplaceIdentity>
 -OfferId <String> -Payload <IMultiContextAndPlansPayload> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### OfferViaIdentityCollectionExpanded
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionInputObject <IMarketplaceIdentity>
 -OfferId <String> [-ETag <String>] [-PlansContext <IContextAndPlansDetails[]>] [-PropertiesOfferId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfferViaIdentityExpanded
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -InputObject <IMarketplaceIdentity>
 [-OfferId <String>] [-ETag <String>] [-PlansContext <IContextAndPlansDetails[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfferViaIdentityPrivateStore
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> -Payload <IMultiContextAndPlansPayload>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfferViaIdentityPrivateStoreExpanded
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> [-ETag <String>] [-PlansContext <IContextAndPlansDetails[]>]
 [-PropertiesOfferId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfferViaJsonFilePath
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### OfferViaJsonString
```
Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert -CollectionId <String> -OfferId <String>
 -PrivateStoreId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
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
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: Offer, OfferExpanded, OfferViaIdentityPrivateStore, OfferViaIdentityPrivateStoreExpanded, OfferViaJsonFilePath, OfferViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: OfferViaIdentityCollection, OfferViaIdentityCollectionExpanded
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
Parameter Sets: OfferExpanded, OfferViaIdentityCollectionExpanded, OfferViaIdentityExpanded, OfferViaIdentityPrivateStoreExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: OfferViaIdentity, OfferViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Offer operation

```yaml
Type: System.String
Parameter Sets: OfferViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Offer operation

```yaml
Type: System.String
Parameter Sets: OfferViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferId
The offer ID to update or delete

```yaml
Type: System.String
Parameter Sets: Offer, OfferExpanded, OfferViaIdentityCollection, OfferViaIdentityCollectionExpanded, OfferViaIdentityExpanded, OfferViaIdentityPrivateStore, OfferViaIdentityPrivateStoreExpanded, OfferViaJsonFilePath, OfferViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMultiContextAndPlansPayload
Parameter Sets: Offer, OfferViaIdentity, OfferViaIdentityCollection, OfferViaIdentityPrivateStore
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IContextAndPlansDetails[]
Parameter Sets: OfferExpanded, OfferViaIdentityCollectionExpanded, OfferViaIdentityExpanded, OfferViaIdentityPrivateStoreExpanded
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
Parameter Sets: Offer, OfferExpanded, OfferViaJsonFilePath, OfferViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: OfferViaIdentityPrivateStore, OfferViaIdentityPrivateStoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PropertiesOfferId
The offer ID which contains the plans.

```yaml
Type: System.String
Parameter Sets: OfferExpanded, OfferViaIdentityCollectionExpanded, OfferViaIdentityPrivateStoreExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMultiContextAndPlansPayload

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer

## NOTES

## RELATED LINKS

