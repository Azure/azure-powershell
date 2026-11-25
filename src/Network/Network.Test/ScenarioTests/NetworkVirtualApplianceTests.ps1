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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Test creating new NetworkVirtualAppliance
#>
function Test-NetworkVirtualApplianceCRUD
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "barracuda sdwan release"
    $scaleunit = 1
    $version = 'latest'
    $newasn = 1271
    $asn=1270
    $prefix = "10.0.0.0/16"
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix

        $ipConfig1 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $true
        $ipConfig2 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig-2" -Primary $false
        $nicConfig1 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PublicNic" -IpConfiguration $ipConfig1, $ipConfig2
        $ipConfig3 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig" -Primary $true
        $ipConfig4 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig-2" -Primary $false
        $nicConfig2 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PrivateNic" -IpConfiguration $ipConfig3, $ipConfig4
        $networkProfile = New-AzVirtualApplianceNetworkProfile -NetworkInterfaceConfiguration $nicConfig1, $nicConfig2

        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi" -NetworkProfile $networkProfile

        Assert-NotNull $nva
        
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $getnva
        
        ## There is a bug in the update call in the nfvrp. The NfvRp team will record the powershell tests once fixed.
        # $updatednva = Update-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -VirtualApplianceAsn $newasn -Force
        # Assert-True { $updatednva.VirtualApplianceAsn -eq $newasn}

        $rmresult = Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force -PassThru
        Assert-True { $true }
   	}   
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Test Get Saas NetworkVirtualAppliance
#>
function Test-SaasNetworkVirtualApplianceGet
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $rgName = "rsapt-test"
    $location = "australiaeast"
    $nvaname = "test-nva5"
    $wanname = "wan-test"
    $hubname = "hubtest"
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    try{
        $hub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $hubname
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName  $rgName -Name $nvaname
        Assert-NotNull $getnva
        Assert-NotNull($getnva.PartnerManagedResource) 
   	}   
    finally{
        # Clean up
	}
}

<#
.SYNOPSIS
Test creating new VirtualApplianceSite
#>
function Test-VirtualApplianceSiteCRUD
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $sitename = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "barracuda sdwan release"
    $scaleunit = 1
    $version = 'latest'    
    $asn = 1270
    $prefix = "10.0.0.0/16"
    $siteprefix = "10.0.1.0/24"
    $newsiteprefix = "10.0.2.0/24"
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix
        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId /subscriptions/5e1e8156-5dec-452a-bfe5-6b6e0947c27a/resourceGroups/sliceTestRG/providers/Microsoft.Network/virtualHubs/sliceHub -Sku $sku -CloudInitConfiguration "echo hi" 
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        
        $o365Policy = New-AzOffice365PolicyProperty -Allow -Optimize
        $site = New-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -AddressPrefix $siteprefix -O365Policy $o365Policy -NetworkVirtualApplianceId $getnva.Id
        $getsite = Get-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -NetworkVirtualApplianceId $getnva.Id
        $setsite = Update-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -NetworkVirtualApplianceId $getnva.Id -AddressPrefix $newsiteprefix -Force
        Remove-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -NetworkVirtualApplianceId $getnva.Id -Force
        Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force
   	}   
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Test creating new NVA in VNet
#>
function Test-NVAInVnetCRUD
{
    $rgname = Get-ResourceGroupName
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "barracuda sdwan release"
    $scaleunit = 2
    $version = 'latest'    
    $asn = 1270
    $vnetName = "MyVNet"
    $vnetAddressPrefix = "10.1.0.0/16"
    $publicSubnetName = "publicSubnet"
    $publicSubnetPrefix = "10.1.1.0/24"
    $privateSubnetName = "privateSubnet"
    $privateSubnetPrefix = "10.1.2.0/24"

    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

         # Create the subnets
        $publicSubnet = New-AzVirtualNetworkSubnetConfig -Name $publicSubnetName -AddressPrefix $publicSubnetPrefix
        $privateSubnet = New-AzVirtualNetworkSubnetConfig -Name $privateSubnetName -AddressPrefix $privateSubnetPrefix
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix $vnetAddressPrefix -Subnet $publicSubnet, $privateSubnet

        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        # Get Subnet Resource IDs
        $publicSubnetId = ($vnet.Subnets | Where-Object { $_.Name -eq $publicSubnetName }).Id
        $privateSubnetId = ($vnet.Subnets | Where-Object { $_.Name -eq $privateSubnetName }).Id
        Assert-NotNull $publicSubnetId
        Assert-NotNull $privateSubnetId

        $privateNicConfig = New-AzNvaInterfaceConfiguration -NicType "PrivateNic" -Name "privateInterface" -SubnetId $privateSubnetId
        $publicNicConfig = New-AzNvaInterfaceConfiguration -NicType "PublicNic" -Name "publicInterface" -SubnetId $publicSubnetId

        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -NvaInterfaceConfiguration $privateNicConfig,$publicNicConfig -Sku $sku -CloudInitConfiguration "echo hi" 
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $getnva
        Assert-NotNull $getnva.NvaInterfaceConfigurations

		Start-Sleep -Seconds 600
		Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force
	}   
	finally{
		# Clean up.
		Clean-ResourceGroup $rgname
	  }
}

