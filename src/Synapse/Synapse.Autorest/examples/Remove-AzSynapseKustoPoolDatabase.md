### Example 1: Delete an existing Kusto database by name
```powershell
PS C:\> Remove-AzSynapseKustoPoolDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -Name mykustodatabase
```

The above command deletes the Kusto database named "mykustodatabase" in the workspace "testws" found in the resource group "testrg".

