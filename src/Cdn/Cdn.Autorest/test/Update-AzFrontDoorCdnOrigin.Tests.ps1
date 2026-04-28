if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnOrigin' {
    BeforeAll {
        $script:ogName = 'org-pstest-orig-upd'
        $script:originName = 'ori-psName-upd'
        $hp = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath '/' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $lb = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 4
        New-AzFrontDoorCdnOriginGroup -OriginGroupName $script:ogName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -LoadBalancingSetting $lb -HealthProbeSetting $hp | Out-Null
        New-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName -OriginHostHeader 'en.wikipedia.org' -HostName 'en.wikipedia.org' -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000 | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        Update-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName -Weight 999
        $u = Get-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName
        $u.Weight | Should -Be 999
    }

    It 'UpdateViaIdentityExpanded' {
        $o = Get-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName
        Update-AzFrontDoorCdnOrigin -Weight 888 -InputObject $o
        $u = Get-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $script:ogName -OriginName $script:originName
        $u.Weight | Should -Be 888
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfileExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityOriginGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityOriginGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
