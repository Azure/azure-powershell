### Example 1: Delete a pool
```powershell
Remove-AzDevCenterAdminPool -ResourceGroupName testRg -Name DevPool -ProjectName DevProject
```
This command deletes a pool named "DevPool" in the project "DevProject".

### Example 2: Delete a pool using InputObject
```powershell
$pool = Get-AzDevCenterAdminPool -ResourceGroupName testRg -Name DevPool -ProjectName DevProject
Remove-AzDevCenterAdminPool -InputObject $pool
```
This command deletes a pool named "DevPool" in the project "DevProject".
