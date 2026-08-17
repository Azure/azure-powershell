if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryWorkspacePrivateLinkResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryWorkspacePrivateLinkResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryWorkspacePrivateLinkResource' {
    It 'List' {
        $result = Get-AzDiscoveryWorkspacePrivateLinkResource -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $result = Get-AzDiscoveryWorkspacePrivateLinkResource -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateLinkResourceName $env.WorkspacePrivateLinkResourceName `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateLinkResourceName
    }

    It 'GetViaIdentity' {
        $identity = Get-AzDiscoveryWorkspacePrivateLinkResource -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateLinkResourceName $env.WorkspacePrivateLinkResourceName `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Get-AzDiscoveryWorkspacePrivateLinkResource -InputObject $identity -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateLinkResourceName
    }
}
