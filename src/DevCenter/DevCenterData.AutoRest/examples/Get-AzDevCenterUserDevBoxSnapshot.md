### Example 1: Get all snapshots for a Dev Box by endpoint and user ID
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```
This command gets all snapshots for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the endpoint.

### Example 2: Get a specific snapshot for a Dev Box by endpoint and snapshot ID
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -SnapshotId "snapshot-1234"
```
This command gets the snapshot with ID "snapshot-1234" for the dev box "myDevBox" assigned to the specified user using the endpoint.

### Example 3: Get all snapshots for a Dev Box by dev center and current user
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me"
```
This command gets all snapshots for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 4: Get a specific snapshot for a Dev Box by dev center and snapshot ID
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -SnapshotId "snapshot-1234"
```
This command gets the snapshot with ID "snapshot-1234" for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 5: Get a snapshot using InputObject and endpoint
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    SnapshotId = "snapshot-1234"
}
Get-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $snapshotInput
```
This command gets the snapshot with ID "snapshot-1234" for the dev box "myDevBox" using the endpoint and an identity object.