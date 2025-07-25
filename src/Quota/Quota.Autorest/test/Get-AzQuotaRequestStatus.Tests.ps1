if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaRequestStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaRequestStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaRequestStatus' {
    It 'List' {
        { Get-AzQuotaRequestStatus -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus" } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzQuotaRequestStatus -Scope "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Network/locations/eastus" -Id "6cf5716a-3df8-421a-8457-719e10381dbc" } | Should -Not -Throw
    }
}
