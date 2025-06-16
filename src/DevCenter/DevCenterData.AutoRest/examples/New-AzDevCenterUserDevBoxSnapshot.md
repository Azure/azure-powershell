### Example 1: Create a Dev Box snapshot by endpoint
```powershell
New-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -DevBoxName "myDevBox"
```
This command creates a snapshot for the dev box "myDevBox" assigned to the specified user using the endpoint.

### Example 2: Create a Dev Box snapshot by dev center
```powershell
New-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -UserId "me" `
  -DevBoxName "myDevBox"
```
This command creates a snapshot for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 3: Create a Dev Box snapshot by endpoint and InputObject
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "me"
    ProjectName = "DevProject"
}
New-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $snapshotInput
```
This command creates a snapshot for the dev box "myDevBox" using the endpoint and an identity object.

### Example 4: Create a Dev Box snapshot by dev center and InputObject
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
}
New-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $snapshotInput
```
This command creates a snapshot for the dev box "myDevBox" using the dev center name and an identity object.