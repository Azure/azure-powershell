### Example 1: List express route authorization
```powershell
PS C:\> Get-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

List express route authorization

### Example 2: Get express route authorization
```powershell
PS C:\> Get-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_authorization

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

Get express route authorization

### Example 3: Get express route authorization
```powershell
PS C:\> Get-AzVMwareAuthorization -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/authorizations/azps_test_authorization"

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

Get express route authorization