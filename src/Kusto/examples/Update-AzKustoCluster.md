### Example 1: Update an existing cluster by name
```powershell
PS C:\> Update-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster -Sku Standard_D12_v2 -SkuTier Standard

Location Name                Type                     Zone
-------- ----                ----                     ----
East US  testnewkustocluster Microsoft.Kusto/Clusters
```

The above command updates the sku of the Kusto cluster "testnewkustocluster" found in the resource group "testrg".
