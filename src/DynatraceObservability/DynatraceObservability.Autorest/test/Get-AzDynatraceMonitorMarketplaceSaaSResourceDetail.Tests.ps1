if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail' {
    It 'GetExpanded' {
        {Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -TenantId '72f988bf-86f1-41af-91ab-2d7cd011db47'}  | Should -Not -Throw
    }
}
