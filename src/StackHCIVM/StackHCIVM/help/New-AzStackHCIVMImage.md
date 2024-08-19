---
external help file: Az.StackHCIVM-help.xml
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmimage
schema: 2.0.0
---

# New-AzStackHCIVMImage

## SYNOPSIS
The operation to create an image.
Please note some properties can be set only during  image creation.

## SYNTAX

### MarketplaceURN (Default)
```
New-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 -CustomLocationId <String> -OSType <Object> -URN <String> [-CloudInitDataSource <String>]
 [-StoragePathName <String>] [-StoragePathResourceGroup <String>] [-StoragePathId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GalleryImage
```
New-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 -CustomLocationId <String> -OSType <Object> [-CloudInitDataSource <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-StoragePathId <String>] [-Tag <Hashtable>] -ImagePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Marketplace
```
New-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 -CustomLocationId <String> -OSType <Object> [-CloudInitDataSource <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-StoragePathId <String>] [-Tag <Hashtable>] -Offer <String>
 -Publisher <String> -Sku <String> -Version <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to create an image.
Please note some properties can be set only during image creation.

## EXAMPLES

### Example 1: Create a  Gallery Image
```powershell
New-AzStackHCIVMImage -Name "testImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -ImagePath "C:\ClusterStorage\Volume1\Ubunut.vhdx" -OSType "Linux" -Location "eastus"
```

```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```

This command creates a gallery image from a local path.

### Example 2:  Create a Marketplace Gallery Image
```powershell
New-AzStackHCIVMImage -Name "testMarketplaceImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -Offer "windowsserver" -Publisher "MicrosoftWindowsServer" -Sku "2022-Datacenter" -Version "latest" -OSType "Windows"
```

```output
Name            ResourceGroupName
----            -----------------
testMarketplaceImage       test-rg
```

This command creates a marketplace gallery image using the specified offer , publisher, sku and version.

### Example 3: {Create a  Marketplace Gallery Image From URN
```powershell
New-AzStackHCIVMImage -Name "testMarketplaceImageURN" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -URN  "microsoftwindowsserver:windowsserver:2022-datacenter:latest" -OSType "Windows"
```

```output
Name            ResourceGroupName
----            -----------------
testMarketplaceImageURN       test-rg
```

This command creates a marketplace gallery image using the specified urn.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudInitDataSource
Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]

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
The name must start and end with an alphanumeric character and must contain all alphanumeric characters or '-', '.', or '_'.
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

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Type: System.Object
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImages

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages

## NOTES

## RELATED LINKS
