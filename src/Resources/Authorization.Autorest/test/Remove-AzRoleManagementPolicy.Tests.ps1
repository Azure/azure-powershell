if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRoleManagementPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRoleManagementPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzRoleManagementPolicy' {
    It 'Delete' {
        { 
            $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
            Remove-AzRoleManagementPolicy -Scope $scope -Name "0a4d3ef7-147b-4777-a958-ae9dfab3c331"
        } | Should -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
