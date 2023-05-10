### Example 1: Creates a configuration store with the specified parameters.
```powershell
New-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -Location eastus -Sku Standard
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
```

Creates a configuration store with the specified parameters.

### Example 2: Recover one deleted store.
```powershell
$storeName = "azpstest-appstore-recover"
$resourceGroupName = "azpstest_gp"
$location = "eastus"
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard
Remove-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName
Get-AzAppConfigurationDeletedStore -Location $location -Name $storeName
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard -CreateMode 'Recover'
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus   azpstest-appstore-recover azpstest_gp
```

Recover one deleted store.