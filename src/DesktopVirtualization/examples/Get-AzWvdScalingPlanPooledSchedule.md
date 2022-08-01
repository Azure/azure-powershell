### Example 1: List Windows Virtual Desktop Scaling Plan Pooled Schedules
```powershell
Get-AzWvdScalingPlan -ResourceGroupName ResourceGroupName -ScalingPlanName scalingPlan1
```

```output
Location      Name                          Type
--------      ----                          ----
westcentralus scalingPlanScheduleWeekdays1 Microsoft.DesktopVirtualization/scalingPlans/pooledSchedules 
westcentralus scalingPlanScheduleWeekdays2 Microsoft.DesktopVirtualization/scalingPlans/pooledSchedules 
```

This command lists all the Windows Virtual Desktop Scaling Plans in a Resource Group.
### Example 2: Get a Windows Virtual Desktop Scaling Plan Pooled Schedule by name
```powershell
Get-AzWvdScalingPlan -ResourceGroupName ResourceGroupName -ScalingPlanName scalingPlan1 -ScalingPlanScheduleName 
```

```output
Location      Name                          Type
--------      ----                          ----
westcentralus scalingPlanScheduleWeekdays1 Microsoft.DesktopVirtualization/scalingPlans/pooledSchedules 
```

This command gets a Windows Virtual Desktop Scaling Plan in a Resource Group.