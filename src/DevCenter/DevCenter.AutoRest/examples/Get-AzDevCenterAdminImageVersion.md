### Example 1: List image versions for an image
```powershell
Get-AzDevCenterAdminImageVersion -ResourceGroupName testRg -DevCenterName Contoso -ImageName ContosoBaseImage -GalleryName StandardGallery
```
This command lists the image versions for the image "ContosoBaseImage" under the gallery "StandardGallery". 

### Example 2: Get an image version
```powershell
Get-AzDevCenterAdminImageVersion -ResourceGroupName testRg -DevCenterName Contoso -ImageName ContosoBaseImage -VersionName 1.0.0 -GalleryName StandardGallery
```
This command gets the image version "1.0.0" for the image "ContosoBaseImage" in the gallery "StandardGallery".

### Example 3: Get an image version using InputObject
```powershell
$imageVersion =  @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "GalleryName" = "StandardGallery"; "ImageName" = "ContosoBaseImage"; "VersionName" = "1.0.0"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminImageVersion -InputObject $imageVersion
```
This command gets the image version "1.0.0" for the image "ContosoBaseImage" in the gallery "StandardGallery".

