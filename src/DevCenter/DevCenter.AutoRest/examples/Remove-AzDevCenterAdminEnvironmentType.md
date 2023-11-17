### Example 1: Deletes an environment type
```powershell
Remove-AzDevCenterAdminEnvironmentType -ResourceGroupName testRg -DevCenterName Contoso -Name DevTest 
```
This command deletes the environment type "WebDevBox" in the dev center "Contoso". 

### Example 2: Deletes an environment type using InputObject
```powershell
$envType = Get-AzDevCenterAdminEnvironmentType -ResourceGroupName testRg -DevCenterName Contoso -Name DevTest
Remove-AzDevCenterAdminEnvironmentType -InputObject $envType
```
This command deletes the environment type "WebDevBox" in the dev center "Contoso". 
