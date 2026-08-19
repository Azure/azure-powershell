if(($null -eq $TestName) -or ($TestName -contains 'New-AzMonitorHealthModelRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModelRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModelRelationship' {
    It 'CreateExpanded' {
        {
            $childEntityName = $env.RelationshipCreateChildEntityName
            $existingChild = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $childEntityName -ErrorAction SilentlyContinue
            if ($null -eq $existingChild) {
                New-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $childEntityName -DisplayName 'Relationship create child' -Impact Standard -HealthObjective 99.0 | Out-Null
            }
            $result = New-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipCreateName -ParentEntityName $env.EntityName -ChildEntityName $childEntityName -DisplayName 'Create relationship'
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.RelationshipCreateName
            $result.ParentEntityName | Should -Be $env.EntityName
            $result.ChildEntityName | Should -Be $childEntityName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
