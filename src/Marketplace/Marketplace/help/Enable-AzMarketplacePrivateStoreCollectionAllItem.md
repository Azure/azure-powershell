---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/enable-azmarketplaceprivatestorecollectionallitem
schema: 2.0.0
---

# Enable-AzMarketplacePrivateStoreCollectionAllItem

## SYNOPSIS
Delete all existing offers from the collection and enable approve all items.

## SYNTAX

### Approve (Default)
```
Enable-AzMarketplacePrivateStoreCollectionAllItem -CollectionId <String> -PrivateStoreId <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApproveViaIdentityPrivateStore
```
Enable-AzMarketplacePrivateStoreCollectionAllItem -CollectionId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApproveViaIdentity
```
Enable-AzMarketplacePrivateStoreCollectionAllItem -InputObject <IMarketplaceIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete all existing offers from the collection and enable approve all items.

## EXAMPLES

### EXAMPLE 1
```
Enable-AzMarketplacePrivateStoreCollectionAllItem -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188
```

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: String
Parameter Sets: Approve, ApproveViaIdentityPrivateStore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IMarketplaceIdentity
Parameter Sets: ApproveViaIdentity
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
Type: String
Parameter Sets: Approve
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
Parameter Sets: ApproveViaIdentityPrivateStore
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
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollection
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IMarketplaceIdentity\>: Identity Parameter
  \[AdminRequestApprovalId \<String\>\]: The admin request approval ID to get create or update
  \[CollectionId \<String\>\]: The collection ID
  \[Id \<String\>\]: Resource identity path
  \[OfferId \<String\>\]: The offer ID to update or delete
  \[PrivateStoreId \<String\>\]: The store ID - must use the tenant ID
  \[RequestApprovalId \<String\>\]: The request approval ID to get create or update

PRIVATESTOREINPUTOBJECT \<IMarketplaceIdentity\>: Identity Parameter
  \[AdminRequestApprovalId \<String\>\]: The admin request approval ID to get create or update
  \[CollectionId \<String\>\]: The collection ID
  \[Id \<String\>\]: Resource identity path
  \[OfferId \<String\>\]: The offer ID to update or delete
  \[PrivateStoreId \<String\>\]: The store ID - must use the tenant ID
  \[RequestApprovalId \<String\>\]: The request approval ID to get create or update

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.marketplace/enable-azmarketplaceprivatestorecollectionallitem](https://learn.microsoft.com/powershell/module/az.marketplace/enable-azmarketplaceprivatestorecollectionallitem)

