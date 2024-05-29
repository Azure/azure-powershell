### Example 1: Get location capabilities by location name
```powershell
Get-AzMySqlFlexibleServerLocationBasedCapability -Location westus2
```

```output
"Please refer to https://aka.ms/mysql-pricing for pricing details"

SKU               Memory Tier            vCore
---               ------ ----            -----
Standard_B1s        1024 Burstable           1
Standard_B1ms       2048 Burstable           1
Standard_B2s        2048 Burstable           2
Standard_D2ds_v4    4096 GeneralPurpose      2
Standard_D4ds_v4    4096 GeneralPurpose      4
Standard_D8ds_v4    4096 GeneralPurpose      8
Standard_D16ds_v4   4096 GeneralPurpose     16
Standard_D32ds_v4   4096 GeneralPurpose     32
Standard_D48ds_v4   4096 GeneralPurpose     48
Standard_D64ds_v4   4096 GeneralPurpose     64
Standard_E2ds_v4    8192 MemoryOptimized     2
Standard_E4ds_v4    8192 MemoryOptimized     4
Standard_E8ds_v4    8192 MemoryOptimized     8
Standard_E16ds_v4   8192 MemoryOptimized    16
Standard_E32ds_v4   8192 MemoryOptimized    32
Standard_E48ds_v4   8192 MemoryOptimized    48
Standard_E64ds_v4   8192 MemoryOptimized    64
```
This cmdlet shows basic sku information of the provided location.