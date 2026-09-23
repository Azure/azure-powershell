if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryBookshelfPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryBookshelfPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryBookshelfPrivateEndpointConnection' {
    It 'UpdateExpanded' -Skip {
        # Skip: Server-side RP bug causes intermittent LRO failures for PEC updates.
        $result = Update-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via UpdateExpanded' `
             -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }

    It 'UpdateViaIdentityBookshelfExpanded' -Skip {
        $bookshelf = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Update-AzDiscoveryBookshelfPrivateEndpointConnection `
            -BookshelfInputObject $bookshelf `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via parent identity' `
             -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        $identity = Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Update-AzDiscoveryBookshelfPrivateEndpointConnection -InputObject $identity `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via identity' `
             -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }
}
