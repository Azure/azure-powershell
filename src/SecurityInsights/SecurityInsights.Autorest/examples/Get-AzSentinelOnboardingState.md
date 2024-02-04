### Example 1: List all Onboarding States
```powershell
 Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Id   : /subscriptions/314b1a41-c53c-4092-8d4a-2810f6a44a0c/resourceGroups/myRG/providers/Microsoft.OperationalInsights/workspaces/cybersecurity/providers/Microsoft.SecurityInsights/onboardingStates/default
Name : default
```

This command lists all Onboarding States under a Microsoft Sentinel workspace.

### Example 2: Get an Onboarding State
```powershell
 Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "default"
```
```output
Id   : /subscriptions/314b1a41-c53c-4092-8d4a-2810f6a44a0c/resourceGroups/myRG/providers/Microsoft.OperationalInsights/workspaces/cybersecurity/providers/Microsoft.SecurityInsights/onboardingStates/default
Name : default
```

This command gets an Onboarding State.