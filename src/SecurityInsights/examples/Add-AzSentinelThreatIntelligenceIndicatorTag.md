### Example 1: Add a tag to a Threat Intelligence Indicator
```powershell
PS C:\> Add-AzSentinelThreatIntelligenceIndicatorTag -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "myThreatIntelligenceIndicatorName" -ThreatIntelligenceTag @("myTITag")

{{ Add output here }}
```

This command adds a tag to a Threat Intelligence Indicator.

### Example 1: Add a tag by Threat Intelligence Indicator object Id
```powershell
PS C:\> $tiIndicator = Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "myThreatIntelligenceIndicatorName" 
PS C:\> $tiIndicator | Get-AzSentinelThreatIntelligenceIndicatorTag -ThreatIntelligenceTag @("myTITag")

{{ Add output here }}
```

This command adds a tag to a Threat Intelligence Indicator by object.