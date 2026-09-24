if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedLicenseProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedLicenseProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConnectedLicenseProfile' {
    It 'UpdateExpanded' {
        # Update WS paygo subscription (without Hotpatch - requires VBS enabled)
        $all = @(Update-AzConnectedLicenseProfile -MachineName "PAYGOWS2025" -ResourceGroupName "yao_test" -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled")
        $all | Should -Not -BeNullOrEmpty
    }

}
