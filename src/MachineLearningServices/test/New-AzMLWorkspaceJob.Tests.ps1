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
            New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandjobenv -Version 1 -Image "library/python:latest"
            $commandJob = New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" `
            -ComputeId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/computes/aml02' `
            -EnvironmentId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/environments/commandjobenv/versions/1'`
            -DisplayName 'commandjob01' -ExperimentName 'commandjobexperiment'
            New-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01 -Job $commandJob
            Remove-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01
        } | Should -Not -Throw
    }
}
