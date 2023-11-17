### Example 1: Create a dev box by endpoint
```powershell
New-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0 -Name myDevBox -PoolName DevPool
```
This command creates the dev box "myDevBox" for the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 2: Create a dev box by dev center
```powershell
New-AzDevCenterUserDevBox -DevCenter Contoso -ProjectName DevProject -UserId "me" -Name myDevBox -PoolName DevPool
```
This command creates the dev box "myDevBox" for the currently signed-in user.

### Example 3: Create a dev box by endpoint and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
New-AzDevCenterUserDevBox -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput -PoolName DevPool
```
This command creates the dev box "myDevBox" for the currently signed-in user.

### Example 4: Create a dev box by dev center and InputObject
```powershell
$devBoxInput = @{"DevBoxName" = "myDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject" }
New-AzDevCenterUserDevBox -DevCenter Contoso -InputObject $devBoxInput -PoolName DevPool
```
This command creates the dev box "myDevBox" for the user "786a823c-8037-48ab-89b8-8599901e67d0".