### Example 1: Update a Windows Virtual Desktop Scaling Plan by name
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'ScalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -TimeZone 'Pacific Standard Time' `
            -Schedule @(
                @{
                    'Name'                           = 'Work Week';
                    'DaysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'RampUpStartTime'                = @{
                                                            'Hour' = 7
                                                            'Minute' = 0
                                                        };
                    'RampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'RampUpMinimumHostsPct'          = 20;
                    'RampUpCapacityThresholdPct'     = 20;

                    'PeakStartTime'                  = @{
                                                            'Hour' = 9
                                                            'Minute' = 30
                                                        };
                    'PeakLoadBalancingAlgorithm'     = 'DepthFirst';

                    'RampDownStartTime'              = @{
                                                            'Hour' = 16
                                                            'Minute' = 15
                                                        };
                    'RampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'RampDownMinimumHostsPct'        = 20;
                    'RampDownCapacityThresholdPct'   = 20;
                    'RampDownForceLogoffUser'       = $true;
                    'RampDownWaitTimeMinute'        = 30;
                    'RampDownNotificationMessage'    = 'Log out now, please.';
                    'RampDownStopHostsWhen'          = 'ZeroSessions';

                    'OffPeakStartTime'               = @{
                                                            'Hour' = 18
                                                            'Minute' = 0
                                                        };
                    'OffPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'HostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName1';
                    'ScalingPlanEnabled' = $false;
                },
                @{
                    'HostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName2';
                    'ScalingPlanEnabled' = $false;
                }

            )
```

```output
Location      Name         Type
--------      ----         ----
westcentralus scalingPlan1 Microsoft.DesktopVirtualization/scalingplans
```

This command updates a Windows Virtual Desktop Scaling Plan in a Resource Group.
