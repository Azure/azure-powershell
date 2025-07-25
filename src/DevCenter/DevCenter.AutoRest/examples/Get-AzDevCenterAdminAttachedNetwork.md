### Example 1: List attached networks in a dev center
```powershell
Get-AzDevCenterAdminAttachedNetwork -ResourceGroupName testRg -DevCenterName Contoso
```
This command lists the attached networks in the dev center "Contoso" under the resource group "testRg".

### Example 2: List attached networks in a project
```powershell
Get-AzDevCenterAdminAttachedNetwork -ProjectName DevProject -ResourceGroupName testRg
```
This command lists the attached networks in the project "DevProject" under the resource group "testRg".

### Example 3: Get a dev center attached network
```powershell
 Get-AzDevCenterAdminAttachedNetwork -ConnectionName network-uswest3 -ResourceGroupName testRg -DevCenterName Contoso
```
This command gets the attached network named "network-uswest3" in the dev center "Contoso" under the resource group "testRg".

### Example 4: Get a project attached network
```powershell
 Get-AzDevCenterAdminAttachedNetwork -ConnectionName network-uswest3 -ProjectName DevProject -ResourceGroupName testRg
```
This command gets the attached network named "network-uswest3" in the project "DevProject" under the resource group "testRg".
