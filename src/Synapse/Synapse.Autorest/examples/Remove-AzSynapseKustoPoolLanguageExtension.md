### Example 1: Remove a list of language extensions from kusto pool
```powershell
PS C:\> Remove-AzSynapseKustoPoolLanguageExtension -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -Value (@{Name="R"})
```

The above command removes a list of language extensions that can run within KQL queries.
