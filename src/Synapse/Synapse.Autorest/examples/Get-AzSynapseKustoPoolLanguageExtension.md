### Example 1: List all language extensions set for a workspace
```powershell
Get-AzSynapseKustoPoolLanguageExtension -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testpool
```

```output
Name
----
PYTHON
```

The above command returns a list of language extensions that can run within KQL queries.


