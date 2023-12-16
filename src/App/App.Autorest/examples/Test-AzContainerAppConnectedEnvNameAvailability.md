### Example 1: Checks if resource connectedEnvironmentName is available.
```powershell
Test-AzContainerAppConnectedEnvNameAvailability -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Type Microsoft.App/containerApps -Name azpsconenv
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks if resource connectedEnvironmentName is available.