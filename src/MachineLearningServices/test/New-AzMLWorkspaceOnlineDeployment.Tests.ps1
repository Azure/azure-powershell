if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceOnlineDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceOnlineDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceOnlineDeployment' {
    It 'CreateExpanded' {
        { 
            New-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01 -Location "eastus" -EndpointComputeType 'Managed' `
            -CodeId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/codes/787fc793-1ac7-414e-a035-7248767b7b23/versions/1" -CodeScoringScript "score.py" `
            -EnvironmentId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/environments/CliV2AnonymousEnvironment/versions/8a424b013f5b0177929a1697d772da41" `
            -Model "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/models/a99089c5-23a6-4431-9ecd-37c70f01c9bc/versions/1" -InstanceType "Standard_F2s_v2" `
            -SkuName "Default" -SkuCapacity 1
            Update-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01 -Tag @{'key'='value'}
            # Remove-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01
        } | Should -Not -Throw
    }
}
