### Example 1: Update an existing kusto script by name
```powershell
Update-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $resourceGroupName -SubscriptionId $SubscriptionId -JsonString $jsonBody
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command updates the Kusto script "newkustoscript" found in the resource group "testrg".