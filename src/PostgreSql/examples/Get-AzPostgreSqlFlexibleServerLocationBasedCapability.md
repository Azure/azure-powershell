### Example 1: Get location capabilities by location name
```powershell
Get-AzPostgreSqlFlexibleServerLocationBasedCapability -Location eastus
```

```output
SKU               Memory vCore Tier
---               ------ ----- ----
Standard_B1ms       2048     1 Burstable
Standard_B2s        2048     2 Burstable
Standard_D2s_v3     4096     2 GeneralPurpose
Standard_D4s_v3     4096     4 GeneralPurpose
Standard_D8s_v3     4096     8 GeneralPurpose
Standard_D16s_v3    4096    16 GeneralPurpose
Standard_D32s_v3    4096    32 GeneralPurpose
Standard_D48s_v3    4096    48 GeneralPurpose
Standard_D64s_v3    4096    64 GeneralPurpose
Standard_D2ds_v4    4096     2 GeneralPurpose
Standard_D4ds_v4    4096     4 GeneralPurpose
Standard_D8ds_v4    4096     8 GeneralPurpose
Standard_D16ds_v4   4096    16 GeneralPurpose
Standard_D32ds_v4   4096    32 GeneralPurpose
Standard_D48ds_v4   4096    48 GeneralPurpose
Standard_D64ds_v4   4096    64 GeneralPurpose
Standard_E2s_v3     8192     2 MemoryOptimized
Standard_E4s_v3     8192     4 MemoryOptimized
Standard_E8s_v3     8192     8 MemoryOptimized
Standard_E16s_v3    8192    16 MemoryOptimized
Standard_E32s_v3    8192    32 MemoryOptimized
Standard_E48s_v3    8192    48 MemoryOptimized
Standard_E64s_v3    6912    64 MemoryOptimized
Standard_E2ds_v4    8192     2 MemoryOptimized
Standard_E4ds_v4    8192     4 MemoryOptimized
Standard_E8ds_v4    8192     8 MemoryOptimized
Standard_E16ds_v4   8192    16 MemoryOptimized
Standard_E20ds_v4   8192    20 MemoryOptimized
Standard_E32ds_v4   8192    32 MemoryOptimized
Standard_E48ds_v4   8192    48 MemoryOptimized
Standard_E64ds_v4   6912    64 MemoryOptimized
```
This cmdlet shows basic sku information of the provided location.