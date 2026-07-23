### Example 1: List images in a dev center
```powershell
Get-AzDevCenterAdminImage -ResourceGroupName testRg -DevCenterName Contoso
```
This command lists the images in the dev center "Contoso" under the resource group "testRg".

### Example 2: List images in a gallery under a dev center
```powershell
Get-AzDevCenterAdminImage -ResourceGroupName testRg -DevCenterName Contoso -GalleryName StandardGallery
```
This command lists the images in the gallery "StandardGallery" under the dev center "Contoso". 

### Example 3: Get an image
```powershell
Get-AzDevCenterAdminImage -ResourceGroupName testRg -DevCenterName Contoso -GalleryName StandardGallery -Name ContosoBaseImage
```
This command gets the image named "ContosoBaseImage" in the gallery "StandardGallery" under the dev center "Contoso".

### Example 4: Get an image using InputObject
```powershell
$image = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "GalleryName" = "StandardGallery"; "ImageName" = "ContosoBaseImage"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminImage -InputObject $image
```
This command gets the image named "ContosoBaseImage" in the gallery "StandardGallery" under the dev center "Contoso".
