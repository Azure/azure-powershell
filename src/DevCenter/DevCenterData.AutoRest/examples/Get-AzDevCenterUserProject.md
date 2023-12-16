### Example 1: List projects by endpoint
```powershell
Get-AzDevCenterUserProject -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```
This command lists the projects under the endpoint.

### Example 2: List projects by dev center
```powershell
Get-AzDevCenterUserProject -DevCenterName Contoso -ProjectName DevProject
```
This command lists the projects under the dev center.

### Example 3: Get project by endpoint
```powershell
Get-AzDevCenterUserProject -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject 
```
This command gets the project "DevProject".

### Example 4: Get project by dev center
```powershell
Get-AzDevCenterUserProject -DevCenterName Contoso -ProjectName DevProject 
```
This command gets the project "DevProject".

### Example 5: Get project by endpoint and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject";}
Get-AzDevCenterUserProject -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command gets the project "DevProject".

### Example 6: Get project by dev center and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject";}
Get-AzDevCenterUserProject -DevCenterName Contoso -InputObject $devBoxInput
```
This command gets the project "DevProject".
