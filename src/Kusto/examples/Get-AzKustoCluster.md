### Example 1: List all Kusto clusters in a resource group
```powershell
PS C:\> Get-AzKustoCluster -ResourceGroupName testrg

Location Name                 Type                     Zone
-------- ----                 ----                     ----
East US  testnewkustocluster  Microsoft.Kusto/Clusters
East US  testnewkustocluster2 Microsoft.Kusto/Clusters
```

The above command lists all Kusto clusters in the resource group "testrg".

### Example 2: Get a specific Kusto cluster by name
```powershell
PS C:\>  Get-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster

Location Name                Type                     Zone
-------- ----                ----                     ----
East US  testnewkustocluster Microsoft.Kusto/Clusters
```

The above command returns the Kusto cluster named "testnewkustocluster" in the resource group "testrg".
