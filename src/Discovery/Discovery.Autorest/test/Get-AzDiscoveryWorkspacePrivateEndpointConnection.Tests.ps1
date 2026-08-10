if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryWorkspacePrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryWorkspacePrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryWorkspacePrivateEndpointConnection' {
    It 'List' {
        $result = Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentityWorkspace' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Get-AzDiscoveryWorkspacePrivateEndpointConnection `
            -WorkspaceInputObject $workspace `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }

    It 'Get' {
        $result = Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }

    It 'GetViaIdentity' {
        $identity = Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Get-AzDiscoveryWorkspacePrivateEndpointConnection -InputObject $identity -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }
}
