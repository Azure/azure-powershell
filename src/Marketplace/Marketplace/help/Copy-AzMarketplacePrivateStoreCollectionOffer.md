---
external help file:
Module Name: Az.Marketplace
online version: https://docs.microsoft.com/powershell/module/az.marketplace/copy-azmarketplaceprivatestorecollectionoffer
schema: 2.0.0
---

# Copy-AzMarketplacePrivateStoreCollectionOffer

## SYNOPSIS
transferring offers (copy or move) from source collection to target collection(s)

## SYNTAX

### TransferExpanded (Default)
```
Copy-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -PrivateStoreId <String>
 [-OfferIdList <String[]>] [-Operation <String>] [-TargetCollection <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Transfer
```
Copy-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -PrivateStoreId <String>
 -Payload <ITransferOffersProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TransferViaIdentity
```
Copy-AzMarketplacePrivateStoreCollectionOffer -InputObject <IMarketplaceIdentity>
 -Payload <ITransferOffersProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TransferViaIdentityExpanded
```
Copy-AzMarketplacePrivateStoreCollectionOffer -InputObject <IMarketplaceIdentity> [-OfferIdList <String[]>]
 [-Operation <String>] [-TargetCollection <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
transferring offers (copy or move) from source collection to target collection(s)

## EXAMPLES

### Example 1: Copy offers from source collection to target collections.
```powershell
$payload = @{OfferIdsList = "aumatics.azure_managedservices"; Operation = "Copy"; TargetCollection = "3ac32d8c-e888-4dc6-b4ff-be4d755af13a"}
Copy-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -Payload $payload
```

```output
Failed Succeeded
------ ---------
{}     {DefaultCollection}
```

This command copy offers from source collection to target collections.

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: Transfer, TransferExpanded
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: TransferViaIdentity, TransferViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OfferIdList
Offers ids list to transfer from source collection to target collection(s)

```yaml
Type: System.String[]
Parameter Sets: TransferExpanded, TransferViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
Operation to perform (For example: Copy or Move)

```yaml
Type: System.String
Parameter Sets: TransferExpanded, TransferViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
Transfer offers properties
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.ITransferOffersProperties
Parameter Sets: Transfer, TransferViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateStoreId
The store ID - must use the tenant ID

```yaml
Type: System.String
Parameter Sets: Transfer, TransferExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetCollection
Target collections ids

```yaml
Type: System.String[]
Parameter Sets: TransferExpanded, TransferViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.ITransferOffersProperties

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.ITransferOffersResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IMarketplaceIdentity>`: Identity Parameter
  - `[AdminRequestApprovalId <String>]`: The admin request approval ID to get create or update
  - `[CollectionId <String>]`: The collection ID
  - `[Id <String>]`: Resource identity path
  - `[OfferId <String>]`: The offer ID to update or delete
  - `[PrivateStoreId <String>]`: The store ID - must use the tenant ID
  - `[RequestApprovalId <String>]`: The request approval ID to get create or update

PAYLOAD `<ITransferOffersProperties>`: Transfer offers properties
  - `[OfferIdsList <String[]>]`: Offers ids list to transfer from source collection to target collection(s)
  - `[Operation <String>]`: Operation to perform (For example: Copy or Move)
  - `[TargetCollection <String[]>]`: Target collections ids

## RELATED LINKS

