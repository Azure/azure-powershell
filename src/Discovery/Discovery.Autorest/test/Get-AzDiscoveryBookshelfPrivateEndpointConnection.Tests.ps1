if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryBookshelfPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryBookshelfPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryBookshelfPrivateEndpointConnection' {
    It 'List' {
        $result = Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $result = Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }

    It 'GetViaIdentityBookshelf' {
        $bookshelf = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Get-AzDiscoveryBookshelfPrivateEndpointConnection `
            -BookshelfInputObject $bookshelf `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }

    It 'GetViaIdentity' {
        $identity = Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateEndpointConnectionName $env.BookshelfPrivateEndpointConnectionNameForGet `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Get-AzDiscoveryBookshelfPrivateEndpointConnection -InputObject $identity -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateEndpointConnectionNameForGet
    }
}
