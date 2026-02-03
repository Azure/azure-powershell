---
external help file:
Module Name: Az.EdgeMarketplace
online version: https://learn.microsoft.com/powershell/module/az.edgemarketplace/invoke-azedgemarketplaceofferaccesstokengeneration
schema: 2.0.0
---

# Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration

## SYNOPSIS
Invoke Edge Marketplace Offer Access Token Generation.

## SYNTAX

```
Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration -EdgeMarketplaceRegion <String> -OfferId <String>
 -ResourceUri <String> [-DefaultProfile <PSObject>] [-DeviceSku <String>] [-DeviceVersion <String>]
 [-EdgeMarketplaceResourceId <String>] [-HypervGeneration <String>] [-MarketplaceSku <String>]
 [-MarketplaceSkuVersion <String>] [-PublisherName <String>] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration cmdlet generates an access token for an Edge Marketplace offer
by first creating a token request (using New-AzEdgeMarketplaceOfferAccessToken with -NoWait), polling the operation 
status to extract the requestId, and then retrieving the completed token (using Get-AzEdgeMarketplaceOfferAccessToken).

This is a convenience cmdlet that combines both operations into a single synchronous command.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

