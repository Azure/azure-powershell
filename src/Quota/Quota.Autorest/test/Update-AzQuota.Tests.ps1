if(($null -eq $TestName) -or ($TestName -contains 'Update-AzQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzQuota' {
    It 'UpdateExpanded' {
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
        $limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
        Update-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family" -Name "standardFSv2Family" -Limit $limit
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
        $quota.Limit.Value | Should -Be $limit.Value
    }

    It 'UpdateViaIdentityExpanded' {
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
        $limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
        Update-AzQuota -InputObject $quota.Id -Name "standardFSv2Family" -Limit $limit
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
        $quota.Limit.Value | Should -Be $limit.Value
    }
}
