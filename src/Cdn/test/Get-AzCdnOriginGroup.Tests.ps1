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

Describe 'Get-AzCdnOriginGroup'  {
    BeforeAll {
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
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$($env.ClassicEndpointName)/origingroups/$($originGroup.Name)"
    }
    It 'List' {
        $originGroups = Get-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $originGroups.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $endpointOriginGroup = Get-AzCdnOriginGroup -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $endpointOriginGroup.Name | Should -Be $originGroup.Name
        $endpointOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $originGroup.HealthProbeSetting.ProbeIntervalInSecond
        $endpointOriginGroup.HealthProbeSetting.ProbePath | Should -Be $originGroup.HealthProbeSetting.ProbePath
        $endpointOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $originGroup.HealthProbeSetting.ProbeProtocol
        $endpointOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be  $originGroup.HealthProbeSetting.ProbeRequestType
        $endpointOriginGroup.Origin[0].Id | Should -Be $originGroup.Origin[0].Id
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $endpointOriginGroup = Get-AzCdnOriginGroup -SubscriptionId $env.SubscriptionId -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Get-AzCdnOriginGroup
        
        $endpointOriginGroup.Name | Should -Be $originGroup.Name
        $endpointOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $originGroup.HealthProbeSetting.ProbeIntervalInSecond
        $endpointOriginGroup.HealthProbeSetting.ProbePath | Should -Be $originGroup.HealthProbeSetting.ProbePath
        $endpointOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $originGroup.HealthProbeSetting.ProbeProtocol
        $endpointOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be  $originGroup.HealthProbeSetting.ProbeRequestType
        $endpointOriginGroup.Origin[0].Id | Should -Be $originGroup.Origin[0].Id
    }
}
