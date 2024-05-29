---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestorecollectionoffer
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

### GetViaIdentityPrivateStore
```
Get-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String>
 -PrivateStoreInputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMarketplacePrivateStoreCollectionOffer -CollectionId <String> -OfferId <String> -PrivateStoreId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCollection
```
Get-AzMarketplacePrivateStoreCollectionOffer -OfferId <String> -CollectionInputObject <IMarketplaceIdentity>
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

### Example 1: Gets collection offers
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

This command get collection offers.

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityPrivateStore, Get
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
Parameter Sets: GetViaIdentityCollection
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

### -InputObject
Identity Parameter

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
Parameter Sets: GetViaIdentityPrivateStore, Get, GetViaIdentityCollection
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
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentityPrivateStore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IOffer

## NOTES

## RELATED LINKS
