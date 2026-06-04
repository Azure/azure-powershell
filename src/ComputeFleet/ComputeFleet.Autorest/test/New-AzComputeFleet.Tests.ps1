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
    It 'CreateLaunchModeFleet' {
        {
            # Build storage profile with managed disk
            $storageProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile]::new()
            $storageProfile.ImageReferencePublisher = "MicrosoftWindowsServer"
            $storageProfile.ImageReferenceOffer = "WindowsServer"
            $storageProfile.ImageReferenceSku = "2022-datacenter-azure-edition"
            $storageProfile.ImageReferenceVersion = "latest"
            $storageProfile.OSDiskCreateOption = "FromImage"
            $storageProfile.OSDiskCaching = "ReadWrite"
            $storageProfile.OSDiskOstype = "Windows"
            $storageProfile.ManagedDiskStorageAccountType = "Standard_LRS"

            # Build OS profile
            $osProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile]::new()
            $osProfile.AdminUsername = "testadmin"
            $osProfile.ComputerNamePrefix = $env.VmNamePrefix
            $osProfile.AdminPassword = ConvertTo-SecureString "TestP@ss1234!" -AsPlainText -Force

            # Build network profile
            $ipConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration]::new()
            $ipConfig.Name = "ipconfig1"
            $ipConfig.Primary = $true
            $ipConfig.SubnetId = $env.SubnetId

            $nicConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration]::new()
            $nicConfig.Name = "nic1"
            $nicConfig.Primary = $true
            $nicConfig.EnableAcceleratedNetworking = $false
            $nicConfig.NetworkSecurityGroupId = $env.NsgId
            $nicConfig.IPConfiguration = @($ipConfig)

            # Build VM profile
            $vmProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile]::new()
            $vmProfile.StorageProfile = $storageProfile
            $vmProfile.OSProfile = $osProfile
            $vmProfile.NetworkProfileNetworkApiVersion = "2020-11-01"
            $vmProfile.NetworkProfileNetworkInterfaceConfiguration = @($nicConfig)
            $vmProfile.SecurityProfileSecurityType = "TrustedLaunch"
            $vmProfile.UefiSettingSecureBootEnabled = $true
            $vmProfile.UefiSettingVTpmEnabled = $true

            # Build VM size profiles
            $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize1.Name = "Standard_D2s_v3"
            $vmSize2 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize2.Name = "Standard_D4s_v3"

            # Create the fleet in Launch mode
            $fleet = New-AzComputeFleet -Name $env.LaunchFleetName `
                -ResourceGroupName $env.ResourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize1, $vmSize2) `
                -RegularPriorityProfileCapacity 2 `
                -RegularPriorityProfileMinCapacity 1 `
                -RegularPriorityProfileAllocationStrategy "LowestPrice" `
                -Mode "Launch" `
                -VMNamePrefix $env.VmNamePrefix `
                -Tag @{ environment = "test" }

            $fleet.Name | Should -Be $env.LaunchFleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"
        } | Should -Not -Throw
    }

    It 'CreateLaunchModeFleetViaJsonFilePath' {
        {
            $jsonBody = @{
                location = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = @{
                            storageProfile = @{
                                imageReference = @{
                                    publisher = "MicrosoftWindowsServer"
                                    offer = "WindowsServer"
                                    sku = "2022-datacenter-azure-edition"
                                    version = "latest"
                                }
                                osDisk = @{
                                    createOption = "FromImage"
                                    caching = "ReadWrite"
                                    osType = "Windows"
                                    managedDisk = @{
                                        storageAccountType = "Standard_LRS"
                                    }
                                }
                            }
                            osProfile = @{
                                adminUsername = "testadmin"
                                adminPassword = "TestP@ss1234!"
                                computerNamePrefix = $env.VmNamePrefix
                            }
                            networkProfile = @{
                                networkApiVersion = "2020-11-01"
                                networkInterfaceConfigurations = @(
                                    @{
                                        name = "nic1"
                                        properties = @{
                                            primary = $true
                                            enableAcceleratedNetworking = $false
                                            networkSecurityGroup = @{ id = $env.NsgId }
                                            ipConfigurations = @(
                                                @{
                                                    name = "ipconfig1"
                                                    properties = @{
                                                        primary = $true
                                                        subnet = @{ id = $env.SubnetId }
                                                    }
                                                }
                                            )
                                        }
                                    }
                                )
                            }
                            securityProfile = @{
                                securityType = "TrustedLaunch"
                                uefiSettings = @{
                                    secureBootEnabled = $true
                                    vTpmEnabled = $true
                                }
                            }
                        }
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                        @{ name = "Standard_D4s_v3" }
                    )
                    regularPriorityProfile = @{
                        capacity = 2
                        minCapacity = 1
                        allocationStrategy = "LowestPrice"
                    }
                    mode = "Launch"
                    vmNamePrefix = $env.VmNamePrefix
                }
                tags = @{ environment = "test" }
            }

            $jsonFilePath = Join-Path $PSScriptRoot "launch-fleet.json"
            $jsonBody | ConvertTo-Json -Depth 15 | Set-Content -Path $jsonFilePath

            $fleet = New-AzComputeFleet -Name $env.LaunchFleetJsonName `
                -ResourceGroupName $env.ResourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonFilePath

            $fleet.Name | Should -Be $env.LaunchFleetJsonName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"

            Remove-Item -Path $jsonFilePath -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'CreateLaunchModeFleetViaJsonString' {
        {
            $jsonBody = @{
                location = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = @{
                            storageProfile = @{
                                imageReference = @{
                                    publisher = "MicrosoftWindowsServer"
                                    offer = "WindowsServer"
                                    sku = "2022-datacenter-azure-edition"
                                    version = "latest"
                                }
                                osDisk = @{
                                    createOption = "FromImage"
                                    caching = "ReadWrite"
                                    osType = "Windows"
                                    managedDisk = @{
                                        storageAccountType = "Standard_LRS"
                                    }
                                }
                            }
                            osProfile = @{
                                adminUsername = "testadmin"
                                adminPassword = "TestP@ss1234!"
                                computerNamePrefix = $env.VmNamePrefix
                            }
                            networkProfile = @{
                                networkApiVersion = "2020-11-01"
                                networkInterfaceConfigurations = @(
                                    @{
                                        name = "nic1"
                                        properties = @{
                                            primary = $true
                                            enableAcceleratedNetworking = $false
                                            networkSecurityGroup = @{ id = $env.NsgId }
                                            ipConfigurations = @(
                                                @{
                                                    name = "ipconfig1"
                                                    properties = @{
                                                        primary = $true
                                                        subnet = @{ id = $env.SubnetId }
                                                    }
                                                }
                                            )
                                        }
                                    }
                                )
                            }
                            securityProfile = @{
                                securityType = "TrustedLaunch"
                                uefiSettings = @{
                                    secureBootEnabled = $true
                                    vTpmEnabled = $true
                                }
                            }
                        }
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                        @{ name = "Standard_D4s_v3" }
                    )
                    regularPriorityProfile = @{
                        capacity = 2
                        minCapacity = 1
                        allocationStrategy = "LowestPrice"
                    }
                    mode = "Launch"
                    vmNamePrefix = $env.VmNamePrefix
                }
                tags = @{ environment = "test" }
            }

            $jsonString = $jsonBody | ConvertTo-Json -Depth 15

            $fleet = New-AzComputeFleet -Name $env.LaunchFleetJsonStrName `
                -ResourceGroupName $env.ResourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonString $jsonString

            $fleet.Name | Should -Be $env.LaunchFleetJsonStrName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Launch"
        } | Should -Not -Throw
    }

    It 'CreateManagedModeFleet' -Skip {
        {
            # Build storage profile with managed disk
            $storageProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile]::new()
            $storageProfile.ImageReferencePublisher = "MicrosoftWindowsServer"
            $storageProfile.ImageReferenceOffer = "WindowsServer"
            $storageProfile.ImageReferenceSku = "2022-datacenter-azure-edition"
            $storageProfile.ImageReferenceVersion = "latest"
            $storageProfile.OSDiskCreateOption = "FromImage"
            $storageProfile.OSDiskCaching = "ReadWrite"
            $storageProfile.OSDiskOstype = "Windows"
            $storageProfile.ManagedDiskStorageAccountType = "Standard_LRS"

            # Build OS profile
            $osProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile]::new()
            $osProfile.AdminUsername = "testadmin"
            $osProfile.ComputerNamePrefix = $env.VmNamePrefix
            $osProfile.AdminPassword = ConvertTo-SecureString "TestP@ss1234!" -AsPlainText -Force

            # Build network profile
            $ipConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration]::new()
            $ipConfig.Name = "ipconfig1"
            $ipConfig.Primary = $true
            $ipConfig.SubnetId = $env.SubnetId

            $nicConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration]::new()
            $nicConfig.Name = "nic1"
            $nicConfig.Primary = $true
            $nicConfig.EnableAcceleratedNetworking = $false
            $nicConfig.NetworkSecurityGroupId = $env.NsgId
            $nicConfig.IPConfiguration = @($ipConfig)

            # Build VM profile
            $vmProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile]::new()
            $vmProfile.StorageProfile = $storageProfile
            $vmProfile.OSProfile = $osProfile
            $vmProfile.NetworkProfileNetworkApiVersion = "2020-11-01"
            $vmProfile.NetworkProfileNetworkInterfaceConfiguration = @($nicConfig)
            $vmProfile.SecurityProfileSecurityType = "TrustedLaunch"
            $vmProfile.UefiSettingSecureBootEnabled = $true
            $vmProfile.UefiSettingVTpmEnabled = $true

            # Build VM size profiles
            $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
            $vmSize1.Name = "Standard_D2s_v3"

            # Create the fleet in Managed mode (default)
            $fleet = New-AzComputeFleet -Name $env.ManagedFleetName `
                -ResourceGroupName $env.ResourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ComputeProfileBaseVirtualMachineProfile $vmProfile `
                -ComputeProfileComputeApiVersion "2024-03-01" `
                -VMSizesProfile @($vmSize1) `
                -SpotPriorityProfileCapacity 2 `
                -SpotPriorityProfileAllocationStrategy "PriceCapacityOptimized" `
                -SpotPriorityProfileEvictionPolicy "Delete" `
                -Tag @{ environment = "test" }

            $fleet.Name | Should -Be $env.ManagedFleetName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Managed"
        } | Should -Not -Throw
    }

    It 'CreateManagedModeFleetViaJsonFilePath' {
        {
            $jsonBody = @{
                location = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = @{
                            storageProfile = @{
                                imageReference = @{
                                    publisher = "MicrosoftWindowsServer"
                                    offer = "WindowsServer"
                                    sku = "2022-datacenter-azure-edition"
                                    version = "latest"
                                }
                                osDisk = @{
                                    createOption = "FromImage"
                                    caching = "ReadWrite"
                                    osType = "Windows"
                                    managedDisk = @{
                                        storageAccountType = "Standard_LRS"
                                    }
                                }
                            }
                            osProfile = @{
                                adminUsername = "testadmin"
                                adminPassword = "TestP@ss1234!"
                                computerNamePrefix = $env.VmNamePrefix
                            }
                            networkProfile = @{
                                networkApiVersion = "2020-11-01"
                                networkInterfaceConfigurations = @(
                                    @{
                                        name = "nic1"
                                        properties = @{
                                            primary = $true
                                            enableAcceleratedNetworking = $false
                                            networkSecurityGroup = @{ id = $env.NsgId }
                                            ipConfigurations = @(
                                                @{
                                                    name = "ipconfig1"
                                                    properties = @{
                                                        primary = $true
                                                        subnet = @{ id = $env.SubnetId }
                                                    }
                                                }
                                            )
                                        }
                                    }
                                )
                            }
                            securityProfile = @{
                                securityType = "TrustedLaunch"
                                uefiSettings = @{
                                    secureBootEnabled = $true
                                    vTpmEnabled = $true
                                }
                            }
                        }
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                    )
                    spotPriorityProfile = @{
                        capacity = 2
                        allocationStrategy = "PriceCapacityOptimized"
                        evictionPolicy = "Delete"
                    }
                }
                tags = @{ environment = "test" }
            }

            $jsonFilePath = Join-Path $PSScriptRoot "managed-fleet.json"
            $jsonBody | ConvertTo-Json -Depth 15 | Set-Content -Path $jsonFilePath

            $fleet = New-AzComputeFleet -Name $env.ManagedFleetJsonName `
                -ResourceGroupName $env.ResourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonFilePath

            $fleet.Name | Should -Be $env.ManagedFleetJsonName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Managed"

            Remove-Item -Path $jsonFilePath -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'CreateManagedModeFleetViaJsonString' {
        {
            $jsonBody = @{
                location = $env.Location
                properties = @{
                    computeProfile = @{
                        baseVirtualMachineProfile = @{
                            storageProfile = @{
                                imageReference = @{
                                    publisher = "MicrosoftWindowsServer"
                                    offer = "WindowsServer"
                                    sku = "2022-datacenter-azure-edition"
                                    version = "latest"
                                }
                                osDisk = @{
                                    createOption = "FromImage"
                                    caching = "ReadWrite"
                                    osType = "Windows"
                                    managedDisk = @{
                                        storageAccountType = "Standard_LRS"
                                    }
                                }
                            }
                            osProfile = @{
                                adminUsername = "testadmin"
                                adminPassword = "TestP@ss1234!"
                                computerNamePrefix = $env.VmNamePrefix
                            }
                            networkProfile = @{
                                networkApiVersion = "2020-11-01"
                                networkInterfaceConfigurations = @(
                                    @{
                                        name = "nic1"
                                        properties = @{
                                            primary = $true
                                            enableAcceleratedNetworking = $false
                                            networkSecurityGroup = @{ id = $env.NsgId }
                                            ipConfigurations = @(
                                                @{
                                                    name = "ipconfig1"
                                                    properties = @{
                                                        primary = $true
                                                        subnet = @{ id = $env.SubnetId }
                                                    }
                                                }
                                            )
                                        }
                                    }
                                )
                            }
                            securityProfile = @{
                                securityType = "TrustedLaunch"
                                uefiSettings = @{
                                    secureBootEnabled = $true
                                    vTpmEnabled = $true
                                }
                            }
                        }
                        computeApiVersion = "2024-03-01"
                    }
                    vmSizesProfile = @(
                        @{ name = "Standard_D2s_v3" }
                    )
                    spotPriorityProfile = @{
                        capacity = 2
                        allocationStrategy = "PriceCapacityOptimized"
                        evictionPolicy = "Delete"
                    }
                }
                tags = @{ environment = "test" }
            }

            $jsonString = $jsonBody | ConvertTo-Json -Depth 15

            $fleet = New-AzComputeFleet -Name $env.ManagedFleetJsonStrName `
                -ResourceGroupName $env.ResourceGroupName `
                -SubscriptionId $env.SubscriptionId `
                -JsonString $jsonString

            $fleet.Name | Should -Be $env.ManagedFleetJsonStrName
            $fleet.ProvisioningState | Should -Be "Succeeded"
            $fleet.Mode | Should -Be "Managed"
        } | Should -Not -Throw
    }
}
