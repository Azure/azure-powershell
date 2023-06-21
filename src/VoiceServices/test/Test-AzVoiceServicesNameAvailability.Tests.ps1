if(($null -eq $TestName) -or ($TestName -contains 'Test-AzVoiceServicesNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzVoiceServicesNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzVoiceServicesNameAvailability' {
    It 'CheckExpanded' {
        { Test-AzVoiceServicesNameAvailability -Location eastus -Name 'VoiceServicesTestName' -Type "Microsoft.VoiceServices/CommunicationsGateways" } | Should -Not -Throw
    }
}
