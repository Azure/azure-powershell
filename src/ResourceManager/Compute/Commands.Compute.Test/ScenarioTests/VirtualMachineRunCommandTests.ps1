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
Test Virtual Machine Run Command Get
.Description
AzureAutomationTest
#>
function Test-VirtualMachineGetRunCommand
{
    # Common
    $loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(" ", "")

    $commandId = "RunPowerShellScript"

    $result = Get-AzureRmVMRunCommandDocument -Location $loc -CommandId $commandId

    Assert-AreEqual $commandId $result.Id
    Assert-AreEqual "Windows" $result.OsType
    $result_output = $result | Out-String

    $result = Get-AzureRmVMRunCommandDocument -Location $loc

    Assert-True {$result.Count -gt 0}
    $result_output = $result | Out-String
}


<#
.SYNOPSIS
Test Virtual Machine Run Command Set
#>
function Test-VirtualMachineSetRunCommand
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(" ", "")
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRmVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRmVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzureRmPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzureRmPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureRmNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureRmNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = New-AzureRmVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzureRmVMNetworkInterface -Id $nicId -Primary `
             | Set-AzureRmVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Set-AzureRmVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzureRmVMSourceImage -VM $p | New-AzureRmVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzureRmVM -Name $vmname -ResourceGroupName $rgname;

        $vm = Get-AzureRmVM -ResourceGroupName $rgname
        $commandId = "RunPowerShellScript"

        $param = @{"first" = "var1";"second" = "var2"};

        $path = 'ScenarioTests\test.ps1';
        
        $result = Invoke-AzureRmVMRunCommand -ResourceGroupName $rgname -Name $vmname -CommandId $commandId -ScriptPath $path -Parameter $param;
        $result_output = $result | Out-String;

        # Remove All VMs
        Get-AzureRmVM -ResourceGroupName $rgname | Remove-AzureRmVM -Force;
        $vms = Get-AzureRmVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
