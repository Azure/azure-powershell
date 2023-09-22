### Example 1: Checks if resource name is available.
```powershell
Test-AzContainerAppNamespaceAvailability -EnvName azpsenv -ResourceGroupName azps_test_group_app -Name azpsapp -Type Microsoft.App/containerApps
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks if resource name is available.