### Example 1: Remove a project policy
```powershell
Remove-AzDevCenterAdminProjectPolicy -DevCenterName Contoso -Name MyPolicy -ResourceGroupName testRg
```
This command deletes the project policy named "MyPolicy" in the dev center "Contoso".

### Example 2: Remove a project policy using InputObject
```powershell
$policy = Get-AzDevCenterAdminProjectPolicy -DevCenterName Contoso -Name MyPolicy -ResourceGroupName testRg
Remove-AzDevCenterAdminProjectPolicy -InputObject $policy
```
This command deletes the project policy named "MyPolicy" in the dev center "Contoso".