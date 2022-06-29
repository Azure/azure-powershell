---
external help file:
Module Name: Az.Marketplace
online version: https://docs.microsoft.com/powershell/module/az.marketplace/get-azmarketplacecollectiontosubscriptionmapping
schema: 2.0.0
---

# Get-AzMarketplaceCollectionToSubscriptionMapping

## SYNOPSIS
For a given subscriptions list, the API will return a map of collections and the related subscriptions from the supplied list.

## SYNTAX

### CollectionsExpanded (Default)
```
Get-AzMarketplaceCollectionToSubscriptionMapping -PrivateStoreId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Collections
```
Get-AzMarketplaceCollectionToSubscriptionMapping -PrivateStoreId <String>
 -Payload <ICollectionsToSubscriptionsMappingPayload> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CollectionsViaIdentity
```
Get-AzMarketplaceCollectionToSubscriptionMapping -InputObject <IMarketplaceIdentity>
 -Payload <ICollectionsToSubscriptionsMappingPayload> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CollectionsViaIdentityExpanded
```
Get-AzMarketplaceCollectionToSubscriptionMapping -InputObject <IMarketplaceIdentity>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
For a given subscriptions list, the API will return a map of collections and the related subscriptions from the supplied list.

## EXAMPLES

### Example 1: For a given subscriptions list, the Cmdlet will return a map of collections and the related subscriptions from the supplied list.
```powershell
$res = Get-AzMarketplaceCollectionToSubscriptionMapping -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -Payload @{SubscriptionId = "53425a7b-4ac1-4729-8340-e1da5046212c"}
$res.keys
```

```output
e58535dc-1be3-4d2c-904c-1f97984ebe5d
fdb889a1-cf3e-49f0-95b8-2bb012fa01f1
```

This command For a given subscriptions list, will return a map of collections and the related subscriptions from the supplied list.

## PARAMETERS

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
Parameter Sets: CollectionsViaIdentity, CollectionsViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Payload
The subscriptions list to get the related collections
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.ICollectionsToSubscriptionsMappingPayload
Parameter Sets: Collections, CollectionsViaIdentity
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
Parameter Sets: Collections, CollectionsExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscriptions ids list

```yaml
Type: System.String[]
Parameter Sets: CollectionsExpanded, CollectionsViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.ICollectionsToSubscriptionsMappingPayload

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.ICollectionsToSubscriptionsMappingResponseProperties

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

PAYLOAD `<ICollectionsToSubscriptionsMappingPayload>`: The subscriptions list to get the related collections
  - `[SubscriptionId <String[]>]`: Subscriptions ids list

## RELATED LINKS

