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
    It 'List' -skip {
        $all = @(Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.ResourceGroupName -ScopeName $env.PrivateLinkScopeName -SubscriptionId $env.SubscriptionId)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'Get' -skip {
        $all = @(Get-AzConnectedNetworkSecurityPerimeterConfiguration -PerimeterName $env.PerimeterName -ResourceGroupName $env.ResourceGroupName -ScopeName $env.PrivateLinkScopeName -SubscriptionId $env.SubscriptionId)
        $all | Should -Not -BeNullOrEmpty
    }
}