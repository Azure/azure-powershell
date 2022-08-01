### Example 1: Create a Windows Virtual Desktop Scaling Plan Pooled Schedule
```powershell
New-AzWvdScalingPlanPooledSchedule `
    -ResourceGroupName ResourceGroupName `
    -scalingPlanName 'scalingPlan1' `
    -ScalingPlanScheduleName 'PooledSchedule1' `
    -DaysOfWeek 'Monday','Tuesday','Wednesday' `
    -RampUpStartTimeHour '6' `
    -RampUpStartTimeMinute '0' `
    -RampUpMinimumHostsPct 1 `
    -RampUpLoadBalancingAlgorithm 'BreadthFirst' `
    -RampUpCapacityThreshold 10 `
    -PeakStartTimeHour '8' `
    -PeakStartTimeMinute '15' `
    -PeakLoadBalancingAlgorithm 'BreadthFirst' `
    -RampDownStartTimeHour '16' `
    -RampDownStartTimeMinute '30' `
    -RampDownLoadBalancingAlgorithm 'BreadthFirst' `
    -RampDownCapacityThreshold 10 `
    -OffPeakStartTimeHour '18' `
    -OffPeakStartTimeMinute '45'
```

Location      Name         Type
--------      ----         ----
westcentralus scalingPlanScheduleWeekdays1 Microsoft.DesktopVirtualization/scalingPlans/pooledSchedules 
```

This command creates a new Windows Virtual Desktop Scaling Plan in a Resource Group.
