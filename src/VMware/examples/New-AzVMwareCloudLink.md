### Example 1: Create a cloud link in a private cloud
```powershell
PS C:\> New-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -LinkedCloud "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group2/providers/Microsoft.AVS/privateClouds/azps_test_cloud2/"

Name                Type                                   ResourceGroupName
----                ----                                   -----------------
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks azps_test_group
```

Create a cloud link in a private cloud