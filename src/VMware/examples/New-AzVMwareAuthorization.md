### Example 1: Create autorization
```powershell
PS C:\> New-AzVMwareAuthorization -Name azps_test_auth -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name           Type
----           ----
azps_test_auth Microsoft.AVS/privateClouds/authorizations
```

This cmdlet creates authorization `azps_test_auth` under private cloud `azps_test_cloud`