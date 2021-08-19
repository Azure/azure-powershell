### Example 1: Delete an existing Kusto pool by name
```powershell
PS C:\> Remove-AzSynapseKustoPool -ResourceGroupName testrg -WorkspaceName testws -Name testnewkustopool
```

The above command deletes the Kusto pool named "testnewkustopool" in the workspace "testws".
