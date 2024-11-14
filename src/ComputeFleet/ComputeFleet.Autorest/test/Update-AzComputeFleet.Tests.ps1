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
    It 'UpdateExpanded' {
        {
            # $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName3
            # $securedPassword = ConvertTo-SecureString -AsPlainText "testPassword01%" -Force
            # $fleet.ComputeProfileBaseVirtualMachineProfile.OSProfile.AdminPassword = $securedPassword
            # $fleet = Update-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName3 -VCpuCountMax 3
            # $fleet.VMAttributes.VCpuCountMax | Should -Be 3
            
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName3
            $fleet = Update-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName3 -AcceleratorCountMax 3
            $fleet.AcceleratorCountMax | Should -Be 3
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName3
            $fleet.MemoryInGiBMax = 500
            $securedPassword = ConvertTo-SecureString -AsPlainText "testPassword01%" -Force
            $fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
            $updatedFleet = Update-AzComputeFleet -InputObject $fleet
            $jsonString = $updatedFleet | ConvertTo-Json
            Write-Host "FLEET: $($jsonString)"
            $updatedFleet.MemoryInGiBMax | Should -Be 500
        } | Should -Not -Throw
    }
}