<#
.SYNOPSIS
Test IPv4 Hub NVA and Permanent Internet Ingress creation and same-mode idle timeout updates
#>
function Test-NetworkVirtualApplianceLoadBalancerConfigurationHub
{
    Test-NetworkVirtualApplianceLoadBalancerConfiguration -DeploymentType Hub
}

<#
.SYNOPSIS
Test IPv4 VNet NVA and Permanent Internet Ingress creation and same-mode idle timeout updates
#>
function Test-NetworkVirtualApplianceSourceIPLoadBalancerConfigurationVnet
{
    Test-NetworkVirtualApplianceLoadBalancerConfiguration -DeploymentType Vnet -LoadDistribution SourceIP
}

function Test-NetworkVirtualApplianceLoadBalancerConfiguration
{
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("Hub", "Vnet")]
        [string] $DeploymentType,

        [ValidateSet("SourceIP", "SourceIPProtocol")]
        [string] $LoadDistribution = "SourceIPProtocol"
    )

    # Recording requires existing network resources; run scenarios sequentially because they share the ingress IP.
    $rgname = "dev2-testingipv6"
    $location = "australiaeast"
    $hubname = "chainingHub"
    $vnetName = "vnet-v6"
    $inVnet = $DeploymentType -eq "Vnet"
    $publicIpName = "ipv4-test03"
    $nvaname = Get-ResourceName
    $collectionName = "lb-test-collection"
    $ruleName = "https-lb-test"
    $creationAttempted = $false
    $creationSucceeded = $false
    $scenarioError = $null

    function Assert-NvaLoadBalancerSettings($configuration, $distribution, $timeout, $stage)
    {
        Assert-NotNull $configuration "$stage did not return LoadBalancerConfiguration."
        Assert-AreEqual $distribution $configuration.LoadDistribution "$stage returned an unexpected load distribution."
        Assert-AreEqual $timeout $configuration.IdleTimeoutInMinutes "$stage returned an unexpected idle timeout."
    }

    function Assert-NvaNetworkPlacement($appliance)
    {
        if ($inVnet)
        {
            Assert-AreEqual 2 $appliance.NvaInterfaceConfigurations.Count
            $privateConfig = $appliance.NvaInterfaceConfigurations | Where-Object { $_.Name -eq "privateInterface" }
            $publicConfig = $appliance.NvaInterfaceConfigurations | Where-Object { $_.Name -eq "publicInterface" }
            Assert-NotNull $privateConfig "The private interface configuration did not round-trip."
            Assert-NotNull $publicConfig "The public interface configuration did not round-trip."
            Assert-AreEqual $privateSubnet.Id $privateConfig.Subnet.Id
            Assert-AreEqual $publicSubnet.Id $publicConfig.Subnet.Id
            Assert-True { $privateConfig.NicType -contains "PrivateNic" }
            Assert-True { $publicConfig.NicType -contains "PublicNic" }
            Assert-True { [string]::IsNullOrEmpty($appliance.VirtualHub.Id) }
        }
        else
        {
            Assert-AreEqual $hub.Id $appliance.VirtualHub.Id
        }
    }

    $networkParameters = @{}
    if ($inVnet)
    {
        $vnet = Get-AzVirtualNetwork -ResourceGroupName $rgname -Name $vnetName -ErrorAction Stop
        Assert-NotNull $vnet "The recording VNet was not found."
        Assert-AreEqual $location $vnet.Location
        $privateSubnet = $vnet.Subnets | Where-Object { $_.Name -eq "subnet1" }
        $publicSubnet = $vnet.Subnets | Where-Object { $_.Name -eq "subnet2" }
        Assert-NotNullOrEmpty $privateSubnet.Id "Private subnet subnet1 was not found."
        Assert-NotNullOrEmpty $publicSubnet.Id "Public subnet subnet2 was not found."
        $privateInterface = New-AzNvaInterfaceConfiguration -NicType PrivateNic -Name privateInterface -SubnetId $privateSubnet.Id -ErrorAction Stop
        $publicInterface = New-AzNvaInterfaceConfiguration -NicType PublicNic -Name publicInterface -SubnetId $publicSubnet.Id -ErrorAction Stop
        $networkParameters.NvaInterfaceConfiguration = @($privateInterface, $publicInterface)
    }
    else
    {
        $hub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -ErrorAction Stop
        Assert-NotNull $hub "The recording hub was not found."
        Assert-AreEqual $location $hub.Location
        $networkParameters.VirtualHubId = $hub.Id
    }

    $pip = Get-AzPublicIpAddress -ResourceGroupName $rgname -Name $publicIpName -ErrorAction Stop
    Assert-NotNull $pip "The recording ingress public IP was not found."
    Assert-AreEqual $location $pip.Location
    Assert-AreEqual "IPv4" $pip.PublicIpAddressVersion
    Assert-True { [string]::IsNullOrEmpty($pip.IpConfiguration.Id) } "The ingress public IP must not already be attached."

    $sku = New-AzVirtualApplianceSkuProperty -VendorName "fortinet-sdwan-and-ngfw" -BundledScaleUnit 2 -MarketPlaceVersion "7.6.7" -ErrorAction Stop
    $ingress = New-AzVirtualApplianceInternetIngressIpsProperty -InternetIngressPublicIpId $pip.Id -ErrorAction Stop
    $initialConfiguration = New-AzNetworkVirtualApplianceLoadBalancerConfiguration -LoadDistribution $LoadDistribution -IdleTimeoutInMinutes 5 -ErrorAction Stop

    # Record one timeout update, keeping the distribution unchanged.
    $cases = @(
        @{ Stage = "Same-mode timeout update"; Configuration = (New-AzNetworkVirtualApplianceLoadBalancerConfiguration -LoadDistribution $LoadDistribution -IdleTimeoutInMinutes 20); Distribution = $LoadDistribution; Timeout = 20 }
    )

    try
    {
        $creationAttempted = $true
        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn 65222 @networkParameters -Sku $sku -CloudInitConfiguration "echo hi" -AddressFamily "IPv4" -InternetIngressIp $ingress -LoadBalancerConfiguration $initialConfiguration -ErrorAction Stop
        $creationSucceeded = $true
        Assert-NotNull $nva
        Assert-NvaLoadBalancerSettings $nva.LoadBalancerConfiguration $LoadDistribution 5 "NVA create"

        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -ErrorAction Stop
        Assert-NvaNetworkPlacement $getnva
        Assert-AreEqual "Succeeded" $getnva.ProvisioningState
        Assert-AreEqual 1 $getnva.AddressFamily.Count
        Assert-AreEqual "IPv4" $getnva.AddressFamily[0]
        Assert-True { $getnva.InternetIngressPublicIps.Id -contains $pip.Id } "The ingress public IP did not round-trip."
        Assert-NvaLoadBalancerSettings $getnva.LoadBalancerConfiguration $LoadDistribution 5 "NVA create GET"

        # Allow live provisioning to settle before the first update, without slowing playback.
        if ((getTestMode) -ne "Playback")
        {
            Write-Verbose "Waiting 12 minutes after creation before updating test NVA '$nvaname'."
            Start-Sleep -Seconds 720
        }

        foreach ($case in $cases)
        {
            $parameters = @{
                ResourceGroupName = $rgname
                Name = $nvaname
                Tag = $getnva.Tag
                Force = $true
                ErrorAction = "Stop"
            }
            if ($null -ne $case.Configuration)
            {
                $parameters.LoadBalancerConfiguration = $case.Configuration
            }

            $updated = Update-AzNetworkVirtualAppliance @parameters
            Assert-NvaLoadBalancerSettings $updated.LoadBalancerConfiguration $case.Distribution $case.Timeout "NVA $($case.Stage)"
            $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -ErrorAction Stop
            Assert-NvaNetworkPlacement $getnva
            Assert-NvaLoadBalancerSettings $getnva.LoadBalancerConfiguration $case.Distribution $case.Timeout "NVA GET $($case.Stage)"
            Assert-AreEqual 1 $getnva.AddressFamily.Count
            Assert-AreEqual "IPv4" $getnva.AddressFamily[0]
            Assert-True { $getnva.InternetIngressPublicIps.Id -contains $pip.Id } "An update removed the ingress public IP."
        }

        $ruleCases = @(@{ Stage = "Create"; Configuration = $initialConfiguration; Distribution = $LoadDistribution; Timeout = 5 }) + $cases
        foreach ($case in $ruleCases)
        {
            $parameters = @{
                Name = $ruleName
                Protocol = "TCP"
                SourceAddressPrefix = "20.213.138.201/32"
                DestinationPortRange = 9090
                AppliesOn = $pip.Name
                ErrorAction = "Stop"
            }
            if ($null -ne $case.Configuration)
            {
                $parameters.LoadBalancerConfiguration = $case.Configuration
            }

            $rule = New-AzVirtualApplianceInboundSecurityRulesProperty @parameters
            $result = Update-AzVirtualApplianceInboundSecurityRule -ResourceGroupName $rgname -VirtualApplianceName $nvaname -Name $collectionName -RuleType Permanent -Rule $rule -Confirm:$false -ErrorAction Stop
            Assert-NotNull $result
            Assert-AreEqual 1 $result.Rules.Count
            Assert-AreEqual $ruleName $result.Rules[0].Name
            Assert-NvaLoadBalancerSettings $result.Rules[0].LoadBalancerConfiguration $case.Distribution $case.Timeout "Ingress $($case.Stage)"

            $response = Invoke-AzRestMethod -Method GET -Path "$($getnva.Id)/inboundSecurityRules/${collectionName}?api-version=2026-05-01" -ErrorAction Stop
            Assert-AreEqual 200 $response.StatusCode
            $persisted = ($response.Content | ConvertFrom-Json).properties
            Assert-AreEqual "Permanent" $persisted.ruleType
            Assert-AreEqual 1 $persisted.rules.Count
            $persistedRule = $persisted.rules[0]
            Assert-AreEqual $ruleName $persistedRule.name
            Assert-AreEqual "TCP" $persistedRule.protocol
            Assert-AreEqual "20.213.138.201/32" $persistedRule.sourceAddressPrefix
            Assert-AreEqual 9090 $persistedRule.destinationPortRange
            Assert-True { $persistedRule.appliesOn -contains $pip.Name }
            Assert-NvaLoadBalancerSettings $persistedRule.loadBalancerConfiguration $case.Distribution $case.Timeout "Ingress GET $($case.Stage)"

            # Ingress rule settings must not change the NVA internal load balancer settings.
            $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -ErrorAction Stop
            Assert-NvaLoadBalancerSettings $getnva.LoadBalancerConfiguration $LoadDistribution 20 "NVA after ingress $($case.Stage)"
        }
    }
    catch
    {
        $scenarioError = $_
        throw
    }
    finally
    {
        if ($creationAttempted)
        {
            # Only this test's NVA is removed. Never delete the shared hub, VNet, subnets, IP, or resource group.
            try
            {
                # Allow live operations to settle before cleanup, without slowing playback.
                if ((getTestMode) -ne "Playback")
                {
                    if ($inVnet -and $creationSucceeded)
                    {
                        Write-Verbose "Waiting 15 minutes before deleting test VNet NVA '$nvaname'."
                        Start-Sleep -Seconds 900
                    }
                    elseif (-not $inVnet)
                    {
                        Write-Verbose "Waiting 10 minutes before deleting test Hub NVA '$nvaname'."
                        Start-Sleep -Seconds 600
                    }
                }
                Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force -ErrorAction Stop
            }
            catch
            {
                if ($null -eq $scenarioError)
                {
                    throw
                }
                Write-Warning "Cleanup of test NVA '$nvaname' failed: $($_.Exception.Message). The original test failure is preserved."
            }
        }
    }
}

