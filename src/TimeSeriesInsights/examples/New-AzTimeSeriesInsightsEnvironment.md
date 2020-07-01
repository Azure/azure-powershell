### Example 1: Create a standard time series insights environment
```powershell
PS C:\> $TimeSpan = New-TimeSpan -Days 1 -Hours 1 -Minutes 25
PS C:\> New-AzTimeSeriesInsightsEnvironment -ResourceGroupName testgroup -Name tsitest001 -Kind Standard -Location eastus -Sku S1 -DataRetentionTime $TimeSpan -Capacity 2

Kind     Location Name       SkuCapacity SkuName Type
----     -------- ----       ----------- ------- ----
Standard eastus   tsitest001 2           S1      Microsoft.TimeSeriesInsights/Environments
```

This command creates a standard time series insights environment.

### Example 2: Create a longterm time series insights environment
```powershell
PS C:\> New-AzStorageAccount -ResourceGroupName testgroup -AccountName staccount001 -Location eastus -SkuName Standard_GRS
PS C:\> $ks = Get-AzStorageAccountKey -ResourceGroupName "testgroup" -Name "staccount001"
PS C:\> $k  = $ks[0] | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzTimeSeriesInsightsEnvironment -ResourceGroupName testgroup -Name tsitest002 -Kind LongTerm -Location eastus -Sku L1 -StorageAccountName staccount001 -StorageAccountKey $k -TimeSeriesIdProperty @{name='cdc';type='string'}

Kind     Location Name       SkuCapacity SkuName Type
----     -------- ----       ----------- ------- ----
LongTerm eastus   tsitest002 1           L1      Microsoft.TimeSeriesInsights/Environments
```

This command creates a longterm time series insights environment.
