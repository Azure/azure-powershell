---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/new-azgalleryimageversion
schema: 2.0.0
---

# New-AzGalleryImageVersion

## SYNOPSIS

Create a gallery image version.

## SYNTAX

```
New-AzGalleryImageVersion [-ResourceGroupName] <String> [-GalleryName] <String>
 [-GalleryImageDefinitionName] <String> [-Name] <String> [-AsJob] -Location <String>
 [-DataDiskImage <GalleryDataDiskImage[]>] [-OSDiskImage <GalleryOSDiskImage>]
 [-PublishingProfileEndOfLifeDate <DateTime>] [-PublishingProfileExcludeFromLatest] [-ReplicaCount <Int32>]
 [-SourceImageId <String>] [-StorageAccountType <String>] [-Tag <Hashtable>] [-TargetRegion <Hashtable[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

Create a gallery image version.

## EXAMPLES

### Example 1: Create an image version from a virtual machine

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$sourceImageId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myVMRG/providers/Microsoft.Compute/virtualMachines/myVM"
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId
```

Add a new image version from a virtual machine into the image definition.

### Example 2: Create an image version from a managed image

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$sourceImageId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myImageRG/providers/Microsoft.Compute/images/myImage"
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId
```

Add a new image version from a managed image into the image definition.

### Example 3: Create an image version from an another image version

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$sourceImageId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myImageRG/providers/Microsoft.Compute/galleries/myOtherGallery/images/myImageDefinition/versions/1.0.0"
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId
```

Copy an image version into another image version

### Example 4: Add a new image version from a managed disk

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$osDisk = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myDiskRG/providers/Microsoft.Compute/disks/myOSDisk" }}
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -OSDiskImage $osDisk
```

Create an image version from a managed disk

### Example 5: Add a new image version from a managed disk and add additional data disks

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$osDisk = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myDiskRG/providers/Microsoft.Compute/disks/myOSDisk" }}
$dataDisk0 = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myDiskRG/providers/Microsoft.Compute/disks/myDataDisk" }; Lun = 0; }
$dataDisks = @($dataDisk0)
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -OSDiskImage $osDisk  -DataDiskImage $dataDisks
```

Create an image version by specifying OS and data disks

### Example 6: Add a new image version from a snapshot of an OS disk

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$osSnapshot = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mySnapshotRG/providers/Microsoft.Compute/snapshots/myOSSnapshot" }}
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -OSDiskImage $osDisk
```

Create an image version from a disk snapshot

### Example 7: Add a new image version from a snapshot of an OS disk and add additional data disks

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$osSnapshot = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mySnapshotRG/providers/Microsoft.Compute/snapshots/myOSSnapshot" }}
$dataSnapshot0 = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mySnapshotRG/providers/Microsoft.Compute/snapshots/myDataSnapshot" }; Lun = 0; }
$dataDisks = @($dataSnapshot0)
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -OSDiskImage $osSnapshot  -DataDiskImage $dataDisks
```

Create an image version by specifying snapshots for OS and data disks.

