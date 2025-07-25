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
Tests to query load balancer health per rule..
#>
function Test-LoadBalancerHealthPerRule
{
     # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $lbName = Get-ResourceName
    $lbRuleName = Get-ResourceName
    $probeName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $vmUsername = "azureuser"
    $vmPassword = ConvertTo-SecureString "$vmUsername@123" -AsPlainText -Force
    $ipConfigName = Get-ResourceName
    $vmsize = "Standard_A2"
    $ImagePublisher = "MicrosoftWindowsServer"
    $imageOffer = "WindowsServer"
    $imageSKU = "2019-Datacenter-GS"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -sku Standard

        # Create LoadBalancer
        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicip

        $bepool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName

        $probe = @{
            Name              = $probeName
            Protocol          = 'tcp'
            Port              = '80'
            IntervalInSeconds = '360'
            ProbeCount        = '5'
        }
        $healthprobe = New-AzLoadBalancerProbeConfig @probe

        $lbrule = @{
            Name                    = $lbRuleName
            Protocol                = 'tcp'
            FrontendPort            = '80'
            BackendPort             = '80'
            IdleTimeoutInMinutes    = '15'
            FrontendIpConfiguration = $frontend
            BackendAddressPool      = $bePool
            Probe                   = $healthprobe
        }
        $rule = New-AzLoadBalancerRuleConfig @lbrule -EnableTcpReset -DisableOutboundSNAT

        $loadbalancer = @{
            ResourceGroupName       = $rgName
            Name                    = $lbName
            Location                = $rglocation
            Sku                     = 'Standard'
            FrontendIpConfiguration = $frontend
            BackendAddressPool      = $bePool
            LoadBalancingRule       = $rule
            Probe                   = $healthprobe
        }
        $lb = New-AzLoadBalancer @loadbalancer

        $cred = New-Object System.Management.Automation.PSCredential ($vmUsername, $vmPassword);
        
        $RdpPublicIP = New-AzPublicIpAddress -Name "RdpPublicIP" -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceGroup.Location -AllocationMethod Static -Sku Standard -IpAddressVersion IPv4
    
        # both LB pool and Instance Level public ip for RPD
        $Ip4Config = New-AzNetworkInterfaceIpConfig -Name $ipConfigName -Subnet $vnet.subnets[0] -PrivateIpAddressVersion IPv4 -LoadBalancerBackendAddressPool $bepool -PublicIpAddress $RdpPublicIP
    
        $NIC = New-AzNetworkInterface -Name "NIC" -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceGroup.Location -NetworkSecurityGroupId $nsg.Id -IpConfiguration $Ip4Config 
    
        $vmName = "myVM"
        $VMconfig = New-AzVMConfig -VMName $vmName -VMSize $vmsize
        | Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $cred -ProvisionVMAgent 3> $null
        | Set-AzVMSourceImage -PublisherName $ImagePublisher -Offer $imageOffer -Skus $imageSKU -Version "latest" 3> $null
        | Set-AzVMOSDisk -Name "$vmName.vhd" -CreateOption fromImage  3> $null | Add-AzVMNetworkInterface -Id $NIC.Id  3> $null 
    
        $VM = New-AzVM -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceGroup.Location  -VM $VMconfig

        # install IIS (port 80)
        $ext = @{
            Publisher          = 'Microsoft.Compute'
            ExtensionType      = 'CustomScriptExtension'
            ExtensionName      = 'IIS'
            ResourceGroupName  = $rgName
            VMName             = "myVM"
            Location           = $region
            TypeHandlerVersion = '1.8'
            SettingString      = '{"commandToExecute":"powershell Add-WindowsFeature Web-Server; powershell Add-Content -Path \"C:\\inetpub\\wwwroot\\Default.htm\" -Value $($env:computername)"}'
        }
        Set-AzVMExtension @ext -AsJob
        
        # List
        $list = Get-AzLoadBalancerRuleHealth -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $lbruleName

        Assert-True { @($list.LoadBalancerBackendAddresses).Count -eq 1}
        Assert-AreEqual $list.LoadBalancerBackendAddresses[0].IpAddress "10.0.1.4"
        Assert-True { $list.Down.Count -eq 1}
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}