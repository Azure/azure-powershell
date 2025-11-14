if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest' {
    It 'List' {
        $manifest = Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        $manifest | Should -Not -BeNullOrEmpty
        $manifest.ResourceName | Should -Be $env.Name
    }
}
