### Example 1: Get all pending Dev Box approvals by endpoint
```powershell
Get-AzDevCenterUserDevCenterApproval `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject"
```
This command gets all pending Dev Box creation approvals for the project "DevProject" using the specified endpoint.

### Example 2: Get all pending Dev Box approvals by dev center name
```powershell
Get-AzDevCenterUserDevCenterApproval `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject"
```
This command gets all pending Dev Box creation approvals for the project "DevProject" using the dev center name.