### Example 1: List pools by endpoint
```powershell
Get-AzDevCenterUserPool -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```
This command lists the pools in the project "DevProject".

### Example 2: List pools by dev center
```powershell
Get-AzDevCenterUserPool -DevCenter Contoso -ProjectName DevProject
```
This command lists the pools in the project "DevProject".

### Example 3: Get pool by endpoint
```powershell
Get-AzDevCenterUserPool -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -PoolName DevPool
```
This command gets the pool "DevPool" in the project "DevProject".

### Example 4: Get pool by dev center
```powershell
Get-AzDevCenterUserPool -DevCenter Contoso -ProjectName DevProject -PoolName DevPool
```
This command gets the pool "DevPool" in the project "DevProject".

### Example 5: Get pool by endpoint and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool" }
Get-AzDevCenterUserPool -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command gets the pool "DevPool" in the project "DevProject".

### Example 6: Get pool by dev center and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool" }
Get-AzDevCenterUserPool -DevCenter Contoso -InputObject $devBoxInput
```
This command gets the pool "DevPool" in the project "DevProject".
