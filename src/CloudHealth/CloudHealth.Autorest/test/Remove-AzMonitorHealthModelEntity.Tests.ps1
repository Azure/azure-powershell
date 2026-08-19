if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMonitorHealthModelEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorHealthModelEntity.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMonitorHealthModelEntity' {
    It 'Delete' {
        {
            New-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityDeleteName -DisplayName 'Delete entity' -Impact Standard -HealthObjective 99.0 | Out-Null
            $deleted = Remove-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityDeleteName -PassThru
            $deleted | Should -BeTrue
            { Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityDeleteName -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
