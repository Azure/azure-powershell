### Example 1: List available SKUs and their properties in the location

```powershell
PS C:\> Get-AzPostgreSqlFlexibleServerLocationBasedCapability -Location eastus
For prices please refer to https://aka.ms/postgresql-pricing

SKU               Tier             VCore    Memory    Max Disk IOPS
----------------  ---------------  -------  --------  ---------------
Standard_B1ms     Burstable        1        2 GiB     640
Standard_B2s      Burstable        2        4 GiB     1280
Standard_D2s_v3   GeneralPurpose   2        8 GiB     3200
Standard_D4s_v3   GeneralPurpose   4        16 GiB    6400
Standard_D8s_v3   GeneralPurpose   8        32 GiB    12800
Standard_D16s_v3  GeneralPurpose   16       64 GiB    18000
Standard_D32s_v3  GeneralPurpose   32       128 GiB   18000
Standard_D48s_v3  GeneralPurpose   48       192 GiB   18000
Standard_D64s_v3  GeneralPurpose   64       256 GiB   18000
Standard_E2s_v3   MemoryOptimized  2        16 GiB    3200
Standard_E4s_v3   MemoryOptimized  4        32 GiB    6400
Standard_E8s_v3   MemoryOptimized  8        64 GiB    12800
Standard_E16s_v3  MemoryOptimized  16       128 GiB   18000
Standard_E32s_v3  MemoryOptimized  32       256 GiB   18000
Standard_E48s_v3  MemoryOptimized  48       384 GiB   18000
Standard_E64s_v3  MemoryOptimized  64       432 GiB   18000
```

Provide available skus in the location