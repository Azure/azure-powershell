if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnOriginGroup' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:endpointName = 'e-clipstest-og-new'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        $script:originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origins/$($origin.Name)"
        $hp = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath '/health.aspx' -ProbeProtocol 'Https' -ProbeRequestType 'GET'
        $og = @{ Name = 'originGroup1'; healthProbeSetting = $hp; Origin = @(@{ Id = $script:originId }) }
        $defaultOG = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:endpointName/origingroups/$($og.Name)"
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin -OriginGroup $og -DefaultOriginGroupId $defaultOG | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $hp2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath '/check-health.aspx' -ProbeProtocol 'Http' -ProbeRequestType 'HEAD'
        $createdOG = New-AzCdnOriginGroup -EndpointName $script:endpointName -Name 'originGroup2' -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HealthProbeSetting $hp2 -Origin @(@{ Id = $script:originId })
        $createdOG.Name | Should -Be 'originGroup2'
        $createdOG.HealthProbeSetting.ProbeIntervalInSecond | Should -Be 120
        $createdOG.HealthProbeSetting.ProbePath | Should -Be '/check-health.aspx'
        $createdOG.HealthProbeSetting.ProbeProtocol | Should -Be 'Http'
        $createdOG.HealthProbeSetting.ProbeRequestType | Should -Be 'HEAD'
    }
}
