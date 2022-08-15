### Example 1: Remove a list of language extensions from cluster
```powershell
Remove-AzKustoClusterLanguageExtension -ResourceGroupName testrg -ClusterName testnewkustocluster -Value (@{Name="R"})
```

The above command removes a list of language extensions that can run within KQL queries.
