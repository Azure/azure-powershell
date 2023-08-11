if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWvdScalingPlanPooledSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdScalingPlanPooledSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWvdScalingPlanPooledSchedule' {
    $scalingPlanName = 'ScalingPlanPowershellContained1' 
    It 'Delete' {
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

            $scalingPlanPooledSchedule = New-AzWvdScalingPlanPooledSchedule `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -ScalingPlanName $scalingPlanName `
                -ScalingPlanScheduleName 'PooledSchedule1' `
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

            $scalingPlanPooledSchedule.Name | Should -Be "$($scalingPlanName)/PooledSchedule1"

            $scalingPlanPooledSchedule = Remove-AzWvdScalingPlanPooledSchedule `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -ScalingPlanName $scalingPlanName `
                -ScalingPlanScheduleName 'PooledSchedule1'

            $scalingPlanPooledSchedules = Get-AzWvdScalingPlanPooledSchedule `
            -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -ScalingPlanName $scalingPlanName `

            $scalingPlanPooledSchedule.Count | Should -Be 0

        }
        finally {
            # This will delete the schedule too if it's still hanging around.
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $scalingPlanName


        }
    }
}
