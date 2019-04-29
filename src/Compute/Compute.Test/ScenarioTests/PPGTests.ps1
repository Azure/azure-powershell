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
        $loc = "westcentralus"
        
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
        $loc = "westcentralus"
        
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

        $asetName = $rgname + 'as';
        New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -ProximityPlacementGroupId $ppg.Id -Sku 'Classic';
        $av = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;     

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-AreEqual $av.Id $ppg.AvailabilitySets[0].Id;

        Remove-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Force;
        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-Null $ppg.AvailabilitySets;

        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Force;
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
        $loc = "westcentralus"
        
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

        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-AreEqual $vm.Id $ppg.VirtualMachines[0].Id;

        Remove-AzVM -ResourceGroupName $rgname -Name $vmName -Force;
        $ppg = Get-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname;
        Assert-Null $ppg.VirtualMachines;

        Remove-AzProximityPlacementGroup -ResourceGroupName $rgname -Name $ppgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
