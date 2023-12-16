### Example 1: Delete a gallery
```powershell
Remove-AzDevCenterAdminGallery -ResourceGroupName testRg -DevCenterName Contoso -Name StandardGallery
```
This command deletes a gallery named "StandardGallery" from the dev center "Contoso".

### Example 2: Delete a gallery using InputObject
```powershell
$gallery = Get-AzDevCenterAdminGallery -ResourceGroupName testRg -DevCenterName Contoso -Name StandardGallery
Remove-AzDevCenterAdminGallery -InputObject $gallery
```
This command deletes a gallery named "StandardGallery" from the dev center "Contoso".
