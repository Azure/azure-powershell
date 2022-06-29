---
external help file:
Module Name: Az.Marketplace
online version: https://docs.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestorecollectionoffer
schema: 2.0.0
---

# Get-AzMarketplacePrivateStoreCollectionOffer

## SYNOPSIS
Gets information about a specific offer.

## SYNTAX

### List (Default)
```
Get-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -PrivateStoreId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String> -PrivateStoreId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMarketplacePrivateStoreCollectionOffer -InputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about a specific offer.

## EXAMPLES

### Example 1: Gets collection offers.
```powershell
Get-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId a260d38c-96cf-492d-a340-404d0c4b3ad6
```

```output
Name                                            SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                        			------------------- ------------------- ----------------------- ------------------------ ------------------------ -------------------
data3-limited-1019419.d3_azure_managed_services
viacode_consulting-1089577.viacodems
RedHat.RHEL_7
```

This command get colletion offer

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentity
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
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateStoreId
The store ID - must use the tenant ID

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IOffer

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

## RELATED LINKS

