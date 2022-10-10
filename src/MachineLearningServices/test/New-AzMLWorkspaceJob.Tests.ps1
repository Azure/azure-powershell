if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceJob' {
    It 'CommandJob' {
        { 
            New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name commandjobenv02 -Version 1 -Image "library/python:latest"
            $commandJob = New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" `
            -ComputeId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test01/providers/Microsoft.MachineLearningServices/workspaces/mlworkspacekeep/computes/cpu-cluster' `
            -EnvironmentId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test01/providers/Microsoft.MachineLearningServices/workspaces/mlworkspacekeep/environments/commandjobenv02/versions/1'`
            -DisplayName 'commandJob03' -ExperimentName 'commandjobexperiment'
            New-AzMLWorkspaceJob -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name commandJob03 -Job $commandJob
            Stop-AzMLWorkspaceJob -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name commandJob03 
            # Remove operation exists 404 status code during runing operation.
            # Remove-AzMLWorkspaceJob -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name commandJob03
        } | Should -Not -Throw
    }
}
