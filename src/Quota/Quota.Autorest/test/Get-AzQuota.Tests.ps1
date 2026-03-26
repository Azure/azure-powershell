if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuota' {
    It 'List' {
        { Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family" } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family" 
            Get-AzQuota -InputObject $quota.Id
        } | Should -Not -Throw
    }
}
