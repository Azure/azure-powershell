---
external help file:
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplacecollectiontosubscriptionmapping
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

### CollectionsViaJsonFilePath
```
Get-AzMarketplaceCollectionToSubscriptionMapping -PrivateStoreId <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CollectionsViaJsonString
```
Get-AzMarketplaceCollectionToSubscriptionMapping -PrivateStoreId <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
For a given subscriptions list, the API will return a map of collections and the related subscriptions from the supplied list.

## EXAMPLES

### Example 1: Map subscriptions to collections
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: CollectionsViaIdentity, CollectionsViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Collections operation

```yaml
Type: System.String
Parameter Sets: CollectionsViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Collections operation

```yaml
Type: System.String
Parameter Sets: CollectionsViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
The subscriptions list to get the related collections
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollectionsToSubscriptionsMappingPayload
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
Parameter Sets: Collections, CollectionsExpanded, CollectionsViaJsonFilePath, CollectionsViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollectionsToSubscriptionsMappingPayload

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollectionsToSubscriptionsMappingResponse

## NOTES

## RELATED LINKS

