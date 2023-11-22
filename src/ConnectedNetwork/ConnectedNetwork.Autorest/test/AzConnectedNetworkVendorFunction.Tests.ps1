if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendorFunction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendorFunction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendorFunction' {
    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorFunction -LocationName $env.Location -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorFunction -LocationName $env.Location -VendorName $env.existingVendor -ServiceKey $env.ServiceKey -SubscriptionId $env.VendorSubscription
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }
}
