### Example 1: Create role profile properties object

```powershell
$role = New-AzCloudServiceRoleProfilePropertiesObject -Name 'WebRole' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
```

This command creates role profile properties object which is used for creating or updating a cloud service. For more details see New-AzCloudService.
