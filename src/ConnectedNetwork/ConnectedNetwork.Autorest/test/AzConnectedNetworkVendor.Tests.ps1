if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendor' {
    It 'CreateExpanded' {
        {
            $config = New-AzConnectedNetworkVendor -Name $env.VendorName1
            $config.Name | Should -Be $env.VendorName1

            $config = New-AzConnectedNetworkVendor -Name $env.VendorName2 -SubscriptionId $env.subscriptionId
            $config.Name | Should -Be $env.VendorName2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendor
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendor -Name $env.VendorName2
            $config.Name | Should -Be $env.VendorName2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkVendor -Name $env.VendorName1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzConnectedNetworkVendor -Name $env.VendorName2
            Remove-AzConnectedNetworkVendor -InputObject $config
        } | Should -Not -Throw
    }
}
