### Example 1: Update a Windows Virtual Desktop Scaling Plan by name
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -HostPoolType 'Pooled' `
            -TimeZone 'Pacific Standard Time' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week'
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday')
                    'rampUpStartTime'                = @{
                                                            'hour' = 6
                                                            'minute' = 0
                                                        }
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst'
                    'rampUpMinimumHostsPct'          = 20
                    'rampUpCapacityThresholdPct'     = 20
                    'peakStartTime'                  = @{
                                                            'hour' = 8
                                                            'minute' = 30
                                                        }
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst'
                    'RampDownStartTime'              = @{
                                                            'hour' = 16
                                                            'minute' = 15
                                                        }
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst'
                    'rampDownMinimumHostsPct'        = 20
                    'rampDownCapacityThresholdPct'   = 20
                    'rampDownForceLogoffUser'        = $true
                    'rampDownWaitTimeMinute'         = 30
                    'rampDownNotificationMessage'    = 'Log out now, please.'
                    'rampDownStopHostsWhen'          = 'ZeroSessions'
                    'offPeakStartTime'               = @{
                                                            'hour' = 18
                                                            'minute' = 0
                                                        }
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst'
                }
            ) `
            -HostPoolReference @(
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName1';
                    'scalingPlanEnabled' = $false;
                },
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName2';
                    'scalingPlanEnabled' = $false;
                }

            )

Location      Name         Type
--------      ----         ----
westcentralus scalingPlan1 Microsoft.DesktopVirtualization/scalingplans
```

This command updates a Windows Virtual Desktop Scaling Plan in a Resource Group.