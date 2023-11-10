if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnOriginGroup'  {
    BeforeAll {
        $originGroupName = 'org-pstest120'
        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
        -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
        -SampleSize 5 -SuccessfulSamplesRequired 4
        New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting
    }

    It 'UpdateExpanded' {
        $originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $originGroup.Name | Should -Be $originGroupName
        $originGroup.LoadBalancingSetting.SuccessfulSamplesRequired | Should -Be 4

        $updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
        -SampleSize 5 -SuccessfulSamplesRequired 3
        Update-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName `
        -LoadBalancingSetting $updateLoadBalancingSetting
    
        $originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $originGroup.LoadBalancingSetting.SuccessfulSamplesRequired | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded'  {
        $updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
        -SampleSize 5 -SuccessfulSamplesRequired 3
        $ogObject = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        Update-AzFrontDoorCdnOriginGroup  -LoadBalancingSetting $updateLoadBalancingSetting -InputObject $ogObject
    
        $originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $originGroup.LoadBalancingSetting.SuccessfulSamplesRequired | Should -Be 3
    }
}
