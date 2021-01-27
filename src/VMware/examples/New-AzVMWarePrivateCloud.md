### Example 1: Create private cloud
```powershell
PS C:\> New-AzVMwarePrivateCloud -Name azps-test-cloud -ResourceGroupName azps-test-group -NetworkBlock 192.168.48.0/22 -SkuName av36 -ManagementClusterSize 3 -Location australiaeast

Location      Name            Type
--------      ----            ----
australiaeast azps-test-cloud Microsoft.AVS/privateClouds
```

Create private cloud

