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

function Check-ColocationStatus
{
    param ($colocationStatus)

    Assert-NotNull $colocationStatus;
    Assert-AreEqual  "Aligned" $colocationStatus.DisplayStatus;
    Assert-AreEqual  "ColocationStatus/Aligned" $colocationStatus.Code;
    Assert-AreEqual  "Info" $colocationStatus.Level;
    Assert-AreEqual  "All resources in the proximity placement group are aligned." $colocationStatus.Message;
}

function Check-ColocationStatusUnknown
{
    param ($colocationStatus)

    Assert-NotNull $colocationStatus;
    Assert-AreEqual  "Unknown" $colocationStatus.DisplayStatus;
    Assert-AreEqual  "ColocationStatus/Unknown" $colocationStatus.Code;
    Assert-AreEqual  "Warning" $colocationStatus.Level;
    Assert-AreEqual  "Colocation status is currently unknown." $colocationStatus.Message;
}

<#
.SYNOPSIS
Test ProximityPlacementGroup
#>
function Test-ProximityPlacementGroup
{
    param ($loc)
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $ppgname = $rgname + 'ppg'
        New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Location $loc -ProximityPlacementGroupType "Standard" -Tag @{key1 = "val1"};

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;

        Assert-AreEqual $rgname $ppg.ResourceGroupName;
        Assert-AreEqual $ppgname $ppg.Name;
        Assert-AreEqual $loc $ppg.Location;
        Assert-AreEqual "Standard" $ppg.ProximityPlacementGroupType;
        Assert-True { $ppg.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val1" $ppg.Tags["key1"];
        Assert-Null $ppg.ColocationStatus;

        $ppgStatus = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -ColocationStatus;
        Assert-AreEqual $rgname $ppgStatus.ResourceGroupName;
        Assert-AreEqual $ppgname $ppgStatus.Name;
        Assert-AreEqual $loc $ppgStatus.Location;
        Assert-AreEqual "Standard" $ppgStatus.ProximityPlacementGroupType;
        Assert-True { $ppgStatus.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val1" $ppgStatus.Tags["key1"];

        Check-ColocationStatus $ppgStatus.ColocationStatus;

        $ppgs = Get-AzProximityPlacementGroup -ResourceGroupName $rgname;
        Assert-AreEqual 1 $ppgs.Count;

        $ppgs = Get-AzProximityPlacementGroup;
        Assert-True {  $ppgs.Count -ge 1 };

        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Force;

        $ppgs = Get-AzProximityPlacementGroup -ResourceGroupName $rgname;
        Assert-AreEqual 0 $ppgs.Count;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ProximityPlacementGroup with availability set
#>
function Test-ProximityPlacementGroupAvSet
{
    param ($loc)
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $ppgname1 = $rgname + 'ppg'
        New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1 -Location $loc -ProximityPlacementGroupType "Standard" -Tag @{key1 = "val1"};

        $ppg1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1;
        Assert-AreEqual $rgname $ppg1.ResourceGroupName;
        Assert-AreEqual $ppgname1 $ppg1.Name;
        Assert-AreEqual $loc $ppg1.Location;
        Assert-AreEqual "Standard" $ppg1.ProximityPlacementGroupType;
        Assert-True { $ppg1.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val1" $ppg1.Tags["key1"];

        Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1 -ColocationStatus;

        $asetName = $rgname + 'as';
        New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -ProximityPlacementGroupId $ppg1.Id -Sku 'Classic';
        $av = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-AreEqual $ppg1.Id $av.ProximityPlacementGroup.Id;

        $ppg1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1;
        Assert-AreEqual $av.Id $ppg1.AvailabilitySets[0].Id;
        Assert-Null $ppg1.ColocationStatus;

        $ppgStatus1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1 -ColocationStatus;
        Assert-AreEqual $av.Id $ppgStatus1.AvailabilitySets[0].Id;
        Check-ColocationStatus $ppgStatus1.ColocationStatus;

        # Create another PPG
        $ppgname2 = $rgname + 'ppg2'
        New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -Location $loc -ProximityPlacementGroupType "Standard" -Tag @{key2 = "val2"};
        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-Null $ppg2.AvailabilitySets;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-Null $ppgStatus2.AvailabilitySets;
        Check-ColocationStatus $ppgStatus2.ColocationStatus;

        # Update AvSet to another PPG
        Update-AzAvailabilitySet -AvailabilitySet $av -ProximityPlacementGroupId $ppg2.Id;

        $av = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-AreEqual $ppg2.Id $av.ProximityPlacementGroup.Id;

        $ppg1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1;
        Assert-Null $ppg1.AvailabilitySets;
        Assert-Null $ppg1.ColocationStatus;

        $ppgStatus1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1 -ColocationStatus;
        Assert-Null $ppgStatus1.AvailabilitySets;
        Check-ColocationStatus $ppgStatus1.ColocationStatus;

        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-AreEqual $av.Id $ppg2.AvailabilitySets[0].Id;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-AreEqual $av.Id $ppgStatus2.AvailabilitySets[0].Id;
        Check-ColocationStatus $ppgStatus2.ColocationStatus;

        Remove-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Force;
        $ppg1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1;
        Assert-Null $ppg1.AvailabilitySets;
        Assert-Null $ppg1.ColocationStatus;

        $ppgStatus1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1 -ColocationStatus;
        Assert-Null $ppgStatus1.AvailabilitySets;
        Check-ColocationStatus $ppgStatus1.ColocationStatus;

        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-Null $ppg2.AvailabilitySets;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-Null $ppgStatus2.AvailabilitySets;
        Check-ColocationStatus $ppgStatus2.ColocationStatus;

        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname1 -Force;
        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ProximityPlacementGroup with virtual machine
#>
function Test-ProximityPlacementGroupVM
{
    param ($loc)
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $ppgname = $rgname + 'ppg'
        New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Location $loc -ProximityPlacementGroupType "Standard" -Tag @{key1 = "val1"};

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;

        Assert-AreEqual $rgname $ppg.ResourceGroupName;
        Assert-AreEqual $ppgname $ppg.Name;
        Assert-AreEqual $loc $ppg.Location;
        Assert-AreEqual "Standard" $ppg.ProximityPlacementGroupType;
        Assert-True { $ppg.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val1" $ppg.Tags["key1"];

        Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -ColocationStatus;

        # Create a subnet configuration
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix 192.168.1.0/24;

        # Create a virtual network
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgname -Location $loc -Name  ('vnet' + $rgname) -AddressPrefix 192.168.0.0/16 -Subnet $subnet;

        # Create a public IP address and specify a DNS name
        $pip = New-AzPublicIpAddress -ResourceGroupName $rgname -Location $loc -Name ('pubip' + $rgname) -AllocationMethod Static -IdleTimeoutInMinutes 4;

        # Create a network security group
        $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgname -Location $loc -Name ('netsg' + $rgname);

        # Create a virtual network card and associate with public IP address and NSG
        $nic = New-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc `
                                      -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id;

        $vmname = 'vm' + $rgname;
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        # Create a virtual machine configuration
        $p = New-AzVMConfig -VMName $vmName -VMSize Standard_A1 -ProximityPlacementGroupId $ppg.Id `
                  | Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $cred `
                  | Add-AzVMNetworkInterface -Id $nic.Id;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Create a virtual machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName;
        Assert-AreEqual $ppg.Id $vm.ProximityPlacementGroup.Id;

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-AreEqual $vm.Id $ppg.VirtualMachines[0].Id;
        Assert-Null $ppg.ColocationStatus;

        $ppgStatus1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -ColocationStatus;
        Assert-AreEqual $vm.Id $ppgStatus1.VirtualMachines[0].Id;
        Check-ColocationStatus $ppgStatus1.ColocationStatus;

        Stop-AzVM -ResourceGroupName $rgname -Name $vmName -Force;

        $ppgname2 = $rgname + 'ppg2'
        New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -Location $loc -ProximityPlacementGroupType "Standard" -Tag @{key2 = "val2"};
        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-Null $ppg2.VirtualMachines;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-Null $ppgStatus2.VirtualMachines;
        Check-ColocationStatus $ppgStatus2.ColocationStatus;

        Update-AzVM -ResourceGroupName $rgname -VM $vm -ProximityPlacementGroupId $ppg2.Id;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName;
        Assert-AreEqual $ppg2.Id $vm.ProximityPlacementGroup.Id;

        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-AreEqual $vm.Id $ppg2.VirtualMachines[0].Id;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 =Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-AreEqual $vm.Id $ppgStatus2.VirtualMachines[0].Id;
        Check-ColocationStatusUnknown $ppgStatus2.ColocationStatus;

        Update-AzVM -ResourceGroupName $rgname -VM $vm -ProximityPlacementGroupId "";
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName;
        Assert-Null $vm.ProximityPlacementGroup.Id;

        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-AreEqual 0 $ppg2.VirtualMachines.Count;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 =Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-AreEqual 0 $ppgStatus2.VirtualMachines.Count;
        Check-ColocationStatus $ppgStatus2.ColocationStatus;

        Remove-AzVM -ResourceGroupName $rgname -Name $vmName -Force;
        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-Null $ppg.VirtualMachines;
        Assert-Null $ppg.ColocationStatus;

        $ppgStatus1 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -ColocationStatus;
        Assert-Null $ppgStatus1.VirtualMachines;
        Check-ColocationStatus $ppgStatus1.ColocationStatus;

        $ppg2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2;
        Assert-Null $ppg2.VirtualMachines;
        Assert-Null $ppg2.ColocationStatus;

        $ppgStatus2 = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -ColocationStatus;
        Assert-Null $ppgStatus2.VirtualMachines;
        Check-ColocationStatus $ppgStatus2.ColocationStatus;

        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Force;
        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname2 -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test the PPG Zones and the vmIntentList parameters. 
#>
function Test-PPGVMIntentAndZoneFeatures
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "westeurope";

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $ppgname = $rgname + 'ppg';
        $vmIntentList1 = 'Standard_D4d_v4';
        $vmIntentList2 = 'Standard_D4d_v5';
        $vmIntentListUpdate3 = 'Standard_DS3_v2';
        $zone = '1';
        $zone2 = '2';

        $proxgroup = New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Location $loc -Zone $zone -IntentVMSizeList $vmIntentList1, $vmIntentList2 ;

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-AreEqual $ppg.Intent.VmSizes[0] $vmIntentList1;
        Assert-AreEqual $ppg.Intent.VmSizes[1] $vmIntentList2;
        Assert-AreEqual $ppg.Zones[0] $zone;

        $proxgroup = New-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Location $loc -Zone $zone -IntentVMSizeList $vmIntentList1, $vmIntentListUpdate3 ;
        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-AreEqual $ppg.Intent.VmSizes[0] $vmIntentList1;
        Assert-AreEqual $ppg.Intent.VmSizes[1] $vmIntentListUpdate3;

        # Create a subnet configuration
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix 192.168.1.0/24;

        # Create a virtual network
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rgname -Location $loc -Name  ('vnet' + $rgname) -AddressPrefix 192.168.0.0/16 -Subnet $subnet;

        # Create a public IP address and specify a DNS name
        $pip = New-AzPublicIpAddress -ResourceGroupName $rgname -Location $loc -Name ('pubip' + $rgname) -AllocationMethod Static -IdleTimeoutInMinutes 4;

        # Create a network security group
        $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgname -Location $loc -Name ('netsg' + $rgname);

        # Create a virtual network card and associate with public IP address and NSG
        $nic = New-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc `
                                      -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id;

        $vmname = 'vm' + $rgname;
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $vmSize = 'Standard_D4ds_v5';

        # Create a virtual machine configuration
        $p = New-AzVMConfig -VMName $vmName -VMSize $vmSize -ProximityPlacementGroupId $ppg.Id `
                  | Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $cred `
                  | Add-AzVMNetworkInterface -Id $nic.Id;

        $publisherName = "MicrosoftWindowsServer";
        $offer = "WindowsServer";
        $sku = "2019-DataCenter";
        $vmconfig = Set-AzVMSourceImage -VM $p -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest';


        # Create a virtual machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName;
        Assert-AreEqual $ppg.Id $vm.ProximityPlacementGroup.Id;

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-AreEqual $vm.Id $ppg.VirtualMachines[0].Id;
        Assert-AreEqual $vm.ProximityPlacementGroup.Id $ppg.Id;
        
        # Create a virtual machine using Simple Parameter set.
        $domainNameLabel = "d" + $rgname;
        New-AzVM -ResourceGroupName $rgname -Location $loc -name $vmname -credential $cred -DomainNameLabel $domainNameLabel -ProximityPlacementGroupId $ppg.Id ;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName;
        Assert-AreEqual $ppg.Id $vm.ProximityPlacementGroup.Id;
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
