---
external help file:
Module Name: Az.Marketplace
online version: https://docs.microsoft.com/powershell/module/az.marketplace/set-azmarketplacebulkprivatestorecollectionaction
schema: 2.0.0
---

# Set-AzMarketplaceBulkPrivateStoreCollectionAction

## SYNOPSIS
Perform an action on bulk collections

## SYNTAX

### BulkExpanded (Default)
```
Set-AzMarketplaceBulkPrivateStoreCollectionAction -PrivateStoreId <String> [-Action <String>]
 [-CollectionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Bulk
```
Set-AzMarketplaceBulkPrivateStoreCollectionAction -PrivateStoreId <String> -Payload <IBulkCollectionsPayload>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Perform an action on bulk collections

## EXAMPLES

### Example 1: Preforms bulk action on collections 
```powershell
Set-AzMarketplaceBulkPrivateStoreCollectionAction -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a -Payload @{Action = "EnableCollections"; CollectionId = "3ac32d8c-e888-4dc6-b4ff-be4d755af13a", "fdb889a1-cf3e-49f0-95b8-2bb012fa01f1" }
```

```output
Failed Succeeded
------ ---------
{}     {DefaultCollection, test}
```

This command Preforms bulk action on collections

## PARAMETERS

### -Action
Action to perform (For example: EnableCollections, DisableCollections)

```yaml
Type: System.String
Parameter Sets: BulkExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionId
collection ids list that the action is performed on

```yaml
Type: System.String[]
Parameter Sets: BulkExpanded
Aliases:

Required: False
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

### -Payload
Bulk collections action properties
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IBulkCollectionsPayload
Parameter Sets: Bulk
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
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IBulkCollectionsPayload

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IBulkCollectionsResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PAYLOAD `<IBulkCollectionsPayload>`: Bulk collections action properties
  - `[Action <String>]`: Action to perform (For example: EnableCollections, DisableCollections)
  - `[CollectionId <String[]>]`: collection ids list that the action is performed on

## RELATED LINKS

