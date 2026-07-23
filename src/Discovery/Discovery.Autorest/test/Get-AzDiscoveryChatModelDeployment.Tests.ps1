if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryChatModelDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryChatModelDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryChatModelDeployment' {
    It 'Get' {
        $result = Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ChatModelDeploymentWorkspaceName -Name $env.ChatModelDeploymentNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ChatModelDeploymentNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ChatModelDeploymentWorkspaceName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ChatModelDeploymentWorkspaceName -Name $env.ChatModelDeploymentNameForGet -ErrorAction Stop
        $result = Get-AzDiscoveryChatModelDeployment -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ChatModelDeploymentNameForGet
    }}
