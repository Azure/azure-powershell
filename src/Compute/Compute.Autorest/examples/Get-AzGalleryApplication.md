### Example 1: Get a Gallery Application in a Gallery
```powershell
Get-AzGalleryApplication -ResourceGroupName $rgName -GalleryName $galleryName -name $galleryAppName
```

Retrieve a Gallery Application resource with the provided Resource Group, Gallery, and Gallery Application name.

### Example 2: Get all the Gallery Applications in a Gallery
```powershell
Get-AzGalleryApplication -GalleryName $GalleryName -ResourceGroupName $rgName
```

Retrieve all the Gallery Application resources in the provided Resource Group and Gallery.