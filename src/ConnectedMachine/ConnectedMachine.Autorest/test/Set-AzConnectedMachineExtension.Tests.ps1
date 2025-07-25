if(($null -eq $TestName) -or ($TestName -contains 'Set-AzConnectedMachineExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzConnectedMachineExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzConnectedMachineExtension' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        $customSplat = @{
            MachineName = $env.MachineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            Name = "networkWatcher"
        }
    
        $customSplat.ExtensionType = "NetworkWatcherAgentWindows"
        $customSplat.Publisher = "Microsoft.Azure.NetworkWatcher"
        $customSplat.TypeHandlerVersion = "1.4.2798.3"
        $customSplat.Settings = @{
            commandToExecute = "powershell.exe ls"
        }
        $all = @(Set-AzConnectedMachineExtension @customSplat)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
