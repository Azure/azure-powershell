if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryWorkspacePrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryWorkspacePrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryWorkspacePrivateEndpointConnection' {
    It 'UpdateExpanded' -Skip {
        # Skip: Server-side RP bug causes intermittent LRO failures for PEC updates.
        $description = 'Approved via UpdateExpanded'
        $result = Update-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription $description `
             -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }

    It 'UpdateViaIdentityWorkspaceExpanded' -Skip {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Update-AzDiscoveryWorkspacePrivateEndpointConnection `
            -WorkspaceInputObject $workspace `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via parent identity' `
             -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        $identity = Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = Update-AzDiscoveryWorkspacePrivateEndpointConnection -InputObject $identity `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via identity' `
             -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }
}
