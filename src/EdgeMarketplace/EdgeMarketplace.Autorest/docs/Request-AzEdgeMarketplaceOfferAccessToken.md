---
external help file:
Module Name: Az.EdgeMarketplace
online version: https://learn.microsoft.com/powershell/module/az.edgemarketplace/request-azedgemarketplaceofferaccesstoken
schema: 2.0.0
---

# Request-AzEdgeMarketplaceOfferAccessToken

## SYNOPSIS
Request Edge Marketplace Offer Access Token.

## SYNTAX

```
Request-AzEdgeMarketplaceOfferAccessToken -EdgeMarketplaceRegion <String> -OfferId <String>
 -ResourceUri <String> [-DefaultProfile <PSObject>] [-DeviceSku <String>] [-DeviceVersion <String>]
 [-EdgeMarketplaceResourceId <String>] [-HypervGeneration <String>] [-MarketplaceSku <String>]
 [-MarketplaceSkuVersion <String>] [-PublisherName <String>] [-Timeout <Int32>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The Request-AzEdgeMarketplaceOfferAccessToken cmdlet generates an access token for an Edge Marketplace offer
by first creating a token request (using New-AzEdgeMarketplaceOfferAccessToken with -NoWait), polling the operation 
status to extract the requestId, and then retrieving the completed token (using Get-AzEdgeMarketplaceOfferAccessToken).

This is a convenience cmdlet that combines both operations into a single synchronous command.

## EXAMPLES

### Example 1: Request access token
```powershell
Request-AzEdgeMarketplaceOfferAccessToken -OfferId offerId -ResourceUri resourceUri -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion xxxxx.xxxx.xxxxxxx
```

```output
AccessToken
-----------
https://accesstokenlink
```

This command used to request access token using expanded parameters.

### Example 2: Request access token with Timeout parameter
```powershell
Request-AzEdgeMarketplaceOfferAccessToken -OfferId offerId -ResourceUri resourceUri -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion xxxxx.xxxx.xxxxxxx -Timeout 45
```

```output
AccessToken
-----------
https://accesstokenlink
```

This command used to request access token using expanded parameters and customised timeout parameter.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceSku
The device sku

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceVersion
The device sku version

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EdgeMarketplaceRegion
The region where the disk will be created

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

### -EdgeMarketplaceResourceId
The edge marketplace resource id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HypervGeneration
The hyperv generation version

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSku
The marketplace sku

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSkuVersion
The marketplace sku version

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferId
Id of the offer

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

### -PublisherName
The name of the publisher

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource

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

### -Timeout
The maximum time in minutes to wait for the operation to complete.
Default is 30 minutes.

```yaml
Type: System.Int32
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IDiskAccessToken

## NOTES

## RELATED LINKS

