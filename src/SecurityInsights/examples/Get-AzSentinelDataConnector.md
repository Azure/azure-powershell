### Example 1: List all Data Connectors
```powershell
PS C:\> Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all DataConnectors under a Microsoft Sentinel workspace.

### Example 2: Get a Data Connector
```powershell
PS C:\> Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myDataConnectorId"

{{ Add output here }}
```

This command gets a DataConnector.

### Example 3: Get a Data Connector by object Id
```powershell
PS C:\> $DataConnectors = Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $DataConnectors[0] | Get-AzSentinelDataConnector

{{ Add output here }}
```

This command gets a Data Connector by object