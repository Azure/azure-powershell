### Example 1: Schedule a maintenance
```powershell
Invoke-AzVMwareScheduleMaintenance -MaintenanceName maintenance1 -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         DisplayName      StateName    ScheduledStartTime   ReadinessStatus ProvisioningState
----         -----------      ---------    ------------------   --------------- -----------------
maintenance1 vcsa 7.0 upgrade NotScheduled 1/12/2023 4:17:55 PM NotReady        Succeeded
```

Schedules the specified maintenance item within the private cloud and resource group.