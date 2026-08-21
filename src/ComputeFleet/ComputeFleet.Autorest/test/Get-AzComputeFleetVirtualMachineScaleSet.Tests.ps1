if(($null -eq $TestName) -or ($TestName -contains 'Get-AzComputeFleetVirtualMachineScaleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeFleetVirtualMachineScaleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzComputeFleetVirtualMachineScaleSet' {
    BeforeAll {
        $resourceGroupName = "fleet-vmss-list-test-rg"
        $vnetName = "vnet"
        $nsgName = "nsg"
        $vmNamePrefix = "fleetvm"
        $managedFleetName = "managed-fleet-vmss"

        if ($TestMode -ne 'playback') {
            $result = New-TestResourceGroup -ResourceGroupName $resourceGroupName `
                -Location $env.Location -VNetName $vnetName -NsgName $nsgName
            $subnetId = $result.SubnetId
            $nsgId = $result.NsgId
        } else {
            $subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet1"
            $nsgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/networkSecurityGroups/nsg"
        }

        $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix

        $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
        $vmSize1.Name = "Standard_D2s_v3"

        New-AzComputeFleet -Name $managedFleetName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize1) `
            -SpotPriorityProfileCapacity 2 `
            -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
            -SpotPriorityProfileEvictionPolicy "Delete" `
            -RegularPriorityProfileCapacity 2 `
            -RegularPriorityProfileMinCapacity 1 `
            -RegularPriorityProfileAllocationStrategy "LowestPrice" `
            -Tag @{ environment = "test" }

        # Wait for VMSS resources to be provisioned
        if ($TestMode -ne 'playback') {
            Start-Sleep -Seconds 60
        }
    }

    It 'List' {
        {
            $vmssList = Get-AzComputeFleetVirtualMachineScaleSet -Name $managedFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            $vmssList.Count | Should -BeGreaterOrEqual 2
        } | Should -Not -Throw
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
        }
    }
}
