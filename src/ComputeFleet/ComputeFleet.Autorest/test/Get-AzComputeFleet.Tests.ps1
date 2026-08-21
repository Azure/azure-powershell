if(($null -eq $TestName) -or ($TestName -contains 'Get-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzComputeFleet' {
    BeforeAll {
        $resourceGroupName = "fleet-get-test-rg"
        $resourceGroupName2 = "fleet-get-test-rg2"
        $vnetName = "vnet"
        $vnetName2 = "vnet2"
        $nsgName = "nsg"
        $nsgName2 = "nsg2"
        $vmNamePrefix = "fleetvm"
        $launchFleetName = "launch-fleet"
        $launchFleetName2 = "launch-fleet2"

        if ($TestMode -ne 'playback') {
            $result1 = New-TestResourceGroup -ResourceGroupName $resourceGroupName `
                -Location $env.Location -VNetName $vnetName -NsgName $nsgName `
                -VNetAddressPrefix "172.16.0.0/16" -SubnetAddressPrefix "172.16.0.0/24"
            $subnetId = $result1.SubnetId
            $nsgId = $result1.NsgId

            $result2 = New-TestResourceGroup -ResourceGroupName $resourceGroupName2 `
                -Location $env.Location -VNetName $vnetName2 -NsgName $nsgName2 `
                -VNetAddressPrefix "172.17.0.0/16" -SubnetAddressPrefix "172.17.0.0/24"
            $subnetId2 = $result2.SubnetId
            $nsgId2 = $result2.NsgId
        } else {
            $subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet1"
            $nsgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/networkSecurityGroups/nsg"
            $subnetId2 = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test2/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet1"
            $nsgId2 = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test2/providers/Microsoft.Network/networkSecurityGroups/nsg2"
        }

        $vmProfile1 = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId
        $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
        $vmSize1.Name = "Standard_D2s_v3"

        New-AzComputeFleet -Name $launchFleetName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile1 `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize1) `
            -RegularPriorityProfileCapacity 2 `
            -RegularPriorityProfileMinCapacity 1 `
            -RegularPriorityProfileAllocationStrategy "LowestPrice" `
            -Mode "Launch" `
            -VMNamePrefix $vmNamePrefix `
            -Tag @{ environment = "test" }

        $vmProfile2 = New-TestVmProfile -SubnetId $subnetId2 -NsgId $nsgId2
        $vmSize2 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
        $vmSize2.Name = "Standard_D2s_v3"

        New-AzComputeFleet -Name $launchFleetName2 `
            -ResourceGroupName $resourceGroupName2 `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile2 `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize2) `
            -RegularPriorityProfileCapacity 2 `
            -RegularPriorityProfileMinCapacity 1 `
            -RegularPriorityProfileAllocationStrategy "LowestPrice" `
            -Mode "Launch" `
            -VMNamePrefix $vmNamePrefix `
            -Tag @{ environment = "test" }
    }

    It 'ListBySubscriptionId' {
        {
            $fleetList = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId
            $fleetList.Count | Should -BeGreaterOrEqual 2

            $fleetNames = $fleetList | ForEach-Object { $_.Name }
            $fleetNames | Should -Contain $launchFleetName
            $fleetNames | Should -Contain $launchFleetName2
        } | Should -Not -Throw
    }

    It 'ListFleetsByResourceGroup' {
        {
            $fleetList = Get-AzComputeFleet -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId
            $fleetList.Count | Should -BeGreaterOrEqual 1

            $fleetNames = $fleetList | ForEach-Object { $_.Name }
            $fleetNames | Should -Contain $launchFleetName
            $fleetNames | Should -Not -Contain $launchFleetName2
        } | Should -Not -Throw
    }

    It 'GetFleet' {
        {
            $fleet = Get-AzComputeFleet -Name $launchFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            $fleet.Name | Should -Be $launchFleetName
            $fleet.ResourceGroupName | Should -Be $resourceGroupName
            $fleet.Location | Should -Be $env.Location
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"
        } | Should -Not -Throw
    }

    It 'GetFleetViaIdentity' {
        {
            $fleet = Get-AzComputeFleet -Name $launchFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            $fleetViaIdentity = Get-AzComputeFleet -InputObject $fleet

            $fleetViaIdentity.Name | Should -Be $launchFleetName
            $fleetViaIdentity.ResourceGroupName | Should -Be $resourceGroupName
            $fleetViaIdentity.ProvisioningState | Should -Be "Succeeded"
            $fleetViaIdentity.Mode | Should -Be "Launch"
        } | Should -Not -Throw
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
            Remove-AzResourceGroup -Name $resourceGroupName2 -ErrorAction SilentlyContinue -Confirm:$false
        }
    }
}
