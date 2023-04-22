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

Describe 'Remove-AzCdnOriginGroup'  {
    It 'Delete' {
        $originGroupName = "originGroup2"
        $probeInterval = 120
        $probePath = "/check-health.aspx"
        $probeProtocol = "Http"
        $probeRequestType = "HEAD"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval `
            -ProbePath $probePath -ProbeProtocol $probeProtocol -ProbeRequestType $probeRequestType 

        New-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -Name $originGroupName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbeParametersObject -Origin @(@{ Id = $originId })
        
        Remove-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -Name $originGroupName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'DeleteViaIdentity' {
        $originGroupName = "originGroup2"
        $probeInterval = 120
        $probePath = "/check-health.aspx"
        $probeProtocol = "Http"
        $probeRequestType = "HEAD"

        New-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -Name $originGroupName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbeParametersObject -Origin @(@{ Id = $originId })
        
        Get-AzCdnOriginGroup -EndpointName $env.ClassicEndpointName -Name $originGroupName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Remove-AzCdnOriginGroup
    }
}
