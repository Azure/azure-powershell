if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoverySupercomputer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoverySupercomputer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoverySupercomputer' {
    It 'Get' {
        $result = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.SupercomputerNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -ErrorAction Stop
        $result = Get-AzDiscoverySupercomputer -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.SupercomputerNameForGet
    }}
