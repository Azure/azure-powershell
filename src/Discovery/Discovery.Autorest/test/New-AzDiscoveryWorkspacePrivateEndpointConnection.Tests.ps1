if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryWorkspacePrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryWorkspacePrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryWorkspacePrivateEndpointConnection' {
    # Skip: PEC create/update/delete operations fail due to server-side RP bug (LRO returns status: "Failed").
    # Get-AzDiscoveryWorkspacePrivateEndpointConnection tests confirm the cmdlet works for read operations.
    It 'CreateExpanded' -Skip {
        $result = New-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via CreateExpanded' `
            -PrivateLinkServiceConnectionStateActionsRequired 'None' -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }

    It 'CreateViaJsonString' -Skip {
        $json = @{
            properties = @{
                privateLinkServiceConnectionState = @{
                    status = 'Approved'
                    description = 'Approved via ViaJsonString'
                    actionsRequired = 'None'
                }
            }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }

    It 'CreateViaJsonFilePath' -Skip {
        $jsonPath = Join-Path $PSScriptRoot 'new-wspec-test.json'
        try {
            $json = @{
                properties = @{
                    privateLinkServiceConnectionState = @{
                        status = 'Approved'
                        description = 'Approved via ViaJsonFilePath'
                        actionsRequired = 'None'
                    }
                }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.WorkspaceNameForGet `
                -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaIdentityWorkspaceExpanded' -Skip {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = New-AzDiscoveryWorkspacePrivateEndpointConnection `
            -WorkspaceInputObject $workspace `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForGet `
            -PrivateLinkServiceConnectionStateStatus 'Approved' `
            -PrivateLinkServiceConnectionStateDescription 'Approved via parent identity' `
            -PrivateLinkServiceConnectionStateActionsRequired 'None' -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspacePrivateEndpointConnectionNameForGet
    }
}
