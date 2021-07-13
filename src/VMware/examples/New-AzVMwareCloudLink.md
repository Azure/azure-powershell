### Example 1: Create a cloud link in a private cloud
```powershell
PS C:\> New-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -LinkedCloud /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_2/providers/Microsoft.AVS/privateClouds/azps_test_cloud_2/

Name                Type
----                ----
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks
```

Create a cloud link in a private cloud