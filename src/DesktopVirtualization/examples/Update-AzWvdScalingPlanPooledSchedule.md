### Example 1: Update a ScalingPlanPooledSchedule
```powershell
Update-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -daysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -rampUpStartTime 1900-01-01T06:00:00Z `
                                        -rampUpLoadBalancingAlgorithm BreadthFirst `
                                        -rampUpMinimumHostsPct 20 `
                                        -rampUpCapacityThresholdPct 20 `
                                        -peakStartTime 1900-01-01T08:00:00Z `
                                        -peakLoadBalancingAlgorithm DepthFirst `
                                        -RampDownStartTime 1900-01-01T18:00:00Z `
                                        -rampDownLoadBalancingAlgorithm BreadthFirst `
                                        -rampDownMinimumHostsPct = 20 `
                                        -rampDownCapacityThresholdPct = 20 `
                                        -rampDownForceLogoffUser $true `
                                        -rampDownWaitTimeMinute 30 `
                                        -rampDownNotificationMessage "Log out now, please." `
                                        -rampDownStopHostsWhen ZeroSessions `
                                        -offPeakStartTime 1900-01-01T20:00:00Z `
                                        -offPeakLoadBalancingAlgorithm DepthFirst
```

```output
Name
----
spName/scheduleName
```

Updates an existing PooledSchedule in a Scaling Plan.
