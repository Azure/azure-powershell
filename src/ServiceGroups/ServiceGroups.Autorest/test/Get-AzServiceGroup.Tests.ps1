if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceGroup' {
    It 'Get' {
        $serviceGroup = Get-AzServiceGroup -Name $env.ServiceGroupNameForGet
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.Name | Should -Be $env.ServiceGroupNameForGet
        $serviceGroup.DisplayName | Should -Be $env.ServiceGroupDisplayName
    }

    It 'GetViaIdentity' {
        $serviceGroupObj = Get-AzServiceGroup -Name $env.ServiceGroupNameForGet
        $serviceGroup = Get-AzServiceGroup -InputObject $serviceGroupObj
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.Name | Should -Be $env.ServiceGroupNameForGet
        $serviceGroup.DisplayName | Should -Be $env.ServiceGroupDisplayName
    }
}
