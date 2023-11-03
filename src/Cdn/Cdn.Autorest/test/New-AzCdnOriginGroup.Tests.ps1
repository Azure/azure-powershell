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

Describe 'New-AzCdnOriginGroup'  {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $endpointName = 'end-pstest030'
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName)"
        
        $location = "westus"
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject 
            Origin = @(@{
                Id = $originId
            })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origingroups/$($originGroup.Name)"
        $createdEndpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup

        $originGroupName2 = "originGroup2"
        $probeInterval2 = 120
        $probePath2 = "/check-health.aspx"
        $probeProtocol2 = "Http"
        $probeRequestType2 = "HEAD"
        $healthProbeParametersObject2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval2 `
            -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2 

        $createdOriginGroup = New-AzCdnOriginGroup -EndpointName $endpointName -Name $originGroupName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId })
        
        $createdEndpoint.DefaultOriginGroupId | Should -Be $defaultOriginGroup
        $createdOriginGroup.Name | Should -Be $originGroupName2
        $createdOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $probeInterval2
        $createdOriginGroup.HealthProbeSetting.ProbePath | Should -Be $probePath2
        $createdOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $probeProtocol2
        $createdOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be $probeRequestType2
        $createdOriginGroup.Origin[0].Id | Should -Be $originId
    }
}
