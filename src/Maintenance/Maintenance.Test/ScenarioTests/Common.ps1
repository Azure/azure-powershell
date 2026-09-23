# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Gets maintenance configuration name
#>
function Get-RandomMaintenanceConfigurationName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets virtual machine name
#>
function Get-RandomVirtualMachineName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets dedicated host name
#>
function Get-RandomDedicatedHostGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets dedicated host name
#>
function Get-RandomDedicatedHostName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets resource group name
#>
function Get-RandomResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $namespace = $provider.Split("/")[0]
        if($provider.Contains("/"))
        {
            $type = $provider.Substring($namespace.Length + 1)
            $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

            if ($location -eq $null)
            {
                return "eastus2euap"
            } else
            {
                return $location.Locations[0].ToLower() -replace '\s',''
            }
        }

        return "eastus2euap"
    }

    return "eastus2euap"
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Creates a new virtual machine
#>
function New-VirtualMachine(
    [string] $virtualMachineName,
    [string] $resourceGroupName,
    [string] $location)
{
    $vmLocalAdminUser = "LocalAdminUser"
    $vmLocalAdminSecurePassword = ConvertTo-SecureString -String ([guid]::NewGuid()) -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential($vmLocalAdminUser, $vmLocalAdminSecurePassword)
    $patchMode = "AutomaticByPlatform"
    $patchSettings = New-Object `
        -TypeName Microsoft.Azure.Management.Compute.Models.WindowsVMGuestPatchAutomaticByPlatformSettings `
        -Property @{BypassPlatformSafetyChecksOnUserSchedule = $true}
    $sku = "Standard_D2s_v3"
    $computerName = $virtualMachineName
    $networkName = "Net$virtualMachineName"
    $nicName = "Nic$virtualMachineName"
    $nsgName = "Nsg$virtualMachineName"
    $subnetName = "Subnet$virtualMachineName"
    $subnetAddressPrefix = "10.0.0.0/24"
    $vnetAddressPrefix = "10.0.0.0/16"
    $securityType = "TrustedLaunch"
    $imagePublisher = "MicrosoftWindowsServer"
    $imageOffer = "WindowsServer"
    $imageSku = "2022-datacenter-azure-edition"
    $imageVersion = "latest"

    $nsg = New-AzNetworkSecurityGroup `
        -Name $nsgName `
        -ResourceGroupName $resourceGroupName `
        -Location $location

    $subnetConfig = New-AzVirtualNetworkSubnetConfig `
        -Name $subnetName `
        -AddressPrefix $subnetAddressPrefix `
        -NetworkSecurityGroupId $nsg.Id
    
    if ($subnetConfig.PSObject.Properties.Match('DefaultOutboundAccess').Count -gt 0) { $subnetConfig.DefaultOutboundAccess = $false }
    
    $vnet = New-AzVirtualNetwork `
        -Name $networkName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -AddressPrefix $vnetAddressPrefix `
        -Subnet $subnetConfig

    $nic = New-AzNetworkInterface `
        -Name $nicName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -SubnetId $vnet.Subnets[0].Id

    $vmConfig = New-AzVMConfig `
        -VMName $virtualMachineName `
        -VMSize $sku `
        -SecurityType $securityType
    Set-AzVMOperatingSystem `
        -VM $vmConfig `
        -Windows `
        -ComputerName $computerName `
        -Credential $credential `
        -ProvisionVMAgent `
        -EnableAutoUpdate `
        -PatchMode $patchMode `
        | Out-Null
    Set-AzVMSourceImage `
        -VM $vmConfig `
        -PublisherName $imagePublisher `
        -Offer $imageOffer `
        -Skus $imageSku `
        -Version $imageVersion `
        | Out-Null

    Set-AzVMBootDiagnostic -VM $vmConfig -Disable | Out-Null
    Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id | Out-Null

    New-AzVM -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig | Out-Null
    $virtualMachine = Get-AzVM -ResourceGroupName $resourceGroupName -Name $virtualMachineName
    $virtualMachine.OSProfile.WindowsConfiguration.PatchSettings.AutomaticByPlatformSettings = $patchSettings
    Update-AzVM -VM $virtualMachine -ResourceGroupName $ResourceGroupName | Out-Null

    return $virtualMachine.Id
}

