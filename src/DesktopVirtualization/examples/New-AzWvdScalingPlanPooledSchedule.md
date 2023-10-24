### Example 1: Create a Scaling Plan Pooled Schedule
```powershell
New-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -DaysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -RampUpStartTimeHour 6 `
                                        -RampUpStartTimeMinute 30 `
                                        -RampUpLoadBalancingAlgorithm BreadthFirst `
                                        -RampUpMinimumHostsPct 20 `
                                        -RampUpCapacityThresholdPct 20 `
                                        -PeakStartTimeHour 8 `
                                        -PeakStartTimeMinute 30 `
                                        -PeakLoadBalancingAlgorithm DepthFirst `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -RampDownLoadBalancingAlgorithm BreadthFirst `
                                        -RampDownMinimumHostsPct 20 `
                                        -RampDownCapacityThresholdPct 20 `
                                        -RampDownForceLogoffUser:$true `
                                        -RampDownWaitTimeMinute 30 `
                                        -RampDownNotificationMessage "Log out now, please." `
                                        -RampDownStopHostsWhen ZeroSessions `
                                        -OffPeakStartTimeHour 22 `
                                        -OffPeakStartTimeMinute 45 `
                                        -OffPeakLoadBalancingAlgorithm DepthFirst
```

```output
Name
----
scalingplan1/PooledSchedule1
```

Add a Scaling Plan Pooled Schedule to an existing Scaling Plan.