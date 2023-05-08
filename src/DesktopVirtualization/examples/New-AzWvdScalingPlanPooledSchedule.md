### Example 1: Create a Scaling Plan Pooled Schedule
```powershell
New-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -daysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -rampUpStartTimeHour 6 `
                                        -rampUpStartTimeMinute 30 `
                                        -rampUpLoadBalancingAlgorithm BreadthFirst `
                                        -rampUpMinimumHostsPct 20 `
                                        -rampUpCapacityThresholdPct 20 `
                                        -peakStartTimeHour 8 `
                                        -peakStartTimeMinute 30 `
                                        -peakLoadBalancingAlgorithm DepthFirst `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -rampDownLoadBalancingAlgorithm BreadthFirst `
                                        -rampDownMinimumHostsPct 20 `
                                        -rampDownCapacityThresholdPct 20 `
                                        -rampDownForceLogoffUser:$true `
                                        -rampDownWaitTimeMinute 30 `
                                        -rampDownNotificationMessage "Log out now, please." `
                                        -rampDownStopHostsWhen ZeroSessions `
                                        -offPeakStartTimeHour 22 `
                                        -offPeakStartTimeMinute 45 `
                                        -offPeakLoadBalancingAlgorithm DepthFirst
```

```output
Name
----
scalingplan1/PooledSchedule1
```

Add a Scaling Plan Pooled Schedule to an existing Scaling Plan.
