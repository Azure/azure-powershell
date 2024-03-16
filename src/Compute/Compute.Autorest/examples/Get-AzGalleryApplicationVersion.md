### Example 1: Get a Gallery Application Version
```powershell
Get-AzGalleryApplicationVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryApplicationName $galleryAppName -Name $versionName
```

Retrieve a Gallery Application Version resource with the provided Resource Group, Gallery, Gallery Application name, and version name.

### Example 2: Get all the Gallery Application Versions in a GalleryApplication
```powershell
Get-AzGalleryApplicationVersion -GalleryName $GalleryName -ResourceGroupName $rgName -GalleryApplicationName $galleryAppName
```

Retrieve all the Gallery Application Version resources in the provided Resource Group, Gallery, and Gallery Application Name.