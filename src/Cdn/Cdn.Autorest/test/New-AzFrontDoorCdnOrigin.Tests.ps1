if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnOrigin' {
    BeforeAll {
        $script:ogName = 'org-pstest-orig-new'
        $script:originName = 'ori-psName-new'
        $hp = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath '/' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $lb = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 4
        New-AzFrontDoorCdnOriginGroup -OriginGroupName $script:ogName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -LoadBalancingSetting $lb -HealthProbeSetting $hp | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $o = New-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName -OriginHostHeader 'en.wikipedia.org' -HostName 'en.wikipedia.org' -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000
        $o.Name | Should -Be $script:originName
    }
}
