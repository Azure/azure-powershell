### Example 1: Update a ScalingPlanPooledSchedule
```powershell
Update-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName `
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
spName/scheduleName
```

Updates an existing PooledSchedule in a Scaling Plan.