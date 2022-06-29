---
external help file:
Module Name: Az.Marketplace
online version: https://docs.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestorev1
schema: 2.0.0
---

# Get-AzMarketplacePrivateStoreV1

## SYNOPSIS
Get information about the private store

## SYNTAX

### List (Default)
```
Get-AzMarketplacePrivateStoreV1 [-UseCache <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMarketplacePrivateStoreV1 -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMarketplacePrivateStoreV1 -InputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get information about the private store

## EXAMPLES

### Example 1: Get Private Store details
```powershell
Get-AzMarketplacePrivateStoreV1
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
a260d38c-96cf-492d-a340-404d0c4b3ad6                                         User                    12/1/2021 9:01:33 PM                              User
```

This command Gets the private store details


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

### -Id
The store ID - must use the tenant ID

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrivateStoreId

Required: True
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

### -UseCache
Determines if to use cache or DB for serving this request

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IPrivateStore

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

