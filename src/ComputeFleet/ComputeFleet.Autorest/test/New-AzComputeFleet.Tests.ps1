if(($null -eq $TestName) -or ($TestName -contains 'New-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzComputeFleet' {

    BeforeAll {
        $resourceGroupName = "fleet-create-test-rg"
        $vnetName = "vnet"
        $nsgName = "nsg"
        $vmNamePrefix = "fleetvm"
        $launchFleetName = "launch-fleet"
        $launchFleetJsonName = "launch-fleet-json"
        $launchFleetJsonStrName = "launch-fleet-jsonstr"
        $managedFleetName = "managed-fleet"
        $managedFleetJsonName = "managed-fleet-json"
        $managedFleetJsonStrName = "managed-fleet-jsonstr"

        $result = New-TestResourceGroup -ResourceGroupName $resourceGroupName `
            -Location $env.Location -VNetName $vnetName -NsgName $nsgName
        $subnetId = $result.SubnetId
        $nsgId = $result.NsgId
    }

    It 'CreateLaunchModeFleet' {
        {
            $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId

            $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize1.Name = "Standard_D2s_v3"
            $vmSize2 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize2.Name = "Standard_D4s_v3"

            $fleet = New-AzComputeFleet -Name $launchFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize1, $vmSize2) `
                -RegularPriorityProfileCapacity 2 `
                -RegularPriorityProfileMinCapacity 1 `
                -RegularPriorityProfileAllocationStrategy "LowestPrice" `
                -Mode "Launch" `
                -VMNamePrefix $vmNamePrefix `
                -Tag @{ environment = "test" }

            $fleet.Name | Should -Be $launchFleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"
        } | Should -Not -Throw
    }

    It 'CreateLaunchModeFleetViaJsonFilePath' {
        {
            $jsonBody = @{
                location   = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = Get-BaseVmProfileJson -SubnetId $subnetId -NsgId $nsgId
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                        @{ name = "Standard_D4s_v3" }
                    )
                    regularPriorityProfile = @{
                        capacity           = 2
                        minCapacity        = 1
                        allocationStrategy = "LowestPrice"
                    }
                    mode         = "Launch"
                    vmNamePrefix = $vmNamePrefix
                }
                tags = @{ environment = "test" }
            }

            $jsonFilePath = Join-Path $PSScriptRoot "launch-fleet.json"
            $jsonBody | ConvertTo-Json -Depth 15 | Set-Content -Path $jsonFilePath

            $fleet = New-AzComputeFleet -Name $launchFleetJsonName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonFilePath

            $fleet.Name | Should -Be $launchFleetJsonName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"

            Remove-Item -Path $jsonFilePath -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'CreateLaunchModeFleetViaJsonString' {
        {
            $jsonBody = @{
                location   = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = Get-BaseVmProfileJson -SubnetId $subnetId -NsgId $nsgId
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                        @{ name = "Standard_D4s_v3" }
                    )
                    regularPriorityProfile = @{
                        capacity           = 2
                        minCapacity        = 1
                        allocationStrategy = "LowestPrice"
                    }
                    mode         = "Launch"
                    vmNamePrefix = $vmNamePrefix
                }
                tags = @{ environment = "test" }
            }

            $jsonString = $jsonBody | ConvertTo-Json -Depth 15

            $fleet = New-AzComputeFleet -Name $launchFleetJsonStrName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonString $jsonString

            $fleet.Name | Should -Be $launchFleetJsonStrName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"
        } | Should -Not -Throw
    }

    It 'CreateManagedModeFleet' {
        {
            $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId

            $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize1.Name = "Standard_D2s_v3"

            $fleet = New-AzComputeFleet -Name $managedFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize1) `
                -SpotPriorityProfileCapacity 2 `
                -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
                -SpotPriorityProfileEvictionPolicy "Delete" `
                -Tag @{ environment = "test" }

            $fleet.Name | Should -Be $managedFleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }

    It 'CreateManagedModeFleetViaJsonFilePath' {
        {
            $jsonBody = @{
                location   = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = Get-BaseVmProfileJson -SubnetId $subnetId -NsgId $nsgId
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                    )
                    spotPriorityProfile = @{
                        capacity           = 2
                        allocationStrategy = "PriceCapacityOptimized"
                        evictionPolicy     = "Delete"
                    }
                }
                tags = @{ environment = "test" }
            }

            $jsonFilePath = Join-Path $PSScriptRoot "managed-fleet.json"
            $jsonBody | ConvertTo-Json -Depth 15 | Set-Content -Path $jsonFilePath

            $fleet = New-AzComputeFleet -Name $managedFleetJsonName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonFilePath

            $fleet.Name | Should -Be $managedFleetJsonName
            $fleet.ProvisioningState | Should -Be "Succeeded"

            Remove-Item -Path $jsonFilePath -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'CreateManagedModeFleetViaJsonString' {
        {
            $jsonBody = @{
                location   = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = Get-BaseVmProfileJson -SubnetId $subnetId -NsgId $nsgId
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                    )
                    spotPriorityProfile = @{
                        capacity           = 2
                        allocationStrategy = "PriceCapacityOptimized"
                        evictionPolicy     = "Delete"
                    }
                }
                tags = @{ environment = "test" }
            }

            $jsonString = $jsonBody | ConvertTo-Json -Depth 15

            $fleet = New-AzComputeFleet -Name $managedFleetJsonStrName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonString $jsonString

            $fleet.Name | Should -Be $managedFleetJsonStrName
            $fleet.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }

    AfterAll {
        Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
    }
}