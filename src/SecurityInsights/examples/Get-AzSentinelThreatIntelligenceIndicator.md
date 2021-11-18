### Example 1: List all Threat Intelligence Indicators
```powershell
PS C:\> Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Threat Intelligence Indicators under a Microsoft Sentinel workspace.

### Example 2: Get a Threat Intelligence Indicator
```powershell
PS C:\> Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "myBookmarkName"

{{ Add output here }}
```

This command gets a Threat Intelligence Indicator.

### Example 3: Get a Threat Intelligence Indicator by object Id
```powershell
PS C:\> $tiIndicators = Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $tiIndicators[0] | Get-AzSentinelThreatIntelligenceIndicator

{{ Add output here }}
```

This command gets a Threat Intelligence Indicator by object