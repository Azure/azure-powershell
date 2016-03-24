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
Test Virtual Machine Scalet Set

PS C:\> Get-Command *VMSS* | ft Name,Version,ModuleName

Name                                            Version ModuleName
----                                            ------- ----------
Add-AzureRmVmssAdditionalUnattendContent           1.2.4      AzureRM.Compute
Add-AzureRmVmssExtension                           1.2.4      AzureRM.Compute
Add-AzureRmVMSshPublicKey                          1.2.4      AzureRM.Compute
Add-AzureRmVmssNetworkInterfaceConfiguration       1.2.4      AzureRM.Compute
Add-AzureRmVmssSecret                              1.2.4      AzureRM.Compute
Add-AzureRmVmssSshPublicKey                        1.2.4      AzureRM.Compute
Add-AzureRmVmssWinRMListener                       1.2.4      AzureRM.Compute
Get-AzureRmVmss                                    1.2.4      AzureRM.Compute
Get-AzureRmVmssSku                                 1.2.4      AzureRM.Compute
Get-AzureRmVmssVM                                  1.2.4      AzureRM.Compute
New-AzureRmVmss                                    1.2.4      AzureRM.Compute
New-AzureRmVmssConfig                              1.2.4      AzureRM.Compute
New-AzureRmVmssIpConfig                            1.2.4      AzureRM.Compute
New-AzureRmVmssVaultCertificateConfig              1.2.4      AzureRM.Compute
Remove-AzureRmVmss                                 1.2.4      AzureRM.Compute
Remove-AzureRmVmssExtension                        1.2.4      AzureRM.Compute
Remove-AzureRmVmssNetworkInterfaceConfiguration    1.2.4      AzureRM.Compute
Restart-AzureRmVmss                                1.2.4      AzureRM.Compute
Set-AzureRmVmss                                    1.2.4      AzureRM.Compute
Set-AzureRmVmssOsProfile                           1.2.4      AzureRM.Compute
Set-AzureRmVmssStorageProfile                      1.2.4      AzureRM.Compute
Set-AzureRmVmssVM                                  1.2.4      AzureRM.Compute
Start-AzureRmVmss                                  1.2.4      AzureRM.Compute
Stop-AzureRmVmss                                   1.2.4      AzureRM.Compute
Update-AzureRmVmss                                 1.2.4      AzureRM.Compute
Update-AzureRmVmssInstance                         1.2.4      AzureRM.Compute
#>

