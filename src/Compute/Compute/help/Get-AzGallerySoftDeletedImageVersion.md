---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azgallerysoftdeletedimageversion
schema: 2.0.0
---

# Get-AzGallerySoftDeletedImageVersion

## SYNOPSIS
Get soft-deleted image versions from an Azure Compute Gallery.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzGallerySoftDeletedImageVersion -ResourceGroupName <String> -GalleryName <String>
 -GalleryImageDefinitionName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameter
```
Get-AzGallerySoftDeletedImageVersion -GalleryImageDefinitionResourceId <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectParameter
```
Get-AzGallerySoftDeletedImageVersion -InputObject <PSGalleryImage> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Lists soft-deleted image versions for a gallery image definition. Use `-Name` to return only the matching version.

## EXAMPLES

### Example 1
```powershell
Get-AzGallerySoftDeletedImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
    -GalleryImageDefinitionName $imageName
```

List all soft-deleted versions for an image definition.

### Example 2
```powershell
Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $imageName |
    Get-AzGallerySoftDeletedImageVersion -Name '1.0.0'
```

Get a specific soft-deleted version by piping an image definition.

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

### -GalleryImageDefinitionResourceId
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
The gallery image definition whose soft-deleted versions are listed.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryImage
Parameter Sets: ObjectParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Filter the results to the specified gallery image version name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GalleryImageVersionName

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
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryImage

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGallerySoftDeletedImageVersion

## NOTES

## RELATED LINKS
