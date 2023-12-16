### Example 1: List galleries in a dev center
```powershell
Get-AzDevCenterAdminGallery -ResourceGroupName testRg -DevCenterName Contoso
```
This command lists the galleries in the dev center "Contoso" under the resource group "testRg".

### Example 2: Get a gallery
```powershell
Get-AzDevCenterAdminGallery -ResourceGroupName testRg -DevCenterName Contoso -Name StandardGallery
```
This command gets the gallery named "StandardGallery" in the dev center "Contoso" under the resource group "testRg".

### Example 3: Get a gallery using InputObject
```powershell
$gallery = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "GalleryName" = "StandardGallery"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminGallery -InputObject $gallery
```
This command gets the gallery named "StandardGallery" in the dev center "Contoso" under the resource group "testRg".
