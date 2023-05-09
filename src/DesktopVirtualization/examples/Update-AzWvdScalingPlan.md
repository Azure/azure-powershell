### Example 1: Update a Windows Virtual Desktop Scaling Plan by name
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week';
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'rampUpStartTime'                = '1900-01-01T06:00:00Z';
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'rampUpMinimumHostsPct'          = 20;
                    'rampUpCapacityThresholdPct'     = 20;
                    'peakStartTime'                  = '1900-01-01T08:00:00Z';
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst';
                    'RampDownStartTime'              = '1900-01-01T18:00:00Z';
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'rampDownMinimumHostsPct'        = 20;
                    'rampDownCapacityThresholdPct'   = 20;
                    'rampDownForceLogoffUser'        = $true;
                    'rampDownWaitTimeMinute'         = 30;
                    'rampDownNotificationMessage'    = 'Log out now, please.';
                    'rampDownStopHostsWhen'          = 'ZeroSessions';
                    'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
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
```

```output
Location      Name         Type
--------      ----         ----
westcentralus scalingPlan1 Microsoft.DesktopVirtualization/scalingplans
```

This command updates a Windows Virtual Desktop Scaling Plan in a Resource Group.
