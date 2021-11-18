### Example 1: Query Threat Intelligence Indicators
```powershell
PS C:\> Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -MinConfidence 50 -ThreatType @("phishing")

{{ Add output here }}
```

This command queries for all Threat Intelligence Indicators with a minamum Confidence score of 50 and a threat type of phising.

### Example 2: Query Threat Intelligence Indicators
```powershell
PS C:\> Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Source @("Microsoft Emerging Threat Feed") -Keyword @("117.117.96.9")

{{ Add output here }}
```

This command queries for all Threat Intelligence Indicators from the Microsoft Emerging Threat Feed where the IP Address exists.
