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
Deployment of resources: VM, storage account, network interface, nsg, virtual network and route table.
#>

function Get-TestResourcesDeployment([string]$rgn)
{
    $virtualMachineName = Get-NrpResourceName
    $storageAccountName = Get-NrpResourceName
    $routeTableName = Get-NrpResourceName
    $virtualNetworkName = Get-NrpResourceName
    $networkInterfaceName = Get-NrpResourceName
    $networkSecurityGroupName = Get-NrpResourceName
    $diagnosticsStorageAccountName = Get-NrpResourceName
    
        $paramFile = (Resolve-Path ".\TestData\DeploymentParameters.json").Path
        $paramContent =
@"
{
            "rgName": {
            "value": "$rgn"
            },
            "location": {
            "value": "$location"
            },
            "virtualMachineName": {
            "value": "$virtualMachineName"
            },
            "virtualMachineSize": {
            "value": "Standard_A4"
            },
            "adminUsername": {
            "value": "netanaytics12"
            },
            "storageAccountName": {
            "value": "$storageAccountName"
            },
            "routeTableName": {
            "value": "$routeTableName"
            },
            "virtualNetworkName": {
            "value": "$virtualNetworkName"
            },
            "networkInterfaceName": {
            "value": "$networkInterfaceName"
            },
            "networkSecurityGroupName": {
            "value": "$networkSecurityGroupName"
            },
            "adminPassword": {
            "value": "netanalytics-32${resourceGroupName}"
            },
            "storageAccountType": {
            "value": "Standard_LRS"
            },
            "diagnosticsStorageAccountName": {
            "value": "$diagnosticsStorageAccountName"
            },
            "diagnosticsStorageAccountId": {
            "value": "Microsoft.Storage/storageAccounts/${diagnosticsStorageAccountName}"
            },
            "diagnosticsStorageAccountType": {
            "value": "Standard_LRS"
            },
            "addressPrefix": {
            "value": "10.17.3.0/24"
            },
            "subnetName": {
            "value": "default"
            },
            "subnetPrefix": {
            "value": "10.17.3.0/24"
            },
            "publicIpAddressName": {
            "value": "${virtualMachineName}-ip"
            },
            "publicIpAddressType": {
            "value": "Dynamic"
            }
}
"@;

        $st = Set-Content -Path $paramFile -Value $paramContent -Force;
        New-AzResourceGroupDeployment  -Name "${rgn}" -ResourceGroupName "$rgn" -TemplateFile "$templateFile" -TemplateParameterFile $paramFile
}

function Get-TestResourcesDeploymentVMSS([string]$rgn)
{
        $paramFileVMSS = (Resolve-Path ".\TestData\DeploymentParametersVMSS.json").Path

        $paramContentVMSS =
@"
{
            "vmSku": {
            "value": "Standard_D4s_v3"
            },
            "windowsOSVersion": {
            "value": "2019-Datacenter"
            },
            "vmssName": {
            "value": "$virtualMachineScaleSetName"
            },
            "instanceCount": {
            "value": 3
            },
            "singlePlacementGroup": {
            "value": true
            },
            "adminUsername": {
            "value": "netanaytics12"
            },
            "adminPassword": {
            "value": "netanalytics-32${resourceGroupName}"
            },
            "location": {
            "value": "$location"
            },
            "platformFaultDomainCount": {
            "value": 1
            }
}
"@;

        $stVMSS = Set-Content -Path $paramFileVMSS -Value $paramContentVMSS -Force;

        New-AzResourceGroupDeployment  -Name "${rgn}" -ResourceGroupName "$rgn" -TemplateFile "$templateFileVMSS" -TemplateParameterFile $paramFileVMSS
}

function Get-NrpResourceName
{
	Get-ResourceName "psnrp";
}

function Get-NrpResourceGroupName
{
   Get-ResourceGroupName "psnrp";
}

function Wait-Vm($vm)
{
    # Don't wait more than N minutes to avoid getting stuck in a loop if VM can't recover
    $minutes = 30;
    while((Get-AzVM -ResourceGroupName $vm.ResourceGroupName -Name $vm.Name).ProvisioningState -ne "Succeeded")
    {
        Start-TestSleep -Milliseconds 60
        if(--$minutes -eq 0)
        {
            break;
        }
    }
}

<#
.SYNOPSIS
Get existing Network Watcher.
#>
function Get-CreateTestNetworkWatcher($location, $nwName, $nwRgName)
{
    $nw = $null
    $canonicalLocation = Normalize-Location $location

    # Get Network Watcher
    $nwlist = Get-AzNetworkWatcher
    foreach ($i in $nwlist)
    {
        if($i.Location -eq $canonicalLocation)
        {
            $nw = $i
            break
        }
    }

    # Create Network Watcher if no existing nw
    if(!$nw)
    {
        $nw = New-AzNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location
    }

    return $nw
}

function Get-CanaryLocation
{
    Get-ProviderLocation "Microsoft.Network/networkWatchers" "Central US EUAP";
}

function Get-PilotLocation
{
    Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US";
}

<#
.SYNOPSIS
Test GetTopology NetworkWatcher API.
#>
function Test-GetTopology
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "East US"

    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"
        
        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
		# Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        # Get topology in the resource group $resourceGroupName
        $topology = Get-AzNetworkWatcherTopology -NetworkWatcher $nw -TargetResourceGroupName $resourceGroupName

        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName

        #Get nic
        $nic = Get-AzNetworkInterface -ResourceGroupName $resourceGroupName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test GetSecurityGroupView NetworkWatcher API.
