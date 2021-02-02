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

# TODO: Use this because we have limited Arm rollout for this feature, change to use $env.Location and $env.ResourceGroup
#$resourceGroup = $env.ResourceGroup
#$resourceLocation = $env.Location
$resourceGroup = 'jehurren-westcentralus'
$resourceLocation = 'westcentralus'

Describe 'Update-AzWvdScalingPlan' {
    It 'UpdateExpanded' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $resourceLocation `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
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
                        'rampDownForceLogoffUser'       = $true;
                        'rampDownWaitTimeMinute'        = 30;
                        'rampDownNotificationMessage'    = 'Log out now, please.';
                        'rampDownStopHostsWhen'          = 'ZeroSessions';

                        'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                        'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                    }
                ) `
                -HostPoolReference @(
                    @{
                        'hostPoolArmPath' = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$resourceGroup/providers/Microsoft.DesktopVirtualization/hostPools/hp-test";
                        'scalingPlanEnabled' = $false;
                    }
                )

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $resourceLocation

            $scalingPlan = Update-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Description 'desc2' `
                -FriendlyName 'fri2' `
                -HostPoolType 'Pooled' `
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
                        'rampDownForceLogoffUser'       = $true;
                        'rampDownWaitTimeMinute'        = 30;
                        'rampDownNotificationMessage'    = 'Log out now, please.';
                        'rampDownStopHostsWhen'          = 'ZeroSessions';

                        'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                        'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                    }
                ) `
                -HostPoolReference @(
                    @{
                        'hostPoolArmPath' = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$resourceGroup/providers/Microsoft.DesktopVirtualization/hostPools/hp-test";
                        'scalingPlanEnabled' = $false;
                    },
                    @{
                        'hostPoolArmPath' = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$resourceGroup/providers/Microsoft.DesktopVirtualization/hostPools/hp-test2";
                        'scalingPlanEnabled' = $false;
                    }
                )
            
            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $resourceLocation
            $scalingPlan.Description | Should -Be 'desc2'
            $scalingPlan.FriendlyName | Should -Be 'fri2'
            $scalingPlan.Schedule.Count | Should -Be 1
            $scalingPlan.HostPoolReference.Count | Should -Be 2

            $scalingPlan = Get-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Schedule.Count | Should -Be 1
            $scalingPlan.HostPoolReference.Count | Should -Be 2
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }
}
