if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnRoute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnRoute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnRoute' {
    BeforeAll {
        $script:endpointName = 'e-clipstest-route-new'
        $script:ogName = 'org-route-new'
        $script:routeName = 'routeName-new'
        New-AzFrontDoorCdnEndpoint -EndpointName $script:endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
        $hp = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath '/' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $lb = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 4
        $og = New-AzFrontDoorCdnOriginGroup -OriginGroupName $script:ogName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -LoadBalancingSetting $lb -HealthProbeSetting $hp
        $script:ogId = $og.Id
        New-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName 'ori-route' -OriginHostHeader 'en.wikipedia.org' -HostName 'en.wikipedia.org' -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000 | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $script:endpointName -Name $script:routeName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName 'ori-route' -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnEndpoint -EndpointName $script:endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $r = New-AzFrontDoorCdnRoute -Name $script:routeName -EndpointName $script:endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -OriginGroupId $script:ogId -PatternsToMatch '/*' -LinkToDefaultDomain 'Enabled' -EnabledState 'Enabled'
        $r.Name | Should -Be $script:routeName
    }
}
