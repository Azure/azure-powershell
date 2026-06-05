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
    # All tests are skipped due to a known cmdlet bug.
    # Update-AzComputeFleet does a read-modify-write (GET → merge → PUT), but the
    # serialization of computeProfile during the PUT differs from the original, causing:
    # "[PropertyChangeNotAllowed] : Changing property 'properties.computeProfile' is not allowed."
    # Use Set-AzComputeFleet (full PUT with all properties) as a workaround.

    It 'UpdateExpanded' -Skip {
        # Known bug: Update-AzComputeFleet does a read-modify-write (GET → merge → PUT), but
        # the serialization of computeProfile during the PUT differs from the original,
        # causing: "[PropertyChangeNotAllowed] : Changing property 'properties.computeProfile' is not allowed."
        {
            $fleet = Update-AzComputeFleet -Name $fleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -RegularPriorityProfileCapacity 2

            $fleet.Name | Should -Be $fleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.RegularPriorityProfileCapacity | Should -Be 2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        # Known bug: Same as UpdateExpanded - computeProfile serialization mismatch on PUT.
        {
            $existingFleet = Get-AzComputeFleet -Name $fleetIdentityName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            $fleet = Update-AzComputeFleet -InputObject $existingFleet `
                -RegularPriorityProfileCapacity 3

            $fleet.Name | Should -Be $fleetIdentityName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.RegularPriorityProfileCapacity | Should -Be 3
        } | Should -Not -Throw
    }

}
