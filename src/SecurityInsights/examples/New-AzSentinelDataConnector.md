### Example 1: Enable a data connector.
```powershell
New-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind 'ThreatIntelligence' -Indicator Enabled
```

This command enables the Threat Intelligence data connector