#>
function Test-GetSecurityGroupView
{ 
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $securityRuleName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    
    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
        
        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName
        
        #Get network security group
        $nsg = Get-AzNetworkSecurityGroup -ResourceGroupName $resourceGroupName
        
        # Set security rule
        $nsg[0] | Add-AzNetworkSecurityRuleConfig -Name scr1 -Description "test" -Protocol Tcp -SourcePortRange * -DestinationPortRange 80 -SourceAddressPrefix * -DestinationAddressPrefix * -Access Deny -Priority 122 -Direction Outbound
        $nsg[0] | Set-AzNetworkSecurityGroup

        Wait-Seconds 300

        # Get nsg rules for the target VM
        $job = Get-AzNetworkWatcherSecurityGroupView -NetworkWatcher $nw -Target $vm.Id -AsJob
        $job | Wait-Job
        $nsgView = $job | Receive-Job

        #Verification 
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Access Deny 
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].DestinationPortRange 80-80 
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Direction Outbound 
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Name UserRule_scr1 
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Protocol TCP 
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Priority 122 
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test GetNextHop NetworkWatcher API.
#>
function Test-GetNextHop
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $nwRgName = Get-NrpResourceGroupName
    $securityRuleName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    
    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
        
        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName
        
        #Get public IP address
        $address = Get-AzPublicIpAddress -ResourceGroupName $resourceGroupName

        #Get Nic for Source IP address
        $Nics = Get-AzNetworkInterface | Where-Object {$_.Id -eq $vm.NetworkProfile.NetworkInterfaces.Id.ForEach({$_})}
        
        #Write-Output $Nics

        #Get next hop
        $job = Get-AzNetworkWatcherNextHop -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -DestinationIPAddress 10.1.3.6 -SourceIPAddress $Nics[0].IpConfigurations[0].PrivateIpAddress -AsJob
        $job | Wait-Job
        $nextHop1 = $job | Receive-Job
        $nextHop2 = Get-AzNetworkWatcherNextHop -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -DestinationIPAddress 12.11.12.14 -SourceIPAddress $Nics[0].IpConfigurations[0].PrivateIpAddress
    
        #Verification
        Assert-AreEqual $nextHop1.NextHopType None
        Assert-AreEqual $nextHop1.NextHopIpAddress 10.0.1.2
        Assert-AreEqual $nextHop2.NextHopType Internet
        Assert-AreEqual $nextHop2.RouteTableId "System Route"
    } 
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test VerifyIPFlow NetworkWatcher API.
#>
function Test-VerifyIPFlow
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $location = Get-PilotLocation
    
    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
        
        #Get network security group
        $nsg = Get-AzNetworkSecurityGroup -ResourceGroupName $resourceGroupName

        # Set security rules
        $nsg[0] | Add-AzNetworkSecurityRuleConfig -Name scr1 -Description "test1" -Protocol Tcp -SourcePortRange * -DestinationPortRange 80 -SourceAddressPrefix * -DestinationAddressPrefix * -Access Deny -Priority 122 -Direction Outbound
        $nsg[0] | Set-AzNetworkSecurityGroup

        $nsg[0] | Add-AzNetworkSecurityRuleConfig -Name sr2 -Description "test2" -Protocol Tcp -SourcePortRange "23-45" -DestinationPortRange "46-56" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Allow -Priority 123 -Direction Inbound
        $nsg[0] | Set-AzNetworkSecurityGroup

        Wait-Seconds 300

        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName
       
        #Get private Ip address of nic
        $nic = Get-AzNetworkInterface -ResourceGroupName $resourceGroupName
        $address = $nic[0].IpConfigurations[0].PrivateIpAddress

        #Verify IP Flow
        $job = Test-AzNetworkWatcherIPFlow -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -Direction Inbound -Protocol Tcp -RemoteIPAddress 121.11.12.14 -LocalIPAddress $address -LocalPort 50 -RemotePort 40 -AsJob
        $job | Wait-Job
        $verification1 = $job | Receive-Job
        $verification2 = Test-AzNetworkWatcherIPFlow -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -Direction Outbound -Protocol Tcp -RemoteIPAddress 12.11.12.14 -LocalIPAddress $address -LocalPort 80 -RemotePort 80

        #Verification
        Assert-AreEqual $verification2.Access Deny
        Assert-AreEqual $verification2.RuleName securityRules/scr1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test NetworkConfigurationDiagnostic NetworkWatcher API.
#>
function Test-NetworkConfigurationDiagnostic
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "East US"
    
    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
        
        #Get network security group
        $nsg = Get-AzNetworkSecurityGroup -ResourceGroupName $resourceGroupName

        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName

        #Invoke network configuration diagnostic
        $profile = New-AzNetworkWatcherNetworkConfigurationDiagnosticProfile -Direction Inbound -Protocol Tcp -Source 10.1.1.4 -Destination * -DestinationPort 50 
        $result1 = Invoke-AzNetworkWatcherNetworkConfigurationDiagnostic -NetworkWatcher $nw -TargetResourceId $vm.Id -Profile $profile
        $result2 = Invoke-AzNetworkWatcherNetworkConfigurationDiagnostic -NetworkWatcher $nw -TargetResourceId $vm.Id -Profile $profile -VerbosityLevel Full

        #Verification
        Assert-AreEqual $result1.results[0].profile.direction Inbound
        Assert-AreEqual $result1.results[0].profile.protocol Tcp
        Assert-AreEqual $result1.results[0].profile.source 10.1.1.4
        Assert-AreEqual $result1.results[0].profile.destinationPort 50
        Assert-AreEqual $result1.results[0].networkSecurityGroupResult.securityRuleAccessResult Deny
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test PacketCapture API.
#>
function Test-PacketCapture
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $pcName1 = Get-NrpResourceName
    $pcName2 = Get-NrpResourceName

    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"

        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName
        

        #Install networkWatcherAgent on Vm
        Set-AzVMExtension -ResourceGroupName "$resourceGroupName" -Location "$location" -VMName $vm.Name -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher" 

        #Create filters for packet capture
        $f1 = New-AzPacketCaptureFilterConfig -Protocol Tcp -RemoteIPAddress 127.0.0.1-127.0.0.255 -LocalPort 80 -RemotePort 80-120
        $f2 = New-AzPacketCaptureFilterConfig -LocalIPAddress 127.0.0.1;127.0.0.5

        #Create packet capture
        $job = New-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -TargetVirtualMachineId $vm.Id -LocalFilePath C:\tmp\Capture.cap -Filter $f1, $f2 -AsJob
        $job | Wait-Job
        New-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2 -TargetVirtualMachineId $vm.Id -LocalFilePath C:\tmp\Capture.cap -TimeLimitInSeconds 1
        Start-TestSleep -Seconds 2

        #Get packet capture
        $job = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -AsJob
        $job | Wait-Job
        $pc1 = $job | Receive-Job
        $pc2 = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2
        $pcList = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName "*"

        #Verification
        Assert-AreEqual $pc1.Name $pcName1
        Assert-AreEqual "Succeeded" $pc1.ProvisioningState
        Assert-AreEqual $pc1.TotalBytesPerSession 1073741824
        Assert-AreEqual $pc1.BytesToCapturePerPacket 0
        Assert-AreEqual $pc1.TimeLimitInSeconds 18000
        Assert-AreEqual $pc1.Filters[0].LocalPort 80
        Assert-AreEqual $pc1.Filters[0].Protocol TCP
        Assert-AreEqual $pc1.Filters[0].RemoteIPAddress 127.0.0.1-127.0.0.255
        Assert-AreEqual $pc1.Filters[1].LocalIPAddress 127.0.0.1;127.0.0.5
        Assert-AreEqual $pc1.StorageLocation.FilePath C:\tmp\Capture.cap

        $currentCount = $pcList.Count;

        #Stop packet capture
        $job = Stop-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -AsJob
        $job | Wait-Job

        #Get packet capture
        $pc1 = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1

        #Remove packet capture
        $job = Remove-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -AsJob
        $job | Wait-Job

        #List packet captures
        $pcList = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw
        Assert-AreEqual $pcList.Count ($currentCount - 1)

        #Remove packet capture
        Remove-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test PacketCapture API.
