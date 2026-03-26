### Example 1: Enable a Dev Box add-on by endpoint
```powershell
Enable-AzDevCenterUserDevBoxAddOn `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -DevBoxName "myDevBox" `
  -AddOnName "devboxtunnel-sys-default"
```
This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the specified user using the endpoint.

### Example 2: Enable a Dev Box add-on by dev center
```powershell
Enable-AzDevCenterUserDevBoxAddOn `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -DevBoxName "myDevBox" `
  -AddOnName "devboxtunnel-sys-default"
```
This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the specified user using the dev center name.

### Example 3: Enable a Dev Box add-on by endpoint and InputObject
```powershell
$addOnInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
Enable-AzDevCenterUserDevBoxAddOn `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $addOnInput
```
This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the endpoint and an identity object.

### Example 4: Enable a Dev Box add-on by dev center and InputObject
```powershell
$addOnInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
Enable-AzDevCenterUserDevBoxAddOn `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $addOnInput
```
This command enables the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the dev center name and an identity object.