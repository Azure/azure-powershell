if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnOriginGroup' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:endpointName = 'e-clipstest-og-upd'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        $script:originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origins/origin1"
        $hp = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath '/health.aspx' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $og = @{ Name = 'originGroup1'; healthProbeSetting = $hp; Origin = @(@{ Id = $script:originId }) }
        $defaultOG = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origingroups/originGroup1"
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin -OriginGroup $og -DefaultOriginGroupId $defaultOG | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        $hp3 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 60 -ProbePath '/updated.aspx' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        Update-AzCdnOriginGroup -EndpointName $script:endpointName -Name 'originGroup1' -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HealthProbeSetting $hp3 -Origin @(@{ Id = $script:originId })
        $u = Get-AzCdnOriginGroup -Name 'originGroup1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $u.HealthProbeSetting.ProbeIntervalInSecond | Should -Be 60
        $u.HealthProbeSetting.ProbePath | Should -Be '/updated.aspx'
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

    It 'UpdateViaIdentityEndpointExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
