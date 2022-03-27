### Example 1: List all language extensions set for a cluster
```powershell
PS C:\> Get-AzKustoClusterLanguageExtension -ResourceGroupName testrg -ClusterName testnewkustocluster

Name
----
R
PYTHON
```

The above command returns a list of language extensions that can run within KQL queries.
