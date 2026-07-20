if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnOriginGroup' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:endpointName = 'e-clipstest-og-rm'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origins/origin1"
        $hp = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath '/health.aspx' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $og = @{ Name = 'originGroup1'; healthProbeSetting = $hp; Origin = @(@{ Id = $originId }) }
        $defaultOG = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origingroups/originGroup1"
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin -OriginGroup $og -DefaultOriginGroupId $defaultOG | Out-Null
        $hp2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath '/check.aspx' -ProbeProtocol 'Http' -ProbeRequestType 'HEAD'
        New-AzCdnOriginGroup -EndpointName $script:endpointName -Name 'originGroup2' -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HealthProbeSetting $hp2 -Origin @(@{ Id = $originId }) | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'Delete' {
        Remove-AzCdnOriginGroup -EndpointName $script:endpointName -Name 'originGroup2' -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        { Get-AzCdnOriginGroup -Name 'originGroup2' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
