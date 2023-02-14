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

    $result = Get-AzVMRunCommandDocument -Location $loc -CommandId $commandId

    Assert-AreEqual $commandId $result.Id
    Assert-AreEqual "Windows" $result.OsType
    $result_output = $result | Out-String

    $result = Get-AzVMRunCommandDocument -Location $loc

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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

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

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        $vm = Get-AzVM -ResourceGroupName $rgname
        $commandId = "RunPowerShellScript"

        $param = @{"first" = "var1";"second" = "var2"};

        $path = 'ScenarioTests\test.ps1';
        
        $job = Invoke-AzVMRunCommand -ResourceGroupName $rgname -Name $vmname -CommandId $commandId -ScriptPath $path -Parameter $param -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.Value;

        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        $result = Invoke-AzVMRunCommand -ResourceId $vm.Id -CommandId $commandId -ScriptPath $path -Parameter $param;
        Assert-NotNull $result.Value;

        $result = Get-AzVM -ResourceGroupName $rgname -Name $vmname | Invoke-AzVMRunCommand -CommandId $commandId -ScriptPath $path -Parameter $param;
        Assert-NotNull $result.Value;

        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set VM Run Command Set
#>
function Test-VirtualMachineScaleSetVMRunCommand
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-Location "Microsoft.Compute" "virtualMachines";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = Get-PasswordForVM;
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssId = $vmssVMs[0].InstanceId;

        $commandId = "RunPowerShellScript"
        $param = @{"first" = "var1";"second" = "var2"};
        $path = 'ScenarioTests\test.ps1';

        $job = Invoke-AzVmssVMRunCommand -ResourceGroupName $rgname -Name $vmssName -InstanceId $vmssId -CommandId $commandId -ScriptPath $path -Parameter $param -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.Value;

        $vmssVM = Get-AzVmssVM -ResourceGroupName $rgname -Name $vmssName -InstanceId $vmssId;

        $result = Invoke-AzVmssVMRunCommand -ResourceId $vmssVM.Id -CommandId $commandId -ScriptPath $path -Parameter $param;
        Assert-NotNull $result.Value;

        $result = Get-AzVmssVM -ResourceGroupName $rgname -Name $vmssName -InstanceId $vmssId | Invoke-AzVmssVMRunCommand -CommandId $commandId -ScriptPath $path -Parameter $param;
        Assert-NotNull $result.Value;

        $vmssVM = Get-AzVmssVM -ResourceGroupName $rgname -Name $vmssName -InstanceId $vmssId;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
