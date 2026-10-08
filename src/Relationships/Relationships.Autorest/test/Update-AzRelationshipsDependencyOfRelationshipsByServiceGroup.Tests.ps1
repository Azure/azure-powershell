if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup' {
    It 'UpdateExpanded' {
        $relationship = Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName $env.ServiceGroupName -Name $env.SgDepRelNameToUpdate -TargetId $env.DepTargetId
        $relationship.Name | Should -Be $env.SgDepRelNameToUpdate
    }

    It 'UpdateViaIdentityExpanded' {
        $identity = @{
            ServiceGroupName = $env.ServiceGroupName
            Name = $env.SgDepRelNameToUpdate
        }
        $relationship = Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup -InputObject $identity -TargetId $env.DepTargetId
        $relationship.Name | Should -Be $env.SgDepRelNameToUpdate
    }
}
