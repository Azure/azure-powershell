### Example 1: List dev boxes by endpoint
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/"
```
This command lists dev boxes under the endpoint.

### Example 2: List dev boxes by endpoint and user id
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -UserId 786a823c-8037-48ab-89b8-8599901e67d0
```
This command lists dev boxes under the endpoint assigned to user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 3: List dev boxes by endpoint, user id, and project
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId "me"
```
This command lists dev boxes under the project "DevProject" assigned to the currently signed-in user.

### Example 4: List dev boxes by dev center name
```powershell
Get-AzDevCenterUserDevBox -DevCenter Contoso
```
This command lists dev boxes under the dev center "Contoso".

### Example 5: List dev boxes by dev center and user id
```powershell
Get-AzDevCenterUserDevBox -DevCenter Contoso -UserId "me"
```
This command lists dev boxes under the dev center "Contoso" assigned to the currently signed-in user.

### Example 6: List dev boxes by dev center, user id, and project
```powershell
Get-AzDevCenterUserDevBox -DevCenter Contoso -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0
```
This command lists dev boxes under the project "DevProject" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 7: Get a dev box by endpoint
```powershell
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0 -Name myDevBox
```
This command gets the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 8: Get a dev box by dev center
```powershell
Get-AzDevCenterUserDevBox -DevCenter Contoso -ProjectName DevProject -UserId "me" -Name myDevBox
```
This command gets the dev box "myDevBox" assigned to the currently signed-in user.

### Example 9: Get a dev box by endpoint and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command gets the dev box "myDevBox" assigned to the currently signed-in user.

### Example 10: Get a dev box by dev center and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserDevBox -DevCenter Contoso -InputObject $devBoxInput 
```
This command gets the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0".
