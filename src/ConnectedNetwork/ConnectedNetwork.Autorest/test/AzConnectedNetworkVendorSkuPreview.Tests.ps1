if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkVendorSkuPreview'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkVendorSkuPreview.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkVendorSkuPreview' {
    It 'CreateExpanded' {
        {
            $config = New-AzConnectedNetworkVendorSkuPreview -PreviewSubscription $env.PreviewSubscription -SkuName "sku1" -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Name | Should -Be $env.PreviewSubscription
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkVendorSkuPreview -SkuName "sku1" -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkVendorSkuPreview -SkuName "sku1" -VendorName $env.existingVendor -PreviewSubscription $env.PreviewSubscription -SubscriptionId $env.VendorSubscription
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkVendorSkuPreview -PreviewSubscription $env.PreviewSubscription -SkuName "sku1" -VendorName $env.existingVendor -SubscriptionId $env.VendorSubscription
        } | Should -Not -Throw
    }
}
