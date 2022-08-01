$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdScalingPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdScalingPlan' {
    It 'UpdateExpanded' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_resourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $env.Scaling_Location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @(
                    @{
                        'name'                           = 'Work Week';
                        'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');

                        'rampUpStartTime'                = @{
                                                                'hour' = 6
                                                                'minute' = 0
                                                            };
                        'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                        'rampUpMinimumHostsPct'          = 20;
                        'rampUpCapacityThresholdPct'     = 20;

                        'peakStartTime'                  = @{
                                                                'hour' = 8
                                                                'minute' = 30
                                                            };
                        'peakLoadBalancingAlgorithm'     = 'DepthFirst';

                        'RampDownStartTime'              = @{
                                                                'hour' = 16
                                                                'minute' = 15
                                                            };
                        'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                        'rampDownMinimumHostsPct'        = 20;
                        'rampDownCapacityThresholdPct'   = 20;
                        'rampDownForceLogoffUser'       = $true;
                        'rampDownWaitTimeMinute'        = 30;
                        'rampDownNotificationMessage'    = 'Log out now, please.';
                        'rampDownStopHostsWhen'          = 'ZeroSessions';

                        'offPeakStartTime'               = @{
                                                                'hour' = 18
                                                                'minute' = 0
                                                            };
                        'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                    }
                ) `
                -HostPoolReference @(
                    @{
                        'hostPoolArmPath' = $env.Scaling_HostPoolArmPath;
                        'scalingPlanEnabled' = $false;
                    }
                )

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Scaling_Location

            $scalingPlan = Update-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Description 'desc2' `
                -FriendlyName 'fri2' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @(
                    @{
                        'name'                           = 'Work Week';
                        'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');

                        'rampUpStartTime'                = @{
                                                                'hour' = 7
                                                                'minute' = 0
                                                            };
                        'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                        'rampUpMinimumHostsPct'          = 20;
                        'rampUpCapacityThresholdPct'     = 20;

                        'peakStartTime'                  = @{
                                                                'hour' = 8
                                                                'minute' = 30
                                                            };
                        'peakLoadBalancingAlgorithm'     = 'DepthFirst';

                        'RampDownStartTime'              = @{
                                                                'hour' = 16
                                                                'minute' = 15
                                                            };
                        'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                        'rampDownMinimumHostsPct'        = 20;
                        'rampDownCapacityThresholdPct'   = 20;
                        'rampDownForceLogoffUser'       = $true;
                        'rampDownWaitTimeMinute'        = 30;
                        'rampDownNotificationMessage'    = 'Log out now, please.';
                        'rampDownStopHostsWhen'          = 'ZeroSessions';

                        'offPeakStartTime'               = @{
                                                                'hour' = 18
                                                                'minute' = 0
                                                            };
                        'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                    }
                ) `
                -HostPoolReference @(
                    @{
                        'hostPoolArmPath' = $env.Scaling_HostPoolArmPath;
                        'scalingPlanEnabled' = $false;
                    },
                    @{
                        'hostPoolArmPath' = $env.Scaling_HostPoolArmPath2;
                        'scalingPlanEnabled' = $false;
                    }
                )
            
            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Scaling_Location
            $scalingPlan.Description | Should -Be 'desc2'
            $scalingPlan.FriendlyName | Should -Be 'fri2'
            $scalingPlan.Schedule.Count | Should -Be 1
            $scalingPlan.HostPoolReference.Count | Should -Be 2

            $scalingPlan = Get-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Schedule.Count | Should -Be 1
            $scalingPlan.HostPoolReference.Count | Should -Be 2
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }
}