<#
.SYNOPSIS
Test Virtual Machine Scale Set
#>
function Test-VirtualMachineScaleSet
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'westus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzureRMPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzureRMPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;

        # Create LoadBalancer
        $frontendName = Get-ResourceName
        $backendAddressPoolName = Get-ResourceName
        $probeName = Get-ResourceName
        $inboundNatPoolName = Get-ResourceName
        $lbruleName = Get-ResourceName
        $lbName = Get-ResourceName

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $pubip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatPool = New-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId `
            $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3362 -BackendPort 3370;
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName `
            -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 `
            -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP;
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $loc `
            -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -LoadBalancingRule $lbrule -InboundNatPool $inboundNatPool;
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName
        Assert-AreEqual $expectedLb.Name $actualLb.Name
        Assert-AreEqual $expectedLb.Location $actualLb.Location
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState
        Assert-NotNull $expectedLb.ResourceGuid
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name
        Assert-AreEqual $pubip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress
        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name
        Assert-AreEqual $probeName $expectedLb.Probes[0].Name
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatPools[0].FrontendIPConfiguration.Id
        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id
        
        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = "BaR@123" + $rgname;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Remove-AzureRmVmssExtension -Name $extname `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test2' -IPConfiguration $ipCfg `
            | Remove-AzureRmVmssNetworkInterfaceConfiguration -Name 'test2' `
            | New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName;

        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss');
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssName -eq $vmssResult.Name };
        $output = $vmssResult | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List All
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss ListAll');

        $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetsListAll;
        $args = ($argList | select -ExpandProperty Value);
        $vmssList = Get-AzureRmVmss;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List from RG
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss List');
        $vmssList = Get-AzureRmVmss -ResourceGroupName $rgname;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List Skus
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssSku');
        $skuList = Get-AzureRmVmssSku -ResourceGroupName $rgname  -VMScaleSetName $vmssName;
        $output = $skuList | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("Sku") };

        # List All VMs
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM List');

        $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsList;
        $argList[0].Value = $rgname;
        $argList[1].Value = $vmssName;
        $args = ($argList | select -ExpandProperty Value);
        $vmListResult = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName; # -Select $null;
        $output = $vmListResult | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("StorageProfile") };

        # List each VM
        for ($i = 0; $i -lt 2; $i++)
        {
            Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM');
            $vm = Get-AzureRmVmssVM -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vm;
            $output = $vm | Out-String;
            Write-Verbose ($output);
            Assert-True { $output.Contains("StorageProfile") };

            Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM -InstanceView');
            $vmInstance = Get-AzureRmVmssVM -InstanceView  -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vmInstance;
            $output = $vmInstance | Out-String;
            Write-Verbose($output);
            Assert-True { $output.Contains("PlatformUpdateDomain") };
        }

        # List Next (negative test)
        # Assert-ThrowsContains { Get-AzureRmVmssNextList -NextPageLink test.com  } "Invalid URI: The format of the URI could not be determined.";

        # Stop/Start/Restart Operation
        for ($i = 0; $i -lt 2; $i++)
        {
            $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsPowerOff;
            $argList[0].Value = $rgname;
            $argList[1].Value = $vmssName;
            $argList[2].Value = $i.ToString();
            $args = ($argList | select -ExpandProperty Value);
            Invoke-AzureComputeMethod -MethodName VirtualMachineScaleSetVMPowerOff -ArgumentList $args;

            $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsDeallocate;
            $argList[0].Value = $rgname;
            $argList[1].Value = $vmssName;
            $argList[2].Value = $i.ToString();;
            $args = ($argList | select -ExpandProperty Value);
            Invoke-AzureComputeMethod -MethodName VirtualMachineScaleSetVMDeallocate -ArgumentList $args;

            $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsStart;
            $argList[0].Value = $rgname;
            $argList[1].Value = $vmssName;
            $argList[2].Value = $i.ToString();;
            $args = ($argList | select -ExpandProperty Value);
            Invoke-AzureComputeMethod -MethodName VirtualMachineScaleSetVMStart -ArgumentList $args;

            $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsRestart;
            $argList[0].Value = $rgname;
            $argList[1].Value = $vmssName;
            $argList[2].Value = $i.ToString();;
            $args = ($argList | select -ExpandProperty Value);
            Invoke-AzureComputeMethod -MethodName VirtualMachineScaleSetVMRestart -ArgumentList $args;
        }

        $st = Stop-AzureRmVmss -StayProvision -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $st = Stop-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $st = Start-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $st = Restart-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        $instanceListParam = @();
        for ($i = 0; $i -lt 2; $i++)
        {
            $instanceListParam += $i.ToString();
        }

        $st = Stop-AzureRmVmss -StayProvision -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $instanceListParam;
        $st = Stop-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $instanceListParam;
        $st = Start-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $instanceListParam;
        $st = Restart-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $instanceListParam;

        # Remove
        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1;

        $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsDelete;
        $argList[0].Value = $rgname;
        $argList[1].Value = $vmssName;
        $i = 0;
        $argList[2].Value = $i.ToString();
        $args = ($argList | select -ExpandProperty Value);

        try
        {
            Invoke-AzureComputeMethod -MethodName VirtualMachineScaleSetVMDelete -ArgumentList $args;
        }
        catch
        {
            $actualMessage = $_.Exception.Message;
            Write-Output ("Caught exception: '$actualMessage'");
            if (-not $actualMessage.Contains("BadRequest"))
            {
                throw "Expected exception does not contain expected text 'BadRequest', the actual message is '$actualMessage'";
            }
        }

        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Reimage and Upgrade
#>
function Test-VirtualMachineScaleSetReimageUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'westus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = "BaR@123" + $rgname;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $aucComponentName="Microsoft-Windows-Shell-Setup";
        $aucComponentName="MicrosoftWindowsShellSetup";
        $aucPassName ="oobeSystem";
        $aucSetting = "AutoLogon";
        $aucContent = "<UserAccounts><AdministratorPassword><Value>password</Value><PlainText>true</PlainText></AdministratorPassword></UserAccounts>";

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssAdditionalUnattendContent -ComponentName  $aucComponentName -Content  $aucContent -PassName  $aucPassName -SettingName  $aucSetting `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $vmss.VirtualMachineProfile.OsProfile.WindowsConfiguration.AdditionalUnattendContent = $null;
        $st = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        # Manual Upgrade operation
        $st = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName | Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName;
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        Update-AzureRmVmssInstance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "0";
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        # Reimage operation
        try
        {
            Set-AzureRmVmss -Reimage -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        }
        catch
        {
            $actualMessage = $_.Exception.Message;
            Write-Output ("Caught exception: '$actualMessage'");
            if (-not $actualMessage.Contains("Conflict"))
            {
                throw "Expected exception does not contain expected text 'Conflict', the actual message is '$actualMessage'";
            }
        }

        # Remove
        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1;

        $argList = New-AzureComputeArgumentList -MethodName VirtualMachineScaleSetVMsDelete;
        $argList[0].Value = $rgname;
        $argList[1].Value = $vmssName;
        $i = 0;
        $argList[2].Value = $i.ToString();
        $args = ($argList | select -ExpandProperty Value);

        try
        {
            Invoke-AzureComputeMethod -MethodName VirtualMachineScaleSetVMDelete -ArgumentList $args;
        }
        catch
        {
            $actualMessage = $_.Exception.Message;
            Write-Output ("Caught exception: '$actualMessage'");
            if (-not $actualMessage.Contains("BadRequest"))
            {
                throw "Expected exception does not contain expected text 'BadRequest', the actual message is '$actualMessage'";
            }
        }

        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
