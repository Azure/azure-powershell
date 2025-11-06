### Example 1: Create a Dev Box add-on by endpoint and user ID
```powershell
New-AzDevCenterUserDevBoxAddOn `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -AddOnName "devboxtunnel-sys-default" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```
This command creates the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the endpoint.

### Example 2: Create a Dev Box add-on by dev center name and current user
```powershell
New-AzDevCenterUserDevBoxAddOn `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -AddOnName "devboxtunnel-sys-default" `
  -UserId "me"
```
This command creates the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 3: Create a Dev Box add-on using InputObject and endpoint
```powershell
$addOnInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
New-AzDevCenterUserDevBoxAddOn `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $addOnInput
```
This command creates the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the endpoint and an identity object.

### Example 4: Create a Dev Box add-on using InputObject and dev center name
```powershell
$addOnInput = @{
    DevBoxName = "myDevBox"
    UserId = "me"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
New-AzDevCenterUserDevBoxAddOn `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $addOnInput
```
This command creates the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the dev center name and an identity object.