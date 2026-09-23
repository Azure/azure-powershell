### Example 1: List maintenance under resource group
```powershell
Get-AzVMwareMaintenance -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         ResourceGroupName
----         -----------------
maintenance1 group1
maintenance2 group1
```

Lists all maintenance items within the specified private cloud and resource group

### Example 2: Get a maintenace by name in a private cloud
```powershell
Get-AzVMwareMaintenance -Name maintenance1 -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         DisplayName      Component StateName ReadinessStatus ScheduledStartTime    EstimatedDurationInMinute ClusterId
----         -----------      --------- --------- --------------- ------------------    ------------------------- ---------
maintenance1 vcsa 7.0 upgrade VCSA      Scheduled NotReady        1/12/2023 11:00:11 AM                       960         1
```

Gets detailed information about a specific maintenance item by name within the private cloud and resource group.

