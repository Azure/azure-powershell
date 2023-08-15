### Example 1: Get a Scaling Plan Personal Schedule
```powershell
Get-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName -ScalingPlanName scalingPlan1
```

```output
Name
----
scalingPlan1/weekdays_schedule
scalingPlan1/PersonalSchedule1
```

Gets an existing Scaling Plan Personal Schedule.