if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup' {
    It 'List' {
        $relationship = Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName $env.ServiceGroupName
        $relationship.Name | Should -Contain $env.SgDepRelNameForGet
    }

    It 'Get' {
        $relationship = Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName $env.ServiceGroupName -Name $env.SgDepRelNameForGet
        $relationship.Name | Should -Be $env.SgDepRelNameForGet
    }

    It 'GetViaIdentity' {
        $identity = @{
            ServiceGroupName = $env.ServiceGroupName
            Name = $env.SgDepRelNameForGet
        }
        $relationship = Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -InputObject $identity
        $relationship.Name | Should -Be $env.SgDepRelNameForGet
    }
}
