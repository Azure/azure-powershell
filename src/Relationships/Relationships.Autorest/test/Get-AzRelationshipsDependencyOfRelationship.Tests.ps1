if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRelationshipsDependencyOfRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRelationshipsDependencyOfRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRelationshipsDependencyOfRelationship' {
    It 'Get' {
        $relationship = Get-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForGet
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForGet
    }

    It 'GetViaIdentity' {
        $identity = @{
            ResourceUri = $env.DepResourceGroupResourceUri
            Name = $env.DepRelNameForGet
        }
        $relationship = Get-AzRelationshipsDependencyOfRelationship -InputObject $identity
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForGet
    }
}
