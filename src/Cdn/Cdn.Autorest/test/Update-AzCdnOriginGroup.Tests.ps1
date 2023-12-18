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

Describe 'Update-AzCdnOriginGroup'  {
    It 'UpdateExpanded' {
        $subId = $env.SubscriptionId
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$($env.ClassicEndpointName)/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject 
            Origin = @(@{
                Id = $originId
            })
        }

        Update-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -Name $originGroup.Name -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbeParametersObject -Origin @(@{ Id = $originId })
        $updatedOriginGroup = Get-AzCdnOriginGroup -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
            
        $updatedOriginGroup.Name | Should -Be $originGroup.Name
        $updatedOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be "240"
        $updatedOriginGroup.HealthProbeSetting.ProbePath | Should -Be "/health.aspx"
        $updatedOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be "Https"
        $updatedOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be "GET"
    }
}
