### Example 1: Create a cloud link in a private cloud
```powershell
PS C:\> New-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -LinkedCloud "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group2/providers/Microsoft.AVS/privateClouds/azps_test_cloud2/"

Name                Type
----                ----
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks
```

Create a cloud link in a private cloud