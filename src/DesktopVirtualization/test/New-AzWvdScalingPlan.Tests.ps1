$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdScalingPlan.Recording.json'
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

Describe 'New-AzWvdScalingPlan' {
    It 'CreateExpanded' {
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
            $scalingPlan.Description | Should -Be 'desc'
            $scalingPlan.FriendlyName | Should -Be 'fri'
            $scalingPlan.HostPoolType | Should -Be 'Pooled'
            $scalingPlan.TimeZone | Should -Be '(UTC-08:00) Pacific Time (US & Canada)'
            $scalingPlan.Schedule.Count | Should -Be 1
            $scalingPlan.Schedule[0].Name | Should -Be 'Work Week'
            $scalingPlan.Schedule[0].daysOfWeek | Should -Be @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday')
            $scalingPlan.Schedule[0].rampUpLoadBalancingAlgorithm | Should -Be 'BreadthFirst'
            $scalingPlan.Schedule[0].rampUpStartTime.ToLongTimeString() | Should -Be '6:00:00 AM'
            $scalingPlan.Schedule[0].rampUpMinimumHostsPct | Should -Be 20
            $scalingPlan.Schedule[0].rampUpCapacityThresholdPct | Should -Be 20
            $scalingPlan.Schedule[0].peakStartTime.ToLongTimeString() | Should -Be '8:00:00 AM'
            $scalingPlan.Schedule[0].peakLoadBalancingAlgorithm | Should -Be 'DepthFirst'
            $scalingPlan.Schedule[0].RampDownStartTime.ToLongTimeString() | Should -Be '6:00:00 PM'
            $scalingPlan.Schedule[0].rampDownLoadBalancingAlgorithm | Should -Be 'BreadthFirst'
            $scalingPlan.Schedule[0].rampDownMinimumHostsPct | Should -Be 20
            $scalingPlan.Schedule[0].rampDownCapacityThresholdPct | Should -Be 20
            $scalingPlan.Schedule[0].rampDownForceLogoffUser | Should -Be $true
            $scalingPlan.Schedule[0].rampDownWaitTimeMinute | Should -Be 30
            $scalingPlan.Schedule[0].rampDownNotificationMessage | Should -Be 'Log out now, please.'
            $scalingPlan.Schedule[0].rampDownStopHostsWhen | Should -Be 'ZeroSessions'
            $scalingPlan.Schedule[0].offPeakStartTime.ToLongTimeString() | Should -Be '8:00:00 PM'
            $scalingPlan.Schedule[0].offPeakLoadBalancingAlgorithm | Should -Be 'DepthFirst'
            $scalingPlan.HostPoolReference.Count | Should -Be 1
            $scalingPlan.HostPoolReference[0].HostPoolArmPath | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$resourceGroup/providers/Microsoft.DesktopVirtualization/hostPools/hp-test"
            $scalingPlan.HostPoolReference[0].ScalingPlanEnabled | Should -Be $false

            $scalingPlan = Get-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }
}
