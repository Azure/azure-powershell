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
Test DedicatedHost
#>
function Test-DedicatedHost
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $hostGroupName = $rgname + 'hostgroup'
        New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 1  -Zone "2" -Tag @{key1 = "val1"};

        $hostGroup = Get-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName;

        Assert-AreEqual $rgname $hostGroup.ResourceGroupName;
        Assert-AreEqual $hostGroupName $hostGroup.Name;
        Assert-AreEqual $loc $hostGroup.Location;
        Assert-True { $hostGroup.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val1" $hostGroup.Tags["key1"];
        Assert-True { $hostGroup.Zones.Contains("2") };
        Assert-AreEqual 0 $hostGroup.Hosts.Count;
        Assert-AreEqual $true $hostGroup.SupportAutomaticPlacement;

        $hostGroups = Get-AzHostGroup -ResourceGroupName $rgname;
        Assert-AreEqual 1 $hostGroups.Count;

        $hostName = $rgname + 'host'
        New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku "ESv3-Type1" -Tag @{key1 = "val2"};

        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        Assert-AreEqual $rgname $dedicatedHost.ResourceGroupName;
        Assert-AreEqual $hostName $dedicatedHost.Name;
        Assert-AreEqual $loc $dedicatedHost.Location;
        Assert-AreEqual "ESv3-Type1" $dedicatedHost.Sku.Name;
        Assert-True { $dedicatedHost.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val2" $dedicatedHost.Tags["key1"];

        $dedicatedHostStatus =Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -InstanceView;
        Assert-AreEqual $rgname $dedicatedHostStatus.ResourceGroupName;
        Assert-AreEqual $hostName $dedicatedHostStatus.Name;
        Assert-AreEqual $loc $dedicatedHostStatus.Location;
        Assert-AreEqual "ESv3-Type1" $dedicatedHostStatus.Sku.Name;
        Assert-True { $dedicatedHostStatus.Tags.Keys.Contains("key1") };
        Assert-AreEqual "val2" $dedicatedHostStatus.Tags["key1"];
        Assert-NotNull  $dedicatedHostStatus.InstanceView;
        Assert-NotNull  $dedicatedHostStatus.InstanceView.AssetId;
        Assert-NotNull  $dedicatedHostStatus.InstanceView.Statuses;

        $dedicatedHosts = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName;
        Assert-AreEqual 1 $dedicatedHosts.Count;
        Assert-AreEqual $dedicatedHost.Id $dedicatedHosts[0].Id;

        $hostGroup = Get-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName;
        Assert-AreEqual 1 $hostGroup.Hosts.Count;
        Assert-AreEqual 1 $hostGroup.Count;

        $hostGroupInstanceViewResult = Get-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -InstanceView;
        Assert-NotNull $hostGroupInstanceViewResult.Hosts;
        foreach ($hostInstanceViewWithName in $hostGroupInstanceViewResult.InstanceView.Hosts) {
            Assert-NotNull $hostInstanceViewWithName.Name;
        } 

        Remove-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;

        Assert-ThrowsContains {
            Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName; } `
            "ResourceNotFound";

        $dedicatedHosts = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName;
        Assert-AreEqual 0 $dedicatedHosts.Count;

        $hostGroup = Get-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupName;
        Assert-AreEqual 0 $hostGroup.Hosts.Count;

        Remove-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupName;

        Assert-ThrowsContains {
            Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName; } `
            "ParentResourceNotFound";

        Assert-ThrowsContains {
            Get-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupName; } `
            "ResourceNotFound";

        $hostGroups = Get-AzHostGroup -ResourceGroupName $rgname;
        Assert-AreEqual 0 $hostGroups.Count;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test DedicatedHostVirtualMachine
#>
function Test-DedicatedHostVirtualMachine
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        $loc = $loc.Replace(' ', '');
        
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $hostGroupName = $rgname + 'hostgroup'
        New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 2 -Zone "2" -SupportAutomaticPlacement $false -Tag @{key1 = "val1"};
        $hostGroup = Get-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName;

        Assert-AreEqual $false $hostGroup.SupportAutomaticPlacement;

        $hostName = $rgname + 'host'
        New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku "ESv3-Type1" -PlatformFaultDomain 1 -Tag @{key1 = "val2"};

        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        $dedicatedHostId = $dedicatedHost.Id;

        # VM Profile & Hardware
        $vmsize = 'Standard_E2s_v3';
        $vmname0 = 'v' + $rgname;

        # Creating a VM using simple parameter set
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname0-$vmname0".tolower();

        New-AzVM -ResourceGroupName $rgname -Name $vmname0 -Credential $cred -Zone "2" -Size $vmsize -HostId $dedicatedHostId -DomainNameLabel $domainNameLabel;
        $vm0 = Get-AzVM -ResourceGroupName $rgname -Name $vmname0;
        Assert-AreEqual $dedicatedHostId $vm0.Host.Id;

        $vmname1 = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -Zone "2" -Sku "Standard" -AllocationMethod "Static" -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = New-AzVMConfig -VMName $vmname1 -VMSize $vmsize -Zone "2" -HostId $dedicatedHostId `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;
        Assert-AreEqual $dedicatedHostId $vm1.Host.Id;

        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        Assert-AreEqual 2 $dedicatedHost.VirtualMachines.Count;
        Assert-AreEqual $vm0.Id $dedicatedHost.VirtualMachines[0].Id;
        Assert-AreEqual $vm1.Id $dedicatedHost.VirtualMachines[1].Id;

        $dedicatedHostGroup = Get-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupNam;
        Assert-AreEqual 1 $dedicatedHostGroup.Hosts.Count;
        Assert-AreEqual $dedicatedHostId $dedicatedHostGroup.Hosts[0].Id;

        # Remove Host from VM
        Stop-AzVM -ResourceGroupName $rgname -Name $vmName1 -Force;
        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmName1;
        Update-AzVM -ResourceGroupName $rgname -VM $vm1 -HostId $null;

        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;
        Assert-Null $vm1.Host;
        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        Assert-AreEqual 1 $dedicatedHost.VirtualMachines.Count;
        Assert-AreEqual $vm0.Id $dedicatedHost.VirtualMachines[0].Id;
        $dedicatedHostGroup = Get-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupNam;
        Assert-AreEqual 1 $dedicatedHostGroup.Hosts.Count;
        Assert-AreEqual $dedicatedHostId $dedicatedHostGroup.Hosts[0].Id;

        # Add Host back to the VM
        Update-AzVM -ResourceGroupName $rgname -VM $vm1 -HostId $dedicatedHostId;

        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;
        Assert-AreEqual $dedicatedHostId $vm1.Host.Id;
        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        Assert-AreEqual 2 $dedicatedHost.VirtualMachines.Count;
        Assert-AreEqual $vm0.Id $dedicatedHost.VirtualMachines[0].Id;
        Assert-AreEqual $vm1.Id $dedicatedHost.VirtualMachines[1].Id;
        $dedicatedHostGroup = Get-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupNam;
        Assert-AreEqual 1 $dedicatedHostGroup.Hosts.Count;
        Assert-AreEqual $dedicatedHostId $dedicatedHostGroup.Hosts[0].Id;

        # Remove the VMs
        Remove-AzVM -ResourceGroupName $rgname -Name $vmname1 -Force;

        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        Assert-AreEqual 1 $dedicatedHost.VirtualMachines.Count;
        Assert-AreEqual $vm0.Id $dedicatedHost.VirtualMachines[0].Id;

        $dedicatedHostGroup = Get-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupNam;
        Assert-AreEqual 1 $dedicatedHostGroup.Hosts.Count;
        Assert-AreEqual $dedicatedHostId $dedicatedHostGroup.Hosts[0].Id;

        Remove-AzVM -ResourceGroupName $rgname -Name $vmname0 -Force;
        Remove-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        Remove-AzHostGroup -ResourceGroupName $rgname -HostGroupName $hostGroupName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Restart dedicated host feature.
#>
function Test-DedicatedHostRestart
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        # [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        # $loc = $loc.Replace(' ', '');
        $loc = "eastus2euap";
        

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $hostGroupName = $rgname + 'hostgroup';
        New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 1  -Zone "2" -Tag @{key1 = "val1"};

        $hostGroup = Get-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName;
        $hostName = $rgname + 'host';
        New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku "ESv3-Type1" -Tag @{key1 = "val2"};

        $dedicatedHost = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;
        
        # Restart the dedicated host
        Restart-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName;

        # Resource Id Parameter set
        Restart-AzHost -ResourceId $dedicatedHost.Id;

        # Object Parameter set
        Restart-AzHost -Host $dedicatedHost;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}