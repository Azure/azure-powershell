# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0.

<#
.SYNOPSIS
Tests fixed/preferred VM config binding, pipeline input, CPU options and size conflicts.
#>
function Test-FlexProfileConfigBinding
{
    # Step 1: Preserve positional fixed-size configuration.
    $size = 'Standard_D2s_v5'
    $fixed = New-AzVMConfig 'fixed-vm' $size
    Assert-AreEqual $size $fixed.HardwareProfile.VmSize
    Assert-Null $fixed.FlexProfile

    # Step 2: Bind preferred size by name and pipeline in both identity parameter sets.
    $preferred = New-AzVMConfig -VMName 'preferred-vm' -PreferredVMSize $size
    Assert-AreEqual $size $preferred.FlexProfile.PreferredVMSize
    Assert-Null $preferred.HardwareProfile.VmSize

    $pipeline = [PSCustomObject]@{ VMName = 'pipeline-vm'; PreferredVMSize = $size } | New-AzVMConfig
    Assert-AreEqual 'pipeline-vm' $pipeline.Name
    Assert-AreEqual $size $pipeline.FlexProfile.PreferredVMSize
    Assert-Null $pipeline.HardwareProfile.VmSize

    $aliasPipeline = [PSCustomObject]@{ Name = 'pipeline-alias'; PreferredVMSize = $size } | New-AzVMConfig
    Assert-AreEqual 'pipeline-alias' $aliasPipeline.Name
    Assert-AreEqual $size $aliasPipeline.FlexProfile.PreferredVMSize

    $fixedPipeline = [PSCustomObject]@{ VMName = 'pipeline-fixed'; VMSize = $size } | New-AzVMConfig
    Assert-AreEqual $size $fixedPipeline.HardwareProfile.VmSize
    Assert-Null $fixedPipeline.FlexProfile

    $identity = New-AzVMConfig -VMName 'identity-vm' -PreferredVMSize $size -IdentityType SystemAssigned
    Assert-AreEqual $size $identity.FlexProfile.PreferredVMSize
    Assert-AreEqual 'SystemAssigned' $identity.Identity.Type
    $identityPipeline = [PSCustomObject]@{ VMName = 'identity-pipeline'; PreferredVMSize = $size } |
        New-AzVMConfig -IdentityType SystemAssigned
    Assert-AreEqual $size $identityPipeline.FlexProfile.PreferredVMSize
    Assert-AreEqual 'SystemAssigned' $identityPipeline.Identity.Type

    # Step 3: Preserve CPU customizations without setting a fixed size.
    foreach ($mode in @('Deterministic', 'Opportunistic'))
    {
        $cpu = New-AzVMConfig -VMName 'cpu-vm' -PreferredVMSize $size `
            -vCPUCountAvailable 2 -vCPUCountPerCore 1 -ProcessorMode $mode
        Assert-AreEqual $size $cpu.FlexProfile.PreferredVMSize
        Assert-Null $cpu.HardwareProfile.VmSize
        Assert-AreEqual 2 $cpu.HardwareProfile.VmSizeProperties.VCPUsAvailable
        Assert-AreEqual 1 $cpu.HardwareProfile.VmSizeProperties.VCPUsPerCore
        Assert-AreEqual $mode $cpu.HardwareProfile.ProcessorMode
    }

    # Step 4: Reject conflicting or missing sizes before allocating resources.
    Assert-ThrowsContains { New-AzVMConfig -VMName 'both' -VMSize $size -PreferredVMSize $size } 'PreferredVMSize'
    Assert-ThrowsContains { New-AzVMConfig -VMName 'both-empty' -VMSize $size -PreferredVMSize '' } 'PreferredVMSize'
    Assert-ThrowsContains { New-AzVMConfig -VMName 'neither' } 'PreferredVMSize'
    Assert-ThrowsContains { New-AzVMConfig -VMName 'identity-neither' -IdentityType SystemAssigned } 'PreferredVMSize'
    Assert-ThrowsContains {
        [PSCustomObject]@{ VMName = 'pipeline-both'; VMSize = $size; PreferredVMSize = $size } | New-AzVMConfig
    } 'PreferredVMSize'
    Assert-ThrowsContains {
        New-AzVMConfig -VMName 'identity-both' -IdentityType SystemAssigned -VMSize $size -PreferredVMSize $size
    } 'PreferredVMSize'
    $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ('admin01', $password)
    Assert-ThrowsContains {
        New-AzVM -Name 'both' -Size $size -PreferredVMSize $size -Credential $cred -ErrorAction Stop
    } 'PreferredVMSize'

    # Step 5: Empty is bound and reaches service RequiredParameterMissing validation.
    $empty = New-AzVMConfig -VMName 'empty' -PreferredVMSize ''
    Assert-NotNull $empty.FlexProfile
    Assert-AreEqual '' $empty.FlexProfile.PreferredVMSize
    Assert-Null $empty.HardwareProfile.VmSize
}

<#
.SYNOPSIS
Creates the network prerequisites shared by FlexProfile config-based scenarios.
#>
function New-FlexProfileTestNetwork
{
    param([string] $ResourceGroupName, [string] $Location)

    $subnet = New-AzVirtualNetworkSubnetConfig -Name 'default' -AddressPrefix '10.0.0.0/24'
    $vnet = New-AzVirtualNetwork -Name 'flex-vnet' -ResourceGroupName $ResourceGroupName `
        -Location $Location -AddressPrefix '10.0.0.0/16' -Subnet $subnet
    New-AzNetworkInterface -Name 'flex-nic' -ResourceGroupName $ResourceGroupName `
        -Location $Location -SubnetId $vnet.Subnets[0].Id
}

<#
.SYNOPSIS
Builds a complete Windows VM config using a real NIC and explicit image reference.
#>
function New-FlexProfileTestConfig
{
    param([hashtable] $Parameters, [string] $NicId, [System.Management.Automation.PSCredential] $Credential)

    $vm = New-AzVMConfig @Parameters -SecurityType Standard
    $vm = Set-AzVMOperatingSystem -VM $vm -Windows -ComputerName 'flexvm' -Credential $Credential
    $vm = Set-AzVMSourceImage -VM $vm -PublisherName 'MicrosoftWindowsServer' `
        -Offer 'WindowsServer' -Skus '2022-datacenter-azure-edition' -Version 'latest'
    $vm = Add-AzVMNetworkInterface -VM $vm -Id $NicId
    Set-AzVMOSDisk -VM $vm -CreateOption FromImage -StorageAccountType Standard_LRS
}

<#
.SYNOPSIS
Checks preferred size and actual deployed size without assuming they are identical.
#>
function Assert-FlexProfileRoundTrip
{
    param([object] $VM, [string] $PreferredSize)

    Assert-AreEqual $PreferredSize $VM.FlexProfile.PreferredVMSize
    # Capacity can select a compatible alternative: never assert actual == preferred.
    Assert-NotNull $VM.HardwareProfile.VmSize
}

<#
.SYNOPSIS
Records simple/config creation, conversion, preferred resize, tag/NoWait preservation and opt-out.
.DESCRIPTION
Requires FlexProfile support and Dsv5 quota in the selected Compute test region.
#>
function Test-FlexProfileLifecycle
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation
    $size = 'Standard_D2s_v5'
    $nextSize = 'Standard_D4s_v5'
    $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ('admin01', $password)
    try
    {
        # Step 1: Create preferred-size VMs using the simple and config paths.
        New-AzResourceGroup -Name $rgname -Location $loc -Force
        $simpleName = 'flexsimple'
        $simple = New-AzVM -ResourceGroupName $rgname -Location $loc -Name $simpleName `
            -PreferredVMSize $size -Credential $cred -Image Win2022AzureEditionCore -SecurityType Standard
        Assert-FlexProfileRoundTrip -VM $simple -PreferredSize $size
        Assert-FlexProfileRoundTrip -VM (Get-AzVM -ResourceGroupName $rgname -Name $simpleName) -PreferredSize $size
        $listed = Get-AzVM -ResourceGroupName $rgname | Where-Object { $_.Name -eq $simpleName }
        Assert-FlexProfileRoundTrip -VM $listed -PreferredSize $size

        $nic = New-FlexProfileTestNetwork -ResourceGroupName $rgname -Location $loc
        $name = 'config' + $rgname
        $config = New-FlexProfileTestConfig -Parameters @{ VMName = $name; PreferredVMSize = $size } `
            -NicId $nic.Id -Credential $cred
        $config | New-AzVM -ResourceGroupName $rgname -Location $loc
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $name
        Assert-FlexProfileRoundTrip -VM $vm -PreferredSize $size

        # Step 2: Preserve FlexProfile on synchronous and asynchronous tag-only updates.
        $vm | Update-AzVM -ResourceGroupName $rgname -Tag @{ purpose = 'flex-profile' }
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $name
        Assert-FlexProfileRoundTrip -VM $vm -PreferredSize $size
        Assert-AreEqual 'flex-profile' $vm.Tags['purpose']
        $vm | Update-AzVM -ResourceGroupName $rgname -Tag @{ purpose = 'no-wait' } -NoWait
        for ($attempt = 0; $attempt -lt 60; $attempt++)
        {
            $vm = Get-AzVM -ResourceGroupName $rgname -Name $name
            if ($vm.ProvisioningState -eq 'Failed') { break }
            if ($vm.ProvisioningState -eq 'Succeeded' -and $vm.Tags['purpose'] -eq 'no-wait') { break }
            Start-Sleep -Seconds 5
        }
        Assert-AreEqual 'Succeeded' $vm.ProvisioningState
        Assert-FlexProfileRoundTrip -VM $vm -PreferredSize $size
        Assert-AreEqual 'no-wait' $vm.Tags['purpose']

        # Step 3: Resize through PreferredVMSize without mutating the supplied VM.
        Stop-AzVM -ResourceGroupName $rgname -Name $name -Force
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $name
        $actualSize = $vm.HardwareProfile.VmSize
        Update-AzVM -ResourceGroupName $rgname -VM $vm -PreferredVMSize $nextSize
        Assert-AreEqual $actualSize $vm.HardwareProfile.VmSize
        Assert-AreEqual $size $vm.FlexProfile.PreferredVMSize
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $name
        Assert-FlexProfileRoundTrip -VM $vm -PreferredSize $nextSize

        # Step 4: Forward invalid size, empty preferred size and conflicting fixed-size errors.
        Assert-ThrowsLike {
            Update-AzVM -ResourceGroupName $rgname -VM $vm -PreferredVMSize 'Not_A_Real_VM_Size'
        } '*InvalidParameter*'
        Assert-ThrowsLike {
            Update-AzVM -ResourceGroupName $rgname -VM $vm -PreferredVMSize ''
        } '*RequiredParameterMissing*'
        $invalid = Get-AzVM -ResourceGroupName $rgname -Name $name
        $invalid.HardwareProfile.VmSize = 'Standard_D8s_v5'
        Assert-ThrowsLike { Update-AzVM -ResourceGroupName $rgname -VM $invalid } '*InvalidParameter*'

        # Step 5: Opt out by explicitly removing FlexProfile and selecting a fixed size.
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $name
        $vm.FlexProfile = $null
        $vm.HardwareProfile.VmSize = $size
        Update-AzVM -ResourceGroupName $rgname -VM $vm
        $fixed = Get-AzVM -ResourceGroupName $rgname -Name $name
        Assert-Null $fixed.FlexProfile
        Assert-AreEqual $size $fixed.HardwareProfile.VmSize

        # Step 6: A direct fixed-to-Flow switch must not retain hardwareProfile.vmSize.
        $direct = Get-AzVM -ResourceGroupName $rgname -Name $name
        $direct.FlexProfile = New-Object -TypeName Microsoft.Azure.Management.Compute.Models.FlexProfile -ArgumentList $nextSize
        Assert-AreEqual $size $direct.HardwareProfile.VmSize
        Assert-ThrowsLike { Update-AzVM -ResourceGroupName $rgname -VM $direct } '*InvalidParameter*'

        # Step 7: The PreferredVMSize parameter performs the valid fixed-to-Flow conversion.
        Update-AzVM -ResourceGroupName $rgname -VM $fixed -PreferredVMSize $size
        Assert-Null $fixed.FlexProfile
        Assert-AreEqual $size $fixed.HardwareProfile.VmSize
        Assert-FlexProfileRoundTrip -VM (Get-AzVM -ResourceGroupName $rgname -Name $name) -PreferredSize $size
    }
    finally
    {
        # Step 8: Remove every resource created by this scenario.
        Remove-AzResourceGroup -Name $rgname -Force -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Tests service rejection of unsupported FlexProfile placement using existing prerequisite resources.
#>
function Test-FlexProfileUnsupportedPlacement
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation
    $size = 'Standard_D2s_v5'
    $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ('admin01', $password)
    try
    {
        # Step 1: Provision actual placement resources so failures cannot be missing-resource errors.
        New-AzResourceGroup -Name $rgname -Location $loc -Force
        $nic = New-FlexProfileTestNetwork -ResourceGroupName $rgname -Location $loc
        $availability = New-AzAvailabilitySet -ResourceGroupName $rgname -Name 'flex-as' `
            -Location $loc -Sku Aligned -PlatformFaultDomainCount 2 -PlatformUpdateDomainCount 5
        $ppg = New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name 'flex-ppg' `
            -Location $loc -ProximityPlacementGroupType Standard
        $reservation = New-AzCapacityReservationGroup -ResourceGroupName $rgname -Name 'flex-crg' -Location $loc
        New-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $reservation.Name `
            -Name 'flex-cr' -Location $loc -Sku $size -CapacityToReserve 1
        $vmssConfig = New-AzVmssConfig -Location $loc -SkuCapacity 0 -SkuName $size `
            -OrchestrationMode Flexible -PlatformFaultDomainCount 1 -SecurityType Standard
        $vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName 'flex-vmss' -VirtualMachineScaleSet $vmssConfig
        $hostGroup = New-AzHostGroup -ResourceGroupName $rgname -Name 'flex-hg' -Location $loc -PlatformFaultDomain 1
        $hostResource = New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroup.Name `
            -Name 'flex-host' -Location $loc -Sku DSv5-Type1

        # Step 2: Verify config-based placement exclusions return InvalidParameter.
        $placements = @(
            @{ AvailabilitySetId = $availability.Id },
            @{ ProximityPlacementGroupId = $ppg.Id },
            @{ CapacityReservationGroupId = $reservation.Id },
            @{ VmssId = $vmss.Id },
            @{ HostId = $hostResource.Id }
        )
        $index = 0
        foreach ($placement in $placements)
        {
            $index++
            $parameters = @{ VMName = "placement$index"; PreferredVMSize = $size }
            foreach ($key in $placement.Keys) { $parameters[$key] = $placement[$key] }
            $config = New-FlexProfileTestConfig -Parameters $parameters -NicId $nic.Id -Credential $cred
            Assert-ThrowsLike { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $config } '*InvalidParameter*'
        }

        # Step 3: Cover the simple-path HostGroupId placement using the real host group.
        Assert-ThrowsLike {
            New-AzVM -ResourceGroupName $rgname -Location $loc -Name 'hostgroup-vm' `
                -PreferredVMSize $size -HostGroupId $hostGroup.Id -Credential $cred `
                -Image Win2022AzureEditionCore -SecurityType Standard
        } '*InvalidParameter*'

        # Step 4: Preserve service validation for empty and invalid preferred sizes.
        $empty = New-FlexProfileTestConfig -Parameters @{ VMName = 'empty-create'; PreferredVMSize = '' } `
            -NicId $nic.Id -Credential $cred
        Assert-ThrowsLike { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $empty } '*RequiredParameterMissing*'
        $invalid = New-FlexProfileTestConfig -Parameters @{ VMName = 'invalid-create'; PreferredVMSize = 'Not_A_Real_VM_Size' } `
            -NicId $nic.Id -Credential $cred
        Assert-ThrowsLike { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $invalid } '*InvalidParameter*'
    }
    finally
    {
        # Step 5: Remove every resource created by this scenario.
        Remove-AzResourceGroup -Name $rgname -Force -ErrorAction SilentlyContinue
    }
}
