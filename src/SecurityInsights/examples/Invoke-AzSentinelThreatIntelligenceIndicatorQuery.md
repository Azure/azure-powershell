### Example 1: Query all Threat Intelligence Indicators
```powershell
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName"
```
```output
Etag                                    Kind        Name                                    SystemDataCreatedAt SystemDataCreatedBy
----                                    ----        ----                                    ------------------- -------
"b603878e-0000-0100-0000-62d1d0010000"  indicator   f4dd9aa3-081b-2f0b-a5d7-3805954e8a39
```

This command queries TI indicators.
