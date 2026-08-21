if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryProject' {
    It 'Delete' {
        Remove-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
        { Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNew -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentityWorkspace' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        Remove-AzDiscoveryProject -WorkspaceInputObject $workspace `
            -Name $env.ProjectNameForNewViaPar -Confirm:$false
        { Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNewViaPar -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' {
        $identity = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNewJson -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $identity | Remove-AzDiscoveryProject -Confirm:$false
        { Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNewJson -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
