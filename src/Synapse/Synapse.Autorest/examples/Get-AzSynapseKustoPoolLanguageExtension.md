### Example 1: List all language extensions set for a workspace
```powershell
PS C:\> Get-AzSynapseKustoPoolLanguageExtension -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testpool

Name
----
PYTHON
```

The above command returns a list of language extensions that can run within KQL queries.


