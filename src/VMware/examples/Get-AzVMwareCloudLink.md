### Example 1: List cloud link under resource group
```powershell
PS C:\> Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name                Type
----                ----
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks
```

List cloud link under resource group

### Example 2: Get cloud link
```powershell
PS C:\> Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_cloudlink

Name                Type
----                ----
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks
```

Get cloud link

### Example 3: Get cloud link
```powershell
PS C:\> Get-AzVMwareCloudLink -InputObject /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/cloudLinks/azps_test_cloudlink

Name                Type
----                ----
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks
```

Get cloud link