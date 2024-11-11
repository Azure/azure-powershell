if(($null -eq $TestName) -or ($TestName -contains 'New-AzConnectedLicenseProfileUpdate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedLicenseProfileUpdate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConnectedLicenseProfileUpdate' {
    It 'LicenseProfileUpdate' {
        $productfeature = New-AzConnectedLicenseProfileUpdate -Name "Hotpatch" -SubscriptionStatus "Enable"
        $productfeature | Should -Not -BeNullOrEmpty
    }
}
