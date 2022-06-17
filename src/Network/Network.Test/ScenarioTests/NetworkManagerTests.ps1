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
Tests creating new simple public networkmanager
#>
function Test-NetworkManagerCRUD
{
    # Setup
    # Need to update subscriptionId before runing in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add($subscriptionId)
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses[0] "Connectivity";
        Assert-AreEqual $networkManager.NetworkManagerScopes.Subscriptions[0] $subscriptionId;

        $networkManager.NetworkManagerScopeAccesses.Add("SecurityAdmin");
        $newNetworkManager = Set-AzNetworkManager -ResourceGroupName $rgname -NetworkManager $networkManager
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses[0] "Connectivity";
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses[1] "SecurityAdmin";

        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating new simple public networkmanager group
#>
function Test-NetworkManagerGroupCRUD
{
    # Setup
    # Need to update $subscriptionId and vnetid before running in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add($subscriptionId)
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -MemberType "Microsoft.Network/VirtualNetwork" -Description "SampleDESCRIption" 

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;

        $networkGroup.Description = "A different description."
        $networkGroup.MemberType = "Microsoft.Network/VirtualNetwork"
        $newNetworkGroup = Set-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroup $networkGroup
        Assert-NotNull $newNetworkGroup;
        Assert-AreEqual "A different description." $newNetworkGroup.Description;
        Assert-AreEqual $networkGroupName $newNetworkGroup.Name;

        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job; 
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating new simple public networkmanager staticmember
#>
function Test-NetworkManagerStaticMemberCRUD
{
    # Setup
    # Need to update $subscriptionId and vnetid before running in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"
    $vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/testvnet"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add($subscriptionId)
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        # Create network manager
        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        # Create network group
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -MemberType "Microsoft.Network/VirtualNetwork" -Description "SampleDESCRIption"
        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;

        # Create static member
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $networkManagerStaticMember = Get-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName
        Assert-NotNull $networkManagerStaticMember;
        Assert-AreEqual $staticMemberName $networkManagerStaticMember.Name;

        $newNetworkStaticMember = Set-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -StaticMember $networkManagerStaticMember
        Assert-NotNull $newNetworkStaticMember;
        Assert-AreEqual $staticMemberName $newNetworkStaticMember.Name;

        # Remove static member
        $job = Remove-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Remove network group
        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Remove network manager
        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating new simple public networkmanager Connectivity Configuration
#>
function Test-NetworkManagerConnectivityConfigurationCRUD
{
    # Setup
    # Please pre create vnet and hub vnet before running test in live mode, also please update subscriptionId and uncomment 10 mins sleep code
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $connectivityConfigurationName = Get-ResourceName
    $rglocation = "eastus2euap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"
    $vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/testvnet"
    $hubId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/hub" 
    $vnet = "testvnet"
    $vnetRG = "testRG"
    
    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add($subscriptionId)
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -MemberType "Microsoft.Network/VirtualNetwork" -Description "SampleDESCRIption"
        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;

        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $networkGroup.Id
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]]$connectivityGroup  = @()  
        $connectivityGroup.Add($connectivityGroupItem)   

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub]]$hubList  = @() 
        $hub = New-AzNetworkManagerHub -ResourceId $hubId -ResourceType "Microsoft.Network/virtualNetworks" 
        $hubList.Add($hub)

        New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -Name $connectivityConfigurationName -NetworkManagerName $networkManagerName -ConnectivityTopology "HubAndSpoke" -Hub $hublist -AppliesToGroup $connectivityGroup -DeleteExistingPeering 

        $connConfig = Get-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $connectivityConfigurationName 
        Assert-NotNull $connConfig;
        Assert-AreEqual $connectivityConfigurationName $connConfig.Name;
        Assert-AreEqual "HubAndSpoke" $connConfig.ConnectivityTopology;
        Assert-AreEqual $networkGroup.Id $connConfig.AppliesToGroups[0].NetworkGroupId;
        Assert-AreEqual "None"  $connConfig.AppliesToGroups[0].GroupConnectivity;
        Assert-AreEqual "False"  $connConfig.AppliesToGroups[0].IsGlobal;
        Assert-AreEqual "False"  $connConfig.AppliesToGroups[0].UseHubGateway;
        Assert-AreEqual $hubId  $connConfig.Hubs[0].ResourceId;
        Assert-AreEqual "Microsoft.Network/virtualNetworks" $connConfig.Hubs[0].ResourceType;
        Assert-AreEqual "False"  $connConfig.IsGlobal;
        Assert-AreEqual "True"  $connConfig.DeleteExistingPeering;

        $connConfig.Description = "A different description.";
        $newConnConfig = Set-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkManagerConnectivityConfiguration $connConfig
        Assert-NotNull $newConnConfig;
        Assert-AreEqual "A different description." $newConnConfig.Description;
        Assert-AreEqual $connectivityConfigurationName $newConnConfig.Name;


        [System.Collections.Generic.List[string]]$configids  = @()
        $configids.Add($newConnConfig.Id);
        [System.Collections.Generic.List[String]]$regions = @()  
        $regions.Add($rglocation)
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "Connectivity" 
        # Start-Sleep -Seconds 600
         
        $deploymentStatus = Get-AzNetworkManagerDeploymentStatusList -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "Connectivity"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "Connectivity"  $deploymentStatus.Value[0].DeploymentType;

        $activeConnectivityConfig = Get-AzNetworkManagerActiveConnectivityConfigurationList -NetworkManagerName $networkManagerName -ResourceGroupName $rgname -region $regions
        Assert-NotNull $activeConnectivityConfig;
        Assert-AreEqual  $newConnConfig.Id $activeConnectivityConfig.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $activeConnectivityConfig.Value[0].ConfigurationGroups[0].Id;
        Assert-AreEqual $rglocation  $activeConnectivityConfig.Value[0].Region;
        Assert-AreEqual "HubAndSpoke" $activeConnectivityConfig.Value[0].ConnectivityTopology
        Assert-AreEqual $networkGroup.Id $activeConnectivityConfig.Value[0].AppliesToGroups[0].NetworkGroupId;
        Assert-AreEqual "None"   $activeConnectivityConfig.Value[0].AppliesToGroups[0].GroupConnectivity;
        Assert-AreEqual "False"   $activeConnectivityConfig.Value[0].AppliesToGroups[0].IsGlobal;
        Assert-AreEqual "False"   $activeConnectivityConfig.Value[0].AppliesToGroups[0].UseHubGateway;
        Assert-AreEqual $hubId   $activeConnectivityConfig.Value[0].Hubs[0].ResourceId;
        Assert-AreEqual "Microsoft.Network/virtualNetworks"  $activeConnectivityConfig.Value[0].Hubs[0].ResourceType;
        Assert-AreEqual "False"   $activeConnectivityConfig.Value[0].IsGlobal;
        Assert-AreEqual "True"   $activeConnectivityConfig.Value[0].DeleteExistingPeering;

        $effectiveConnectivityConfig = Get-AzNetworkManagerEffectiveConnectivityConfigurationList -VirtualNetworkName $vnet -ResourceGroupName $vnetRG
        Assert-NotNull $effectiveConnectivityConfig;
        Assert-AreEqual  $newConnConfig.Id $effectiveConnectivityConfig.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveConnectivityConfig.Value[0].ConfigurationGroups[0].Id;
        Assert-AreEqual "HubAndSpoke" $effectiveConnectivityConfig.Value[0].ConnectivityTopology
        Assert-AreEqual $networkGroup.Id $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].NetworkGroupId;
        Assert-AreEqual "None"   $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].GroupConnectivity;
        Assert-AreEqual "False"   $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].IsGlobal;
        Assert-AreEqual "False"   $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].UseHubGateway;
        Assert-AreEqual $hubId   $effectiveConnectivityConfig.Value[0].Hubs[0].ResourceId;
        Assert-AreEqual "Microsoft.Network/virtualNetworks"  $effectiveConnectivityConfig.Value[0].Hubs[0].ResourceType;
        Assert-AreEqual "False"   $effectiveConnectivityConfig.Value[0].IsGlobal;
        Assert-AreEqual "True"   $effectiveConnectivityConfig.Value[0].DeleteExistingPeering;

        $job = Remove-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $connectivityConfigurationName -ForceDelete -PassThru -Force -AsJob;
        # Start-Sleep -Seconds 600
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}


