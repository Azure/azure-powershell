Example 1: Create a new Kusto pool
```powershell
PS C:\> New-AzSynapseKustoPool -ResourceGroupName "testrg" -WorkspaceName "testws" -Name "testnewkustopool" -Location "East US" -SkuName "Storage optimized" -SkuSize "Medium"
```

The above command creates a new Kusto pool named "testnewkustopool" in the workspace "testws" in resource group "testrg".
