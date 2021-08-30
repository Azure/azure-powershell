### Example 1: Update an existing cluster by name
```powershell
PS C:\> Update-AzSynapseKustoPool -ResourceGroupName testrg -WorkspaceName testws -Name testnewkustopool -SkuName "Storage optimized" -SkuSize Medium

Location  Name                    Type                                    Etag
--------  ----                    ----                                    ----
East US 2 testws/testnewkustopool Microsoft.Synapse/workspaces/kustoPools 
```

The above command updates the sku of the Kusto pool "testnewkustopool" found in the workspace "testws".
