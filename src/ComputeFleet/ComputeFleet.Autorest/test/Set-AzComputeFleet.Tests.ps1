if(($null -eq $TestName) -or ($TestName -contains 'Set-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzComputeFleet' {

    BeforeAll {
        $resourceGroupName = "fleet-set-test-rg"
        $vnetName = "vnet"
        $nsgName = "nsg"
        $vmNamePrefix = "fleetvm"
        $fleetName = "set-fleet"
        $fleetJsonName = "set-fleet-json"
        $fleetJsonStrName = "set-fleet-jsonstr"

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
        $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix
        $vmSize = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
        $vmSize.Name = "Standard_D2s_v3"

        New-AzComputeFleet -Name $fleetName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize) `
            -SpotPriorityProfileCapacity 2 `
            -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
            -SpotPriorityProfileEvictionPolicy "Delete" `
            -Tag @{ environment = "test" }

        $vmProfile2 = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix
        New-AzComputeFleet -Name $fleetJsonName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile2 `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize) `
            -SpotPriorityProfileCapacity 2 `
            -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
            -SpotPriorityProfileEvictionPolicy "Delete" `
            -Tag @{ environment = "test" }

        $vmProfile3 = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix
        New-AzComputeFleet -Name $fleetJsonStrName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile3 `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize) `
            -SpotPriorityProfileCapacity 2 `
            -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
            -SpotPriorityProfileEvictionPolicy "Delete" `
            -Tag @{ environment = "test" }
    }

    It 'UpdateExpanded' {
        {
            $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix
            $vmSize = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize.Name = "Standard_D2s_v3"

            $fleet = Set-AzComputeFleet -Name $fleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize) `
                -SpotPriorityProfileCapacity 3 `
                -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
                -SpotPriorityProfileEvictionPolicy "Delete" `
                -Tag @{ environment = "test"; updated = "true" }

            $fleet.Name | Should -Be $fleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Tag["updated"] | Should -Be "true"
            $fleet.SpotPriorityProfileCapacity | Should -Be 3
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {
            $jsonBody = @{
                location   = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = Get-BaseVmProfileJson -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                    )
                    spotPriorityProfile = @{
                        capacity           = 4
                        allocationStrategy = "PriceCapacityOptimized"
                        evictionPolicy     = "Delete"
                    }
                }
                tags = @{ environment = "test"; updated = "json" }
            }

            $jsonFilePath = Join-Path $PSScriptRoot "set-fleet.json"
            $jsonBody | ConvertTo-Json -Depth 15 | Set-Content -Path $jsonFilePath

            $fleet = Set-AzComputeFleet -Name $fleetJsonName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonFilePath

            $fleet.Name | Should -Be $fleetJsonName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Tag["updated"] | Should -Be "json"
            $fleet.SpotPriorityProfileCapacity | Should -Be 4

            Remove-Item -Path $jsonFilePath -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            $jsonBody = @{
                location   = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = Get-BaseVmProfileJson -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                    )
                    spotPriorityProfile = @{
                        capacity           = 5
                        allocationStrategy = "PriceCapacityOptimized"
                        evictionPolicy     = "Delete"
                    }
                }
                tags = @{ environment = "test"; updated = "jsonstr" }
            }

            $jsonString = $jsonBody | ConvertTo-Json -Depth 15

            $fleet = Set-AzComputeFleet -Name $fleetJsonStrName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonString $jsonString

            $fleet.Name | Should -Be $fleetJsonStrName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Tag["updated"] | Should -Be "jsonstr"
            $fleet.SpotPriorityProfileCapacity | Should -Be 5
        } | Should -Not -Throw
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
        }
    }
}
