if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMonitorHealthModel'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorHealthModel.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMonitorHealthModel' {
    It 'List' {
        {
            $list = Get-AzMonitorHealthModel -ResourceGroupName $env.ResourceGroupName
            $list | Should -Not -BeNullOrEmpty
            @($list | Where-Object Name -eq $env.HealthModelName).Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzMonitorHealthModel -ResourceGroupName $env.ResourceGroupName -Name $env.HealthModelName
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.HealthModelName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
