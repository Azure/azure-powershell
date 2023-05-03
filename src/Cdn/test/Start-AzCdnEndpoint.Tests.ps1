if(($null -eq $TestName) -or ($TestName -contains 'Start-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzCdnEndpoint'  {
    It 'Start' {
        Stop-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        Start-AzCdnEndpoint -Name $env.ClassicEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
        $endpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
        
        $endpoint.ResourceState | Should -Be "Running"
    }

    It 'StartViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        Stop-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $endpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Start-AzCdnEndpoint

        $endpoint.ResourceState | Should -Be "Running"
    }
}
