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
Test Invoke-AzVmPatchAssessment cmdlet
#>
function Test-InvokeAzVmPatchAssessment
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = Get-AvailableSku $loc "virtualMachine"
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -Priority 'Low' -MaxPrice 0.1538;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Create a Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $patchResult = invoke-azvmpatchAssessment -resourcegroupname $rgname -vmname $vmname
        
        Assert-NotNull $patchResult;
        Assert-AreEqual "Succeeded" $patchResult.Status;
        Assert-NotNull $patchResult.StartDateTime;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}