#>
function Test-PacketCaptureV2
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $virtualMachineScaleSetName = Get-NrpResourceName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $templateFileVMSS = (Resolve-Path ".\TestData\DeploymentVMSS.json").Path
    $pcName = Get-NrpResourceName
    $pcName2 = $pcName + "1"

    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeploymentVMSS -rgn "$resourceGroupName"
        
        #Get public IP address
        $address = Get-AzPublicIpAddress -ResourceGroupName $resourceGroupName

        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"

        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        Wait-Seconds 600
        
        #Get Vmss and Instances
        $vmss = Get-AzVmss -ResourceGroupName $resourceGroupName -VMScaleSetName $virtualMachineScaleSetName

        #Install networkWatcherAgent on Vmss and Vmss Instances
        Add-AzVmssExtension -VirtualMachineScaleSet $vmss -Name "AzureNetworkWatcherExtension" -Publisher "Microsoft.Azure.NetworkWatcher" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -AutoUpgradeMinorVersion $True
        Update-AzVmss -ResourceGroupName "$resourceGroupName" -Name $virtualMachineScaleSetName -VirtualMachineScaleSet $vmss
        
        # Updating all VMSS instances with NW agent
        $instances = Get-AzVMSSVM -ResourceGroupName "$resourceGroupName" -VMScaleSetName $vmss.Name
        foreach($item in $instances) {
            Update-AzVmssInstance -ResourceGroupName "$resourceGroupName" -VMScaleSetName $vmss.Name -InstanceId $item.InstanceID
        }
        
        #Create filters for packet capture
        $f1 = New-AzPacketCaptureFilterConfig -Protocol Tcp -RemoteIPAddress 127.0.0.1-127.0.0.255 -LocalPort 80 -RemotePort 80-120
        $f2 = New-AzPacketCaptureFilterConfig -LocalIPAddress 127.0.0.1;127.0.0.5
        
        #Create Scope for packet capture
        $s1 = New-AzPacketCaptureScopeConfig -Include "0", "1"
        
        #Create packet capture
        $job = New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcher $nw -Name $pcName -TargetId $vmss.Id -TargetType "azurevmss" -LocalFilePath C:\tmp\Capture.cap -Filter $f1, $f2 -AsJob -TimeLimitInSecond 1200
        $job | Wait-Job
        $job2 = New-AzNetworkWatcherPacketCaptureV2 -NetworkWatcher $nw -Name $pcName2 -TargetId $vmss.Id -TargetType "azurevmss" -Scope $s1 -LocalFilePath C:\tmp\Capture.cap -AsJob
        $job2 | Wait-Job
        
        Start-TestSleep -Seconds 2

        #Get packet capture
        $job = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName -AsJob
        $job | Wait-Job
        $pc = $job | Receive-Job
        $job2 = Get-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2 -AsJob
        $job2 | Wait-Job
        $pc2 = $job2 | Receive-Job
        
        #Verification
        Assert-AreEqual $pc.Name $pcName
        Assert-AreEqual $pc.Filters[0].LocalPort 80
        Assert-AreEqual $pc.Filters[0].Protocol TCP
        Assert-AreEqual $pc.Filters[0].RemoteIPAddress 127.0.0.1-127.0.0.255
        Assert-AreEqual $pc.Filters[1].LocalIPAddress 127.0.0.1;127.0.0.5
        Assert-AreEqual $pc.StorageLocation.FilePath C:\tmp\Capture.cap
        Assert-AreEqual "Succeeded" $pc.ProvisioningState
        Assert-AreEqual $pc.TargetType AzureVMSS
        
        Assert-AreEqual $pc2.Name $pcName2
        Assert-AreEqual $pc2.StorageLocation.FilePath C:\tmp\Capture.cap
        Assert-AreEqual "Succeeded" $pc2.ProvisioningState
        Assert-AreEqual $pc2.TargetType AzureVMSS
        
        #Stop packet capture
        $job = Stop-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName -AsJob
        $job | Wait-Job
        $job2 = Stop-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2 -AsJob
        $job2 | Wait-Job
        
        #Remove packet capture
        $job = Remove-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName -AsJob
        $job | Wait-Job
        $job2 = Remove-AzNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2 -AsJob
        $job2 | Wait-Job
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Troubleshoot API.
#>
function Test-Troubleshoot
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $domainNameLabel = Get-NrpResourceName
    $vnetName = Get-NrpResourceName
    $publicIpName = Get-NrpResourceName
    $vnetGatewayConfigName = Get-NrpResourceName
    $gwName = Get-NrpResourceName
    
    try 
    {
        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet
 
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $resourceGroupName -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    
 
        # Create & Get virtualnetworkgateway
        $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
        $gw = New-AzVirtualNetworkGateway -ResourceGroupName $resourceGroupName -Name $gwName -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"

		# Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        # Create storage
        $stoname = 'sto' + $resourceGroupName
        $stotype = 'Standard_GRS'
        $containerName = 'cont' + $resourceGroupName

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $key = Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $stoname
        $context = New-AzStorageContext -StorageAccountName $stoname -StorageAccountKey $key[0].Value
        New-AzStorageContainer -Name $containerName -Context $context
        $container = Get-AzStorageContainer -Name $containerName -Context $context

        $sto = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        Start-AzNetworkWatcherResourceTroubleshooting -NetworkWatcher $nw -TargetResourceId $gw.Id -StorageId $sto.Id -StoragePath $container.CloudBlobContainer.StorageUri.PrimaryUri.AbsoluteUri;
		$result = Get-AzNetworkWatcherTroubleshootingResult -NetworkWatcher $nw -TargetResourceId $gw.Id

		# Validation
        Assert-AreEqual $result.code "UnHealthy"
		Assert-AreEqual $result.results[0].id "NoConnectionsFoundForGateway"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Flow log API.
#>
function Test-FlowLog
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $domainNameLabel = Get-NrpResourceName
    $nsgName = Get-NrpResourceName
	$stoname =  Get-NrpResourceName
	$workspaceName = Get-NrpResourceName
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US"
    $workspaceLocation = Get-ProviderLocation ResourceManagement "East US"
	$flowlogFormatType = "Json"
	$flowlogFormatVersion = "1"	
	$trafficAnalyticsInterval = 10;
	
    try 
    {
        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Create NetworkSecurityGroup
        $nsg = New-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $resourceGroupName -Location $location

        # Get NetworkSecurityGroup
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $resourceGroupName
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
 
        # Create storage
		$stoname = 'sto' + $stoname
        $stotype = 'Standard_GRS'

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $sto = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

		# create workspace
		$workspaceName = 'tawspace' + $workspaceName
		$workspaceSku = 'free'

		New-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -Location $workspaceLocation -Sku $workspaceSku;
		$workspace = Get-AzOperationalInsightsWorkspace -Name $workspaceName -ResourceGroupName $resourceGroupName
		
		# set operation
        $job = Set-AzNetworkWatcherConfigFlowLog -NetworkWatcher $nw -TargetResourceId $getNsg.Id -EnableFlowLog $true -StorageAccountId $sto.Id -EnableTrafficAnalytics:$true -Workspace $workspace -AsJob -FormatType $flowlogFormatType -FormatVersion $flowlogFormatVersion -TrafficAnalyticsInterval $trafficAnalyticsInterval
        $job | Wait-Job
        $config = $job | Receive-Job
		# get operation
        $job = Get-AzNetworkWatcherFlowLogStatus -NetworkWatcher $nw -TargetResourceId $getNsg.Id -AsJob
        $job | Wait-Job
        $status = $job | Receive-Job

        # Validation set operation
        Assert-AreEqual $config.TargetResourceId $getNsg.Id
        Assert-AreEqual $config.StorageId $sto.Id
        Assert-AreEqual $config.Enabled $true
        Assert-AreEqual $config.RetentionPolicy.Days 0
        Assert-AreEqual $config.RetentionPolicy.Enabled $false
		Assert-AreEqual $config.Format.Type $flowlogFormatType
		Assert-AreEqual $config.Format.Version $flowlogFormatVersion
		Assert-AreEqual $config.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled $true
		Assert-AreEqual $config.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId $workspace.ResourceId
		Assert-AreEqual $config.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId $workspace.CustomerId.ToString()
		Assert-AreEqual $config.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion $workspace.Location
		Assert-AreEqual $config.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.TrafficAnalyticsInterval $trafficAnalyticsInterval
		
		# Validation get operation
        Assert-AreEqual $status.TargetResourceId $getNsg.Id
        Assert-AreEqual $status.StorageId $sto.Id
        Assert-AreEqual $status.Enabled $true
        Assert-AreEqual $status.RetentionPolicy.Days 0
        Assert-AreEqual $status.RetentionPolicy.Enabled $false
		Assert-AreEqual $status.Format.Type  $flowlogFormatType
		Assert-AreEqual $status.Format.Version $flowlogFormatVersion
		Assert-AreEqual $status.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled $true
		Assert-AreEqual $status.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId $workspace.ResourceId
		Assert-AreEqual $status.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId $workspace.CustomerId.ToString()
		Assert-AreEqual $status.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion $workspace.Location
		Assert-AreEqual $status.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.TrafficAnalyticsInterval $trafficAnalyticsInterval
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Flow log CRUD API.
#>
function Test-CRUDNsgFlowLog
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $flowLogName = Get-NrpResourceName
    $domainNameLabel = Get-NrpResourceName
    $nsgName = Get-NrpResourceName
    $stoname =  Get-NrpResourceName
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US"

    try 
    {
        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Create NetworkSecurityGroup
        $nsg = New-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $resourceGroupName -Location $location

        # Get NetworkSecurityGroup
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $resourceGroupName
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
 
        # Create storage
        $stoname = 'sto' + $stoname
        $stotype = 'Standard_GRS'

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $sto = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        # Create flow log
        $job = New-AzNetworkWatcherFlowLog -NetworkWatcher $nw Name $flowLogName -TargetResourceId $getNsg.Id -StorageAccountId $sto.Id -Enabled $true
        $job | Wait-Job
        $config = $job | Receive-Job

        # Validation set operation
        Assert-AreEqual $config.TargetResourceId $getNsg.Id
        Assert-AreEqual $config.StorageId $sto.Id
        Assert-AreEqual $config.Enabled $true
        Assert-AreEqual $config.Format.Type "JSON"
        Assert-AreEqual $config.Format.Version 1

        # Get flow log
        $flowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName

        # Validation get operation
        Assert-AreEqual $flowLog.TargetResourceId $getNsg.Id
        Assert-AreEqual $flowLog.StorageId $sto.Id
        Assert-AreEqual $flowLog.Enabled $true
        Assert-AreEqual $flowLog.Format.Type "JSON"
        Assert-AreEqual $flowLog.Format.Version 1

        # Set flow log
        $flowLog.Format.Version = 2
        $flowLog | Set-AzNetworkWatcherFlowLog -Force

        # Get updated flowLog
        $updatedFlowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
        Assert-AreEqual $updatedFlowLog.Format.Version 2

        # Delete flow log
        Remove-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Flow log CRUD API.
#>
function Test-CRUDVnetFlowLog
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $flowLogName = Get-NrpResourceName
    $domainNameLabel = Get-NrpResourceName
    $vnetName = Get-NrpResourceName
    $stoname =  Get-NrpResourceName
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US"

    try 
    {
        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name "FlowLogSubnet" -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
 
        # Create storage
        $stoname = 'sto' + $stoname
        $stotype = 'Standard_GRS'

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $sto = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        # Create flow log
        $job = New-AzNetworkWatcherFlowLog -NetworkWatcher $nw Name $flowLogName -TargetResourceId $vnet.Id -StorageAccountId $sto.Id -Enabled $true
        $job | Wait-Job
        $config = $job | Receive-Job

        # Validation set operation
        Assert-AreEqual $config.TargetResourceId $vnet.Id
        Assert-AreEqual $config.StorageId $sto.Id
        Assert-AreEqual $config.Enabled $true
        Assert-AreEqual $config.Format.Type "JSON"
        Assert-AreEqual $config.Format.Version 1

        # Get flow log
        $flowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName

        # Validation get operation
        Assert-AreEqual $flowLog.TargetResourceId $vnet.Id
        Assert-AreEqual $flowLog.StorageId $sto.Id
        Assert-AreEqual $flowLog.Enabled $true
        Assert-AreEqual $flowLog.Format.Type "JSON"
        Assert-AreEqual $flowLog.Format.Version 1

        # Set flow log
        $flowLog.Enabled = $false
        $flowLog | Set-AzNetworkWatcherFlowLog -Force

        # Get updated flowLog
        $updatedFlowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
        Assert-AreEqual $updatedFlowLog.Enabled $false

        # Delete flow log
        Remove-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Flow log CRUD API.
#>
function Test-CRUDSubnetFlowLog
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $flowLogName = Get-NrpResourceName
    $domainNameLabel = Get-NrpResourceName
    $vnetName = Get-NrpResourceName
    $stoname =  Get-NrpResourceName
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US"

    try 
    {
        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name "FlowLogSubnet" -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name "FlowLogSubnet" -VirtualNetwork $vnet
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
 
        # Create storage
        $stoname = 'sto' + $stoname
        $stotype = 'Standard_GRS'

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $sto = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        # Create flow log
        $job = New-AzNetworkWatcherFlowLog -NetworkWatcher $nw Name $flowLogName -TargetResourceId $subnet.Id -StorageAccountId $sto.Id -Enabled $true
        $job | Wait-Job
        $config = $job | Receive-Job

        # Validation set operation
        Assert-AreEqual $config.TargetResourceId $subnet.Id
        Assert-AreEqual $config.StorageId $sto.Id
        Assert-AreEqual $config.Enabled $true
        Assert-AreEqual $config.Format.Type "JSON"
        Assert-AreEqual $config.Format.Version 1

        # Get flow log
        $flowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName

        # Validation get operation
        Assert-AreEqual $flowLog.TargetResourceId $subnet.Id
        Assert-AreEqual $flowLog.StorageId $sto.Id
        Assert-AreEqual $flowLog.Enabled $true
        Assert-AreEqual $flowLog.Format.Type "JSON"
        Assert-AreEqual $flowLog.Format.Version 1

        # Set flow log
        $flowLog.Enabled= $false
        $flowLog | Set-AzNetworkWatcherFlowLog -Force

        # Get updated flowLog
        $updatedFlowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
        Assert-AreEqual $updatedFlowLog.Enabled $false

        # Delete flow log
        Remove-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Flow log CRUD API.
#>
function Test-CRUDNicFlowLog
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $flowLogName = Get-NrpResourceName
    $domainNameLabel = Get-NrpResourceName
    $nicName = Get-NrpResourceName
    $stoname =  Get-NrpResourceName
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US"

    try 
    {
        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        $subnet = New-AzVirtualNetworkSubnetConfig -Name "FlowLogSubnet" -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name "FlowLogSubnet" -VirtualNetwork $vnet

        # Create Nic
        $nic = New-AzNetworkInterface -Location $location -Name $nicName -PrivateIpAddress '10.0.0.10' -ResourceGroupName $resourceGroupName -SubnetId $subnet.Id
        #Get nic
        $nic = Get-AzNetworkInterface -ResourceGroupName $resourceGroupName -Name $nicName
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName
 
        # Create storage
        $stoname = 'sto' + $stoname
        $stotype = 'Standard_GRS'

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $sto = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        # Create flow log
        $job = New-AzNetworkWatcherFlowLog -NetworkWatcher $nw Name $flowLogName -TargetResourceId $nic.Id -StorageAccountId $sto.Id -Enabled $true
        $job | Wait-Job
        $config = $job | Receive-Job

        # Validation set operation
        Assert-AreEqual $config.TargetResourceId $nic.Id
        Assert-AreEqual $config.StorageId $sto.Id
        Assert-AreEqual $config.Enabled $true
        Assert-AreEqual $config.Format.Type "JSON"
        Assert-AreEqual $config.Format.Version 1

        # Get flow log
        $flowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName

        # Validation get operation
        Assert-AreEqual $flowLog.TargetResourceId $nic.Id
        Assert-AreEqual $flowLog.StorageId $sto.Id
        Assert-AreEqual $flowLog.Enabled $true
        Assert-AreEqual $flowLog.Format.Type "JSON"
        Assert-AreEqual $flowLog.Format.Version 1

        # Set flow log
        $flowLog.Enabled = $false
        $flowLog | Set-AzNetworkWatcherFlowLog -Force

        # Get updated flowLog
        $updatedFlowLog = Get-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
        Assert-AreEqual $updatedFlowLog.Enabled $false

        # Delete flow log
        Remove-AzNetworkWatcherFlowLog -NetworkWatcher $nw -Name $flowLogName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test ConnectivityCheck NetworkWatcher API.
#>
function Test-ConnectivityCheck
{
    . ".\AzureRM.Resources.ps1"

    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $pcName1 = Get-NrpResourceName
    $pcName2 = Get-NrpResourceName
    $location = Get-ProviderLocation "Microsoft.Network/networkWatchers" "West Central US"
    
    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
		$nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        # Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName
        
        # Install networkWatcherAgent on Vm
        Set-AzVMExtension -ResourceGroupName "$resourceGroupName" -Location "$location" -VMName $vm.Name -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher"

		# Set up protocol configuration
		$config = New-AzNetworkWatcherProtocolConfiguration -Protocol "Http" -Method "Get" -Header @{"accept"="application/json"} -ValidStatusCode @(200,202,204)

        # Connectivity check
        $job = Test-AzNetworkWatcherConnectivity -NetworkWatcher $nw -SourceId $vm.Id -DestinationAddress "bing.com" -DestinationPort 80 -ProtocolConfiguration $config -AsJob
        $job | Wait-Job
        $check = $job | Receive-Job

        # Verification
        Assert-AreEqual $check.ConnectionStatus "Reachable"
        Assert-AreEqual $check.ProbesFailed 0
        Assert-AreEqual $check.Hops.Count 2
        Assert-True { $check.Hops[0].Type -eq "19" -or $check.Hops[0].Type -eq "VirtualMachine"}
        Assert-AreEqual $check.Hops[1].Type "Internet"
        Assert-AreEqual $check.Hops[0].Address "10.17.3.4"
    }
    finally
    {
		Assert-ThrowsContains { Test-AzNetworkWatcherConnectivity -NetworkWatcher $nw -SourceId $vm.Id -DestinationId $vm.Id -DestinationPort 80 } "Connectivity check destination resource id must not be the same as source";
		Assert-ThrowsContains { Test-AzNetworkWatcherConnectivity -NetworkWatcher $nw -SourceId $vm.Id -DestinationPort 80 } "Connectivity check missing destination resource id or address";
		Assert-ThrowsContains { Test-AzNetworkWatcherConnectivity -NetworkWatcher $nw -SourceId $vm.Id -DestinationAddress "bing.com" } "Connectivity check missing destination port";

        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test ReachabilityReport NetworkWatcher API.
#>
function Test-ReachabilityReport
{
    # Setup
    $rgname = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $location = Get-ProviderLocation $resourceTypeParent "West Central US"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $rgName

        $job = Get-AzNetworkWatcherReachabilityReport -NetworkWatcher $nw -Location "West US" -Country "United States" -StartTime "2017-10-05" -EndTime "2017-10-10" -AsJob
        $job | Wait-Job
        $report1 = $job | Receive-Job
        $report2 = Get-AzNetworkWatcherReachabilityReport -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington" -StartTime "2017-10-05" -EndTime "2017-10-10"
        $report3 = Get-AzNetworkWatcherReachabilityReport -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington" -City "seattle" -StartTime "2017-10-05" -EndTime "2017-10-10"

        Assert-AreEqual $report1.AggregationLevel "Country"
        Assert-AreEqual $report1.ProviderLocation.Country "United States"
        Assert-AreEqual $report2.AggregationLevel "State"
        Assert-AreEqual $report2.ProviderLocation.Country "United States"
        Assert-AreEqual $report2.ProviderLocation.State "washington"
        Assert-AreEqual $report3.AggregationLevel "City"
        Assert-AreEqual $report3.ProviderLocation.Country "United States"
        Assert-AreEqual $report3.ProviderLocation.State "washington"
        Assert-AreEqual $report3.ProviderLocation.City "seattle"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ProvidersList NetworkWatcher API.
#>
function Test-ProvidersList
{
    # Setup
    $rgname = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $location = Get-ProviderLocation $resourceTypeParent "West Central US"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $rgname

        $job = Get-AzNetworkWatcherReachabilityProvidersList -NetworkWatcher $nw -Location "West US" -Country "United States" -AsJob
        $job | Wait-Job
        $list1 = $job | Receive-Job
        $list2 = Get-AzNetworkWatcherReachabilityProvidersList -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington"
        $list3 = Get-AzNetworkWatcherReachabilityProvidersList -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington" -City "seattle"

        Assert-AreEqual $list1.Countries.CountryName "United States"
        Assert-AreEqual $list2.Countries.CountryName "United States"
        Assert-AreEqual $list2.Countries.States.StateName "washington"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ConnectionMonitor APIs.
#>
function Test-ConnectionMonitor
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $cmName1 = Get-NrpResourceName
    $cmName2 = Get-NrpResourceName
    # We need location version w/o spaces to work with ByLocationParamSet
    $locationMod = ($location -replace " ","").ToLower()

    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"

        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        #Get Vm
        $vm = Get-AzVM -ResourceGroupName $resourceGroupName
        
        #Install networkWatcherAgent on Vm
        Set-AzVMExtension -ResourceGroupName "$resourceGroupName" -Location "$location" -VMName $vm.Name -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher" 

        #Create connection monitor
        $job1 = New-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 80 -AsJob
        $job1 | Wait-Job
        $cm1 = $job1 | Receive-Job

        #Validation
        Assert-AreEqual $cm1.Name $cmName1
        Assert-AreEqual $cm1.Source.ResourceId $vm.Id
        Assert-AreEqual $cm1.Destination.Address bing.com
        Assert-AreEqual $cm1.Destination.Port 80

        $job2 = New-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2 -SourceResourceId $vm.Id -DestinationAddress google.com -DestinationPort 80 -AsJob
        $job2 | Wait-Job
        $cm2 = $job2 | Receive-Job

        #Validation
        Assert-AreEqual $cm2.Name $cmName2
        Assert-AreEqual $cm2.Source.ResourceId $vm.Id
        Assert-AreEqual $cm2.Destination.Address google.com
        Assert-AreEqual $cm2.Destination.Port 80
        Assert-AreEqual $cm2.MonitoringStatus Running

        # Need to run stop before Set operations

        Stop-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1
        $cm1 = Set-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 81 -ConfigureOnly -MonitoringIntervalInSeconds 50
        Assert-AreEqual $cm1.Destination.Port 81
        Assert-AreEqual $cm1.MonitoringIntervalInSeconds 50

        Stop-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1
        $cm1 = Set-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress test.com -DestinationPort 81 -MonitoringIntervalInSeconds 50
        Assert-AreEqual $cm1.Destination.Address test.com

        Stop-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1
        $cm1 = Set-AzNetworkWatcherConnectionMonitor -ResourceId $cm1.Id -SourceResourceId $vm.Id -DestinationAddress test.com -DestinationPort 80 -MonitoringIntervalInSeconds 50
        Assert-AreEqual $cm1.Destination.Port 80

        Stop-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1
        $cm1Job = Set-AzNetworkWatcherConnectionMonitor -InputObject $cm1 -SourceResourceId $vm.Id -DestinationAddress test.com -DestinationPort 81 -MonitoringIntervalInSeconds 42 -AsJob
        $cm1Job | Wait-Job
        $cm1 = $cm1Job | Receive-Job
        Assert-AreEqual $cm1.MonitoringIntervalInSeconds 42

        Stop-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1
        $cm1 = Set-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress test.com -DestinationPort 80 -MonitoringIntervalInSeconds 42
        Assert-AreEqual $cm1.Destination.Port 80

        # Stop connection monitor
        $stopJob = Stop-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2 -AsJob -PassThru
        $stopJob | Wait-Job
        $stopResult = $stopJob | Receive-Job
        Assert-AreEqual true $stopResult
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2
        Assert-AreEqual $cm2.MonitoringStatus Stopped

        # Start connection monitor
        $startJob = Start-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2 -AsJob -PassThru
        $startJob | Wait-Job
        $startResult = $startJob | Receive-Job
        Assert-AreEqual true $startResult
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2
        Assert-AreEqual $cm2.MonitoringStatus Running

        # Stop connection monitor by Location
        Stop-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cm2.Name
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cm2.Name
        Assert-AreEqual $cm2.MonitoringStatus Stopped
        
        # Start connection monitor by location
        Start-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cm2.Name
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cm2.Name
        Assert-AreEqual $cm2.MonitoringStatus Running

        # Stop connection monitor by Id
        Stop-AzNetworkWatcherConnectionMonitor -ResourceId $cm2.Id
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -ResourceId $cm2.Id
        Assert-AreEqual $cm2.MonitoringStatus Stopped

        # Start connection monitor by Id
        Start-AzNetworkWatcherConnectionMonitor -ResourceId $cm2.Id
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -ResourceId $cm2.Id
        Assert-AreEqual $cm2.MonitoringStatus Running

        # Stop connection monitor by object
        Stop-AzNetworkWatcherConnectionMonitor -InputObject $cm2
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2
        Assert-AreEqual $cm2.MonitoringStatus Stopped

        # Start connection monitor by object
        Start-AzNetworkWatcherConnectionMonitor -InputObject $cm2
        $cm2 = Get-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2
        Assert-AreEqual $cm2.MonitoringStatus Running

        # Get List
        $cms = Get-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name "*"
        Assert-NotNull $cms

        #Query connection monitor
        $report = Get-AzNetworkWatcherConnectionMonitorReport -NetworkWatcher $nw -Name $cmName1
        Assert-NotNull $report

        $report = Get-AzNetworkWatcherConnectionMonitorReport -Location $locationMod -Name $cmName1
        Assert-NotNull $report

        $report = Get-AzNetworkWatcherConnectionMonitorReport -ResourceId $cm1.Id
        Assert-NotNull $report

        $reportJob = Get-AzNetworkWatcherConnectionMonitorReport -InputObject $cm1 -AsJob
        $reportJob | Wait-Job
        $report = $reportJob | Receive-Job
        Assert-NotNull $report

        #Remove connection monitor
        Remove-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName1
        Wait-Vm $vm

        #Create connection monitor
        $job1 = New-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 80 -ConfigureOnly -MonitoringIntervalInSeconds 30 -AsJob
        $job1 | Wait-Job
        $cm1 = $job1 | Receive-Job

        Remove-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1
        Wait-Vm $vm

        #Create connection monitor
        $job1 = New-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 80 -ConfigureOnly -MonitoringIntervalInSeconds 30 -AsJob
        $job1 | Wait-Job
        $cm1 = $job1 | Receive-Job

        Remove-AzNetworkWatcherConnectionMonitor -ResourceId $cm1.Id
        Wait-Vm $vm

        #Create connection monitor
        $job1 = New-AzNetworkWatcherConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 80 -ConfigureOnly -MonitoringIntervalInSeconds 30 -AsJob
        $job1 | Wait-Job
        $cm1 = $job1 | Receive-Job

        $rmJob = Remove-AzNetworkWatcherConnectionMonitor -InputObject $cm1 -AsJob -PassThru
        $rmJob | Wait-Job
        $result = $rmJob | Receive-Job
        Wait-Vm $vm
        
        Assert-ThrowsLike { Set-AzNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name "fakeName" -SourceResourceId $vm.Id -DestinationAddress test.com -DestinationPort 80 -MonitoringIntervalInSeconds 42 } "*not*found*"

        # TODO: check if really deleted
        Remove-AzNetworkWatcher -ResourceGroupName $nw.ResourceGroupName -Name $nw.Name

        Assert-ThrowsLike { New-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 80 } "*There is no*"
        Assert-ThrowsLike { Remove-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 } "*There is no*"
        Assert-ThrowsLike { Get-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 } "*There is no*"
        Assert-ThrowsLike { Set-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress test.com -DestinationPort 80 -MonitoringIntervalInSeconds 42 } "*There is no*"
        Assert-ThrowsLike { Get-AzNetworkWatcherConnectionMonitorReport -Location $locationMod -Name $cmName1 } "*There is no*"
        Assert-ThrowsLike { Stop-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 } "*There is no*"
        Assert-ThrowsLike { Start-AzNetworkWatcherConnectionMonitor -Location $locationMod -Name $cmName1 } "*There is no*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test ConnectionMonitor-2 APIs with VMSS as Source.
#>
function Test-ConnectionMonitorWithVMSSAsSource
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFileVMSS = (Resolve-Path ".\TestData\DeploymentVMSS.json").Path
    $cmName1 = Get-NrpResourceName
    # We need location version w/o spaces to work with ByLocationParamSet
    $locationMod = ($location -replace " ","").ToLower()
    $virtualMachineScaleSetName = Get-NrpResourceName
    $vmssEndpoint = Get-NrpResourceName

    try
    {
        ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeploymentVMSS -rgn "$resourceGroupName"

        Wait-Seconds 600

        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"

        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        #Get Vmss and Instances
        $vmss = Get-AzVmss -ResourceGroupName $resourceGroupName -VMScaleSetName $virtualMachineScaleSetName

        #Install networkWatcherAgent on Vmss and Vmss Instances
        Add-AzVmssExtension -VirtualMachineScaleSet $vmss -Name "AzureNetworkWatcherExtension" -Publisher "Microsoft.Azure.NetworkWatcher" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -AutoUpgradeMinorVersion $True
        Update-AzVmss -ResourceGroupName "$resourceGroupName" -Name $virtualMachineScaleSetName -VirtualMachineScaleSet $vmss

        # To update existing VMs in VMSS, manually upgrade is required since VMSS is in Manual upgrade policy
        $instances = Get-AzVmssVM -ResourceGroupName "$resourceGroupName" -VMScaleSetName $vmss.Name
        foreach($item in $instances) {
            Update-AzVmssInstance -ResourceGroupName "$resourceGroupName" -VMScaleSetName $vmss.Name -InstanceId $item.InstanceID  # won't update simultaneously, one way is to use AsJob
        }

        $srcEndpointVMSS = New-AzNetworkWatcherConnectionMonitorEndpointObject -Name $vmssEndpoint -AzureVMSS -ResourceId $vmss.Id
        $bingEndpoint = New-AzNetworkWatcherConnectionMonitorEndpointObject -ExternalAddress -name Bing -Address "www.bing.com"

        $tcpProtocolConfiguration = New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject -TcpProtocol -Port 80
        $tcpTestConfiguration = New-AzNetworkWatcherConnectionMonitorTestConfigurationObject -Name "tcp-tc" -TestFrequencySec 60 -ProtocolConfiguration $tcpProtocolConfiguration -SuccessThresholdChecksFailedPercent 20 -SuccessThresholdRoundTripTimeMs 30

        $testGroup1 = New-AzNetworkWatcherConnectionMonitorTestGroupObject -Name "testGroup1" -TestConfiguration $tcpTestConfiguration -Source $srcEndpointVMSS -Destination $bingEndpoint

        #Create connection monitor with VMSS as source.
        $job1 = New-AzNetworkWatcherConnectionMonitor -NetworkWatcherName $nw.Name -ResourceGroupName $nw.ResourceGroupName -Name $cmName1 -TestGroup $testGroup1 -AsJob
        $job1 | Wait-Job
        $cm1 = $job1 | Receive-Job

        $rmJob = Remove-AzNetworkWatcherConnectionMonitor -InputObject $cm1 -AsJob -PassThru
        $rmJob | Wait-Job
        $result = $rmJob | Receive-Job

        #Validation
        Assert-AreEqual $cm1.Name $cmName1
        Assert-AreEqual $cm1.ProvisioningState Succeeded

        #Assert-AreEqual $tes "test"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test ConnectionMonitorConvertToV2 , convert classic connection monitor to V2.
#>
function Test-ConnectionMonitorConvertToV2
{
    # Setup
    $resourceGroupName = Get-NrpResourceGroupName
    $nwName = Get-NrpResourceName
    $location = Get-PilotLocation
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-NrpResourceGroupName
    $securityGroupName = Get-NrpResourceName
    $templateFile = (Resolve-Path ".\TestData\Deployment.json").Path
    $cmName1 = "Cmv11Feb1MigrationTaskCM"
    $location = "centraluseuap"

    try 
    {
        . ".\AzureRM.Resources.ps1"

        # Create Resource group
        New-AzResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"

        # Create Resource group for Network Watcher
        New-AzResourceGroup -Name $nwRgName -Location "$location"
        
        # Get Network Watcher
        $nw = Get-CreateTestNetworkWatcher -location $location -nwName $nwName -nwRgName $nwRgName

        # Before converting, check connection monitor exists or not
        $alreadyConverted = $true
        $cm1 = Get-AzNetworkWatcherConnectionMonitor -NetworkWatcherName $nw.Name -ResourceGroupName $nw.ResourceGroupName -Name $cmName1
        Assert-NotNull $cm1
        
        $job1 = Convert-AzNetworkWatcherClassicConnectionMonitor -ResourceGroup $nw.ResourceGroupName -NetworkWatcherName $nw.Name -Name $cm1.Name
        Assert-True { $cm1.ConnectionMonitorType -eq "MultiEndpoint" -and $job1 -eq $null}

        #Validation
        if($cm1.ConnectionMonitorType -eq "SingleSourceDestination")
        {
            Assert-NotNull $job1
        }
        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}