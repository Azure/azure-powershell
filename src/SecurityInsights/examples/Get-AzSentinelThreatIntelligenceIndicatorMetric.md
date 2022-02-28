### Example 1: Get all metrics for Threat Intelligence Indicators
```powershell
PS C:\> Get-AzSentinelThreatIntelligenceIndicatorMetric -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

LastUpdatedTimeUtc : 2022-02-07T10:44:45.3919348Z
PatternTypeMetric  : {network-traffic, url, ipv4-addr, file}
SourceMetric       : {Microsoft Emerging Threat Feed, Bing Safety Phishing URL, Azure Sentinel, CyberCrime…}
ThreatTypeMetric   : {botnet, maliciousurl, phishing, malicious-activity…}
```

This command gets Threat Intelligence Indicator metrics.