if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMonitorHealthModelRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorHealthModelRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMonitorHealthModelRelationship' {
    It 'Delete' {
        {
            $childEntityName = $env.RelationshipDeleteChildEntityName
            $existingChild = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $childEntityName -ErrorAction SilentlyContinue
            if ($null -eq $existingChild) {
                New-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $childEntityName -DisplayName 'Relationship delete child' -Impact Standard -HealthObjective 99.0 | Out-Null
            }
            New-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipDeleteName -ParentEntityName $env.EntityName -ChildEntityName $childEntityName -DisplayName 'Delete relationship' | Out-Null
            $deleted = Remove-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipDeleteName -PassThru
            $deleted | Should -BeTrue
            { Get-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipDeleteName -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
