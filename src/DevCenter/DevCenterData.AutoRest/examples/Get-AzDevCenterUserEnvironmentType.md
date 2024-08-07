### Example 1: List environment types by endpoint and project
```powershell
Get-AzDevCenterUserEnvironmentType -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```
This command lists environment types under the project "DevProject".

### Example 2: List environment types by dev center and project
```powershell
Get-AzDevCenterUserEnvironmentType -DevCenterName Contoso -ProjectName DevProject
```
This command lists environment types under the project "DevProject".

