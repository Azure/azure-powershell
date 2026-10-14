if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryWorkspace' {
    It 'Get' {
        $result = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspaceNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
        $result = Get-AzDiscoveryWorkspace -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspaceNameForGet
    }}
