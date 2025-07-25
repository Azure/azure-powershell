if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzActionGroupReceiver'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzActionGroupReceiver.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzActionGroupReceiver' {
    It 'EnableExpanded' {
        {
            # Receiver with name smsreceiver in action group with Id MONITOR:xx is already enabled
            Enable-AzActionGroupReceiver -ActionGroupName $env.actiongroupname -ResourceGroupName $env.resourceGroup -ReceiverName $env.smsreceiver
        } | Should -Throw "is already enabled"
    }

    It 'EnableViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityExpanded' {
        {
            # Receiver with name smsreceiver in action group with Id MONITOR:xx is already enabled
            $ag = Get-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup
            Enable-AzActionGroupReceiver -InputObject $ag -ReceiverName $env.emailreceiver1
        } | Should -Throw "is already enabled"
    }
}
