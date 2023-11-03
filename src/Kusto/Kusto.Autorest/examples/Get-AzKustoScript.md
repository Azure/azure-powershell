### Example 1: List all Kusto cluster database scripts

```powershell
Get-AzKustoScript -ClusterName testnewkustocluster -ResourceGroupName testrg -DatabaseName mykustodatabase
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command returns all Kusto cluster database scripts in the cluster "testnewkustocluster" found in the resource group "testrg".

### Example 2: Get a specific Kusto database script by name
```powershell
Get-AzKustoScript -ClusterName testnewkustocluster -ResourceGroupName testrg -DatabaseName mykustodatabase -Name newkustoscript
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command returns the Kusto database script named "newkustoscript" in the cluster "testnewkustocluster" found in the resource group "testrg".
