### Example 1: Create role profile properties object
```powershell
PS C:\> New-AzCloudServiceCloudServiceRoleProfilePropertiesObject -Name 'ContosoFrontEnd' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
```
This command creates role profile properties object which is used for creating new cloud service. For more details see New-AzCloudService.