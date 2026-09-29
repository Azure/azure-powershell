---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azgallerysoftdeletedimageversion
schema: 2.0.0
---

# Get-AzGallerySoftDeletedImageVersion

## SYNOPSIS
List the soft-deleted (recycle bin) gallery image versions of a gallery image definition.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzGallerySoftDeletedImageVersion [-ResourceGroupName] <String> [-GalleryName] <String>
 [-GalleryImageDefinitionName] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameter
```
Get-AzGallerySoftDeletedImageVersion [-GalleryImageDefinitionResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectParameter
```
Get-AzGallerySoftDeletedImageVersion [-InputObject] <PSGalleryImage>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
List the gallery image versions that have been soft-deleted (moved to the recycle bin) for a gallery image definition. Soft-deleted image versions are only listed when the gallery's soft-delete policy is enabled. Use `Restore-AzGalleryImageVersion` to recover a soft-deleted image version within its retention time, or `Remove-AzGalleryImageVersion -BypassSoftDelete` to permanently delete it.

## EXAMPLES

### Example 1
```powershell
Get-AzGallerySoftDeletedImageVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryImageDefinitionName $imageName
```

List all soft-deleted gallery image versions of the given gallery image definition.

### Example 2
```powershell
Get-AzGallerySoftDeletedImageVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryImageDefinitionName $imageName -Name "1.0.0"
```

Get the soft-deleted gallery image version named `1.0.0` of the given gallery image definition.

### Example 3
```powershell
Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $imageName | Get-AzGallerySoftDeletedImageVersion
```

List all soft-deleted gallery image versions of the given gallery image definition using pipeline input.

## PARAMETERS

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
The name of the gallery image definition.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases: GalleryImageName

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
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The gallery image definition whose soft-deleted image versions should be listed.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryImage
Parameter Sets: ObjectParameter
Aliases: GalleryImage

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the soft-deleted gallery image version to filter on. Supports wildcards.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases: GalleryImageVersionName

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -GalleryImageDefinitionResourceId
The resource ID of the gallery image definition.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameter
Required: True
Position: 0
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource ID of the gallery image definition.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryImage

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGallerySoftDeletedImageVersion

## NOTES

## RELATED LINKS