<#
.SYNOPSIS
Tests creating/getting/deleting new simple public networkmanager security admin Configuration/RuleCollection/Rule
#>
function Test-NetworkManagerSecurityAdminRuleCRUD
{
    # Setup
    # Need to update $subscriptionId/vnetid before running in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $SecurityConfigurationName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"
    $vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/vnet3"
    $vnetName = "vnet3"
    $vnetRG = "testRG"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add($subscriptionId)
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("SecurityAdmin");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -MemberType "Microsoft.Network/VirtualNetwork" -Description "SampleConfigDESCRIption"

        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        [System.Collections.Generic.List[string]]$ApplyOnNetworkIntentPolicyBasedServices  = @()
        $ApplyOnNetworkIntentPolicyBasedServices.Add("None")
        New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -Description "DESCription" -DeleteExistingNSG -ApplyOnNetworkIntentPolicyBasedService $ApplyOnNetworkIntentPolicyBasedServices
        
        $securityConfig = Get-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual $ApplyOnNetworkIntentPolicyBasedServices $securityConfig.ApplyOnNetworkIntentPolicyBasedServices;

        $securityConfig.Description = "A different description."
        $securityConfig = Set-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkManagerSecurityAdminConfiguration $securityConfig
        Assert-NotNull $securityConfig;
        Assert-AreEqual "A different description." $securityConfig.Description;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)

        New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 

        $ruleCollection = Get-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual  $networkGroup.Id $ruleCollection.AppliesToGroups[0].NetworkGroupId;

        $ruleCollection.Description = "Sample rule Collection Description"
        $ruleCollection = Set-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -NetworkManagerSecurityAdminRuleCollection $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Sample rule Collection Description" $ruleCollection.Description;
 
        $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
        $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 

        [System.Collections.Generic.List[string]]$sourcePortList = @()
        $sourcePortList.Add("100")
        [System.Collections.Generic.List[String]]$destinationPortList = @()
        $destinationPortList.Add("99");
        New-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Description "Description" -Protocol  "TCP" -Direction "Inbound" -Access "Allow" -Priority 100 -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -Source $sourceAddressPrefix -Destination $destinationAddressPrefix 

        $adminRule = Get-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName
        Assert-NotNull $adminRule
        Assert-AreEqual $RuleName $adminRule.Name 
        Assert-AreEqual "TCP" $adminRule.Protocol 
        Assert-AreEqual "Inbound" $adminRule.Direction 
        Assert-AreEqual "Allow" $adminRule.Access 
        Assert-AreEqual 100 $adminRule.Priority

        Assert-AreEqual "100" $adminRule.SourcePortRanges[0] 
        Assert-AreEqual "99" $adminRule.DestinationPortRanges[0]
        Assert-AreEqual "10.0.0.1" $adminRule.Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $adminRule.Sources[0].AddressPrefix

        $newAdminRule = Set-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -SecurityAdminRule $adminRule
        Assert-NotNull $newAdminRule;
        Assert-AreEqual $RuleName $newAdminRule.Name;

        [System.Collections.Generic.List[string]]$configids  = @()
        $configids.Add($securityConfig.Id);
        [System.Collections.Generic.List[String]]$regions = @()  
        $regions.Add($rglocation)
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "SecurityAdmin" 
        # Start-Sleep -Seconds 600
       
        $deploymentStatus = Get-AzNetworkManagerDeploymentStatusList -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "SecurityAdmin"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "SecurityAdmin"  $deploymentStatus.Value[0].DeploymentType;
        Assert-AreEqual $securityConfig.Id  $deploymentStatus.Value[0].ConfigurationIds[0];

        $activeSecurityAdminRule = Get-AzNetworkManagerActiveSecurityAdminRuleList -NetworkManagerName $networkManagerName -ResourceGroupName $rgname -region $regions
        Assert-NotNull $activeSecurityAdminRule;
        Assert-AreEqual  $newAdminRule.Id $activeSecurityAdminRule.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $activeSecurityAdminRule.Value[0].RuleGroups[0].Id;
        Assert-AreEqual  $networkGroup.Id $activeSecurityAdminRule.Value[0].RuleCollectionAppliesToGroups[0].NetworkGroupId;
        Assert-AreEqual $rglocation  $activeSecurityAdminRule.Value[0].Region;
        Assert-AreEqual $securityConfig.Description $activeSecurityAdminRule.Value[0].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.Description $activeSecurityAdminRule.Value[0].RuleCollectionDescription;

        Assert-AreEqual "TCP" $activeSecurityAdminRule.Value[0].Protocol 
        Assert-AreEqual "Inbound" $activeSecurityAdminRule.Value[0].Direction 
        Assert-AreEqual "Allow" $activeSecurityAdminRule.Value[0].Access 
        Assert-AreEqual 100 $activeSecurityAdminRule.Value[0].Priority

        Assert-AreEqual "100" $activeSecurityAdminRule.Value[0].SourcePortRanges[0] 
        Assert-AreEqual "99" $activeSecurityAdminRule.Value[0].DestinationPortRanges[0]
        Assert-AreEqual "10.0.0.1" $activeSecurityAdminRule.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $activeSecurityAdminRule.Value[0].Sources[0].AddressPrefix

        $effectiveSecurityAdminRule = Get-AzNetworkManagerEffectiveSecurityAdminRuleList  -VirtualNetworkName $vnetName -ResourceGroupName $vnetRG
        Assert-NotNull $effectiveSecurityAdminRule;
        Assert-AreEqual  $newAdminRule.Id $effectiveSecurityAdminRule.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRule.Value[0].RuleGroups[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRule.Value[0].RuleCollectionAppliesToGroups[0].NetworkGroupId;
       

        Assert-AreEqual $securityConfig.Description $effectiveSecurityAdminRule.Value[0].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.Description $effectiveSecurityAdminRule.Value[0].RuleCollectionDescription;

        Assert-AreEqual "TCP" $effectiveSecurityAdminRule.Value[0].Protocol 
        Assert-AreEqual "Inbound" $effectiveSecurityAdminRule.Value[0].Direction 
        Assert-AreEqual "Allow" $effectiveSecurityAdminRule.Value[0].Access 
        Assert-AreEqual 100 $effectiveSecurityAdminRule.Value[0].Priority

        Assert-AreEqual "100" $effectiveSecurityAdminRule.Value[0].SourcePortRanges[0] 
        Assert-AreEqual "99" $effectiveSecurityAdminRule.Value[0].DestinationPortRanges[0]
        Assert-AreEqual "10.0.0.1" $effectiveSecurityAdminRule.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $effectiveSecurityAdminRule.Value[0].Sources[0].AddressPrefix

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "SecurityAdmin" 
        # Start-Sleep -Seconds 600

        $job = Remove-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -Name $RuleCollectionName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests NetworkManagerEffectiveVirtualNetworkList
#>
function Test-NetworkManagerEffectiveVirtualNetworkList
{
    # Setup
    # Need to deploy commit on vnets before running this test in live mode
    $rgName = "pstest"
    $networkManagerName = "testnm"
    $networkGroupName = "testng2"
    $rglocation = "centraluseuap"
    

    try{
        $vnetList = Get-AzNetworkManagerEffectiveVirtualNetworkByNetworkGroupList -NetworkGroupName $networkGroupName -NetworkManagerName $networkManagerName -ResourceGroupName $rgname
        Assert-NotNull $vnetList
        Assert-AreEqual "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/pstest/providers/Microsoft.Network/virtualNetworks/pstestvent" $vnetList.Value[0].Id 
        Assert-AreEqual $rglocation $vnetList.Value[0].Location 
        Assert-AreEqual "Dynamic" $vnetList.Value[0].MembershipType

        $conditionalMember = "{`"allOf`": [{`"value`": `"[resourceGroup().Name]`", `"equals`": `"pstest`"}]}"
        $vnetList = Get-AzNetworkManagerEffectiveVirtualNetworkList -NetworkManagerName $networkManagerName -ResourceGroupName $rgname -ConditionalMember $conditionalMember
        Assert-NotNull $vnetList
        Assert-AreEqual "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/pstest/providers/Microsoft.Network/virtualNetworks/pstestvent" $vnetList.Value[0].Id 
        Assert-AreEqual $rglocation $vnetList.Value[0].Location 
        Assert-AreEqual "Dynamic" $vnetList.Value[0].MembershipType
	}
    finally{
	}
}

