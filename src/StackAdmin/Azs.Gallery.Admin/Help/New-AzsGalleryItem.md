---
external help file: Azs.Gallery.Admin-help.xml
Module Name: Azs.Gallery.Admin
online version: 
schema: 2.0.0
---

# New-AzsGalleryItem

## SYNOPSIS
Uploads a provider gallery item to the storage.

## SYNTAX

```
New-AzsGalleryItem [-GalleryItemUri] <String> [<CommonParameters>]
```

## DESCRIPTION
Uploads a provider gallery item to the storage.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
New-AzsGalleryItem -GalleryItemUri 'http://galleryitemuri'
```

Create a new gallery item.

## PARAMETERS

### -GalleryItemUri
The URI to the gallery item JSON file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Gallery.Admin.Models.GalleryItem

## NOTES

## RELATED LINKS

