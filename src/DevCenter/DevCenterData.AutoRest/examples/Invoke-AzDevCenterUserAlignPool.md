### Example 1: Align all Dev Boxes in a pool by endpoint and target
```powershell
Invoke-AzDevCenterUserAlignPool `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -PoolName "DevPool01" `
  -Target "NetworkProperties"
```
This command aligns all Dev Boxes in the pool "DevPool01" in project "DevProject" on the "NetworkProperties" target using the endpoint.

### Example 2: Align all Dev Boxes in a pool by dev center name and multiple targets
```powershell
Invoke-AzDevCenterUserAlignPool `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -PoolName "DevPool01" `
  -Target "NetworkProperties"
```
This command aligns all Dev Boxes in the pool "DevPool01" on both "NetworkProperties" and "DevBoxDefinition" using the dev center name.

### Example 3: Align all Dev Boxes in a pool using InputObject and endpoint
```powershell
$poolInput = @{
    ProjectName = "DevProject"
    PoolName = "DevPool01"
}
Invoke-AzDevCenterUserAlignPool `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $poolInput `
  -Target "NetworkProperties"
```
This command aligns all Dev Boxes in the pool "DevPool01" using the endpoint and an identity object.

### Example 4: Align all Dev Boxes in a pool using Body parameter
```powershell
$body = @{
    Target = @("NetworkProperties")
}
Invoke-AzDevCenterUserAlignPool `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -PoolName "DevPool01" `
  -Body $body
```
This command aligns all Dev Boxes in the pool "DevPool01" using the dev center name and a body object specifying the target.