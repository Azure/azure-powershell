### Example 1: Create the Fusion Alert rule
```powershell
 $AlertRuleTemplateName = "f71aba3d-28fb-450b-b192-4e76a83015c8"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind Fusion -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
```

This command creates an Alert Rule of the Fusion kind based on the template "Advanced Multistage Attack Detection"

### Example 2: Create the ML Behavior Analytics Alert Rule
```powershell
 $AlertRuleTemplateName = "fa118b98-de46-4e94-87f9-8e6d5060b60b"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind MLBehaviorAnalytics -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
```

This command creates an Alert Rule of the MLBehaviorAnalytics kind based on the template "Anomalous SSH Login Detection"

### Example 3: Create the Threat Intelligence Alert Rule
```powershell
 $AlertRuleTemplateName = "0dd422ee-e6af-4204-b219-f59ac172e4c6"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind ThreatIntelligence -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
```

This command creates an Alert Rule of the ThreatIntelligence kind based on the template "Microsoft Threat Intelligence Analytics"

### Example 4: Create a Microsoft Security Incident Creation Alert Rule
```powershell
 $AlertRuleTemplateName = "a2e0eb51-1f11-461a-999b-cd0ebe5c7a72"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind MicrosoftSecurityIncidentCreation -Enabled -AlertRuleTemplateName $AlertRuleTemplateName -ProductFilter "Azure Security Center for IoT"
```

This command creates an Alert Rule of the MicrosoftSecurityIncidentCreation kind based on the template for Create incidents based on Azure Security Center for IoT alerts.

### Example 5: Create a Scheduled Alert Rule
```powershell
New-AzSentinelAlertRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind Scheduled -Enabled -DisplayName "Powershell Exection Alert (Several Times per Hour)" -Severity Low -Query "SecurityEvent | where EventId == 4688" -QueryFrequency (New-TimeSpan -Hours 1) -QueryPeriod (New-TimeSpan -Hours 1) -TriggerThreshold 10
```

This command creates an Alert Rule of the Scheduled kind. Please note that that query (parameter -Query) needs to be on a single line as as string.

### Example 6: Create a Near Realtime Alert Rule
```powershell
New-AzSentinelAlertRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind NRT -Enabled -DisplayName "Break glass account accessed" -Severity High -Query "let Break_Glass_Account = _GetWatchlist('break_glass_account')\n|project UPN;\nSigninLogs\n| where UserPrincipalName in (Break_Glass_Account)"
```

This command creates an Alert Rule of the NRT kind. Please note that that query (parameter -Query) needs to be on a single line as as string.
