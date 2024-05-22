if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedMachineExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedMachineExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConnectedMachineExtension' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        $splat = @{
            ResourceGroupName = "ytongtest"
            MachineName = "testmachine"
            Name = "customScript"
            Settings = @{
                commandToExecute = "powershell.exe ls"
            }
        }
        $all = Update-AzConnectedMachineExtension @splat
        $all | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaIdentityMachineExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'UpdateViaIdentityMachine' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}

