if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryBookshelfPrivateLinkResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryBookshelfPrivateLinkResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryBookshelfPrivateLinkResource' {
    It 'List' {
        $result = Get-AzDiscoveryBookshelfPrivateLinkResource -ResourceGroupName $env.ResourceGroupName -BookshelfName $env.BookshelfNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $result = Get-AzDiscoveryBookshelfPrivateLinkResource -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateLinkResourceName $env.BookshelfPrivateLinkResourceName `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateLinkResourceName
    }

    It 'GetViaIdentity' {
        $identity = Get-AzDiscoveryBookshelfPrivateLinkResource -ResourceGroupName $env.ResourceGroupName `
            -BookshelfName $env.BookshelfNameForGet `
            -PrivateLinkResourceName $env.BookshelfPrivateLinkResourceName `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Get-AzDiscoveryBookshelfPrivateLinkResource -InputObject $identity -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.BookshelfPrivateLinkResourceName
    }
}
