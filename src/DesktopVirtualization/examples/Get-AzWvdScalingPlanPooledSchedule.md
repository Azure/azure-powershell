### Example 1: Get a Scaling Plan Pooled Schedule
```powershell
Get-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName -ScalingPlanName scalingPlan1
```

```output
Name
----
scalingPlan1/weekdays_schedule
scalingPlan1/PooledSchedule1
```

Gets an existing ScalingPlanPooledSchedule.
