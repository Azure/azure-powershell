if(($null -eq $TestName) -or ($TestName -contains 'Update-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzComputeFleet' {
    It 'Update' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $securedPassword = ConvertTo-SecureString -AsPlainText "[Sanitized]" -Force
            $fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
            $fleet.AcceleratorCountMax = 3
            $fleet = Update-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName -Resource $fleet
            $fleet.AcceleratorCountMax | Should -Be 3
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $securedPassword = ConvertTo-SecureString -AsPlainText "[Sanitized]" -Force
            $fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
            $fleet.MemoryInGiBMax = 500
            $fleet = Update-AzComputeFleet -InputObject $fleet -Resource $fleet
            $fleet.MemoryInGiBMax | Should -Be 500
        } | Should -Not -Throw
    }
}
