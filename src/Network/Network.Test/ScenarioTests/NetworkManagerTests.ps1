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
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $managementGroupId = "/providers/Microsoft.Management/managementGroups/SwaggerStackTestMG"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $managementGroups  = @($managementGroupId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions -ManagementGroup $managementGroups

        # Define access
        $access  = @("Connectivity")

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses "Connectivity";
        Assert-AreEqual $networkManager.NetworkManagerScope.Subscription $scope.Subscription;
        Assert-AreEqual $networkManager.NetworkManagerScope.ManagementGroup $scope.ManagementGroup;

        # Update access
        $networkManager.NetworkManagerScopeAccesses.Add("SecurityAdmin");
        $newNetworkManager = Set-AzNetworkManager -InputObject $networkManager
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses[0] "Connectivity";
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses[1] "SecurityAdmin";

        # Delete network manager
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
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("Connectivity")
        $scope = New-AzNetworkManagerScope -Subscription $group

        # Create a network manager
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation
        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        # Create a network group
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -Description "Sample description" 

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;

        # Update a network group
        $networkGroup.Description = "A different description."
        $newNetworkGroup = Set-AzNetworkManagerGroup -InputObject $networkGroup
        Assert-NotNull $newNetworkGroup;
        Assert-AreEqual "A different description." $newNetworkGroup.Description;
        Assert-AreEqual $networkGroupName $newNetworkGroup.Name;

        # Remove a network group
        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job; 
        $removeResult = $job | Receive-Job;

        # Remove a network manager
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
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("Connectivity")
        $scope = New-AzNetworkManagerScope -Subscription $group

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation
        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        # Create network group
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -Description "SampleDESCRIption"
        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;

        # Create static member
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $networkManagerStaticMember = Get-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName
        Assert-NotNull $networkManagerStaticMember;
        Assert-AreEqual $staticMemberName $networkManagerStaticMember.Name;

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
    # Please update subscriptionId and uncomment 1 mins sleep code
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $connectivityConfigurationName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"
    $hubId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet-Hub" 
    $vnetName = "SwaggerStackVnet"
    $vnetRGName = "SwaggerStackRG"
    
    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("Connectivity")
        $scope = New-AzNetworkManagerScope -Subscription $group
        
        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation
        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        # Create network group
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -Description "SampleDESCRIption"
        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;

        # Create static member
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $networkGroup.Id
        $connectivityGroup  = @($connectivityGroupItem)  

        $hub = New-AzNetworkManagerHub -ResourceId $hubId -ResourceType "Microsoft.Network/virtualNetworks" 
        $hubList = @($hub) 

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
        $newConnConfig = Set-AzNetworkManagerConnectivityConfiguration -InputObject $connConfig
        Assert-NotNull $newConnConfig;
        Assert-AreEqual "A different description." $newConnConfig.Description;
        Assert-AreEqual $connectivityConfigurationName $newConnConfig.Name;


        $configids  = @($newConnConfig.Id)
        $regions = @($rglocation)  
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "Connectivity" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60

        $deploymentStatus = Get-AzNetworkManagerDeploymentStatus -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "Connectivity"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "Connectivity"  $deploymentStatus.Value[0].DeploymentType;

        $activeConnectivityConfig = Get-AzNetworkManagerActiveConnectivityConfiguration -NetworkManagerName $networkManagerName -ResourceGroupName $rgname -region $regions
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

        $effectiveConnectivityConfig = Get-AzNetworkManagerEffectiveConnectivityConfiguration -VirtualNetworkName $vnetName -VirtualNetworkResourceGroupName $vnetRGName
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

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60

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
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"
    $vnetName = "SwaggerStackVnet"
    $vnetRGName = "SwaggerStackRG"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("SecurityAdmin")
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -Description "SampleConfigDESCRIption"

        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        $ApplyOnNetworkIntentPolicyBasedServices = @("none")
        New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -Description "DESCription" -DeleteExistingNSG -ApplyOnNetworkIntentPolicyBasedService $ApplyOnNetworkIntentPolicyBasedServices
        
        $securityConfig = Get-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual $ApplyOnNetworkIntentPolicyBasedServices $securityConfig.ApplyOnNetworkIntentPolicyBasedServices;

        $ApplyOnNetworkIntentPolicyBasedServices = @()
        $securityConfig.Description = "A different description."
        $securityConfig.ApplyOnNetworkIntentPolicyBasedServices = $ApplyOnNetworkIntentPolicyBasedServices
        $securityConfig = Set-AzNetworkManagerSecurityAdminConfiguration -InputObject $securityConfig
        Assert-NotNull $securityConfig;
        Assert-AreEqual "A different description." $securityConfig.Description;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual $ApplyOnNetworkIntentPolicyBasedServices $securityConfig.ApplyOnNetworkIntentPolicyBasedServices;

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)

        New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 

        $ruleCollection = Get-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual  $networkGroup.Id $ruleCollection.AppliesToGroups[0].NetworkGroupId;

        $ruleCollection.Description = "Sample rule Collection Description"
        $ruleCollection = Set-AzNetworkManagerSecurityAdminRuleCollection -InputObject $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Sample rule Collection Description" $ruleCollection.Description;
 
        $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
        $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 

        $sourcePortList = @("100")
        $destinationPortList = @("99")
        New-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Description "Description" -Protocol  "TCP" -Direction "Inbound" -Access "Allow" -Priority 100 -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefix -DestinationAddressPrefix $destinationAddressPrefix 

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

        $newAdminRule = Set-AzNetworkManagerSecurityAdminRule -InputObject $adminRule
        Assert-NotNull $newAdminRule;
        Assert-AreEqual $RuleName $newAdminRule.Name;

        $configids  = @($securityConfig.Id)
        $regions = @($rglocation)  
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "SecurityAdmin" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60
       
        $deploymentStatus = Get-AzNetworkManagerDeploymentStatus -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "SecurityAdmin"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "SecurityAdmin"  $deploymentStatus.Value[0].DeploymentType;
        Assert-AreEqual $securityConfig.Id  $deploymentStatus.Value[0].ConfigurationIds[0];

        $activeSecurityAdminRule = Get-AzNetworkManagerActiveSecurityAdminRule -NetworkManagerName $networkManagerName -ResourceGroupName $rgname -region $regions
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

        $effectiveSecurityAdminRuleList = Get-AzNetworkManagerEffectiveSecurityAdminRule  -VirtualNetworkName $vnetName -VirtualNetworkResourceGroupName $vnetRGName
        Assert-NotNull $effectiveSecurityAdminRuleList;

        Assert-AreEqual  $newAdminRule.Id $effectiveSecurityAdminRuleList.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRuleList.Value[0].RuleGroups[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRuleList.Value[0].RuleCollectionAppliesToGroups[0].NetworkGroupId;


        Assert-AreEqual $securityConfig.Description $effectiveSecurityAdminRuleList.Value[0].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.Description $effectiveSecurityAdminRuleList.Value[0].RuleCollectionDescription;

        Assert-AreEqual "TCP" $effectiveSecurityAdminRuleList.Value[0].Protocol 
        Assert-AreEqual "Inbound" $effectiveSecurityAdminRuleList.Value[0].Direction 
        Assert-AreEqual "Allow" $effectiveSecurityAdminRuleList.Value[0].Access 
        Assert-AreEqual 0 $effectiveSecurityAdminRuleList.Value[0].Priority

        Assert-AreEqual "100" $effectiveSecurityAdminRuleList.Value[0].SourcePortRanges[0] 
        Assert-AreEqual "99" $effectiveSecurityAdminRuleList.Value[0].DestinationPortRanges[0]
        Assert-AreEqual "10.0.0.1" $effectiveSecurityAdminRuleList.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $effectiveSecurityAdminRuleList.Value[0].Sources[0].AddressPrefix

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "SecurityAdmin" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60

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
Tests creating/getting/deleting new public networkmanager security admin Configuration/RuleCollection/Rule with manual aggregation option
#>
function Test-NetworkManagerSecurityAdminRuleManualAggregationCRUD
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
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"
    $vnetName = "SwaggerStackVnet"
    $vnetRGName = "SwaggerStackRG"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("SecurityAdmin")
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -Description "SampleConfigDESCRIption"

        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -Description "DESCription" -DeleteExistingNSG -NetworkGroupAddressSpaceAggregationOption "Manual"
    
        $securityConfig = Get-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual "Manual" $securityConfig.NetworkGroupAddressSpaceAggregationOption;

        $securityConfig.Description = "A different description."
        $securityConfig = Set-AzNetworkManagerSecurityAdminConfiguration -InputObject $securityConfig
        Assert-NotNull $securityConfig;
        Assert-AreEqual "A different description." $securityConfig.Description;
         Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual "Manual" $securityConfig.NetworkGroupAddressSpaceAggregationOption;

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)

        New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 

        $ruleCollection = Get-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual  $networkGroup.Id $ruleCollection.AppliesToGroups[0].NetworkGroupId;

        $ruleCollection.Description = "Sample rule Collection Description"
        $ruleCollection = Set-AzNetworkManagerSecurityAdminRuleCollection -InputObject $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Sample rule Collection Description" $ruleCollection.Description;
	
	    $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
        $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix $networkGroup.Id -AddressPrefixType "NetworkGroup" 

        $sourcePortList = @("100")
        $destinationPortList = @("99")
        New-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Description "Description" -Protocol  "TCP" -Direction "Inbound" -Access "Allow" -Priority 100 -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefix -DestinationAddressPrefix $destinationAddressPrefix 

        $adminRule = Get-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName
        Assert-NotNull $adminRule
        Assert-AreEqual $RuleName $adminRule.Name 
        Assert-AreEqual "TCP" $adminRule.Protocol 
        Assert-AreEqual "Inbound" $adminRule.Direction 
        Assert-AreEqual "Allow" $adminRule.Access 
        Assert-AreEqual 100 $adminRule.Priority

        Assert-AreEqual "100" $adminRule.SourcePortRanges[0] 
        Assert-AreEqual "99" $adminRule.DestinationPortRanges[0]
        Assert-AreEqual $networkGroup.Id $adminRule.Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $adminRule.Sources[0].AddressPrefix

        $newAdminRule = Set-AzNetworkManagerSecurityAdminRule -InputObject $adminRule
        Assert-NotNull $newAdminRule;
        Assert-AreEqual $RuleName $newAdminRule.Name;

        $configids  = @($securityConfig.Id)
        $regions = @($rglocation)  
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "SecurityAdmin" 

        # Start-TestSleep -Seconds 60
   
        $deploymentStatus = Get-AzNetworkManagerDeploymentStatus -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "SecurityAdmin"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "SecurityAdmin"  $deploymentStatus.Value[0].DeploymentType;
        Assert-AreEqual $securityConfig.Id  $deploymentStatus.Value[0].ConfigurationIds[0];

        $activeSecurityAdminRule = Get-AzNetworkManagerActiveSecurityAdminRule -NetworkManagerName $networkManagerName -ResourceGroupName $rgname -region $regions
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
        Assert-AreEqual $networkGroup.Id $activeSecurityAdminRule.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $activeSecurityAdminRule.Value[0].Sources[0].AddressPrefix

        $effectiveSecurityAdminRuleList = Get-AzNetworkManagerEffectiveSecurityAdminRule  -VirtualNetworkName $vnetName -VirtualNetworkResourceGroupName $vnetRGName
        Assert-NotNull $effectiveSecurityAdminRuleList;

        Assert-AreEqual  $newAdminRule.Id $effectiveSecurityAdminRuleList.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRuleList.Value[0].RuleGroups[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRuleList.Value[0].RuleCollectionAppliesToGroups[0].NetworkGroupId;
   

        Assert-AreEqual $securityConfig.Description $effectiveSecurityAdminRuleList.Value[0].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.Description $effectiveSecurityAdminRuleList.Value[0].RuleCollectionDescription;

        Assert-AreEqual "TCP" $effectiveSecurityAdminRuleList.Value[0].Protocol 
        Assert-AreEqual "Inbound" $effectiveSecurityAdminRuleList.Value[0].Direction 
        Assert-AreEqual "Allow" $effectiveSecurityAdminRuleList.Value[0].Access 
        Assert-AreEqual 0 $effectiveSecurityAdminRuleList.Value[0].Priority

        Assert-AreEqual "100" $effectiveSecurityAdminRuleList.Value[0].SourcePortRanges[0] 
        Assert-AreEqual "99" $effectiveSecurityAdminRuleList.Value[0].DestinationPortRanges[0]
        Assert-AreEqual $networkGroup.Id $effectiveSecurityAdminRuleList.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $effectiveSecurityAdminRuleList.Value[0].Sources[0].AddressPrefix

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "SecurityAdmin" 

        # Start-TestSleep -Seconds 60

        $job = Remove-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Start-TestSleep -Seconds 60

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
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("Connectivity")
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
        $newScopeConnection = Set-AzNetworkManagerScopeConnection -InputObject $scopeConnection
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
    $networkManagerId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/networkManagers/SwaggerStackNetworkManager"

    try{
        New-AzNetworkManagerSubscriptionConnection -Name $networkManagerConnectionName -NetworkManagerId $networkManagerId -Description "SampleDescription" 
        $networkManagerConnection = Get-AzNetworkManagerSubscriptionConnection -Name $networkManagerConnectionName
        Assert-NotNull $networkManagerConnection;
        Assert-AreEqual $networkManagerConnectionName $networkManagerConnection.Name;

        $networkManagerConnection.Description = "A Different Description."
        $newNetworkManagerConnection = Set-AzNetworkManagerSubscriptionConnection -InputObject $networkManagerConnection
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
    $networkManagerId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/networkManagers/SwaggerStackNetworkManager"
    $managementGroupId = "SwaggerStackTestMG"

    try{
        New-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -Name $networkManagerConnectionName -NetworkManagerId $networkManagerId -Description "SampleDescription" 
        $networkManagerConnection = Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -Name $networkManagerConnectionName
        Assert-NotNull $networkManagerConnection;
        Assert-AreEqual $networkManagerConnectionName $networkManagerConnection.Name;

        $networkManagerConnection.Description = "A Different Description."
        $newNetworkManagerConnection = Set-AzNetworkManagerManagementGroupConnection -InputObject $networkManagerConnection
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

<#
.SYNOPSIS
Tests minimum parameter input for each resource results in successful create
#>
function Test-NetworkManagerResourceMinimumParameterCreate
{
    # Setup
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $vnetNetworkGroupName = Get-ResourceName
    $subnetNetworkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $connectivityConfigurationName = Get-ResourceName
    $SecurityConfigurationName = Get-ResourceName
    $SecurityUserConfigurationName = Get-ResourceName
    $RoutingConfigurationName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName = Get-ResourceName
    $scopeConnectionName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"
    $subnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet/subnets/subnet1"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $managementGroups  = @($managementGroupId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Define access
        $access  = @("SecurityAdmin", "Routing", "SecurityUser")

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        # Create a vnet and subnet network group
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $vnetNetworkGroupName
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $subnetNetworkGroupName -MemberType "Subnet"

        # Create a static member
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $vnetNetworkGroupName -Name $staticMemberName -ResourceId $vnetId
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $subnetNetworkGroupName -Name $staticMemberName -ResourceId $subnetId

        # Create connectivity group item and config
        $vnetNetworkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $vnetNetworkGroupName 
        $subnetNetworkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $subnetNetworkGroupName 
        $connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $vnetNetworkGroup.Id
        $connectivityGroup  = @($connectivityGroupItem)  
        New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -Name $connectivityConfigurationName -NetworkManagerName $networkManagerName -ConnectivityTopology "Mesh" -AppliesToGroup $connectivityGroup -DeleteExistingPeering 

        # Create a security admin config
        New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName

        # Create a security admin rule collection
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $vnetNetworkGroup.Id
        $configGroup.Add($groupItem)
        New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 
        
        # Create a security admin rule
        New-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Protocol "TCP" -Direction "Inbound" -Access "Allow" -Priority 100
	    
        # Create a scope connection
        New-AzNetworkManagerScopeConnection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $scopeConnectionName -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47" -ResourceId $subscriptionId

        # Create a routing config
        New-AzNetworkManagerRoutingConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $RoutingConfigurationName

        # Create a routing rule collection
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerRoutingGroupItem -NetworkGroupId $subnetNetworkGroup.Id
        $configGroup.Add($groupItem)
        New-AzNetworkManagerRoutingRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -Name $RuleCollectionName -AppliesTo $configGroup -DisableBgpRoutePropagation "True"
        
        # Create a routing rule
        $destination = New-AzNetworkManagerRoutingRuleDestination -DestinationAddress "10.1.1.1/32" -Type "AddressPrefix" 
        $nextHop = New-AzNetworkManagerRoutingRuleNextHop -NextHopType "VirtualAppliance" -NextHopAddress "2.2.2.2"
        New-AzNetworkManagerRoutingRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -RuleCollectionName $RuleCollectionName -ResourceName $RuleName -Destination $destination -NextHop $nextHop

        # Create a security user config
        New-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityUserConfigurationName

        # Create a security user rule collection
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityUserGroupItem -NetworkGroupId $subnetNetworkGroup.Id
        $configGroup.Add($groupItem)
        New-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 
        
        # Create a security user rule
        $sourceAddressPrefixes = @()
        $sourceAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.1.0.0/24" -AddressPrefixType "IPPrefix"
        $sourceAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "50.1.0.0/24" -AddressPrefixType "IPPrefix"

        # Add destination address prefix items to the array
        $destinationAddressPrefixes = @()
        $destinationAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "6.6.6.6/32" -AddressPrefixType "IPPrefix"

        $sourcePortList = @("100", "80")
        $destinationPortList = @("99", "200")
        New-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Protocol "TCP" -Direction "Inbound" -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefixes -DestinationAddressPrefix $destinationAddressPrefixes
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating/getting/deleting new simple networkmanager Routing Configuration/RuleCollection/Rule
#>
function Test-NetworkManagerRoutingRuleCRUD
{
    # Setup
    # Need to update $subscriptionId/vnetid before running in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $vnetNetworkGroupName = Get-ResourceName
    $subnetNetworkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $RoutingConfigurationName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName1 = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/16319507-0b13-46b9-9dcb-b943a4ee1d70"
    $vnetId = "/subscriptions/16319507-0b13-46b9-9dcb-b943a4ee1d70/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"
    $subnetId = "/subscriptions/16319507-0b13-46b9-9dcb-b943a4ee1d70/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet/subnets/subnet1"
    $vnetName = "SwaggerStackVnet"
    $vnetRGName = "SwaggerStackRG"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("Routing")
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        # Create Network Groups
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $vnetNetworkGroupName -Description "SampleVnetNG"
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $subnetNetworkGroupName -Description "SampleSubnetNG" -MemberType "Subnet"

        # Create Static Members
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $vnetNetworkGroupName -Name $staticMemberName -ResourceId $vnetId
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $subnetNetworkGroupName -Name $staticMemberName -ResourceId $subnetId

        $vnetNetworkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $vnetNetworkGroupName
        $subnetNetworkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $subnetNetworkGroupName

        # Create a Routing Configuration
        New-AzNetworkManagerRoutingConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $RoutingConfigurationName -Description "Sample Routing Configuration"
        
        $routingConfig = Get-AzNetworkManagerRoutingConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $RoutingConfigurationName
        Assert-NotNull $routingConfig;
        Assert-AreEqual $RoutingConfigurationName $routingConfig.Name;

        # Validate List Routing config command
        $routingConfigs = Get-AzNetworkManagerRoutingConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName
        Assert-NotNull $routingConfigs
        Assert-AreEqual 1 $routingConfigs.Count

        # Get by resourceId
        $resourceId = $routingConfig.Id
        $routingConfig = Get-AzNetworkManagerRoutingConfiguration -ResourceId $resourceId
        Assert-NotNull $routingConfig
        Assert-AreEqual $resourceId $routingConfig.Id

        # Set by InputObject
        $routingConfig.Description = "A different description."
        $routingConfig = Set-AzNetworkManagerRoutingConfiguration -InputObject $routingConfig
        Assert-NotNull $routingConfig;
        Assert-AreEqual "A different description." $routingConfig.Description;
        Assert-AreEqual $RoutingConfigurationName $routingConfig.Name;

        # Set by resourceId
        $resourceId = $routingConfig.Id
        $routingConfig = Set-AzNetworkManagerRoutingConfiguration -ResourceId $resourceId -Description "Updated description."
        Assert-NotNull $routingConfig;
        Assert-AreEqual "Updated description." $routingConfig.Description;
        Assert-AreEqual $RoutingConfigurationName $routingConfig.Name;

        # Set by Name
        $routingConfig = Set-AzNetworkManagerRoutingConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $RoutingConfigurationName -Description "Updated description again."
        Assert-NotNull $routingConfig;
        Assert-AreEqual "Updated description again." $routingConfig.Description;
        Assert-AreEqual $RoutingConfigurationName $routingConfig.Name;

        # Create a Routing Rule Collection
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingGroupItem]]$configGroup  = @() 
        $vnetGroupItem = New-AzNetworkManagerRoutingGroupItem -NetworkGroupId $vnetNetworkGroup.Id
        $subnetGroupItem = New-AzNetworkManagerRoutingGroupItem -NetworkGroupId $subnetNetworkGroup.Id
        $configGroup.Add($vnetGroupItem)
        $configGroup.Add($subnetGroupItem)

        New-AzNetworkManagerRoutingRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -Name $RuleCollectionName -AppliesTo $configGroup -DisableBgpRoutePropagation "False" -Description "First collection"

        $ruleCollection = Get-AzNetworkManagerRoutingRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "False" $ruleCollection.DisableBgpRoutePropagation;

        # Get by resourceId
        $resourceId = $ruleCollection.Id
        $ruleCollection = Get-AzNetworkManagerRoutingRuleCollection -ResourceId $resourceId
        Assert-NotNull $ruleCollection
        Assert-AreEqual $resourceId $ruleCollection.Id

        # Check if the AppliesTo collections are equivalent
        $expectedAppliesTo = $configGroup | ForEach-Object { $_.NetworkGroupId }
        $actualAppliesTo = $ruleCollection.AppliesTo | ForEach-Object { $_.NetworkGroupId }

        foreach ($expectedItem in $expectedAppliesTo)
        {
            $actualItem = $actualAppliesTo | Where-Object { $_ -eq $expectedItem }
            Assert-NotNull $actualItem
            Assert-AreEqual $expectedItem $actualItem
        }

        # Validate List Routing rule collection command
        $ruleCollections = Get-AzNetworkManagerRoutingRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName
        Assert-NotNull $ruleCollections
        Assert-AreEqual 1 $ruleCollections.Count

        # Set by InputObject
        $ruleCollection.Description = "Updated first collection"
        $ruleCollection = Set-AzNetworkManagerRoutingRuleCollection -InputObject $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Updated first collection" $ruleCollection.Description;
 
        # Set by resourceId
        $resourceId = $ruleCollection.Id
        $ruleCollection = Set-AzNetworkManagerRoutingRuleCollection -ResourceId $resourceId -Description "Updated collection"
        Assert-NotNull $ruleCollection;
        Assert-AreEqual "Updated collection" $ruleCollection.Description;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;

        # Set by Name
        $ruleCollection = Set-AzNetworkManagerRoutingRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -Name $RuleCollectionName -Description "Updated collection again"
        Assert-NotNull $ruleCollection;
        Assert-AreEqual "Updated collection again" $ruleCollection.Description;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;

        # Create Routing Rule and validate
        # ByName - Create a Routing Rule by Name
        $destination = New-AzNetworkManagerRoutingRuleDestination -DestinationAddress "10.1.1.1/32" -Type "AddressPrefix" 
        $nextHop = New-AzNetworkManagerRoutingRuleNextHop -NextHopType "VirtualAppliance" -NextHopAddress "2.2.2.2"

        New-AzNetworkManagerRoutingRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -RuleCollectionName $RuleCollectionName -ResourceName $RuleName1 -Destination $destination -NextHop $nextHop

        #region - Start Routing Rule Get-* cmdlets tests

        # Test List - List all the routing rules in a collection
        $routingRule = Get-AzNetworkManagerRoutingRule -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -ConfigName $routingConfigurationName -RuleCollectionName $ruleCollectionName
        Assert-AreEqual 1 $routingRule.Count
        Assert-NotNull $routingRule

        # Test GetByName - Get the routing rule by name
        $routingRule = Get-AzNetworkManagerRoutingRule -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -ConfigName $routingConfigurationName -RuleCollectionName $ruleCollectionName -ResourceName $RuleName1
        Assert-NotNull $routingRule
        Assert-AreEqual $ruleName1 $routingRule.Name
        Assert-AreEqual $routingConfigurationName $routingRule.RoutingConfigurationName
        Assert-AreEqual $ruleCollectionName $routingRule.RuleCollectionName
        Assert-AreEqual $destination.DestinationAddress $routingRule.Destination.DestinationAddress
        Assert-AreEqual $destination.Type $routingRule.Destination.Type
        Assert-AreEqual $nextHop.NextHopAddress $routingRule.NextHop.NextHopAddress
        Assert-AreEqual $nextHop.NextHopType $routingRule.NextHop.NextHopType

        # Test GetByResourceId - Get the routing rule by resourceId
        $resourceId = $routingRule.Id
        $routingRule = Get-AzNetworkManagerRoutingRule -ResourceId $resourceId
        Assert-NotNull $routingRule
        Assert-AreEqual $resourceId $routingRule.Id

        #endregion - End Routing Rule Get-* cmdlets tests

        #region - Start Routing Rule Set-* cmdlets tests

        # Test SetByInputObject - Set the routing rule by input object
        $routingRule.Description = "Updated first routing rule."
        $updatedFirstRoutingRule = Set-AzNetworkManagerRoutingRule -InputObject $routingRule
        Assert-NotNull $updatedFirstRoutingRule;
        Assert-AreEqual $RuleName1 $updatedFirstRoutingRule.Name;
        Assert-AreEqual "Updated first routing rule." $updatedFirstRoutingRule.Description;

        # Test SetByResourceId - Set the routing rule by resourceId
        $resourceId = $updatedFirstRoutingRule.Id
        $updatedFirstRoutingRule = Set-AzNetworkManagerRoutingRule -ResourceId $resourceId -DestinationAddress "30.1.1.1/32" -DestinationType "AddressPrefix" -NextHopAddress "2.2.2.2" -NextHopType "VirtualAppliance" -Description "Again updated routing rule."

        Assert-NotNull $updatedFirstRoutingRule;
        Assert-AreEqual $RuleName1 $updatedFirstRoutingRule.Name;
        Assert-AreEqual "Again updated routing rule." $updatedFirstRoutingRule.Description;

        # Test SetByName - Set the routing rule by name
        $RuleName3 = Get-ResourceName
        $thirdRoutingRule = Set-AzNetworkManagerRoutingRule -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -ConfigName $routingConfigurationName -RuleCollectionName $ruleCollectionName -Name $RuleName3 -DestinationAddress "40.1.1.1/32" -DestinationType "AddressPrefix" -NextHopAddress "2.2.2.2" -NextHopType "VirtualAppliance" -Description "Second updated routing rule."

        Assert-NotNull $thirdRoutingRule;
        Assert-AreEqual $RuleName3 $thirdRoutingRule.Name;
        Assert-AreEqual "Second updated routing rule." $thirdRoutingRule.Description;

        #endregion - End Routing Rule Set-* cmdlets tests

        $configIds  = @($routingConfig.Id)
        $regions = @($rglocation)  
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configIds -CommitType "Routing" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60
       
        $deploymentStatus = Get-AzNetworkManagerDeploymentStatus -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "Routing"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "Routing" $deploymentStatus.Value[0].DeploymentType;
        Assert-AreEqual $routingConfig.Id $deploymentStatus.Value[0].ConfigurationIds[0];

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "Routing" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60

        $job = Remove-AzNetworkManagerRoutingRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $RoutingConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName1 -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Remove by resourceId
        $job = Remove-AzNetworkManagerRoutingRuleCollection -ResourceId $ruleCollection.Id -ForceDelete -PassThru -Force -AsJob;

        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Remove by InputObject
        $job = Remove-AzNetworkManagerRoutingConfiguration -InputObject $routingConfig -ForceDelete -PassThru -Force -AsJob;

        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $vnetNetworkGroupName -Name $staticMemberName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $subnetNetworkGroupName -Name $staticMemberName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $vnetNetworkGroupName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $subnetNetworkGroupName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests creating/getting/deleting new simple public networkmanager Security User Configuration/RuleCollection/Rule
#>
function Test-NetworkManagerSecurityUserRuleCRUD
{
    # Setup
    # Need to update $subscriptionId/vnetid before running in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $SecurityUserConfigurationName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"
    $subnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet/subnets/subnet1"
    $vnetName = "SwaggerStackVnet"
    $vnetRGName = "SwaggerStackRG"

    try
    {
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $group  = @($subscriptionId)
        $access  = @("SecurityUser")
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -Description "Sample SecurityUser Configuration" -MemberType "Subnet"

        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $subnetId

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        New-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityUserConfigurationName -Description "Sample Network Manager"
        
        # Get security user configuration ByName and validate
        $securityUserConfig = Get-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityUserConfigurationName
        Assert-NotNull $securityUserConfig;
        Assert-AreEqual $securityUserConfigurationName $securityUserConfig.Name;

        # Validate List Security User config command
        $securityUserConfigs = Get-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName
        Assert-NotNull $securityUserConfigs
        Assert-AreEqual 1 $securityUserConfigs.Count

        # Get security user configuration ByResourceId and validate
        $securityUserConfig = Get-AzNetworkManagerSecurityUserConfiguration -ResourceId $securityUserConfig.Id
        Assert-NotNull $securityUserConfig;
        Assert-AreEqual $securityUserConfigurationName $securityUserConfig.Name;

        # Set by InputObject
        $securityUserConfig.Description = "A different description."
        $securityUserConfig = Set-AzNetworkManagerSecurityUserConfiguration -InputObject $securityUserConfig
        Assert-NotNull $securityUserConfig;
        Assert-AreEqual "A different description." $securityUserConfig.Description;
        Assert-AreEqual $SecurityUserConfigurationName $securityUserConfig.Name;

        # Set by resourceId
        $securityUserConfig = Set-AzNetworkManagerSecurityUserConfiguration -ResourceId $securityUserConfig.Id -Description "Updated description."
        Assert-NotNull $securityUserConfig;
        Assert-AreEqual "Updated description." $securityUserConfig.Description;
        Assert-AreEqual $SecurityUserConfigurationName $securityUserConfig.Name;

        # Set by name
        $securityUserConfig = Set-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityUserConfigurationName -Description "Updated description."
        Assert-NotNull $securityUserConfig;
        Assert-AreEqual "Updated description." $securityUserConfig.Description;
        Assert-AreEqual $SecurityUserConfigurationName $securityUserConfig.Name;

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityUserGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)

        New-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup

        $ruleCollection = Get-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual $networkGroup.Id $ruleCollection.AppliesToGroups[0].NetworkGroupId;

        # Validate List Security User collection command
        $ruleCollections = Get-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName
        Assert-NotNull $ruleCollections
        Assert-AreEqual 1 $ruleCollections.Count

        # Get RuleCollection by ResourceId
        $ruleCollection = Get-AzNetworkManagerSecurityUserRuleCollection -ResourceId $ruleCollection.Id
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;

        # Set by InputObject
        $ruleCollection.Description = "Sample rule Collection Description"
        $ruleCollection = Set-AzNetworkManagerSecurityUserRuleCollection -InputObject $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Sample rule Collection Description" $ruleCollection.Description;

        # Set rule collection by ResourceId
        $ruleCollection = Set-AzNetworkManagerSecurityUserRuleCollection -ResourceId $ruleCollection.Id -Description "Updated rule Collection Description"
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Updated rule Collection Description" $ruleCollection.Description;

        # Set rule collection by Name
        $ruleCollection = Set-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName -Name $RuleCollectionName -Description "Updated rule Collection Description"
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Updated rule Collection Description" $ruleCollection.Description;
 
        # Add source address prefix items to the array
        $sourceAddressPrefixes = @()
        $sourceAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.1.0.0/24" -AddressPrefixType "IPPrefix"
        $sourceAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "50.1.0.0/24" -AddressPrefixType "IPPrefix"

        # Add destination address prefix items to the array
        $destinationAddressPrefixes = @()
        $destinationAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "6.6.6.6/32" -AddressPrefixType "IPPrefix"
        $destinationAddressPrefixes += New-AzNetworkManagerAddressPrefixItem -AddressPrefix "7.7.7.7/32" -AddressPrefixType "IPPrefix"

        $sourcePortList = @("100", "80")
        $destinationPortList = @("99", "200")
        New-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Description "Description" -Protocol  "TCP" -Direction "Inbound" -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefixes -DestinationAddressPrefix $destinationAddressPrefixes

        $userRule = Get-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityUserConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName
        Assert-NotNull $userRule
        Assert-AreEqual $RuleName $userRule.Name
        Assert-AreEqual "TCP" $userRule.Protocol
        Assert-AreEqual "Inbound" $userRule.Direction

        Assert-AreEqual "100" $userRule.SourcePortRanges[0]
        Assert-AreEqual "80" $userRule.SourcePortRanges[1]
        Assert-AreEqual "99" $userRule.DestinationPortRanges[0]
        Assert-AreEqual "200" $userRule.DestinationPortRanges[1]
        Assert-AreEqual "10.1.0.0/24" $userRule.Sources[0].AddressPrefix
        Assert-AreEqual "IPPrefix" $userRule.Sources[0].AddressPrefixType
        Assert-AreEqual "50.1.0.0/24" $userRule.Sources[1].AddressPrefix
        Assert-AreEqual "IPPrefix" $userRule.Sources[1].AddressPrefixType
        Assert-AreEqual "6.6.6.6/32" $userRule.Destinations[0].AddressPrefix
        Assert-AreEqual "IPPrefix" $userRule.Destinations[0].AddressPrefixType
        Assert-AreEqual "7.7.7.7/32" $userRule.Destinations[1].AddressPrefix
        Assert-AreEqual "IPPrefix" $userRule.Destinations[1].AddressPrefixType

        # Validate List Security User rule command
        $userRules = Get-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityUserConfigurationName -RuleCollectionName $RuleCollectionName
        Assert-NotNull $userRules
        Assert-AreEqual 1 $userRules.Count

        # Get Security User rule by ResourceId
        $userRule = Get-AzNetworkManagerSecurityUserRule -ResourceId $userRule.Id
        Assert-NotNull $userRule
        Assert-AreEqual $RuleName $userRule.Name

        # Set by InputObject
        $userRule.Description = "A different description."
        $newSecurityUserRule = Set-AzNetworkManagerSecurityUserRule -InputObject $userRule
        Assert-NotNull $newSecurityUserRule;
        Assert-AreEqual $RuleName $newSecurityUserRule.Name;

        # Set Security User rule by ResourceId
        $userRule = Set-AzNetworkManagerSecurityUserRule -ResourceId $userRule.Id -Description "Updated description." -Protocol  "TCP" -Direction "Inbound" -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefixes -DestinationAddressPrefix $destinationAddressPrefixes
        Assert-NotNull $userRule;
        Assert-AreEqual "Updated description." $userRule.Description;

        # Set Security User rule by Name
        $userRule = Set-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityUserConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -Description "Updated description again." -Protocol  "TCP" -Direction "Inbound" -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefixes -DestinationAddressPrefix $destinationAddressPrefixes
        Assert-NotNull $userRule;
        Assert-AreEqual "Updated description again." $userRule.Description;

        $configIds  = @($securityUserConfig.Id)
        $regions = @($rglocation)  
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configIds -CommitType "SecurityUser" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60
       
        $deploymentStatus = Get-AzNetworkManagerDeploymentStatus -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Region $regions -DeploymentType "SecurityUser"
        Assert-NotNull $deploymentStatus;
        Assert-AreEqual "SecurityUser"  $deploymentStatus.Value[0].DeploymentType;
        Assert-AreEqual $securityUserConfig.Id  $deploymentStatus.Value[0].ConfigurationIds[0];

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "SecurityUser" 

        # Uncomment during Record to allow time for commit
        # Start-TestSleep -Seconds 60

        # Remove the network manager security user rule
        $job = Remove-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityUserConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -ForceDelete -PassThru -Force -AsJob
        $job | Wait-Job
        $removeResult = $job | Receive-Job

        # Remove security user rule collection by resourceId
        $job = Remove-AzNetworkManagerSecurityUserRuleCollection -ResourceId $ruleCollection.Id -ForceDelete -PassThru -Force -AsJob

		$job | Wait-Job
		$removeResult = $job | Receive-Job

        # Remove by InputObject
        $job = Remove-AzNetworkManagerSecurityUserConfiguration -InputObject $securityUserConfig -ForceDelete -PassThru -Force -AsJob;

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
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

function Test-NetworkManagerIpamPoolCRUD
{
    # Setup
    # Need to update subscriptionId before runing in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $ipamPoolName = Get-ResourceName
    $rglocation = "eastus2euap"
    $subscriptionId = "/subscriptions/dfa8d777-26f3-4e5e-be19-d6d5fa3176fc"
    $addressPrefixes  = @("10.0.0.0/8")
    $tags = @{ testtag = "testval" }

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -Location $rglocation

        # Create ipam pool
        New-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName -Location $rglocation -AddressPrefix $addressPrefixes -Tag $tags

        $ipamPool = Get-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName
        Assert-NotNull $ipamPool;
        Assert-AreEqual $ipamPoolName $ipamPool.Name;
        Assert-AreEqual $rglocation $ipamPool.Location;
        Assert-AreEqual $ipamPool.Properties.AddressPrefixes[0] $addressPrefixes[0];
        Assert-AreEqual $ipamPool.Tags.Count 1;

        # Update access
        $ipamPool.Properties.AddressPrefixes.Add("11.0.0.0/8");
        $newIpamPool = Set-AzNetworkManagerIpamPool -InputObject $ipamPool
        Assert-AreEqual  $newIpamPool.Properties.AddressPrefixes[0] "10.0.0.0/8";
        Assert-AreEqual  $newIpamPool.Properties.AddressPrefixes[1] "11.0.0.0/8";

        # Get Pool Usage
        $poolUsage = Get-AzNetworkManagerIpamPoolUsage -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -IpamPoolName $ipamPoolName
        Assert-NotNull $poolUsage;
        Assert-NotNull $poolUsage.ChildPools.Count 0;
        Assert-AreEqual $poolUsage.AddressPrefixes.Count 1;
        Assert-AreEqual $poolUsage.AddressPrefixes[0] "10.0.0.0/7";
        Assert-AreEqual $poolUsage.AllocatedAddressPrefixes.Count 0;
        Assert-AreEqual $poolUsage.ReservedAddressPrefixes.Count 0;
        Assert-AreEqual $poolUsage.AvailableAddressPrefixes.Count 1;
        Assert-AreEqual $poolUsage.AvailableAddressPrefixes[0] "10.0.0.0/7";
        Assert-AreEqual $poolUsage.TotalNumberOfIPAddresses "33554432";
        Assert-AreEqual $poolUsage.NumberOfAllocatedIPAddresses "0";
        Assert-AreEqual $poolUsage.NumberOfReservedIPAddresses "0";
        Assert-AreEqual $poolUsage.NumberOfAvailableIPAddresses "33554432";

        # Get Associated Resources List
        $listAssociatedResources = Get-AzNetworkManagerAssociatedResourcesList -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -IpamPoolName $ipamPoolName
        Assert-NotNull $listAssociatedResources;
        Assert-AreEqual $listAssociatedResources.Count 0;

        # Delete IpamPool
        $job = Remove-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgName
	}
}

function Test-NetworkManagerIpamPoolStaticCidrCRUD 
{
    # Setup
    # Need to update subscriptionId before runing in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $ipamPoolName = Get-ResourceName
    $staticCidrName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52"
    $addressPrefixes  = @("10.0.0.0/8")

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Define access
        $access  = @("Connectivity")

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        # Create ipam pool
        New-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName -Location $rglocation -AddressPrefix $addressPrefixes

        # Create static cidr
        New-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -PoolName $ipamPoolName -Name $staticCidrName -AddressPrefix $addressPrefixes

        # Get static cidr
        $staticCidr = Get-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -IpamPoolName $ipamPoolName -Name $staticCidrName
        Assert-NotNull $staticCidr;
        Assert-AreEqual $staticCidrName $staticCidr.Name;
        Assert-AreEqual $staticCidr.Properties.AddressPrefixes[0] $addressPrefixes[0];

        # Remove static cidr
        $job = Remove-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -IpamPoolName $ipamPoolName -Name $staticCidrName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
    }
    finally{
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}



function Test-NetworkManagerVerifierWorkspaceReachabilityAnalysisRunCRUD
{
    # Setup
    # Need to update subscriptionId before runing in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $verifierWorkspaceName = Get-ResourceName
    $rglocation = "eastus2euap"
    $subscriptionId = "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359"
    $reachabilityAnalysisIntentName = "analysisIntentTest06"
    $reachabilityAnalysisRunName = "analysisRunTest06"


    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -Location $rglocation

        # Create verifier workspace
        New-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName -Location $rglocation -Description "Sample description" -Tag @{ testtag = "testval" }

         #Get verifier workspace
        $verifierWorkspace = Get-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName 
        Assert-NotNull $verifierWorkspace;
        Assert-AreEqual $verifierWorkspaceName $verifierWorkspace.Name;
        Assert-AreEqual $rglocation $verifierWorkspace.Location;
        Assert-AreEqual $verifierWorkspace.Tags.Count 1;

        # Get verifier workspace list
        $verifierWorkspaceList = Get-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName 
        Assert-NotNull $verifierWorkspaceList;
        Assert-AreEqual $verifierWorkspaceList.Count 1;

         # Get by resourceId
        $resourceId = $verifierWorkspace.Id
        $verifierWorkspace = Get-AzNetworkManagerVerifierWorkspace -ResourceId $resourceId
        Assert-NotNull $verifierWorkspace
        Assert-AreEqual $resourceId $verifierWorkspace.Id

        # Create analysis intent
        $sourcePortList = @("100")
        $destinationPortList = @("99")
        $protocolList = @("TCP")
        $sourceIpList = @("192.168.1.10")
        $destinationIpList = @("172.16.0.5")
        $groupItem = New-AzNetworkManagerIPTraffic -SourceIp $sourceIpList -DestinationIp $destinationIpList -SourcePort $sourcePortList -DestinationPort $destinationPortList -Protocol $protocolList

        $analysisIntent = New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName -SourceResourceId "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/testVM" -DestinationResourceId "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test" -IpTraffic $groupItem

        # Get analysis intent
        $reachabilityAnalysisIntent = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName
        Assert-NotNull $reachabilityAnalysisIntent;
        Assert-AreEqual $reachabilityAnalysisIntentName $reachabilityAnalysisIntent.Name;
        Assert-AreEqual $reachabilityAnalysisIntent.Properties.IpTraffic.SourceIps $sourceIpList;
        Assert-AreEqual $reachabilityAnalysisIntent.Properties.IpTraffic.DestinationIps $destinationIpList;

        # Get by resourceId
        $resourceId = $reachabilityAnalysisIntent.Id
        $reachabilityAnalysisIntent = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceId $resourceId
        Assert-NotNull $reachabilityAnalysisIntent
        Assert-AreEqual $resourceId $reachabilityAnalysisIntent.Id

        # Get  analysis intent list
        $reachabilityAnalysisIntentList = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName
        Assert-NotNull $reachabilityAnalysisIntentList;
        Assert-AreEqual $reachabilityAnalysisIntentList.Count 1

        # Create analysis run
        # Get the intent ID
        $intentId = $analysisIntent.Id

        New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisRunName -IntentId $intentId -Description "DESCription"

        # Get analysis run
        $reachabilityAnalysisRun = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisRunName
        Assert-NotNull $reachabilityAnalysisRun
        Assert-AreEqual $reachabilityAnalysisRunName $reachabilityAnalysisRun.Name

        # Get  analysis run list
        $reachabilityAnalysisRunList = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName
        Assert-NotNull $reachabilityAnalysisRunList;
        Assert-AreEqual $reachabilityAnalysisRunList.Count 1

        # Get by resourceId
        $resourceId = $reachabilityAnalysisRun.Id
        $reachabilityAnalysisRun = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceId $resourceId
        Assert-NotNull $reachabilityAnalysisRun
        Assert-AreEqual $resourceId $reachabilityAnalysisRun.Id

        Start-TestSleep -Seconds 300
        Assert-NotNull $reachabilityAnalysisRun


        Assert-NotNull $reachabilityAnalysisRun.Properties.AnalysisResult
        Assert-AreEqual "DESCription" $reachabilityAnalysisRun.Properties.Description;
        Assert-AreEqual $intentId  $reachabilityAnalysisRun.Properties.IntentId;

        # Delete analysis run
        $job = Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceId $reachabilityAnalysisRun.Id -PassThru -Force -AsJob
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Delete analysis intent
        $job = Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        # Delete verifier workspace
        # Remove by InputObject
        $job = Remove-AzNetworkManagerVerifierWorkspace -InputObject $verifierWorkspace -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgName
	}
}

