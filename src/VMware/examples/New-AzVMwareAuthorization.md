### Example 1: Create an Circuit Authorization in a private cloud
```powershell
PS C:\> New-AzVMwareAuthorization -Name azps_test_authorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name                    Type                                       ResourceGroupName
----                    ----                                       -----------------
azps_test_authorization Microsoft.AVS/privateClouds/authorizations azps_test_group
```

Create an Circuit Authorization in a private cloud