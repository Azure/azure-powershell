<<<<<<<< HEAD:src/SignalR/SignalR.Autorest/test/Update-AzWebPubSubHub.Tests.ps1
if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWebPubSubHub'))
========
if(($null -eq $TestName) -or ($TestName -contains 'Set-AzMonitorWorkspace'))
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/test/Set-AzMonitorWorkspace.Tests.ps1
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
<<<<<<<< HEAD:src/SignalR/SignalR.Autorest/test/Update-AzWebPubSubHub.Tests.ps1
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWebPubSubHub.Recording.json'
========
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMonitorWorkspace.Recording.json'
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/test/Set-AzMonitorWorkspace.Tests.ps1
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

<<<<<<<< HEAD:src/SignalR/SignalR.Autorest/test/Update-AzWebPubSubHub.Tests.ps1
Describe 'Update-AzWebPubSubHub' {
========
Describe 'Set-AzMonitorWorkspace' {
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/test/Set-AzMonitorWorkspace.Tests.ps1
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

<<<<<<<< HEAD:src/SignalR/SignalR.Autorest/test/Update-AzWebPubSubHub.Tests.ps1
    It 'UpdateViaIdentityHubExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
========
    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/test/Set-AzMonitorWorkspace.Tests.ps1
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
