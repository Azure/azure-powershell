if(($null -eq $TestName) -or ($TestName -contains 'WorkspaceCleanRemove'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'WorkspaceCleanRemove.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'WorkspaceCleanRemove' {
    It 'DeleteJob' -skip {
        {
            Remove-AzMLWorkspaceJob -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.commandJob02
        } | Should -Not -Throw
    }

    It 'DeleteBatchDeployment' -skip {
        {
            Remove-AzMLWorkspaceBatchDeployment -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -EndpointName $env.batchEndpoint -Name $env.batchDeployment
        } | Should -Not -Throw
    }

    It 'DeleteBatchEndpoint' {
        {
            Remove-AzMLWorkspaceBatchEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.batchEndpoint
            # Get-AzMLWorkspace -ResourceGroupName $env.DataGroupName -Name $env.computeWorkspace | Remove-AzMLWorkspace -ForceToPurge
        } | Should -Throw
    }

    It 'DeleteModel' {
        {
            Remove-AzMLWorkspaceModelVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name heart-classifier-batch -Version 1
        } | Should -Not -Throw
    }

    It 'DeleteCodeVersion' {
        {Remove-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.codename -Version 1} | Should -Not -Throw
    }

    It 'DeleteBatchCluster' {
        {
            Remove-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.batchClusterName -UnderlyingResourceAction 'Delete'
        } | Should -Not -Throw
    }

    It 'DeleteComputeInstance' {
        {
            Remove-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.computeinstance -UnderlyingResourceAction 'Delete'
        } | Should -Not -Throw
    }

    It 'DeleteMainWorkspace' {
        {
            Remove-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.mainWorkspace -ForceToPurge
        } | Should -Not -Throw 
    }

    It 'DeleteProjectWorkspace' {
        {
            Remove-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.projWorkspace -ForceToPurge
        } | Should -Not -Throw
    }

    It 'DeleteHubWorkspace' {
        {
            Remove-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.hubWorkspace -ForceToPurge
        } | Should -Not -Throw
    }
}
