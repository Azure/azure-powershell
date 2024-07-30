if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedNetworkSecurityPerimeterConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedNetworkSecurityPerimeterConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedNetworkSecurityPerimeterConfiguration' {
    It 'List' {
        $all = @(Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.ResourceGroupNameNSP -ScopeName $env.PrivateLinkScopeNameNSP)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $all = @(Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.ResourceGroupNameNSP -ScopeName $env.PrivateLinkScopeNameNSP -PerimeterName $env.PerimeterName)
        $all | Should -Not -BeNullOrEmpty
    }
}
