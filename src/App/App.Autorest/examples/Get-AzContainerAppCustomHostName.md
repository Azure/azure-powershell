### Example 1: Analyzes a custom hostname for a Container App.
```powershell
Get-AzContainerAppCustomHostName -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app
```

```output
ConflictWithEnvironmentCustomDomain ConflictingContainerAppResourceId CustomDomainVerificationTest HasConflictOnManagedEnvironment HostName IsHostnameAlreadyVerified
----------------------------------- --------------------------------- ---------------------------- ------------------------------- -------- -------------------------
False                                                                 Failed                       False                                    False
```

Analyzes a custom hostname for a Container App.