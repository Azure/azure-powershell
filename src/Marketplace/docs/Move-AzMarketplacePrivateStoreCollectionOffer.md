---
external help file:
Module Name: Az.Marketplace
online version: https://docs.microsoft.com/powershell/module/az.marketplace/move-azmarketplaceprivatestorecollectionoffer
schema: 2.0.0
---

# Move-AzMarketplacePrivateStoreCollectionOffer

## SYNOPSIS
transferring offers (copy or move) from source collection to target collection(s)

## SYNTAX

### TransferExpanded (Default)
```
Move-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -PrivateStoreId <String>
 [-OfferIdsList <String[]>] [-Operation <String>] [-TargetCollection <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Transfer
```
Move-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -PrivateStoreId <String>
 -Payload <ITransferOffersProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TransferViaIdentity
```
Move-AzMarketplacePrivateStoreCollectionOffer -InputObject <IMarketplaceIdentity>
 -Payload <ITransferOffersProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TransferViaIdentityExpanded
```
Move-AzMarketplacePrivateStoreCollectionOffer -InputObject <IMarketplaceIdentity> [-OfferIdsList <String[]>]
 [-Operation <String>] [-TargetCollection <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
transferring offers (copy or move) from source collection to target collection(s)

## EXAMPLES

### Example 1: Gets private store offers regardless of collections 
```powershell
PS C:\> Invoke-AzMarketplaceQueryPrivateStoreOffer -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a

CreatedAt ETag                                   ModifiedAt OfferDisplayName PrivateStoreId                       PublisherDisplayName SpecificPlanIdsLimitation                                                     UniqueOfferId
--------- ----                                   ---------- ---------------- --------------                       -------------------- -------------------------                                                     -------------
          "ed0093ae-0000-0100-0000-61a4dab30000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {d3-azure-health-check, data3-azure-optimiser-plan, data3-managed-azure-plan} data3-limite…
          "750547d8-0000-0100-0000-61b752010000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {mgmt-limited-free, mgmt-assessment}                                          viacode_cons…
          "ef00ab05-0000-0100-0000-61a5f12f0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {RedHatEnterpriseLinux72-ARM}                                                 RedHat.RHEL_7
          "f300276b-0000-0100-0000-61a7e1af0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {128technology_conductor_hourly_427, 128technology_conductor_hourly_452}      128technolog…
          "f300296b-0000-0100-0000-61a7e1af0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {128technology_router_100_hourly_427, 128technology_router_100_hourly_452}    128technolog…

This command gets private store offers regardless of collections 

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

### -OfferIdsList
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


INPUTOBJECT <IMarketplaceIdentity>: Identity Parameter
  - `[AdminRequestApprovalId <String>]`: The admin request approval ID to get create or update
  - `[CollectionId <String>]`: The collection ID
  - `[Id <String>]`: Resource identity path
  - `[OfferId <String>]`: The offer ID to update or delete
  - `[PrivateStoreId <String>]`: The store ID - must use the tenant ID
  - `[RequestApprovalId <String>]`: The request approval ID to get create or update

PAYLOAD <ITransferOffersProperties>: Transfer offers properties
  - `[OfferIdsList <String[]>]`: Offers ids list to transfer from source collection to target collection(s)
  - `[Operation <String>]`: Operation to perform (For example: Copy or Move)
  - `[TargetCollection <String[]>]`: Target collections ids

## RELATED LINKS

