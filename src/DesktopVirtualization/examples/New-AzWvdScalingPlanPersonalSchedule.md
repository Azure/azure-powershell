### Example 1: Create a Scaling Plan Personal Schedule
```powershell
New-AzWvdScalingPlanPersonalSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -DaysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -RampUpStartTimeHour 6 `
                                        -RampUpStartTimeMinute 30 `
                                        -RampUpAutoStartHost "None" `
                                        -RampUpStartVMOnConnect Enable `
                                        -RampUpActionOnDisconnect None `
                                        -RampUpMinutesToWaitOnDisconnect 10 `
                                        -RampUpActionOnLogoff None `
                                        -RampUpMinutesToWaitOnLogoff 10 `
                                        -peakStartTimeHour 8 `
                                        -PeakStartTimeMinute 30 `
                                        -PeakStartVMOnConnect Enable `
                                        -PeakActionOnDisconnect None `
                                        -PeakMinutesToWaitOnDisconnect 10 `
                                        -PeakMinutesToWaitOnLogoff 10 `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -RampDownStartVMOnConnect Enable `
                                        -RampDownActionOnDisconnect None `
                                        -RampDownMinutesToWaitOnDisconnect 10 `
                                        -RampDownMinutesToWaitOnLogoff 10 `
                                        -RampDownActionOnLogoff None `
                                        -OffPeakStartTimeHour 22 `
                                        -OffPeakStartTimeMinute 45 `
                                        -OffPeakStartVMOnConnect Enable `
                                        -OffPeakActionOnDisconnect None `
                                        -OffPeakMinutesToWaitOnDisconnect 10 `
                                        -OffPeakActionOnLogoff Deallocate `
                                        -OffPeakMinutesToWaitOnLogoff 10
```

```output
Name
----
scalingplan1/PersonalSchedule1
```

Add a Scaling Plan Personal Schedule to an existing Scaling Plan.