### Example 1: Restore a Dev Box to a snapshot by endpoint and user ID
```powershell
Restore-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -SnapshotId "snapshot-1234"
```
This command restores the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" to the snapshot with ID "snapshot-1234" using the endpoint.

### Example 2: Restore a Dev Box to a snapshot by dev center name and current user
```powershell
Restore-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -SnapshotId "snapshot-1234"
```
This command restores the dev box "myDevBox" assigned to the current signed-in user to the snapshot with ID "snapshot-1234" using the dev center name.

### Example 3: Restore a Dev Box to a snapshot using InputObject and endpoint
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
}
Restore-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $snapshotInput `
  -SnapshotId "snapshot-1234"
```
This command restores the dev box "myDevBox" to the snapshot with ID "snapshot-1234" using the endpoint and an identity object.

### Example 4: Restore a Dev Box to a snapshot using InputObject and dev center name
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "me"
    ProjectName = "DevProject"
}
Restore-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $snapshotInput `
  -SnapshotId "snapshot-1234"
```
This command restores the dev box "myDevBox" to the snapshot with ID "snapshot-1234" using the dev center name and an identity object.