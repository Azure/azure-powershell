if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaLimit'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaLimit.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaLimit' {
    It 'List' {
        { Get-AzQuotaGroupQuotaLimit -ManagementGroupId "$($env.SubscriptionId)" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" } | Should -Not -Throw
    }
}
