### Example 1: Get all add-ons for a Dev Box by endpoint and user ID
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```
This command gets all add-ons for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the endpoint.

### Example 2: Get all add-ons for a Dev Box by endpoint and current user
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me"
```
This command gets all add-ons for the dev box "myDevBox" assigned to the current signed-in user using the endpoint.

### Example 3: Get a specific add-on for a Dev Box by dev center and user ID
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -AddOnName "devboxtunnel-sys-default"
```
This command gets the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the dev center name.

### Example 4: Get a specific add-on for a Dev Box by dev center and current user
```powershell
Get-AzDevCenterUserDevBoxAddon `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -AddOnName "devboxtunnel-sys-default"
```
This command gets the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 5: Get a Dev Box add-on using InputObject
```powershell
$addonInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    AddOnName = "devboxtunnel-sys-default"
}
Get-AzDevCenterUserDevBoxAddon `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $addonInput
```
This command gets the add-on "devboxtunnel-sys-default" for the dev box "myDevBox" using the endpoint and an identity object.