---
external help file:
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/new-azmarketplaceprivatestorecollectionoffer
schema: 2.0.0
---

# New-AzMarketplacePrivateStoreCollectionOffer

## SYNOPSIS
Create or add an offer to a specific collection of the private store.

## SYNTAX

### CreateExpanded (Default)
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String> -PrivateStoreId <String>
 [-ETag <String>] [-IconFileUri <Hashtable>] [-Plan <IPlan[]>] [-SpecificPlanIdLimitation <String[]>]
 [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityCollection
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionInputObject <IMarketplaceIdentity> -OfferId <String>
 -Payload <IOffer> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityCollectionExpanded
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionInputObject <IMarketplaceIdentity> -OfferId <String>
 [-ETag <String>] [-IconFileUri <Hashtable>] [-Plan <IPlan[]>] [-SpecificPlanIdLimitation <String[]>]
 [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityPrivateStore
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> -Payload <IOffer> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityPrivateStoreExpanded
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> [-ETag <String>] [-IconFileUri <Hashtable>] [-Plan <IPlan[]>]
 [-SpecificPlanIdLimitation <String[]>] [-UpdateSuppressedDueIdempotence] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String> -PrivateStoreId <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String> -PrivateStoreId <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or add an offer to a specific collection of the private store.

## EXAMPLES

### Example 1: Creates or updates offer to private store collection 
```powershell
$acc = @{Accessibility = "azure_managedservices_professional"}
New-AzMarketplacePrivateStoreCollectionOffer -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId 7f5402e4-e8f4-46bd-9bd1-8d27866a606b  -OfferId aumatics.azure_managedservices -Plan $acc
```

```output
Name                           SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                           ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
aumatics.azure_managedservices
```

This command creates or updates offer to private store collection.

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPrivateStore, CreateViaIdentityPrivateStoreExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: CreateViaIdentityCollection, CreateViaIdentityCollectionExpanded
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
Identifier for purposes of race condition

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityCollectionExpanded, CreateViaIdentityPrivateStoreExpanded
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
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityCollectionExpanded, CreateViaIdentityPrivateStoreExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
The privateStore offer data structure.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer
Parameter Sets: CreateViaIdentityCollection, CreateViaIdentityPrivateStore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Plan
Offer plans

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IPlan[]
Parameter Sets: CreateExpanded, CreateViaIdentityCollectionExpanded, CreateViaIdentityPrivateStoreExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateStoreInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: CreateViaIdentityPrivateStore, CreateViaIdentityPrivateStoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SpecificPlanIdLimitation
Plan ids limitation for this offer

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityCollectionExpanded, CreateViaIdentityPrivateStoreExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityCollectionExpanded, CreateViaIdentityPrivateStoreExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer

## NOTES

## RELATED LINKS

