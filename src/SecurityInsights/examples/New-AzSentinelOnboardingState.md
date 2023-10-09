### Example 1: Add Sentinel onboarding state
```powershell
New-AzSentinelOnboardingState -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Name "default"
```

```output
CustomerManagedKey           : 
Etag                         : 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/onboardingStates/default
Name                         : default
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 8/3/2023 3:49:07 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/3/2023 3:49:07 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.SecurityInsights/onboardingStates
```

This command configures the onboarding state of Sentinel