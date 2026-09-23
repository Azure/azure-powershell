if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageDiscoveryWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageDiscoveryWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageDiscoveryWorkspace' {
    It 'List1' {
        {
            $list_sub = Get-AzStorageDiscoveryWorkspace
            $list_sub.count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $workspace = Get-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup
            $workspace.Name | Should -Be $env.testWorkspaceName1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $list_rg = Get-AzStorageDiscoveryWorkspace -ResourceGroupName $env.resourceGroup
            $list_rg.count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
