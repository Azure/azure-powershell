if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnOriginGroup'  {
    BeforeAll {
        $originGroupName = 'org' + (RandomString -allChars $false -len 6);
        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
        -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
        -SampleSize 5 -SuccessfulSamplesRequired 4
        New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting
    }

    It 'Delete' {
        Remove-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        New-AzFrontDoorCdnOriginGroup -SubscriptionId $env.SubscriptionId -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting
        
        Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName | Remove-AzFrontDoorCdnOriginGroup  
    }
}
