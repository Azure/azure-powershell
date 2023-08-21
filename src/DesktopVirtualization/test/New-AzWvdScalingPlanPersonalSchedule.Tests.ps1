if(($null -eq $TestName) -or ($TestName -contains 'New-AzWvdScalingPlanPersonalSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdScalingPlanPersonalSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWvdScalingPlanPersonalSchedule' {
    $scalingPlanName = 'ScalingPlanPowershellContained1' 
    It 'New' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name  $scalingPlanName `
                -Location $env.location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Personal' `
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
                -daysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -rampUpStartTimeHour 6 `
                                        -rampUpStartTimeMinute 30 `
                                        -RampUpAutoStartHost All `
                                        -rampUpStartVMOnConnect Enable `
                                        -rampUpActionOnDisconnect None `
                                        -rampUpMinutesToWaitOnDisconnect 10 `
                                        -rampUpActionOnLogoff None `
                                        -rampUpMinutesToWaitOnLogoff 10 `
                                        -peakStartTimeHour 8 `
                                        -peakStartTimeMinute 30 `
                                        -peakStartVMOnConnect Enable `
                                        -peakActionOnDisconnect None `
                                        -peakMinutesToWaitOnDisconnect 10 `
                                        -peakMinutesToWaitOnLogoff 10 `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -rampDownStartVMOnConnect Enable `
                                        -rampDownActionOnDisconnect None `
                                        -rampDownMinutesToWaitOnDisconnect 10 `
                                        -rampDownMinutesToWaitOnLogoff 10 `
                                        -rampDownActionOnLogoff None `
                                        -offPeakStartTimeHour 22 `
                                        -offPeakStartTimeMinute 45 `
                                        -offPeakStartVMOnConnect Enable `
                                        -offPeakActionOnDisconnect None `
                                        -offPeakMinutesToWaitOnDisconnect 10 `
                                        -offPeakActionOnLogoff Deallocate `
                                        -offPeakMinutesToWaitOnLogoff 10

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
}
