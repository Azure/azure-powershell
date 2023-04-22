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
    BeforeAll {
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $originId = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Cdn/profiles/$cdnProfileName/endpoints/$endpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject 
            Origin = @(@{
                Id = $originId
            })
        }
    }
    It 'UpdateExpanded' {
        $endpointOriginGroup = Get-AzCdnOriginGroup -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    
        $endpointOriginGroup.Name | Should -Be $originGroup.Name
        $endpointOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $originGroup.HealthProbeSetting.ProbeIntervalInSecond
        $endpointOriginGroup.HealthProbeSetting.ProbePath | Should -Be $originGroup.HealthProbeSetting.ProbePath
        $endpointOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $originGroup.HealthProbeSetting.ProbeProtocol
        $endpointOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be  $originGroup.HealthProbeSetting.ProbeRequestType
        $endpointOriginGroup.Origin[0].Id | Should -Be $originGroup.Origin[0].Id

        $probeInterval2 = 120
        $probePath2 = "/check-health.aspx"
        $probeProtocol2 = "Http"
        $probeRequestType2 = "HEAD"
        $healthProbeParametersObject2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval2 `
            -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2 


        Update-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -Name $originGroup.Name -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId })
        $updatedOriginGroup = Get-AzCdnOriginGroup -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
            
        $updatedOriginGroup.Name | Should -Be $originGroup.Name
        $updatedOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $probeInterval2
        $updatedOriginGroup.HealthProbeSetting.ProbePath | Should -Be $probePath2
        $updatedOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $probeProtocol2
        $updatedOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be $probeRequestType2
    }

    It 'UpdateViaIdentityExpanded' {
        $PSDefaultParameterValues['Disabled'] = $true
        $endpointOriginGroup = Get-AzCdnOriginGroup -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    
        $endpointOriginGroup.Name | Should -Be $originGroup.Name
        $endpointOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $originGroup.HealthProbeSetting.ProbeIntervalInSecond
        $endpointOriginGroup.HealthProbeSetting.ProbePath | Should -Be $originGroup.HealthProbeSetting.ProbePath
        $endpointOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $originGroup.HealthProbeSetting.ProbeProtocol
        $endpointOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be  $originGroup.HealthProbeSetting.ProbeRequestType
        $endpointOriginGroup.Origin[0].Id | Should -Be $originGroup.Origin[0].Id

        $probeInterval2 = 120
        $probePath2 = "/check-health.aspx"
        $probeProtocol2 = "Http"
        $probeRequestType2 = "HEAD"
        $healthProbeParametersObject2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval2 `
            -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2 

        $endpointOriginGroup | Update-AzCdnOriginGroup -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId })
        $updatedOriginGroup = Get-AzCdnOriginGroup -Name $originGroup.Name -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
            
        $updatedOriginGroup.Name | Should -Be $originGroup.Name
        $updatedOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $probeInterval2
        $updatedOriginGroup.HealthProbeSetting.ProbePath | Should -Be $probePath2
        $updatedOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $probeProtocol2
        $updatedOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be $probeRequestType2
    }
}
