if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnOriginGroup' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:endpointName = 'e-clipstest-og-get'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origins/origin1"
        $hp = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath '/health.aspx' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $og = @{ Name = 'originGroup1'; healthProbeSetting = $hp; Origin = @(@{ Id = $originId }) }
        $defaultOG = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origingroups/originGroup1"
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin -OriginGroup $og -DefaultOriginGroupId $defaultOG | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $ogs = Get-AzCdnOriginGroup -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $ogs.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $og = Get-AzCdnOriginGroup -Name 'originGroup1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $og.Name | Should -Be 'originGroup1'
    }

    It 'GetViaIdentity' {
        $og = Get-AzCdnOriginGroup -Name 'originGroup1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $og2 = Get-AzCdnOriginGroup -InputObject $og
        $og2.Name | Should -Be 'originGroup1'
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
