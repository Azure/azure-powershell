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
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses"
        $limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
        Update-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses"
        $quota.Limit.Value | Should -Be $limit.Value
    }

    It 'UpdateViaIdentityExpanded' {
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses"
        $limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses"
        Update-AzQuota -InputObject $quota.Id -Name "PublicIPAddresses" -Limit $limit
        $quota = Get-AzQuota -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses"
        $quota.Limit.Value | Should -Be $limit.Value
    }
}
