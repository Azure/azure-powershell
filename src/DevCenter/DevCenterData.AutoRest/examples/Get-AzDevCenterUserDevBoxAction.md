### Example 1: List actions on the dev box by endpoint
```powershell
Get-AzDevCenterUserDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -ProjectName DevProject
```
This command lists the actions on the dev box "myDevBox".

### Example 2: List actions on the dev box by dev center
```powershell
Get-AzDevCenterUserDevBoxAction -DevCenter Contoso -DevBoxName myDevBox -ProjectName DevProject
```
This command lists the actions on the dev box "myDevBox".

### Example 3: Get an action on the dev box by endpoint
```powershell
Get-AzDevCenterUserDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -ProjectName DevProject -ActionName "schedule-default"
```
This command gets the action "schedule-default" for the dev box "myDevBox". 

### Example 4: Get an action on the dev box by dev center
```powershell
Get-AzDevCenterUserDevBoxAction -DevCenter Contoso -DevBoxName myDevBox -ProjectName DevProject -ActionName "schedule-default"
```
This command gets the action "schedule-default" for the dev box "myDevBox". 

### Example 5: Get an action on the dev box by endpoint and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "schedule-default"}
Get-AzDevCenterUserDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command gets the action "schedule-default" for the dev box "myDevBox". 

### Example 6: Get an action on the dev box by dev center and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "schedule-default"}
Get-AzDevCenterUserDevBoxAction -DevCenter Contoso -InputObject $devBoxInput
```
This command gets the action "schedule-default" for the dev box "myDevBox". 
