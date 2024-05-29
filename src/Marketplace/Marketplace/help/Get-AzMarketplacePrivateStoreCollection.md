---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplaceprivatestorecollection
schema: 2.0.0
---

# Get-AzMarketplacePrivateStoreCollection

## SYNOPSIS
Gets private store collection

## SYNTAX

### List (Default)
```
Get-AzMarketplacePrivateStoreCollection -PrivateStoreId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateStore
```
Get-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreInputObject <IMarketplaceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMarketplacePrivateStoreCollection -InputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets private store collection

## EXAMPLES

### Example 1: Get list of private store collections
```powershell
Get-AzMarketplacePrivateStoreCollection -PrivateStoreId 53425a7b-4ac1-4729-8340-e1da5046212c
```

```output
Name                                 SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                                 -------------------  ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
53425a7b-4ac1-4729-8340-e1da5046212c                                          User                    8/23/2021 6:06:52 AM                              User
23455a7b-4ac1-4729-8340-e1da5046212c 12/1/2021 9:01:33 PM                     User                    12/1/2021 9:01:33 PM                              User
```

This command gets list of private store collections.

## PARAMETERS

### -CollectionId
The collection ID

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateStore, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollection

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollectionsList

## NOTES

## RELATED LINKS
