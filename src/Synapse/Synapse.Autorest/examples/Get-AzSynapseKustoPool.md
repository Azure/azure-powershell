### Example 1: List all Kusto pools in a workspace
```powershell
PS C:\> Get-AzSynapseKustoPool -ResourceGroupName testrg -WorkspaceName testws

Location  Name                     Type                                    Etag
--------  ----                     ----                                    ----
East US 2 testws/testnewkustopool  Microsoft.Synapse/workspaces/kustoPools 
East US 2 testws/testnewkustopool1 Microsoft.Synapse/workspaces/kustoPools
```

The above command lists all Kusto pools in the resource group "testrg".

### Example 2: Get a specific Kusto pool by name
```powershell
PS C:\> Get-AzSynapseKustoPool -ResourceGroupName testrg -WorkspaceName testws -Name testnewkustopool

Location  Name                    Type                                    Etag
--------  ----                    ----                                    ----
East US 2 testws/testnewkustopool Microsoft.Synapse/workspaces/kustoPools 
```

The above command returns the Kusto pool named "testnewkustopool" in the resource group "testrg".

