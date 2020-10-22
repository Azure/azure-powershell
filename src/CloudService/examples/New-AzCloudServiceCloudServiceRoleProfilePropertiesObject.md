### Example 1: Create role profile object
```powershell
PS C:\> New-AzCloudServiceCloudServiceRoleProfilePropertiesObject -Name 'ContosoFrontEnd' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
```
This command creates role profile object which is used for creating or updating a cloud service. For more details see New-AzCloudService.