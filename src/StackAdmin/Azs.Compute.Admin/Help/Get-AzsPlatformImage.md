---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version: 
schema: 2.0.0
---

# Get-AzsPlatformImage

## SYNOPSIS
Returns virtual machine images loaded into the platform image repository.

## SYNTAX

### List (Default)
```
Get-AzsPlatformImage [-Location <String>] [<CommonParameters>]
```

### Get
```
Get-AzsPlatformImage -Publisher <String> -Offer <String> -Sku <String> -Version <String> [-Location <String>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzsPlatformImage -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns platform images.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsPlatformImage -Location local
```

Id                             Type                           Name                           Location
--                             ----                           ----                           --------
/subscriptions/0dbab76e-037...
Microsoft.Compute.Admin/loc... 
local
/subscriptions/0dbab76e-037...
Microsoft.Compute.Admin/loc... 
local
/subscriptions/0dbab76e-037...
Microsoft.Compute.Admin/loc... 
local

Returns virtual machine images loaded into the platform image repository at the location local.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsPlatformImage -Location "local" -Publisher Canonical -Offer UbuntuServer -Sku 16.04-LTS -Version 0.1.0
```

Id                             Type                           Name                           Location
--                             ----                           ----                           --------
/subscriptions/0dbab76e-037...
Microsoft.Compute.Admin/loc... 
local

Get a specific platform image.

## PARAMETERS

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offer
Name of the offer.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
Name of the publisher.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Sku
Name of the SKU.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The version of the platform image.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Compute.Admin.Models.PlatformImage

## NOTES

## RELATED LINKS

