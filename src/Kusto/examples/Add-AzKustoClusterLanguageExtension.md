### Example 1: Add a list of language extensions
```powershell
PS C:\> Add-AzKustoClusterLanguageExtension -ResourceGroupName testrg -ClusterName testnewkustocluster -Value (@{Name="R"}, @{Name="PYTHON"})
```

The above command adds a list of language extensions that can run within KQL queries
