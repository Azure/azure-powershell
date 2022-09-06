if(($null -eq $TestName) -or ($TestName -contains 'Install-AzConnectedVMwareVirtualMachinePatch'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Install-AzConnectedVMwareVirtualMachinePatch.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Install-AzConnectedVMwareVirtualMachinePatch' {
    It 'InstallExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Install' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InstallViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InstallViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
