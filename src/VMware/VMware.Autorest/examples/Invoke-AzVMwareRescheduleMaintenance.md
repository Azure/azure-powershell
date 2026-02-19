### Example 1: Reschedule a maintenance
```powershell
Invoke-AzVMwareRescheduleMaintenance -MaintenanceName maintenance1 -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         DisplayName      StateName ScheduledStartTime   ProvisioningState
----         -----------      --------- ------------------   -----------------
maintenance1 vcsa 7.0 upgrade Scheduled 1/12/2023 4:17:55 PM Succeeded
```

Reschedules the specified maintenance within the private cloud and resource group.