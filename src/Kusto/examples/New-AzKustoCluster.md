### Example 1: Create a new Kusto cluster
```powershell
<<<<<<< HEAD
New-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster -Location 'East US' -SkuName Standard_D11_v2 -SkuTier Standard -EnableDoubleEncryption -EngineType 'V2'
=======
New-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster -Location 'East US' -SkuName Standard_D11_v2 -SkuTier Standard -EnableDoubleEncryption true -EngineType 'V2'
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Location Name                Type                     Zone
-------- ----                ----                     ----
East US  testnewkustocluster Microsoft.Kusto/Clusters
```

The above command creates a new Kusto cluster named "testnewkustocluster" in the resource group "testrg".
