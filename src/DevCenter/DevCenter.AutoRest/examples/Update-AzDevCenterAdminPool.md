### Example 1: Update a pool
```powershell
Update-AzDevCenterAdminPool -Name DevPool -ProjectName DevProject -ResourceGroupName testRg -DevBoxDefinitionName WebDevBox -LocalAdministrator "Disabled" -NetworkConnectionName Network1westus2
```
This command updates a pool named "DevPool" in the project "DevProject".

### Example 2: Update a pool using InputObject
```powershell
Get-AzDevCenterAdminPool -ResourceGroupName testRg -Name DevPool -ProjectName DevProject
Update-AzDevCenterAdminPool -InputObject $poolInput -DevBoxDefinitionName WebDevBox -LocalAdministrator "Disabled" -NetworkConnectionName Network1westus2

```
This command updates a pool named "DevPool" in the project "DevProject".

