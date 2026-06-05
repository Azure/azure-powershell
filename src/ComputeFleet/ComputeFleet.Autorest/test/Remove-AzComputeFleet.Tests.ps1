if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzComputeFleet' {

    BeforeAll {
        $resourceGroupName = "fleet-remove-test-rg"
        $vnetName = "vnet"
        $nsgName = "nsg"
        $vmNamePrefix = "fleetvm"
        $deleteFleetName = "delete-fleet"
        $deleteViaIdentityFleetName = "delete-via-identity-fleet"

        $result = New-TestResourceGroup -ResourceGroupName $resourceGroupName `
            -Location $env.Location -VNetName $vnetName -NsgName $nsgName
        $subnetId = $result.SubnetId
        $nsgId = $result.NsgId
    }

    It 'Delete' {
        {
            $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId
            $vmSize = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize.Name = "Standard_D2s_v3"

            $fleet = New-AzComputeFleet -Name $deleteFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize) `
                -RegularPriorityProfileCapacity 1 `
                -RegularPriorityProfileMinCapacity 1 `
                -RegularPriorityProfileAllocationStrategy "LowestPrice" `
                -Mode "Launch" `
                -VMNamePrefix $vmNamePrefix `
                -Tag @{ environment = "test" }

            $fleet.Name | Should -Be $deleteFleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"

            Remove-AzComputeFleet -Name $deleteFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            { Get-AzComputeFleet -Name $deleteFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId
            $vmSize = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize.Name = "Standard_D2s_v3"

            $fleet = New-AzComputeFleet -Name $deleteViaIdentityFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize) `
                -RegularPriorityProfileCapacity 1 `
                -RegularPriorityProfileMinCapacity 1 `
                -RegularPriorityProfileAllocationStrategy "LowestPrice" `
                -Mode "Launch" `
                -VMNamePrefix $vmNamePrefix `
                -Tag @{ environment = "test" }

            $fleet.Name | Should -Be $deleteViaIdentityFleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"

            Remove-AzComputeFleet -InputObject $fleet

            { Get-AzComputeFleet -Name $deleteViaIdentityFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId } | Should -Throw
        } | Should -Not -Throw
    }

    AfterAll {
        Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
    }
}
