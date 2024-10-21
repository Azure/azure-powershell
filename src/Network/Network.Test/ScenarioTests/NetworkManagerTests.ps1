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

        Start-TestSleep -Seconds 60
   
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

        Start-TestSleep -Seconds 60

        $job = Remove-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -ForceDelete -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        Start-TestSleep -Seconds 60

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
    $networkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $connectivityConfigurationName = Get-ResourceName
    $SecurityConfigurationName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName = Get-ResourceName
    $scopeConnectionName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c"
    $vnetId = "/subscriptions/dd7b516d-9de0-4fd6-b6f2-db41b3ee0c0c/resourceGroups/SwaggerStackRG/providers/Microsoft.Network/virtualNetworks/SwaggerStackVnet"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $managementGroups  = @($managementGroupId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Define access
        $access  = @("Connectivity", "SecurityAdmin")

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        # Create a network group
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        # Create a static member
        New-AzNetworkManagerStaticMember -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroupName $networkGroupName -Name $staticMemberName -ResourceId $vnetId

        # Create connectivity group item and config
        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        $connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $networkGroup.Id
        $connectivityGroup  = @($connectivityGroupItem)  
        New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -Name $connectivityConfigurationName -NetworkManagerName $networkManagerName -ConnectivityTopology "Mesh" -AppliesToGroup $connectivityGroup -DeleteExistingPeering 

        # Create a security admin config
        New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName

        # Create a security admin rule collection
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)
        New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 
        
        # Create a security admin rule
        New-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -Protocol "TCP" -Direction "Inbound" -Access "Allow" -Priority 100
	    
        # Create a scope connection
        New-AzNetworkManagerScopeConnection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $scopeConnectionName -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47" -ResourceId $subscriptionId
    }
    finally{
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

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -Location $rglocation

        # Create ipam pool
        New-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName -Location $rglocation -AddressPrefixes $addressPrefixes

        $ipamPool = Get-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName
        Assert-NotNull $ipamPool;
        Assert-AreEqual $ipamPoolName $ipamPool.Name;
        Assert-AreEqual $rglocation $ipamPool.Location;
        Assert-AreEqual $ipamPool.Properties.AddressPrefixes[0] $addressPrefixes[0];

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

        # Get Associated Resources
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
        New-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName -Location $rglocation -AddressPrefixes $addressPrefixes

        # Create static cidr
        New-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -PoolName $ipamPoolName -Name $staticCidrName -AddressPrefixes $addressPrefixes

        # Get static cidr
        $staticCidr = Get-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -PoolName $ipamPoolName -Name $staticCidrName
        Assert-NotNull $staticCidr;
        Assert-AreEqual $staticCidrName $staticCidr.Name;
        Assert-AreEqual $staticCidr.Properties.AddressPrefixes[0] $addressPrefixes[0];

        # Remove static cidr
        $job = Remove-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -PoolName $ipamPoolName -Name $staticCidrName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
    }
    finally{
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}
function Test-NetworkManagerVerifierWorkspaceCRUD
{
    # Setup
    # Need to update subscriptionId before runing in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $verifierWorkspaceName = Get-ResourceName
    $rglocation = "eastus2euap"
    $subscriptionId = "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -Location $rglocation

        # Create verifier workspace
        New-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName -Location $rglocation -Description "Sample description" 

        #Get verifier workspace
        $verifierWorkspace = Get-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName
        Assert-NotNull $verifierWorkspace;
        Assert-AreEqual $verifierWorkspaceName $verifierWorkspace.Name;
        Assert-AreEqual $rglocation $verifierWorkspace.Location;

        # Update verifier workspace
        $verifierWorkspace.Properties.Description = "A different description."
        $newVerifierWorkspace = Set-AzNetworkManagerVerifierWorkspace -InputObject $verifierWorkspace
        Assert-NotNull $newVerifierWorkspace;
        Assert-AreEqual "A different description." $newVerifierWorkspace.Properties.Description;
        Assert-AreEqual $verifierWorkspaceName $newVerifierWorkspace.Name;

        # Delete verifier workspace
        $job = Remove-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgName
	}
}

function Test-NetworkManagerVerifierWorkspaceReachabilityAnalysisIntentCRUD
{
    # Setup
    # Need to update subscriptionId before runing in live mode
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $verifierWorkspaceName = Get-ResourceName
    $rglocation = "eastus2euap"
    $subscriptionId = "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359"
    $reachabilityAnalysisIntentName = "analysisIntentTest06"

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -Location $rglocation

        # Create verifier workspace
        New-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName -Location $rglocation -Description "Sample description" 

        $sourcePortList = @("100")
        $destinationPortList = @("99")
        $protocolList = @("TCP")
        $sourceIpList = @("192.168.1.10")
        $destinationIpList = @("172.16.0.5")

        $ipTraffic = New-AzNetworkManagerIPTraffic -SourceIps $sourceIpList -DestinationIps $destinationIpList -SourcePorts $sourcePortList -DestinationPorts $destinationPortList -Protocols $protocolList

        $analysisIntent = New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName -SourceResourceId "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/testVM" -DestinationResourceId "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test" -IpTraffic $ipTraffic


        # Get analysis intent
        $reachabilityAnalysisIntent = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName
        Assert-NotNull $reachabilityAnalysisIntent;
        Assert-AreEqual $reachabilityAnalysisIntentName $reachabilityAnalysisIntent.Name;
        Assert-AreEqual $reachabilityAnalysisIntent.Properties.IpTraffic.SourceIps $sourceIpList;
        Assert-AreEqual $reachabilityAnalysisIntent.Properties.IpTraffic.DestinationIps $destinationIpList;

        # Delete analysis intent
        $job = Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName -PassThru -Force -AsJob;
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
        New-AzNetworkManagerVerifierWorkspace -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $verifierWorkspaceName -Location $rglocation -Description "Sample description" 

         # Create analysis intent
        $sourcePortList = @("100")
        $destinationPortList = @("99")
        $protocolList = @("TCP")
        $sourceIpList = @("192.168.1.10")
        $destinationIpList = @("172.16.0.5")
        $groupItem = New-AzNetworkManagerIPTraffic -SourceIps $sourceIpList -DestinationIps $destinationIpList -SourcePorts $sourcePortList -DestinationPorts $destinationPortList -Protocols $protocolList

        $analysisIntent = New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisIntentName -SourceResourceId "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/testVM" -DestinationResourceId "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test" -IpTraffic $groupItem

        # Create analysis run
        # Get the intent ID
        $intentId = $analysisIntent.Id
        Write-Host "Analysis Intent ID: $intentId"

        New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisRunName -IntentId $intentId -Description "DESCription"

        # Get analysis run
        $reachabilityAnalysisRun = Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -VerifierWorkspaceName $verifierWorkspaceName -Name $reachabilityAnalysisRunName
        Assert-NotNull $reachabilityAnalysisRun
        Assert-AreEqual $reachabilityAnalysisRunName $reachabilityAnalysisRun.Name

        Start-TestSleep -Seconds 300

        Assert-AreEqual "DESCription" $reachabilityAnalysisRun.Properties.Description;
        Assert-AreEqual $intentId  $reachabilityAnalysisRun.Properties.IntentId;

        # Delete analysis run
        $job = Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $reachabilityAnalysisRunName -VerifierWorkspaceName $verifierWorkspaceName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;
	}
    finally{
        # Cleanup
        Clean-ResourceGroup $rgName
	}
}

