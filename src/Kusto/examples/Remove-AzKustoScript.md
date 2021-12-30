### Example 1: Delete a Kusto script 
```powershell
PS C:\> Remove-AzKustoScript -ClusterName testnewkustocluster -ResourceGroupName testrg -DatabaseName mykustodatabase -Name newkustoscript
```

The above command deletes the Kusto script named "newkustoscript" in the cluster "testnewkustocluster" found in the resource group "testrg".
