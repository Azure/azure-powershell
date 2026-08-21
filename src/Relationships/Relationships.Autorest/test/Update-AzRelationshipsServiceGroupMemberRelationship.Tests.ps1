if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRelationshipsServiceGroupMemberRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRelationshipsServiceGroupMemberRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzRelationshipsServiceGroupMemberRelationship' {
    It 'UpdateExpanded' {
        $relationship = Update-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameToUpdate -TargetId $env.SgmTargetId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameToUpdate
    }

    It 'UpdateViaIdentityExpanded' {
        $identity = @{
            ResourceUri = $env.SgmResourceGroupResourceUri
            Name = $env.SgmRelNameToUpdate
        }
        $relationship = Update-AzRelationshipsServiceGroupMemberRelationship -InputObject $identity -TargetId $env.SgmTargetId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameToUpdate
    }
}
