if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryWorkspacePrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryWorkspacePrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryWorkspacePrivateEndpointConnection' {
    It 'Delete' -Skip {
        # Skip: Server-side RP bug — PEC delete LRO returns status "Failed" (confirmed via direct API call).
        $maxRetries = 3
        for ($i = 1; $i -le $maxRetries; $i++) {
            try {
                Remove-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
                    -WorkspaceName $env.WorkspaceNameForGet `
                    -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForDel `
                    -SubscriptionId $env.SubscriptionId -Confirm:$false
                break
            } catch {
                if ($i -eq $maxRetries) { throw }
                Write-Host "PEC delete attempt $i failed, retrying in 30s..."
                Start-TestSleep -Seconds 30
            }
        }
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForDel `
            -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentityWorkspace' -Skip {
        # Skip: Server-side RP bug — PEC delete LRO returns status "Failed" (confirmed via direct API call).
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $maxRetries = 3
        for ($i = 1; $i -le $maxRetries; $i++) {
            try {
                Remove-AzDiscoveryWorkspacePrivateEndpointConnection -WorkspaceInputObject $workspace `
                    -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForDelViaPar `
                    -Confirm:$false
                break
            } catch {
                if ($i -eq $maxRetries) { throw }
                Write-Host "PEC delete attempt $i failed, retrying in 30s..."
                Start-TestSleep -Seconds 30
            }
        }
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForDelViaPar `
            -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' -Skip {
        # Skip: Server-side RP bug — PEC delete LRO returns status "Failed" (confirmed via direct API call).
        $identity = Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForDelVia `
            -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $maxRetries = 3
        for ($i = 1; $i -le $maxRetries; $i++) {
            try {
                $identity | Remove-AzDiscoveryWorkspacePrivateEndpointConnection -Confirm:$false
                break
            } catch {
                if ($i -eq $maxRetries) { throw }
                Write-Host "PEC delete attempt $i failed, retrying in 30s..."
                Start-TestSleep -Seconds 30
            }
        }
        Start-TestSleep -Seconds 10
        { Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -PrivateEndpointConnectionName $env.WorkspacePrivateEndpointConnectionNameForDelVia `
            -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
