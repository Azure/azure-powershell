### Example 1: Get authorization
```powershell
PS C:\> Get-AzVMwareAuthorization -Name azps_test_auth -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name           Type
----           ----
azps_test_auth Microsoft.AVS/privateClouds/authorizations
```

This cmdlet gets authorization `azps_test_auth` under private cloud `azps_test_cloud`

### Example 2: List authorization
```powershell
PS C:\> Get-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name           Type
----           ----
azps_test_auth Microsoft.AVS/privateClouds/authorizations
```

This cmdlet lists authorization `azps_test_auth` under private cloud `azps_test_cloud`