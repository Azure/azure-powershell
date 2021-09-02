### Example 1: List authorization under resource group
```powershell
PS C:\> Get-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

List authorization under resource group

### Example 2: Get authorization by name in a private cloud
```powershell
PS C:\> Get-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_authorization

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

Get authorization by name in a private cloud

### Example 3: Get authorization by resource id in a private cloud
```powershell
PS C:\> Get-AzVMwareAuthorization -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/authorizations/azps_test_authorization"

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

Get authorization by resource id in a private cloud