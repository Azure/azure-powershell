if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRelationshipsDependencyOfRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRelationshipsDependencyOfRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzRelationshipsDependencyOfRelationship' {
    It 'Delete' {
        Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToDelete
        { Get-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToDelete } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $identity = @{
            ResourceUri = $env.DepResourceGroupResourceUri
            Name = $env.DepRelNameToDeleteViaIdentity
        }
        Remove-AzRelationshipsDependencyOfRelationship -InputObject $identity
        { Get-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToDeleteViaIdentity } | Should -Throw
    }
}
