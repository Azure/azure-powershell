if(($null -eq $TestName) -or ($TestName -contains 'Test-AzKeyVaultManagedHsmNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKeyVaultManagedHsmNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzKeyVaultManagedHsmNameAvailability' {
    It 'CheckExpanded' {
        { Test-AzKeyVaultManagedHsmNameAvailability -Name $env.hsmName } | Should -Not -Throw
    }
    
    It 'CheckViaJsonString' {
        { Test-AzKeyVaultManagedHsmNameAvailability -JsonString  '{
            "name": "bezmshtsdfsf"
          }'} | Should -Not -Throw
    }
}
