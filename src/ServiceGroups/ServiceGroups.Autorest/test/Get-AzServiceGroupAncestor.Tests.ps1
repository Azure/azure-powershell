if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceGroupAncestor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceGroupAncestor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceGroupAncestor' {
    It 'List' {
        $ancestors = Get-AzServiceGroupAncestor -ServiceGroupName $env.ServiceGroupNameForGet
        $ancestors | Should -Not -BeNullOrEmpty
        $ancestors.Count | Should -BeGreaterOrEqual 1
    }

    It 'ListForChild' {
        $ancestors = Get-AzServiceGroupAncestor -ServiceGroupName $env.ChildServiceGroupName
        $ancestors | Should -Not -BeNullOrEmpty
        $ancestors.Count | Should -BeGreaterOrEqual 2
    }
}
