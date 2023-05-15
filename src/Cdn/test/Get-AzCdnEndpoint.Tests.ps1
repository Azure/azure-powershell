if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnEndpoint'  {
    It 'List' {
        $endpoints = Get-AzCdnEndpoint -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $endpoints.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $endpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $endpoint.Name | Should -Be $env.ClassicEndpointName
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $endpoint = Get-AzCdnEndpoint -SubscriptionId $env.SubscriptionId -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Get-AzCdnEndpoint
        
        $endpoint.Name | Should -Be $env.ClassicEndpointName
    }
}
