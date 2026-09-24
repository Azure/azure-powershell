if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModelRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModelRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModelRelationship' {
    It 'UpdateExpanded' {
        {
            $result = Update-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipName -DisplayName 'Shared relationship updated' -Tag @{ role = 'dependency' }
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.RelationshipName
            $result.DisplayName | Should -Be 'Shared relationship updated'
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
