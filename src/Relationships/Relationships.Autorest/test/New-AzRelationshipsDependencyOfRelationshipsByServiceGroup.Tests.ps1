if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelationshipsDependencyOfRelationshipsByServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelationshipsDependencyOfRelationshipsByServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelationshipsDependencyOfRelationshipsByServiceGroup' {
    It 'CreateExpanded' {
        $relationship = New-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName $env.ServiceGroupName -Name $env.SgDepRelNameForNew -TargetId $env.DepTargetId
        $relationship.Name | Should -Be $env.SgDepRelNameForNew
    }

    It 'CreateViaIdentityServiceGroupExpanded' {
        $identity = @{ ServiceGroupName = $env.ServiceGroupName }
        $relationship = New-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupInputObject $identity -Name ($env.SgDepRelNameForNew + 'identity') -TargetId $env.DepTargetId
        $relationship.Name | Should -Be ($env.SgDepRelNameForNew + 'identity')
    }
}