function Wait-VirtualMachineScaleSetReady(
    [string] $virtualMachineScaleSetName,
    [string] $resourceGroupName,
    [switch] $RequireScheduledEventsPolicy)
{
    $maxAttempts = 60
    for ($attempt = 1; $attempt -le $maxAttempts; $attempt++)
    {
        $vmss = Get-AzVmss `
            -ResourceGroupName $resourceGroupName `
            -VMScaleSetName $virtualMachineScaleSetName `
            -ErrorAction Stop
        $instances = @(Get-AzVmssVM `
            -ResourceGroupName $resourceGroupName `
            -VMScaleSetName $virtualMachineScaleSetName `
            -ErrorAction Stop)
        $unreadyInstances = @($instances | Where-Object { $_.ProvisioningState -ne "Succeeded" })
        $scheduledEventsPolicyReady = -not $RequireScheduledEventsPolicy
        if ($RequireScheduledEventsPolicy)
        {
            # Update ScheduledEventsPolicy
            $vmssRestResponse = Invoke-AzRestMethod `
                -Path ("{0}?api-version={1}" -f $vmss.Id, "2025-11-01") `
                -Method GET `
                -ErrorAction Stop
            $vmssRestModel = $vmssRestResponse.Content | ConvertFrom-Json
            $scheduledEventsPolicyReady =
                $vmssRestResponse.StatusCode -ge 200 -and
                $vmssRestResponse.StatusCode -lt 300 -and
                $vmssRestModel.properties.scheduledEventsPolicy.scheduledEventsAdditionalPublishingTargets.eventGridAndResourceGraph.enable -eq $true -and
                $vmssRestModel.properties.scheduledEventsPolicy.scheduledEventsAdditionalPublishingTargets.eventGridAndResourceGraph.scheduledEventsApiVersion -eq "2020-07-01"
        }

        if ($vmss.ProvisioningState -eq "Succeeded" -and
            $instances.Count -eq $vmss.Sku.Capacity -and
            $unreadyInstances.Count -eq 0 -and
            $scheduledEventsPolicyReady)
        {
            Write-Warning "VMSS '$virtualMachineScaleSetName' and all $($instances.Count) instances are ready."
            return $vmss
        }

        if ($attempt -lt $maxAttempts)
        {
            Write-Warning "Waiting for VMSS '$virtualMachineScaleSetName'. VMSS state: '$($vmss.ProvisioningState)'; ready instances: '$($instances.Count - $unreadyInstances.Count)/$($vmss.Sku.Capacity)'; Scheduled Events policy ready: '$scheduledEventsPolicyReady'."
            Start-TestSleep -Seconds 10
        }
    }

    throw "VMSS '$virtualMachineScaleSetName', one of its instances, or its Scheduled Events policy did not become ready."
}

function New-VirtualMachineScaleSet(
    [string] $virtualMachineScaleSetName,
    [string] $resourceGroupName,
    [string] $location)
{
    $vmLocalAdminUser = "LocalAdminUser"
    $vmLocalAdminPassword = [guid]::NewGuid().ToString()
    $vmLocalAdminSecurePassword = ConvertTo-SecureString -String $vmLocalAdminPassword -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential($vmLocalAdminUser, $vmLocalAdminSecurePassword)
    $sku = "Standard_D2s_v3"
    $securityType = "TrustedLaunch"
    $computerNamePrefix = $virtualMachineScaleSetName
    $networkName = "Net$virtualMachineScaleSetName"
    $networkInterfaceName = "Nic$virtualMachineScaleSetName"
    $ipConfigName = "IpConfig$virtualMachineScaleSetName"
    $nsgName = "Nsg$virtualMachineScaleSetName"
    $subnetName = "Subnet$virtualMachineScaleSetName"
    $subnetAddressPrefix = "10.0.0.0/24"
    $vnetAddressPrefix = "10.0.0.0/16"
    $sharedGalleryImageId = "/sharedGalleries/WINDOWSSERVER.1P/images/2022-DATACENTER-AZURE-EDITION/versions/latest"

    $nsg = New-AzNetworkSecurityGroup `
        -Name $nsgName `
        -ResourceGroupName $resourceGroupName `
        -Location $location

    $subnetConfig = New-AzVirtualNetworkSubnetConfig `
        -Name $subnetName `
        -AddressPrefix $subnetAddressPrefix
    $subnetConfig.DefaultOutboundAccess = $false

    $vnet = New-AzVirtualNetwork `
        -Name $networkName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -AddressPrefix $vnetAddressPrefix `
        -Subnet $subnetConfig

    $vnet = Get-AzVirtualNetwork -Name $networkName -ResourceGroupName $resourceGroupName
    $subnet = $vnet.Subnets | Where-Object { $_.Name -eq $subnetName }
    $subnet.NetworkSecurityGroup = $nsg
    $null = Set-AzVirtualNetwork -VirtualNetwork $vnet

    $ipConfig = New-AzVmssIpConfig `
        -Name $ipConfigName `
        -SubnetId $vnet.Subnets[0].Id `
        -Primary
    $ipConfig.PublicIPAddressConfiguration = $null

    $vmssConfig = New-AzVmssConfig `
        -Location $location `
        -SkuCapacity 3 `
        -SkuName $sku `
        -UpgradePolicyMode "Automatic" `
        -OrchestrationMode "Uniform" `
        -SinglePlacementGroup $true `
        -Overprovision $false `
        -PlatformFaultDomainCount 1 `
        -SecurityType $securityType `
        -AutoOSUpgrade

    # Set SystemAssigned identity (required for scheduled events publishing)
    $vmssConfig.Identity = New-Object Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetIdentity
    $vmssConfig.Identity.Type = [Microsoft.Azure.Management.Compute.Models.ResourceIdentityType]::SystemAssigned

    Set-AzVmssStorageProfile `
        -VirtualMachineScaleSet $vmssConfig `
        -OsDiskCreateOption "FromImage" `
        -SharedGalleryImageId $sharedGalleryImageId `
        | Out-Null

    Set-AzVmssUefi `
        -VirtualMachineScaleSet $vmssConfig `
        -EnableVtpm $true `
        -EnableSecureBoot $true `
        | Out-Null

    Set-AzVmssOsProfile `
        -VirtualMachineScaleSet $vmssConfig `
        -ComputerNamePrefix $computerNamePrefix `
        -AdminUsername $credential.UserName `
        -AdminPassword $vmLocalAdminPassword `
        -WindowsConfigurationProvisionVMAgent $true `
        | Out-Null

    Add-AzVmssNetworkInterfaceConfiguration `
        -VirtualMachineScaleSet $vmssConfig `
        -Name $networkInterfaceName `
        -Primary $true `
        -IPConfiguration $ipConfig `
        | Out-Null

    $healthExtensionPublicConfig = @{ "protocol" = "tcp"; "port" = 3389 }
    Add-AzVmssExtension `
        -VirtualMachineScaleSet $vmssConfig `
        -Name "ApplicationHealthExtension" `
        -Publisher "Microsoft.ManagedServices" `
        -Type "ApplicationHealthWindows" `
        -TypeHandlerVersion "1.0" `
        -AutoUpgradeMinorVersion $true `
        -Setting $healthExtensionPublicConfig `
        | Out-Null

    $vmss = New-AzVmss `
        -ResourceGroupName $resourceGroupName `
        -VMScaleSetName $virtualMachineScaleSetName `
        -VirtualMachineScaleSet $vmssConfig `
        -ErrorAction Stop

    if ($vmss.ProvisioningState -ne "Succeeded")
    {
        throw "VMSS '$virtualMachineScaleSetName' creation did not complete successfully. Provisioning state: '$($vmss.ProvisioningState)'."
    }
    
    try
    {
        $scheduledEventsPolicyPayload = @{
            properties = @{
                scheduledEventsPolicy = @{
                    scheduledEventsAdditionalPublishingTargets = @{
                        eventGridAndResourceGraph = @{
                            enable = $true
                            scheduledEventsApiVersion = "2020-07-01"
                        }
                    }
                    allInstancesDown = @{
                        automaticallyApprove = $false
                    }
                }
            }
        } | ConvertTo-Json -Depth 20 -Compress

        $vmssPatchPath = "{0}?api-version={1}" -f $vmss.Id, "2025-11-01"
        $patchResponse = Invoke-AzRestMethod `
            -Path $vmssPatchPath `
            -Method PATCH `
            -Payload $scheduledEventsPolicyPayload `
            -ErrorAction Stop
        if ($patchResponse.StatusCode -lt 200 -or $patchResponse.StatusCode -ge 300)
        {
            throw "VMSS Scheduled Events policy PATCH failed with HTTP status '$($patchResponse.StatusCode)'."
        }
        $null = Wait-VirtualMachineScaleSetReady `
            $virtualMachineScaleSetName `
            $resourceGroupName `
            -RequireScheduledEventsPolicy
    }
    catch
    {
        $patchErrorPayload = ($_.ErrorDetails.Message + "`n" + $_.Exception.Message + "`n" + ($_ | Out-String))
        if ($patchErrorPayload -match "Virtual Machine Scale Set does not support Scheduled Events Policy")
        {
            throw "VMSS '$virtualMachineScaleSetName' does not support Scheduled Events policy; restart will not be attempted."
        }
        else
        {
            Write-Warning "[ERROR][Common.ps1] VMSS PATCH failed unexpectedly: $($_.Exception.Message)"
            Write-Warning "[ERROR][Common.ps1] Full error: $($_ | Out-String)"
            throw
        }
    }

    return $vmss.Id
}

<#
.SYNOPSIS
Creates a new dedicated host
#>
function New-DedicatedHost(
    [string] $dedicatedHostName,
    [string] $dedicatedHostGroupName,
    [string] $resourceGroupName,
    [string] $location)
{
    $sku = "Dsv3-Type3"
    $platformFaultDomain = 1

    $dedicatedHostGroup = New-AzHostGroup `
        -Name $dedicatedHostGroupName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -PlatformFaultDomain $platformFaultDomain

    $dedicatedHost = New-AzHost `
        -HostGroupName $dedicatedHostGroup.Name `
        -Location $location `
        -Name $dedicatedHostName `
        -ResourceGroupName $resourceGroupName `
        -Sku $sku

    return $dedicatedHost.Id
}