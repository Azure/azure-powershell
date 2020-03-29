### Example 1: Update an existing cluster by name
```powershell
PS C:\> Update-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster -Sku Standard_D12_v2 -SkuTier Standard

Location Name                Type                     Zone
-------- ----                ----                     ----
East US  testnewkustocluster Microsoft.Kusto/Clusters
```

The above command updates the sku of the Kusto cluster "testnewkustocluster" found in the resource group "testrg".

### Example 2: Update an existing cluster by piping
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

The above command gets the Kusto cluster "testnewkustocluster" found in the resource group "testrg" using the `Get-AzKustoCluster` cmdlet, and then pipes the result to `Update-AzKustoCluster` to update the cluster's sku to "Standard_D12_v2".
