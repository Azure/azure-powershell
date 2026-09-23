if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnOrigin' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:endpointName = 'e-clipstest-origin-new'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origins/$($origin.Name)"
        $hp = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath '/health.aspx' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $og = @{ Name = 'originGroup1'; healthProbeSetting = $hp; Origin = @(@{ Id = $originId }) }
        $defaultOG = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origingroups/$($og.Name)"
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin -OriginGroup $og -DefaultOriginGroupId $defaultOG | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $newOrigin = New-AzCdnOrigin -Name 'origin2' -HostName 'host2.hello.com' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $newOrigin.Name | Should -Be 'origin2'
        $newOrigin.HostName | Should -Be 'host2.hello.com'
    }
}
