### Example 1: Skip an action on the dev box by endpoint
```powershell
Skip-AzDevCenterUserDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -ProjectName DevProject -Name "schedule-default"
```
This command skips the action "schedule-default" for the dev box "myDevBox". 

### Example 2: Skip an action on the dev box by dev center
```powershell
Skip-AzDevCenterUserDevBoxAction -DevCenterName Contoso -DevBoxName myDevBox -ProjectName DevProject -Name "schedule-default"
```
This command skips the action "schedule-default" for the dev box "myDevBox". 

### Example 3: Skip an action on the dev box by endpoint and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "schedule-default"}
Skip-AzDevCenterUserDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command skips the action "schedule-default" for the dev box "myDevBox". 

### Example 4: Skip an action on the dev box by dev center and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "schedule-default"}
Skip-AzDevCenterUserDevBoxAction -DevCenterName Contoso -InputObject $devBoxInput
```
This command skips the action "schedule-default" for the dev box "myDevBox". 