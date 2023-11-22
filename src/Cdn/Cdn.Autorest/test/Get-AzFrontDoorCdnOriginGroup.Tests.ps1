if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnOriginGroup'  {
    BeforeAll {
        $originGroupName = 'org-pstest020'
        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
        -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
        -SampleSize 5 -SuccessfulSamplesRequired 4

        New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting
    }

    It 'List' {
        $originGroups = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $originGroups.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $originGroup.Name | Should -Be $originGroupName
    }

    It 'GetViaIdentity' {
        $originGroupObject = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $originGroup = Get-AzFrontDoorCdnOriginGroup -InputObject $originGroupObject

        $originGroup.Name | Should -Be $originGroupName
    }
}