<#
.SYNOPSIS
Test creating a dual-stack (IPv4 + IPv6) NetworkVirtualAppliance in a Virtual Hub
#>
function Test-NetworkVirtualApplianceDualStackHub
{
	# Uses a pre-existing dual-stack Virtual Hub (IPv4 + IPv6) to avoid slow hub provisioning during recording.
	$rgname = "dev2-testingipv6"
	$location = "australiaeast"
	$nvaname = Get-ResourceName
	$hubname = "chainhub-03"
	$vendor = "ciscosdwan"
	$scaleunit = 2
	$version = '17.18.02'
	$asn = 65222
	try{
		$sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
		Assert-NotNull $sku

		$hub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $hubname
		Assert-NotNull $hub

		$nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi" -AddressFamily "IPv4","IPv6"
		Assert-NotNull $nva

		$getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
		Assert-NotNull $getnva
		Assert-NotNull $getnva.AddressFamily
		Assert-True { $getnva.AddressFamily -contains "IPv4" }
		Assert-True { $getnva.AddressFamily -contains "IPv6" }
	}   
	finally{
		# Clean up only the NVA created by this test; the shared hub is left intact.
		Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force
	}
}

<#
.SYNOPSIS
Test creating a dual-stack (IPv4 + IPv6) NetworkVirtualAppliance deployed in a VNet
#>
function Test-NetworkVirtualApplianceDualStackVnet
{
	# Uses a pre-existing dual-stack VNet (IPv4 + IPv6 subnets) to avoid slow VNet provisioning during recording.
	$rgname = "dev2-testingipv6"
	$location = "australiaeast"
	$nvaname = Get-ResourceName
	$vendor = "ciscosdwan"
	$scaleunit = 2
	$version = '17.18.02'
	$asn = 65222
	$vnetName = "vnet-v6"
	$publicSubnetName = "subnet2"
	$privateSubnetName = "subnet1"
	try{
		$sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
		Assert-NotNull $sku

		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$publicSubnetId = ($vnet.Subnets | Where-Object { $_.Name -eq $publicSubnetName }).Id
		$privateSubnetId = ($vnet.Subnets | Where-Object { $_.Name -eq $privateSubnetName }).Id
		Assert-NotNull $publicSubnetId
		Assert-NotNull $privateSubnetId

		$privateNicConfig = New-AzNvaInterfaceConfiguration -NicType "PrivateNic" -Name "privateInterface" -SubnetId $privateSubnetId
		$publicNicConfig = New-AzNvaInterfaceConfiguration -NicType "PublicNic" -Name "publicInterface" -SubnetId $publicSubnetId

		$nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -NvaInterfaceConfiguration $privateNicConfig,$publicNicConfig -Sku $sku -CloudInitConfiguration "echo hi" -AddressFamily "IPv4","IPv6"
		$getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
		Assert-NotNull $getnva
		Assert-NotNull $getnva.NvaInterfaceConfigurations
		Assert-NotNull $getnva.AddressFamily
		Assert-True { $getnva.AddressFamily -contains "IPv4" }
		Assert-True { $getnva.AddressFamily -contains "IPv6" }
		Start-Sleep -Seconds 900
		Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force
	}   
	finally{
		# Best-effort cleanup in case the try block exited before the delete above.
		Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force -ErrorAction SilentlyContinue
	}
}


