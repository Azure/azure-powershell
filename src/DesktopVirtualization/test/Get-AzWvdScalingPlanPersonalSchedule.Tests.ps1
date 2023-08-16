if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdScalingPlanPersonalSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdScalingPlanPersonalSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdScalingPlanPersonalSchedule' {
    $scalingPlanName = 'ScalingPlanPowershellContained1' 
    It 'Get' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name  $scalingPlanName `
                -Location $env.location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be $scalingPlanName
            $scalingPlan.Location | Should -Be $env.Location

            $scalingPlanPersonalSchedule = New-AzWvdScalingPlanPersonalSchedule `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -ScalingPlanName $scalingPlanName `
                -ScalingPlanScheduleName 'PersonalSchedule1' `
                -DaysOfWeek 'Monday','Tuesday','Wednesday' `
                -RampUpStartTimeHour '6' `
                -RampUpStartTimeMinute '0' `
                -RampUpMinimumHostsPct 1 `
                -RampUpLoadBalancingAlgorithm 'BreadthFirst' `
                -RampUpCapacityThreshold 10 `
                -PeakStartTimeHour '8' `
                -PeakStartTimeMinute '15' `
                -PeakLoadBalancingAlgorithm 'BreadthFirst' `
                -RampDownStartTimeHour '16' `
                -RampDownStartTimeMinute '30' `
                -RampDownLoadBalancingAlgorithm 'BreadthFirst' `
                -RampDownCapacityThreshold 10 `
                -OffPeakStartTimeHour '18' `
                -OffPeakStartTimeMinute '45' `
                -OffPeakLoadBalancingAlgorithm 'BreadthFirst'

            $scalingPlanPersonalSchedule.Name | Should -Be "$($scalingPlanName)/PersonalSchedule1"

            $scalingPlanPersonalSchedule = Get-AzWvdScalingPlanPersonalSchedule `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -ScalingPlanName $scalingPlanName `
                -ScalingPlanScheduleName 'PersonalSchedule1'

            $scalingPlanPersonalSchedule.Name | Should -Be "$($scalingPlanName)/PersonalSchedule1"
        }
        finally {
            # This will delete the schedule too
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $scalingPlanName
        }
    }
    It 'List' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name  $scalingPlanName `
                -Location $env.location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be $scalingPlanName
            $scalingPlan.Location | Should -Be $env.Location

            $scalingPlanPersonalSchedule = New-AzWvdScalingPlanPersonalSchedule `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -ScalingPlanName $scalingPlanName `
                -ScalingPlanScheduleName 'PersonalSchedule1' `
                -DaysOfWeek 'Monday','Tuesday','Wednesday' `
                -RampUpStartTimeHour '6' `
                -RampUpStartTimeMinute '0' `
                -RampUpMinimumHostsPct 1 `
                -RampUpLoadBalancingAlgorithm 'BreadthFirst' `
                -RampUpCapacityThreshold 10 `
                -PeakStartTimeHour '8' `
                -PeakStartTimeMinute '15' `
                -PeakLoadBalancingAlgorithm 'BreadthFirst' `
                -RampDownStartTimeHour '16' `
                -RampDownStartTimeMinute '30' `
                -RampDownLoadBalancingAlgorithm 'BreadthFirst' `
                -RampDownCapacityThreshold 10 `
                -OffPeakStartTimeHour '18' `
                -OffPeakStartTimeMinute '45' `
                -OffPeakLoadBalancingAlgorithm 'BreadthFirst'

            $scalingPlanPersonalSchedule.Name | Should -Be "$($scalingPlanName)/PersonalSchedule1"

            $scalingPlanPersonalSchedule = New-AzWvdScalingPlanPersonalSchedule `
            -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -ScalingPlanName $scalingPlanName `
            -ScalingPlanScheduleName 'PersonalSchedule2' `
            -DaysOfWeek 'Thursday','Friday' `
            -RampUpStartTimeHour '6' `
            -RampUpStartTimeMinute '0' `
            -RampUpMinimumHostsPct 1 `
            -RampUpLoadBalancingAlgorithm 'BreadthFirst' `
            -RampUpCapacityThreshold 10 `
            -PeakStartTimeHour '8' `
            -PeakStartTimeMinute '15' `
            -PeakLoadBalancingAlgorithm 'BreadthFirst' `
            -RampDownStartTimeHour '16' `
            -RampDownStartTimeMinute '30' `
            -RampDownLoadBalancingAlgorithm 'BreadthFirst' `
            -RampDownCapacityThreshold 10 `
            -OffPeakStartTimeHour '18' `
            -OffPeakStartTimeMinute '45' `
            -OffPeakLoadBalancingAlgorithm 'BreadthFirst'

        $scalingPlanPersonalSchedule.Name | Should -Be "$($scalingPlanName)/PersonalSchedule2"

            $scalingPlanPersonalSchedules = Get-AzWvdScalingPlanPersonalSchedule `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -ScalingPlanName $scalingPlanName

            $scalingPlanPersonalSchedules.Count | Should -Be 2
            $scalingPlanPersonalSchedules[0].Name | Should -Be "$($scalingPlanName)/PersonalSchedule1"
            $scalingPlanPersonalSchedules[1].Name | Should -Be "$($scalingPlanName)/PersonalSchedule2"
        }
        finally {
            # This will delete the schedule too
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $scalingPlanName


        }
    }
}
