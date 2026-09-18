if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceGroup' {
    It 'Delete' {
        Remove-AzServiceGroup -Name $env.ServiceGroupNameToDelete
        { Get-AzServiceGroup -Name $env.ServiceGroupNameToDelete } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $sg = Get-AzServiceGroup -Name $env.ServiceGroupNameToDeleteViaIdentity
        Remove-AzServiceGroup -InputObject $sg
        { Get-AzServiceGroup -Name $env.ServiceGroupNameToDeleteViaIdentity } | Should -Throw
    }
}
