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

    BeforeAll {
        $resourceGroupName = "fleet-update-test-rg2"
        $vnetName = "vnet"
        $nsgName = "nsg"
        $fleetName = "update-fleet"
        $fleetIdentityName = "update-fleet-identity"

        if ($TestMode -ne 'playback') {
            $result = New-TestResourceGroup -ResourceGroupName $resourceGroupName `
                -Location $env.Location -VNetName $vnetName -NsgName $nsgName
            $subnetId = $result.SubnetId
            $nsgId = $result.NsgId
        } else {
            $subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet1"
            $nsgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/networkSecurityGroups/nsg"
        }

        # Create fleets for each test
        $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId
        $vmSize = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
        $vmSize.Name = "Standard_D2s_v3"

        New-AzComputeFleet -Name $fleetName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize) `
            -RegularPriorityProfileCapacity 2 `
            -RegularPriorityProfileAllocationStrategy "LowestPrice" `

        New-AzComputeFleet -Name $fleetIdentityName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize) `
            -RegularPriorityProfileCapacity 2 `
            -RegularPriorityProfileAllocationStrategy "LowestPrice" `
    }

    It 'UpdateExpanded' {
        {
            $fleet = Update-AzComputeFleet -Name $fleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -RegularPriorityProfileCapacity 5 `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `

            $fleet.Name | Should -Be $fleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.RegularPriorityProfileCapacity | Should -Be 5
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $existingFleet = Get-AzComputeFleet -Name $fleetIdentityName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            $fleet = Update-AzComputeFleet -InputObject $existingFleet `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -RegularPriorityProfileCapacity 6 `

            $fleet.Name | Should -Be $fleetIdentityName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.RegularPriorityProfileCapacity | Should -Be 6
        } | Should -Not -Throw
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
        }
    }
}
