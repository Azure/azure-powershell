### Example 1: List all Data Connectors
```powershell
 Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Kind : AzureActiveDirectory
Name : 8207e1f9-a793-4869-afb1-5ad4540d66d1

Kind : AzureAdvancedThreatProtection
Name : 1d75aada-a558-4461-986b-c6822182e81d

Kind : Office365
Name : 6323c716-83ae-4cfd-bf93-58235c8beb23

```

This command lists all DataConnectors under a Microsoft Sentinel workspace.

### Example 2: Get a specific Data Connector
```powershell
 Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" | Where-Object {$_.kind -eq "Office365"}
```
```output
Kind                         : Office365
Name                         : 6323c716-83ae-4cfd-bf93-58235c8beb23
SharePointState              : enabled
```

This command gets a specific DataConnector based on kind