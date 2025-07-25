if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupArmRoleReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupArmRoleReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupArmRoleReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupArmRoleReceiverObject -Name "sample arm role" -RoleId "8e3af657-a8ff-443c-a75c-2fe8c4bcb635" -UseCommonAlertSchema $true
        } | Should -Not -Throw
    }
}
