if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRelationshipsDependencyOfRelationshipsByServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRelationshipsDependencyOfRelationshipsByServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzRelationshipsDependencyOfRelationshipsByServiceGroup' {
    It 'Delete' {
        Remove-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName $env.ServiceGroupName -Name $env.SgDepRelNameToDelete
        { Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName $env.ServiceGroupName -Name $env.SgDepRelNameToDelete -ErrorAction Stop } | Should -Throw
    }
}
