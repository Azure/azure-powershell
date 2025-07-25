### Example 1: Create a gallery
```powershell
New-AzDevCenterAdminGallery -DevCenterName Contoso -Name StandardGallery -ResourceGroupName testRg -GalleryResourceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/rg1/providers/Microsoft.Compute/galleries/StandardGallery"
```
This command create a gallery named "StandardGallery" in the dev center "Contoso". 

### Example 2: Create a gallery using InputObject
```powershell
$gallery = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "GalleryName" = "StandardGallery"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminGallery -InputObject $gallery -GalleryResourceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/rg1/providers/Microsoft.Compute/galleries/StandardGallery"
```
This command create a gallery named "StandardGallery" in the dev center "Contoso". 

