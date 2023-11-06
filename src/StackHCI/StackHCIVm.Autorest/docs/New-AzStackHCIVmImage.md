---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhcivmimage
schema: 2.0.0
---

# New-AzStackHCIVmImage

## SYNOPSIS
The operation to create an image.
Please note some properties can be set only during  image creation.

## SYNTAX

### MarketplaceURN (Default)
```
New-AzStackHCIVmImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -OSType <OperatingSystemTypes> -URN <String> [-SubscriptionId <String>]
 [-CloudInitDataSource <CloudInitDataSource>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GalleryImage
```
New-AzStackHCIVmImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImagePath <String> -Location <String> -OSType <OperatingSystemTypes> [-SubscriptionId <String>]
 [-CloudInitDataSource <CloudInitDataSource>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Marketplace
```
New-AzStackHCIVmImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -Offer <String> -OSType <OperatingSystemTypes> -Publisher <String> -Sku <String> -Version <String>
 [-SubscriptionId <String>] [-CloudInitDataSource <CloudInitDataSource>] [-StoragePathId <String>]
 [-StoragePathName <String>] [-StoragePathResourceGroup <String>] [-Tag <Hashtable>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to create an image.
Please note some properties can be set only during image creation.

## EXAMPLES

### Example 1: Create a  Gallery Image 
```powershell
PS C:\> New-AzStackHCIVmImage -Name "testImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -ImagePath "C:\ClusterStorage\Volume1\Ubunut.vhdx" -OSType "Linux" -Location "eastus" 
```

```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```
This command creates a gallery image from a local path.

### Example 2:  Create a Marketplace Gallery Image 
```powershell
PS C:\> New-AzStackHCIVmImage -Name "testMarketplaceImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -Offer "windowsserver" -Publisher "MicrosoftWindowsServer" -Sku "2022-Datacenter" -Version "latest" -OSType "Windows"
```

```output
Name            ResourceGroupName
----            -----------------
testMarketplaceImage       test-rg
```
This command creates a marketplace gallery image using the specified offer , publisher, sku and version.

### Example 3: {Create a  Marketplace Gallery Image From URN 
```powershell
PS C:\> New-AzStackHCIVmImage -Name "testMarketplaceImageURN" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -URN  "microsoftwindowsserver:windowsserver:2022-datacenter:latest" -OSType "Windows"
```

```output
Name            ResourceGroupName
----            -----------------
testMarketplaceImageURN       test-rg
```
This command creates a marketplace gallery image using the specified urn.

## PARAMETERS

### -CloudInitDataSource
Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomLocationId
The ARM Id of the extended location to create image resource in.

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

### -ImagePath
Local path of image that the image should be created from.

This parameter is required for non marketplace images.

```yaml
Type: System.String
Parameter Sets: GalleryImage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
Name of the Image
The name must start and end with an alphanumeric character and must contain all alphanumeric characters or ‘-‘, ‘.’, or ‘_’.
The max length can be 80 characters and the minimum length is 1 character.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offer
The name of the marketplae gallery image definition offer.

```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
Operating system type that the gallery image uses [Windows, Linux]

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
The name of the marketplace gallery image definition publisher.

```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -Sku
The name of the marketplace gallery image definition SKU.

```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePathId
Storage ContainerID of the storage container to be used for gallery image

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

### -StoragePathName
Storage Container Name of the storage container to be used for gallery image

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

### -StoragePathResourceGroup
Resource Group of the Storage Path.
The Default value is the Resource Group of the Image.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -URN
The URN of the marketplace gallery image.

```yaml
Type: System.String
Parameter Sets: MarketplaceURN
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The version of the marketplace gallery image.

```yaml
Type: System.String
Parameter Sets: Marketplace
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImages

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IMarketplaceGalleryImages

## NOTES

ALIASES

## RELATED LINKS

