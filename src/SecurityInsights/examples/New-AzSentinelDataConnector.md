### Example 1: Create a Data Connector
```powershell
PS C:\> New-AzSentinelDataConnector -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind AzureSecurityCenter -Alerts Enabled -SubscriptionId ((Get-AzContext).Subscription.Id)

{{ Add output here }}
```

This command creates a Data Connector for a Microsoft Defender for Cloud subscription.

### Example 2: Create a Data Connector
```powershell
PS C:\> New-AzSentinelDataConnector -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind MicrosoftCloudAppSecurity -Alerts Enabled -DiscoveryLogs Disabled

{{ Add output here }}
```

This command creates a Data Connector for Microsoft Defender for Cloud Apps.

### Example 3: Create a Data Connector
```powershell
PS C:\> New-AzSentinelDataConnector -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind MicrosoftThreatIntelligence -BingSafetyPhishingURL "Enabled" -BingSafetyPhishingUrlLookbackPeriod "All" -MicrosoftEmergingThreatFeed "Enabled" -MicrosoftEmergingThreatFeedLookbackPeriod "All"

{{ Add output here }}
```

This command creates a Data Connector for Microsoft Threat Intelligence Feed.