<#
.SYNOPSIS
Tests creating new simple public network manager scope connection
#>
function Test-NetworkManagerScopeConnectionCRUD
{
    # Setup
    # Need to update $subscriptionId and vnetid before running in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $scopeConnectionName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add($subscriptionId)
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerScopeConnection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $scopeConnectionName -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47" -ResourceId $subscriptionId -Description "SampleDescription" 

        $scopeConnection = Get-AzNetworkManagerScopeConnection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $scopeConnectionName 
        Assert-NotNull $scopeConnection;
        Assert-AreEqual $scopeConnectionName $scopeConnection.Name;

        $scopeConnection.Description = "A Different Description.";
        $newScopeConnection = Set-AzNetworkManagerScopeConnection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkManagerScopeConnection $scopeConnection
        Assert-NotNull $newScopeConnection;
        Assert-AreEqual "A Different Description." $newScopeConnection.Description;
        Assert-AreEqual $scopeConnectionName $newScopeConnection.Name;

        $job = Remove-AzNetworkManagerScopeConnection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $scopeConnectionName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating/getting/deleting network manager connection on a subscription
#>
function Test-NetworkManagerSubscriptionConnectionCRUD
{
    # Setup
    $networkManagerConnectionName = Get-ResourceName
    $networkManagerId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/PSTestResources/providers/Microsoft.Network/networkManagers/PSTestNM"

    try{
        New-AzNetworkManagerSubscriptionConnection -Name $networkManagerConnectionName -NetworkManagerId $networkManagerId -Description "SampleDescription" 
        $networkManagerConnection = Get-AzNetworkManagerSubscriptionConnection -Name $networkManagerConnectionName
        Assert-NotNull $networkManagerConnection;
        Assert-AreEqual $networkManagerConnectionName $networkManagerConnection.Name;

        $networkManagerConnection.Description = "A Different Description."
        $newNetworkManagerConnection = Set-AzNetworkManagerSubscriptionConnection -NetworkManagerSubscriptionConnection $networkManagerConnection
        Assert-NotNull $newNetworkManagerConnection;
        Assert-AreEqual "A Different Description." $newNetworkManagerConnection.Description;
        Assert-AreEqual $networkManagerConnectionName $newNetworkManagerConnection.Name;

        $job = Remove-AzNetworkManagerSubscriptionConnection -Name $networkManagerConnectionName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
	}
}

<#
.SYNOPSIS
Tests creating/getting/deleting network manager connection on a management group
#>
function Test-NetworkManagerManagementGroupConnectionCRUD
{
    # Setup
    $networkManagerConnectionName = Get-ResourceName
    $networkManagerId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/PSTestResources/providers/Microsoft.Network/networkManagers/PSTestNM"
    $managementGroupId = "SDKTestMG"

    try{
        New-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -Name $networkManagerConnectionName -NetworkManagerId $networkManagerId -Description "SampleDescription" 
        $networkManagerConnection = Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -Name $networkManagerConnectionName
        Assert-NotNull $networkManagerConnection;
        Assert-AreEqual $networkManagerConnectionName $networkManagerConnection.Name;

        $networkManagerConnection.Description = "A Different Description."
        $newNetworkManagerConnection = Set-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -NetworkManagerManagementGroupConnection $networkManagerConnection
        Assert-NotNull $newNetworkManagerConnection;
        Assert-AreEqual "A Different Description." $newNetworkManagerConnection.Description;
        Assert-AreEqual $networkManagerConnectionName $newNetworkManagerConnection.Name;

        $job = Remove-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -Name $networkManagerConnectionName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
	}
}