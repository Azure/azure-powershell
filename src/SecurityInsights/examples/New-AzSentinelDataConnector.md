### Example 1: {{ Add title here }}
```powershell
New-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind 'MicrosoftThreatIntelligence' -BingSafetyPhishingURL Enabled -BingSafetyPhishingUrlLookbackPeriod All  -MicrosoftEmergingThreatFeed Enabled -MicrosoftEmergingThreatFeedLookbackPeriod All
```
```output
```

This command enables the Threat Intelligence data connector