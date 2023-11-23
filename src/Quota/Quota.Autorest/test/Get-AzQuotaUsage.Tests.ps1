if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaUsage' {
    It 'List' {
        { Get-AzQuotaUsage -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus"  } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzQuotaUsage -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus" -Name "MinPublicIpInterNetworkPrefixLength" } | Should -Not -Throw
    }
}
