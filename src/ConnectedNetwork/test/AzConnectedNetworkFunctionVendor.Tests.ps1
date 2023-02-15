if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkFunctionVendor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkFunctionVendor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkFunctionVendor' {
    It 'List' {
        {
            $config = Get-AzConnectedNetworkFunctionVendor
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzConnectedNetworkFunctionVendor -SubscriptionId $env.SubscriptionId
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
