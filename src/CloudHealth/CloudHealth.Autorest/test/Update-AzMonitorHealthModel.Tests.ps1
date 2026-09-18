if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModel'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModel.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModel' {
    It 'UpdateExpanded' {
        {
            $result = Update-AzMonitorHealthModel -Name $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Tag @{ phase = 'updated'; owner = 'test' }
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.HealthModelName
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
