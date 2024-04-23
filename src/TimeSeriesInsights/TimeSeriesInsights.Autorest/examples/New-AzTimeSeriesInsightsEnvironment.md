### Example 1: Create a Gen1 time series insights environment
```powershell
$TimeSpan = New-TimeSpan -Days 1 -Hours 1 -Minutes 25
New-AzTimeSeriesInsightsEnvironment -ResourceGroupName testgroup -Name tsitest001 -Kind Gen1 -Location eastus -Sku S1 -DataRetentionTime $TimeSpan -Capacity 2
```
```output
Kind     Location  Name         SkuCapacity  SkuName  Type
----     --------  ----         -----------  -------  ----
Gen1     eastus    tsitest001      2           S1     Microsoft.TimeSeriesInsights/Environments
```

This command creates a Gen1 time series insights environment.

### Example 2: Create a Gen2 time series insights environment
```powershell
$ks = Get-AzStorageAccountKey -ResourceGroupName "testgroup" -Name "staccount001"
$k  = $ks[0].Value | ConvertTo-SecureString -AsPlainText -Force
New-AzTimeSeriesInsightsEnvironment -ResourceGroupName testgroup -Name tsitest002 -Kind Gen2 -Location eastus -Sku L1 -StorageAccountName staccount001 -StorageAccountKey $k -TimeSeriesIdProperty @{name='cdc';type='string'}
```
```output
Kind     Location  Name        SkuCapacity  SkuName  ype
----     --------  ----        -----------  -------  ----
Gen2     eastus    tsitest002       1         L1     Microsoft.TimeSeriesInsights/Environments
```

This command creates a Gen2 time series insights environment.
