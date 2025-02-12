### Example 1: Delete a dev center
```powershell
Remove-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg
```
This command deletes the dev center "Contoso" in the resource group "testRg".

### Example 2: Delete a dev center using InputObject
```powershell
$devCenter = Get-AzDevCenterAdminDevCenter -ResourceGroupName testRg -Name Contoso

Remove-AzDevCenterAdminDevCenter -InputObject $devCenter
```
This command deletes the dev center "Contoso" in the resource group "testRg".

