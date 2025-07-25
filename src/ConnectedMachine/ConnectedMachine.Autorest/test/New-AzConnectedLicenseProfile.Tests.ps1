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
        # SA and WS PayGo have incompatible pre-requisites - SA claim in only for licensed machine. You can enroll in WS PayGo subscription only if the machine is unlicensed. hotpatch is fine either way.
        $productfeature = New-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"

        # SA benefit only
        # $all = @(New-AzConnectedLicenseProfile -MachineName $env.MachineNameSA -ResourceGroupName $env.ResourceGroupNameProfile -Location $env.Location -SoftwareAssuranceCustomer)

        # WS paygo and hotpatch
        $all = @(New-AzConnectedLicenseProfile -MachineName $env.MachineNamePaygo -ResourceGroupName $env.ResourceGroupNameProfile -Location $env.Location -ProductProfileProductType "WindowsServer" -ProductProfileSubscriptionStatus "Enabled" -ProductProfileProductFeature $productfeature)
        $all | Should -Not -BeNullOrEmpty
    }
}
