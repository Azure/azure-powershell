if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryProject' {
    It 'Get' {
        $result = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ProjectNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $result = Get-AzDiscoveryProject -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ProjectNameForGet
    }}
