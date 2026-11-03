if(($null -eq $TestName) -or ($TestName -contains 'New-AzConnectedLicenseProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedLicenseProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConnectedLicenseProfile' {
    It 'CreateExpanded' {
        # WS paygo subscription only (without Hotpatch - requires VBS enabled)
        $all = @(New-AzConnectedLicenseProfile -MachineName "PAYGOWS2025" -ResourceGroupName "yao_test" -Location "eastus" -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled")
        $all | Should -Not -BeNullOrEmpty
    }
}
