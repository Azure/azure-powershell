### Example 1: Enables the Threat Intelligence data connector
```powershell
New-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind 'MicrosoftThreatIntelligence' -BingSafetyPhishingURL Enabled -BingSafetyPhishingUrlLookbackPeriod All  -MicrosoftEmergingThreatFeed Enabled -MicrosoftEmergingThreatFeedLookbackPeriod All
```

This command enables the Threat Intelligence data connector