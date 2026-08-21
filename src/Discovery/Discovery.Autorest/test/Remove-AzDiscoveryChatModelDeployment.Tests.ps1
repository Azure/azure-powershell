if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryChatModelDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryChatModelDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryChatModelDeployment' {
    It 'Delete' {
        Remove-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
        { Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNew -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentityWorkspace' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        Remove-AzDiscoveryChatModelDeployment -WorkspaceInputObject $workspace `
            -Name $env.ChatModelDeploymentNameForNewViaPar -Confirm:$false
        { Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNewViaPar -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' {
        $identity = Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNewJson -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $identity | Remove-AzDiscoveryChatModelDeployment -Confirm:$false
        { Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNewJson -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
