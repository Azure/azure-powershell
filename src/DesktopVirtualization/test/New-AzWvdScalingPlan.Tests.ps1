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

Describe 'New-AzWvdScalingPlan' {
    It 'CreateExpanded' {
        try {
            [System.Threading.Thread]::CurrentThread.CurrentCulture = 'en-US'
            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.HostPool `
                            -Location $env.Location `
                            -HostPoolType 'Shared' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'des' `
                            -FriendlyName 'fri' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -PreferredAppGroupType 'Desktop'

<#             $Role = New-AzRoleAssignment -ResourceGroupName $env.ResourceGroup `
                                 -ResourceType 'Microsoft.DesktopVirtualization/HostPools' `
                                 -RoleDefinitionName "Contributor" `
                                 -ServicePrincipalName '9cdead84-a844-4324-93f2-b2e6bb768d07' `
                                 -ResourceName $env.HostPool #>

            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool `
                -Location $env.Location `
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
                        'hostPoolArmPath' = $env.HostPoolArmPath;
                        'scalingPlanEnabled' = $false;
                    }
                )

            $scalingPlan.Name | Should -Be $env.HostPool
            $scalingPlan.Location | Should -Be $env.Location
            $scalingPlan.Description | Should -Be 'desc'
            $scalingPlan.FriendlyName | Should -Be 'fri'
            $scalingPlan.HostPoolType | Should -Be 'Pooled'
            $scalingPlan.TimeZone | Should -Be 'Pacific Standard Time'
            $scalingPlan.Schedule.Count | Should -Be 1
            $scalingPlan.Schedule[0].Name | Should -Be 'Work Week'
            $scalingPlan.Schedule[0].daysOfWeek | Should -Be @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday')
            $scalingPlan.Schedule[0].rampUpLoadBalancingAlgorithm | Should -Be 'BreadthFirst'
            $scalingPlan.Schedule[0].RampUpStartTimeHour | Should -Be '6'
            $scalingPlan.Schedule[0].RampUpStartTimeMinute | Should -Be '0'
            $scalingPlan.Schedule[0].rampUpMinimumHostsPct | Should -Be 20
            $scalingPlan.Schedule[0].rampUpCapacityThresholdPct | Should -Be 20
            $scalingPlan.Schedule[0].peakStartTimeHour | Should -Be '8'
            $scalingPlan.Schedule[0].peakStartTimeMinute | Should -Be '30'
            $scalingPlan.Schedule[0].peakLoadBalancingAlgorithm | Should -Be 'DepthFirst'
            $scalingPlan.Schedule[0].RampDownStartTimeHour | Should -Be '16'
            $scalingPlan.Schedule[0].RampDownStartTimeMinute | Should -Be '15'
            $scalingPlan.Schedule[0].rampDownLoadBalancingAlgorithm | Should -Be 'BreadthFirst'
            $scalingPlan.Schedule[0].rampDownMinimumHostsPct | Should -Be 20
            $scalingPlan.Schedule[0].rampDownCapacityThresholdPct | Should -Be 20
            $scalingPlan.Schedule[0].rampDownForceLogoffUser | Should -Be $true
            $scalingPlan.Schedule[0].rampDownWaitTimeMinute | Should -Be 30
            $scalingPlan.Schedule[0].rampDownNotificationMessage | Should -Be 'Log out now, please.'
            $scalingPlan.Schedule[0].rampDownStopHostsWhen | Should -Be 'ZeroSessions'
            $scalingPlan.Schedule[0].OffPeakStartTimeHour | Should -Be '18'
            $scalingPlan.Schedule[0].OffPeakStartTimeMinute | Should -Be '0'
            $scalingPlan.Schedule[0].offPeakLoadBalancingAlgorithm | Should -Be 'DepthFirst'
            $scalingPlan.HostPoolReference.Count | Should -Be 1
            $scalingPlan.HostPoolReference[0].HostPoolArmPath | Should -Be $env.HostPoolArmPath
            $scalingPlan.HostPoolReference[0].ScalingPlanEnabled | Should -Be $false

            $scalingPlan = Get-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool

            $scalingPlan.Name | Should -Be $env.HostPool
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name $env.HostPool
        }
    }
}
