if(($null -eq $TestName) -or ($TestName -contains 'Test-AzDeviceUpdateNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzDeviceUpdateNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzDeviceUpdateNameAvailability' {
    It 'CheckExpanded' {
        {
            $config = New-AzDeviceUpdateCheckNameAvailabilityRequestObject -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
            $config = Test-AzDeviceUpdateNameAvailability -Request $config
            $config.NameAvailable | Should -Be True
        } | Should -Not -Throw
    }

    It 'Check' {
        {
            $config = Test-AzDeviceUpdateNameAvailability -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
            $config.NameAvailable | Should -Be True
        } | Should -Not -Throw
    }
}
