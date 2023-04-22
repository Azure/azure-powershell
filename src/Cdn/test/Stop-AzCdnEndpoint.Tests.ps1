if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzCdnEndpoint'  {
    It 'Stop' {
        Stop-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $endpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
        
        $endpoint.ResourceState | Should -Be "Stopped"
    }

    It 'StopViaIdentity' {
        Start-AzCdnEndpoint -Name $env.ClassicEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
        $endpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName | Stop-AzCdnEndpoint

        $endpoint.ResourceState | Should -Be "Stopped"
        # For other tests, we need to start the endpoint.
        Start-AzCdnEndpoint -Name $env.ClassicEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
    }
}
