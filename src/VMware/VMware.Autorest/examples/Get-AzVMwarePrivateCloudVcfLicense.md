### Example 1: Get VCF licenses for a private cloud
```powershell
Get-AzVMwarePrivateCloudVcfLicense -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Kind Core EndDate                ProvisioningState BroadcomSiteId BroadcomContractNumber
---- ---- -------                ----------------- -------------- ----------------------
vcf5   16 12/31/2025 11:59:59 PM Succeeded         123456         123456
```

Gets VCF license for the specified private cloud and resource group.