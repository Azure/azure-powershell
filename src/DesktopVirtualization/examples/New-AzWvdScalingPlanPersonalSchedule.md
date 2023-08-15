### Example 1: Create a Scaling Plan Personal Schedule
```powershell
New-AzWvdScalingPlanPersonalSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -daysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -rampUpStartTimeHour 6 `
                                        -rampUpStartTimeMinute 30 `
                                        -rampUpAutoStartHosts All `
                                        -rampUpStartVMOnConnect Enable `
                                        -rampUpActionOnDisconnect None `
                                        -rampUpMinutesToWaitOnDisconnect 10 `
                                        -rampUpActionOnLogoff None `
                                        -rampUpMinutesToWaitOnLogoff 10 `
                                        -peakStartTimeHour 8 `
                                        -peakStartTimeMinute 30 `
                                        -peakStartVMOnConnect Enable `
                                        -peakActionOnDisconnect None `
                                        -peakMinutesToWaitOnDisconnect 10 `
                                        -peakActionOnDisconnect Deallocate `
                                        -peakMinutesToWaitOnLogoff 10 `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -rampDownStartVMOnConnect Enable `
                                        -rampDownActionOnDisconnect None `
                                        -rampDownMinutesToWaitOnDisconnect 10 `
                                        -rampDownMinutesToWaitOnLogoff 10 `
                                        -rampDownActionOnLogoff None `
                                        -offPeakStartTimeHour 22 `
                                        -offPeakStartTimeMinute 45 `
                                        -offPeakStartVMOnConnect Enable `
                                        -offPeakActionOnDisconnect None `
                                        -offPeakMinutesToWaitOnDisconnect 10 `
                                        -offPeakActionOnLogoff Deallocate `
                                        -offPeakMinutesToWaitOnLogoff 10
```

```output
Name
----
scalingplan1/PersonalSchedule1
```

Add a Scaling Plan Personal Schedule to an existing Scaling Plan.