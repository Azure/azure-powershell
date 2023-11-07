### Example 1: Create an connectedEnvironment.
```powershell
New-AzContainerAppConnectedEnv -Name azps-connectedenv -ResourceGroupName azps_test_group_app -Location eastus -ExtendedLocationName "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.ExtendedLocation/customLocations/my-custom-location" -ExtendedLocationType CustomLocation

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-connectedenv azps_test_group_app
```

Create an connectedEnvironment.
For more information on how to configure the base environment, see the steps in this document: https://learn.microsoft.com/en-us/azure/container-apps/azure-arc-enable-cluster?tabs=azure-powershell