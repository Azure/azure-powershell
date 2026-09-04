if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModelEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModelEntity.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModelEntity' {
    It 'UpdateExpanded' {
        {
            $result = Update-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName -DisplayName 'Shared entity updated' -HealthObjective 99.7 -Impact Standard
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.EntityName
            $result.DisplayName | Should -Be 'Shared entity updated'
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
