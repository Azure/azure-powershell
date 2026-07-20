if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPaloAltoNetworksMetricsObjectFirewall'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPaloAltoNetworksMetricsObjectFirewall.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPaloAltoNetworksMetricsObjectFirewall' {
    It 'Get' {
        { Get-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg" } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg" } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        # Skip this test as it requires complex identity object setup
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
