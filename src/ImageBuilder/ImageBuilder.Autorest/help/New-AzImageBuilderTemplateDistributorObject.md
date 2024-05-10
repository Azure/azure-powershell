---
external help file:
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.ImageBuilder/new-azimagebuildertemplatedistributorobject
schema: 2.0.0
---

# New-AzImageBuilderTemplateDistributorObject

## SYNOPSIS
Create an in-memory object for ImageTemplateDistributor.

## SYNTAX

### VhdDistributor (Default)
```
New-AzImageBuilderTemplateDistributorObject -RunOutputName <String> -VhdDistributor
 [-ArtifactTag <IImageTemplateDistributorArtifactTags>] [-Uri <String>] [<CommonParameters>]
```

### ManagedImageDistributor
```
New-AzImageBuilderTemplateDistributorObject -ImageId <String> -Location <String> -ManagedImageDistributor
 -RunOutputName <String> [-ArtifactTag <IImageTemplateDistributorArtifactTags>] [<CommonParameters>]
```

### SharedImageDistributor
```
New-AzImageBuilderTemplateDistributorObject -GalleryImageId <String> -RunOutputName <String>
 -SharedImageDistributor [-ArtifactTag <IImageTemplateDistributorArtifactTags>] [-ExcludeFromLatest <Boolean>]
 [-ReplicationRegion <String[]>] [-StorageAccountType <SharedImageStorageAccountType>]
 [-TargetRegion <ITargetRegion[]>] [-Versioning <IDistributeVersioner>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ImageTemplateDistributor.

## EXAMPLES

### Example 1: Create a managed image distributor.
```powershell
New-AzImageBuilderTemplateDistributorObject -ManagedImageDistributor -ArtifactTag @{tag='azpstest'} -ImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image" -RunOutputName "runoutput-01" -Location eastus
```

```output
RunOutputName ImageId                                                                                                             Location
------------- -------                                                                                                             --------
runoutput-01  /subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image eastus
```

This command creates a managed image distributor.

### Example 2: Create a VHD distributor.
```powershell
New-AzImageBuilderTemplateDistributorObject -ArtifactTag @{tag='vhd'} -VhdDistributor -RunOutputName image-vhd
```

```output
RunOutputName Uri
------------- ---
image-vhd
```

This command creates a VHD distributor.

### Example 3: Create a shared image distributor.
```powershell
New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{"test"="dis-share"} -GalleryImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image" -ReplicationRegion "eastus" -RunOutputName "runoutput-01"
```

```output
RunOutputName ExcludeFromLatest GalleryImageId                                                        ReplicationRegion StorageAccountType
------------- ----------------- --------------                                                        ----------------- -------
runoutput-01                    /subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder... {eastus}
```

This command creates a shared image distributor.

## PARAMETERS

### -ArtifactTag
Tags that will be applied to the artifact once it has been created/updated by the distributor.
To construct, see NOTES section for ARTIFACTTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplateDistributorArtifactTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeFromLatest
Flag that indicates whether created image version should be excluded from latest.
Omit to use the default (false).

```yaml
Type: System.Boolean
Parameter Sets: SharedImageDistributor
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GalleryImageId
Resource Id of the Azure Compute Gallery image.

```yaml
Type: System.String
Parameter Sets: SharedImageDistributor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageId
Resource Id of the Managed Disk Image.

```yaml
Type: System.String
Parameter Sets: ManagedImageDistributor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Azure location for the image, should match if image already exists.

```yaml
Type: System.String
Parameter Sets: ManagedImageDistributor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedImageDistributor
Distribute as a Managed Disk Image.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ManagedImageDistributor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationRegion
[Deprecated] A list of regions that the image will be replicated to.
This list can be specified only if targetRegions is not specified.
This field is deprecated - use targetRegions instead.

```yaml
Type: System.String[]
Parameter Sets: SharedImageDistributor
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunOutputName
The name to be used for the associated RunOutput.

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

### -SharedImageDistributor
Distribute via Shared Image Gallery.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SharedImageDistributor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountType
[Deprecated] Storage account type to be used to store the shared image.
Omit to use the default (Standard_LRS).
This field can be specified only if replicationRegions is specified.
This field is deprecated - use targetRegions instead.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType
Parameter Sets: SharedImageDistributor
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetRegion
The target regions where the distributed Image Version is going to be replicated to.
This object supersedes replicationRegions and can be specified only if replicationRegions is not specified.
To construct, see NOTES section for TARGETREGION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ITargetRegion[]
Parameter Sets: SharedImageDistributor
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
Optional Azure Storage URI for the distributed VHD blob.
Omit to use the default (empty string) in which case VHD would be published to the storage account in the staging resource group.

```yaml
Type: System.String
Parameter Sets: VhdDistributor
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Versioning
Describes how to generate new x.y.z version number for distribution.
To construct, see NOTES section for VERSIONING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IDistributeVersioner
Parameter Sets: SharedImageDistributor
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VhdDistributor
Distribute via VHD in a storage account.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: VhdDistributor
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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateManagedImageDistributor

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateSharedImageDistributor

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateVhdDistributor

## NOTES

## RELATED LINKS

