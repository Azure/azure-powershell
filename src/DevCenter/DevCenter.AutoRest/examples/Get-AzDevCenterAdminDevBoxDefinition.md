### Example 1: List dev box definitions in a dev center
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -DevCenterName Contoso
```
This command lists the dev box definitions in the dev center "Contoso" under the resource group "testRg".

### Example 2: List dev box definitions in a project
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -ProjectName DevProject
```
This command lists the dev box definitions in the project "DevProject" under the resource group "testRg".

### Example 3: Get a dev center dev box definition
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -DevCenterName Contoso -Name WebDevBoxDef
```
This command gets the dev box definition "WebDevBoxDef" in the dev center "Contoso" under the resource group "testRg".

### Example 4: Get a project dev box definition
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -ProjectName DevProject -Name WebDevBoxDef
```
This command gets the dev box definition "WebDevBoxDef" in the project "DevProject" under the resource group "testRg".
