if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMonitorHealthModel'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorHealthModel.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMonitorHealthModel' {
    It 'Delete' {
        {
            New-AzMonitorHealthModel -Name $env.HealthModelDeleteName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -EnableSystemAssignedIdentity | Out-Null
            $deleted = Remove-AzMonitorHealthModel -Name $env.HealthModelDeleteName -ResourceGroupName $env.ResourceGroupName -PassThru
            $deleted | Should -BeTrue
            { Get-AzMonitorHealthModel -Name $env.HealthModelDeleteName -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
