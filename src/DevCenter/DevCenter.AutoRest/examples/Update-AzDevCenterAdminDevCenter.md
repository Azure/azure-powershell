### Example 1: Update a dev center
```powershell
Update-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg -IdentityType "SystemAssigned"
```
This command updates a dev center named "Contoso" in the resource group "testRg". 

### Example 2: Update a dev center using InputObject
```powershell
$devCenterInput = Get-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg

Update-AzDevCenterAdminDevCenter -InputObject $devCenterInput -IdentityType "SystemAssigned"
```
This command updates a dev center named "Contoso" in the resource group "testRg". 

