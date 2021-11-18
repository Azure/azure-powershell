### Example 1: List all Onboarding States
```powershell
PS C:\> Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Onboarding States under a Microsoft Sentinel workspace.

### Example 2: Get an Onboarding State
```powershell
PS C:\> Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "default"

{{ Add output here }}
```

This command gets an Onboarding State.

### Example 3: Get an Onboarding State by object Id
```powershell
PS C:\> $OnboardingStates = Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $OnboardingStates[0] | Get-AzSentinelOnboardingState

{{ Add output here }}
```

This command gets an Onboarding State by object