---
external help file:
Module Name: Az.ImageBuilder
online version: https://docs.microsoft.com/powershell/module/az.ImageBuilder/new-azimagebuildertemplatedistributorobject
schema: 2.0.0
---

# New-AzImageBuilderTemplateDistributorObject

## SYNOPSIS
Create an in-memory object for ImageTemplateDistributor.

## SYNTAX

### VhdDistributor (Default)
```
New-AzImageBuilderTemplateDistributorObject -RunOutputName <String> -VhdDistributor
 [-ArtifactTag <IImageTemplateDistributorArtifactTags>] [<CommonParameters>]
```

### ManagedImageDistributor
```
New-AzImageBuilderTemplateDistributorObject -ImageId <String> -Location <String> -ManagedImageDistributor
 -RunOutputName <String> [-ArtifactTag <IImageTemplateDistributorArtifactTags>] [<CommonParameters>]
```

### SharedImageDistributor
```
New-AzImageBuilderTemplateDistributorObject -GalleryImageId <String> -ReplicationRegion <String[]>
 -RunOutputName <String> -SharedImageDistributor [-ArtifactTag <IImageTemplateDistributorArtifactTags>]
 [-ExcludeFromLatest <Boolean>] [-StorageAccountType <SharedImageStorageAccountType>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ImageTemplateDistributor.

## EXAMPLES

### Example 1: Create a managed image distributor
```powershell
New-AzImageBuilderTemplateDistributorObject -ManagedImageDistributor -ArtifactTag @{tag='lucasManage'} -ImageId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/lucas-linux-imageshare -RunOutputName luacas-runout -Location eastus
```

```output
RunOutputName ImageId
------------- -------                                                                                                         
luacas-runout /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Co…
```

This command creates a managed image distributor.

### Example 2: Create a VHD distributor
```powershell
New-AzImageBuilderTemplateDistributorObject -ArtifactTag @{tag='vhd'} -VhdDistributor -RunOutputName image-vhd
```

```output
RunOutputName
-------------
image-vhd
```

This command creates a VHD distributor.

### Example 3: Create a shared image distributor
```powershell
New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/myimagegallery/images/lcuas-linux-share' -ReplicationRegion eastus2 -RunOutputName 'outname' -ExcludeFromLatest $false 
```

```output
RunOutputName ExcludeFromLatest GalleryImageId
------------- ----------------- --------------                                                                                
outname       False             /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/prov… 
```

This command creates a shared image distributor.

## PARAMETERS

### -ArtifactTag
Tags that will be applied to the artifact once it has been created/updated by the distributor.
To construct, see NOTES section for ARTIFACTTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateDistributorArtifactTags
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
Resource Id of the Shared Image Gallery image.

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
A list of regions that the image will be replicated to.

```yaml
Type: System.String[]
Parameter Sets: SharedImageDistributor
Aliases:

Required: True
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
Storage account type to be used to store the shared image.
Omit to use the default (Standard_LRS).

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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.ImageTemplateManagedImageDistributor

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.ImageTemplateSharedImageDistributor

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.ImageTemplateVhdDistributor

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ARTIFACTTAG <IImageTemplateDistributorArtifactTags>`: Tags that will be applied to the artifact once it has been created/updated by the distributor.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

