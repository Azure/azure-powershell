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
        $productfeature = Update-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
        $all = @(Update-AzConnectedLicenseProfile -MachineName $env.MachineNamePaygo -ResourceGroupName $env.ResourceGroupNameProfile -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled" -ProductProfileProductFeature $productfeature)
        $all | Should -Not -BeNullOrEmpty
    }

}
