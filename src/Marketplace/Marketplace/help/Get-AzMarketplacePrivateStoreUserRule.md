---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestoreuserrule
schema: 2.0.0
---

# Get-AzMarketplacePrivateStoreUserRule

## SYNOPSIS
All rules approved in the private store that are relevant for user subscriptions

## SYNTAX

### QueryExpanded (Default)
```
Get-AzMarketplacePrivateStoreUserRule -PrivateStoreId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### QueryViaIdentityExpanded
```
Get-AzMarketplacePrivateStoreUserRule -InputObject <IMarketplaceIdentity> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
All rules approved in the private store that are relevant for user subscriptions

## EXAMPLES

### EXAMPLE 1
```
Get-AzMarketplacePrivateStoreUserRule -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionId 1f58b5dd-313c-42ed-84fc-f1e351bba7fb
```

## PARAMETERS

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
Parameter Sets: QueryViaIdentityExpanded
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
Parameter Sets: QueryExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -SubscriptionId
List of subscription IDs

```yaml
Type: String[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IRuleListResponse
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

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestoreuserrule](https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestoreuserrule)

