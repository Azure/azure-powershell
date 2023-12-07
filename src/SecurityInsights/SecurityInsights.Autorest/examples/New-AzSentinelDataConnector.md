### Example 1: Enable a data connector.
```powershell
New-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind 'MicrosoftThreatIntelligence' -BingSafetyPhishingURL Enabled -BingSafetyPhishingUrlLookbackPeriod All  -MicrosoftEmergingThreatFeed Enabled -MicrosoftEmergingThreatFeedLookbackPeriod All
```

This command enables the Threat Intelligence data connector