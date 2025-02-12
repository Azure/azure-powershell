if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceBatchDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceBatchDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceBatchDeployment' { #Moved
    # New-AzMLWorkspaceBatchEndpoint InternalServerError
    It 'CreateExpanded' -skip {
        {
            New-AzMLWorkspaceBatchEndpoint -ResourceGroupName bml-rg-test0101 -WorkspaceName mlworkspacekeep -Name batchenpoint01 -AuthMode 'Key' -Location 'eastus'
            New-AzMLWorkspaceBatchDeployment -ResourceGroupName bml-rg-test01 -WorkspaceName mlworkspacekeep -EndpointName batchenpoint01 -Name debploy01 -Location "eastus" `
            -CodeId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/bml-rg-test01/providers/Microsoft.MachineLearningServices/workspaces/mlworkspacekeep/codes/bd430754-fba7-4a63-a6b8-8ea8635767f3/versions/1" -CodeScoringScript "digit_identification.py" `
            -EnvironmentId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/bml-rg-test01/providers/Microsoft.MachineLearningServices/workspaces/mlworkspacekeep/environments/CliV2AnonymousEnvironment/versions/5d230430f302e7876f9b64710733f68e" `
            -Compute "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/bml-rg-test01/providers/Microsoft.MachineLearningServices/workspaces/mlworkspacekeep/computes/batch-cluster" `
            -ModelReferenceType 'Id' 
            Update-AzMLWorkspaceBatchDeployment -ResourceGroupName bml-rg-test01 -WorkspaceName mlworkspacekeep -EndpointName batch-pwsh03 -Name nonmlflowdp -Tag @{'key'='value'}
            Remove-AzMLWorkspaceBatchDeployment -ResourceGroupName bml-rg-test01 -WorkspaceName mlworkspacekeep -EndpointName batch-pwsh03 -Name nonmlflowdp
        } | Should -Not -Throw
    }
}
