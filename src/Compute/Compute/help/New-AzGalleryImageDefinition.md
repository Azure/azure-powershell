---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/new-azgalleryimagedefinition
schema: 2.0.0
---

# New-AzGalleryImageDefinition

## SYNOPSIS

Create a gallery image definition.

## SYNTAX

```
New-AzGalleryImageDefinition [-ResourceGroupName] <String> [-GalleryName] <String> [-Name] <String> [-AsJob]
 [-Location] <String> -Publisher <String> -Offer <String> -Sku <String> -OsState <OperatingSystemStateTypes>
 -OsType <OperatingSystemTypes> [-Description <String>] [-DisallowedDiskType <String[]>]
 [-EndOfLifeDate <DateTime>] [-Eula <String>] [-HyperVGeneration <String>] [-MinimumMemory <Int32>]
 [-MinimumVCPU <Int32>] [-MaximumMemory <Int32>] [-MaximumVCPU <Int32>] [-PrivacyStatementUri <String>]
 [-PurchasePlanName <String>] [-PurchasePlanProduct <String>] [-PurchasePlanPublisher <String>]
 [-ReleaseNoteUri <String>] [-Tag <Hashtable>] [-Feature <GalleryImageFeature[]>] [-Architecture <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

Create a gallery image definition.

## EXAMPLES

### Example 1: Create an image definition for specialized linux images

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$description = "My gallery"
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Specialized" -OsType "Linux" -Description $description
```

Creates a gallery image definition to contain image versions for specialized linux images.

### Example 2: Create an image definition for generalized linux images

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$description = "My gallery"
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Linux" -Description $description
```

Creates a gallery image definition to contain image versions for generalized linux images.

### Example 3: Create an image definition for specialized windows images

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$description = "My gallery"
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Specialized" -OsType "Windows" -Description $description
```

Creates a gallery image definition to contain image versions for specialized windows images.

### Example 4: Create an image definition for generalized windows images and set features.

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$description = "My gallery"
$IsHibernateSupported = @{Name='IsHibernateSupported';Value='True'}
$IsAcceleratedNetworkSupported = @{Name='IsAcceleratedNetworkSupported';Value='False'}
$features = @($IsHibernateSupported,$IsAcceleratedNetworkSupported)
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Windows" -Description $description -Feature $features
```

Creates a gallery image definition to contain image versions for generalized windows images.

### Example 5: Create an image definition with plan information

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$purchasePlanName = "myPlanName"
$purchasePlanProduct = "myPlanProduct"
$purchasePlanPublisher = "myPlanPublisher"
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Linux" -PurchasePlanName $purchasePlanName -PurchasePlanProduct $purchasePlanProduct -PurchasePlanPublisher $purchasePlanPublisher
```

Creates a gallery image definition for linux generalized images and define the plan name, product, and publisher. Only image versions that match the plan information can be added to this definition.

### Example 6: Create an image definition and indicate end of life date

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$endOfLifeDate = "2024-08-02T00:00:00+00:00"
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Linux" -EndOfLifeDate $endOfLifeDate
```

This example has the end-of-life date for image definitions set to August 2, 2024 at mignight UTC. End-of-life dates can be specified for image definitions and image versions. Image definitions can still be used after the end-of-life dates.

### Example 7: Create an image definition and recommend minimum and maximum CPU and memory (GB)

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$minMemory = 32
$maxMemory = 128
$minVCPU = 2
$maxVCPU = 8
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Linux" -MinimumMemory $minMemory -MaximumMemory $maxMemory -MinimumVCPU $minVCPU -MaximumVCPU $maxVCPU
```

Creates a gallery image definition and recommends the minimum and maximum ranges for the CPU and memory that the image versions in this image definition support. Image versions can still be used to create virtual machines with memory and vCPU settings outside the recommended ranges.

### Example 8: Create an image definition and indicate which OS disk types are not recommended for the image

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$disallowedDiskTypes = @("Standard_LRS")
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Linux" -DisallowedDiskType $disallowedDiskTypes
```

Creates a gallery image definition and indicate which OS disk types may not be compatible with image versions within this image definition. Image versions can still be used to create virtual machines with an OS disk that is one of the disallowed disk types.

### Example 9: Create an image definition and provide the EULA, privacy statement URI, and release notes URI

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$location = "eastus"
$publisherName = "GreatPublisher"
$offerName = "GreatOffer"
$skuName = "GreatSku"
$eula = "https://myeula"
$privacyStatementUri = "https://mystatement"
$releaseNoteUri = "https://myreleasenotes"
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Generalized" -OsType "Linux" -Eula $eula -PrivacyStatementUri $privacyStatementUri -ReleaseNoteUri $releaseNoteUri
```

Creates a gallery image definition for linux generalized images and specify either the string or path to an EULA agreement, privacy statement, and release notes tied to all image versions in the image definition.

## PARAMETERS

### -Architecture
CPU architecture supported by an OS disk. Possible values are "X64" and "Arm64".

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AsJob

Run cmdlet in the background

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

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description

The description of the gallery image Definition resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisallowedDiskType

The disallowed disk types.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndOfLifeDate

The end of life date of the gallery Image Definition

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Eula

The Eula agreement for the gallery Image Definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Feature

A list of gallery image features.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.GalleryImageFeature[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryName

The name of the gallery.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HyperVGeneration

The hypervisor generation of the Virtual Machine. Applicable to OS disks only. Allowed values are V1 and V2.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location

Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaximumMemory

The maximum of the recommended memory

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaximumVCPU

The maximum of the recommended CPU core

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MinimumMemory

The minimum of the recommended memory

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MinimumVCPU

The minimum of the recommended CPU core

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name

The name of the gallery image definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GalleryImageDefinitionName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Offer

The name of the gallery Image Definition offer.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OsState

The state of OS

```yaml
Type: Microsoft.Azure.Management.Compute.Models.OperatingSystemStateTypes
Parameter Sets: (All)
Aliases:
Accepted values: Generalized, Specialized

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OsType

The type of OS

```yaml
Type: Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes
Parameter Sets: (All)
Aliases:
Accepted values: Windows, Linux

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivacyStatementUri

The privacy statement uri.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Publisher

The name of the gallery Image Definition publisher.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PurchasePlanName

The ID for the purchase plan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PurchasePlanProduct

The product ID for the purchase plan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PurchasePlanPublisher

The publisher ID for the purchase plan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ReleaseNoteUri

The release note uri.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName

The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Sku

The name of the gallery Image Definition SKU.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag

Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### Microsoft.Azure.Management.Compute.Models.OperatingSystemStateTypes

### Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes

### System.DateTime

### System.Collections.Hashtable

### System.Int32

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryImage

## NOTES

## RELATED LINKS