### Example 8: Add a new image version from a combination of disks and snapshots

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$osSnapshot = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mySnapshotRG/providers/Microsoft.Compute/snapshots/myOSSnapshot" }}
$dataDisk0 = @{Source = @{Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myDiskRG/providers/Microsoft.Compute/disks/myDataDisk" }; Lun = 0; }
$dataDisks = @($dataDisk0)
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -OSDiskImage $osSnapshot  -DataDiskImage $dataDisks
```

Create an image version by specifying a snapshot as an OS disk and a managed disk as a data disk.

### Example 9: Add a new image version and copy it to additional regions.

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$sourceImageId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myVMRG/providers/Microsoft.Compute/virtualMachines/myVM"
$replicaCount = 1
$storageAccountType = "Standard_ZRS"
$region_eastus = @{Name = 'East US';ReplicaCount = 3;StorageAccountType = 'Standard_LRS'}
$region_westus = @{Name = 'West US'}
$region_ukwest = @{Name = 'UK West';ReplicaCount = 2}
$region_southcentralus = @{Name = 'South Central US';StorageAccountType = 'Standard_LRS'}
$targetRegions = @($region_eastus, $region_westus, $region_ukwest, $region_southcentralus)
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId -ReplicaCount 1 -StorageAccountType $storageAccountType -TargetRegion $targetRegions
```

Create an image version in four regions. In this example, the global replica count is 1 and the global storage account type is Standard_ZRS. East US will have 3 replicas, each stored on Standard_LRS account storage. West US will inherit from global settings and have 1 replica stored on Standard_ZRS. UK West will have a replica count of 2 stored on Standard_ZRS. South Central US will have one replica stored on Standard_LRS.

### Example 10: Add a new image version with encryption in multiple regions

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$sourceImageId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myVMRG/providers/Microsoft.Compute/virtualMachines/myVM"
$replicaCount = 1
$storageAccountType = "Standard_ZRS"

# East US regional settings
$eastUSdes = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myDESrg/providers/Microsoft.Compute/diskEncryptionSets/myEastUSDES"
$encryption_eastus_os = @{DiskEncryptionSetId = $eastUSdes }
$encryption_eastus_dd0 = @{DiskEncryptionSetId = $eastUSdes; Lun = 0 }
$encryption_eastus_dd = @($encryption_eastus_dd0)
$eastus_encryption = @{OSDiskImage = $eastus_encryption_os; DataDiskImages = $eastus_encryption_dd }
$region_eastus = @{Name = 'East US';ReplicaCount = 3;StorageAccountType = 'Standard_LRS'; Encryption = $encryption_eastus}

# West US regional settings
$westUS2des = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myDESrg/providers/Microsoft.Compute/diskEncryptionSets/myWestUSDES"
$encryption_westus_os = @{DiskEncryptionSetId = $westUSdes }
$encryption_westus_dd0 = @{DiskEncryptionSetId = $westUSdes; Lun = 0 }
$encryption_westus_dd = @($encryption_westus_dd0)
$westus_encryption = @{OSDiskImage = $encryption_westus_os; DataDiskImages = $encryption_westus_dd }
$region_westus = @{Name = 'West US'; Encryption = $westus_encryption}

# Create images
$targetRegions = @($region_eastus, $region_westus)
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId -TargetRegion $targetRegions
```

Create an image version with encryption in two regions. Disk encryption sets are regional resources and a different disk encryption set must be used in each region.

### Example 11: Create an image version and have it excluded from latest

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId -PublishingProfileExcludeFromLatest
```

Add a new image version into an image definition but exclude it from being considered for latest version within its image definition.

### Example 12: Create an image version and set its end-of-life date

```powershell
$rgName = "myResourceGroup"
$galleryName = "myGallery"
$galleryImageDefinitionName = "myImage"
$galleryImageVersionName = "1.0.0"
$location = "eastus"
$endOfLifeDate = "2024-08-02T00:00:00+00:00"
New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageDefinitionName -Name $galleryImageVersionName -Location $location -SourceImageId $sourceImageId -PublishingProfileEndOfLifeDate $endOfLifeDate
```

This example has the end-of-life date for image version set to August 2, 2024 at mignight UTC. End-of-life dates can be specified for both the image definitions and image versions. Image versions can still be used after the end-of-life dates.

## PARAMETERS

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

### -DataDiskImage

Data disk images. e.g. @{Source = @{Id = <source_id>}; Lun = 1; SizeInGB = 100; HostCaching = "ReadOnly" }

```yaml
Type: Microsoft.Azure.Management.Compute.Models.GalleryDataDiskImage[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -GalleryImageDefinitionName

The name of the gallery.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
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

### -Location

Resource location

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

### -Name

The name of the gallery image version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GalleryImageVersionName

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OSDiskImage

OS disk image e.g. @{Source = @{Id = <source_id>}; SizeInGB = 100; HostCaching = "ReadOnly" }

```yaml
Type: Microsoft.Azure.Management.Compute.Models.GalleryOSDiskImage
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublishingProfileEndOfLifeDate

The end of life date of the gallery Image Version.

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

### -PublishingProfileExcludeFromLatest

If it is set, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ReplicaCount

The number of replicas of the Image Version to be created per region.

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

### -SourceImageId

The ID of the source image from which the Image Version is going to be created.

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

### -StorageAccountType

Specifies the storage account type to be used to store the image. This property is not updatable. Available values are Standard_LRS, Standard_ZRS and Premium_LRS.

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

### -TargetRegion

The target regions where the Image Version is going to be replicated to.

```yaml
Type: System.Collections.Hashtable[]
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

### System.Collections.Hashtable

### System.Int32

### System.Management.Automation.SwitchParameter

### System.DateTime

### System.Collections.Hashtable[]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryImageVersion

## NOTES

## RELATED LINKS
