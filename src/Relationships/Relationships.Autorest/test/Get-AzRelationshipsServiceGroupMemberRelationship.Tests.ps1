if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRelationshipsServiceGroupMemberRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRelationshipsServiceGroupMemberRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRelationshipsServiceGroupMemberRelationship' {
    It 'Get' {
        $relationship = Get-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForGet
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForGet
    }

    It 'GetViaIdentity' {
        $identity = @{
            ResourceUri = $env.SgmResourceGroupResourceUri
            Name = $env.SgmRelNameForGet
        }
        $relationship = Get-AzRelationshipsServiceGroupMemberRelationship -InputObject $identity
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForGet
    }
}
