### Example 1: List all Threat Intelligence Indicators
```powershell
 Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Kind : indicator
Name : 8ff8f736-8f9b-a180-49a2-9a395cf088ca

Kind : indicator
Name : 8afa82a1-6c4a-dca2-595f-28239965882d
```

This command lists all Threat Intelligence Indicators under a Microsoft Sentinel workspace.

### Example 2: Get a Threat Intelligence Indicator
```powershell
 Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "514840ce-5582-f7a4-8562-7996e29dc07a"
```
```output
Kind : indicator
Name : 514840ce-5582-f7a4-8562-7996e29dc07a
```

This command gets a Threat Intelligence Indicator by name (Id)

### Example 3: Get the Threat Intelligence Indicator top 3
```powershell
 $tiIndicators = Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Top 3
```
```output
Kind : indicator
Name : 8ff8f736-8f9b-a180-49a2-9a395cf088ca

Kind : indicator
Name : 8afa82a1-6c4a-dca2-595f-28239965882d

Kind : indicator
Name : 38ac867b-85f9-be4c-afd5-b3cffdcf69f1
```

This command gets a Threat Intelligence Indicator by object