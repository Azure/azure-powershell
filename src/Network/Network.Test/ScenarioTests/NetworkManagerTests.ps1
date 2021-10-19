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
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $rglocation = "centraluseuap"
    

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52")
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;
        Assert-AreEqual  $networkmanager.NetworkManagerScopeAccesses[0] "Connectivity";
        Assert-AreEqual $networkManager.NetworkManagerScopes.Subscriptions[0] "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52";

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
Tests creating new simple public networkmanager group
#>
function Test-NetworkManagerGroupCRUD
{
    # Setup
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $rglocation = "centraluseuap"
    

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52")
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        $groupmem = New-AzNetworkManagerGroupMembersItem -ResourceId "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/testvnet"
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerGroupMembersItem]]$groupMembers  = @()
        $groupMembers.Add($groupmem)
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -GroupMember $groupMembers -MemberType "Microsoft.Network/VirtualNetwork" -DisplayName "DISplayName" -Description "SampleDESCRIption" -ConditionalMembership "fakeconditionalmembership" 

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName 
        Assert-NotNull $networkGroup;
        Assert-AreEqual $networkGroupName $networkGroup.Name;
        Assert-AreEqual "DISplayName" $networkGroup.DisplayName;
        Assert-AreEqual "fakeconditionalmembership" $networkGroup.ConditionalMembership;
        Assert-AreEqual "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/testvnet" $networkGroup.GroupMembers[0].ResourceId;

        $networkGroup.DisplayName = "Sample Group Name"
        $newNetworkGroup = Set-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkGroup $networkGroup
        Assert-NotNull $newNetworkGroup;
        Assert-AreEqual "Sample Group Name" $newNetworkGroup.DisplayName;
        Assert-AreEqual $networkGroupName $newNetworkGroup.Name;

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
Tests creating new simple public networkmanager Connectivity Configuration
#>
function Test-NetworkManagerConnectivityConfigurationCRUD
{
    # Setup
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $connectivityConfigurationName = Get-ResourceName
    $rglocation = "eastus2euap"
    
    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52")
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("Connectivity");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        $groupmem = New-AzNetworkManagerGroupMembersItem -ResourceId "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/testvnet"
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerGroupMembersItem]]$groupMembers  = @()
        $groupMembers.Add($groupmem)
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -GroupMember $groupMembers -MemberType "Microsoft.Network/VirtualNetwork" -DisplayName "DISplayName" -Description "SampleDESCRIption"

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        $connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $networkGroup.Id -IsGlobal
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]]$connectivityGroup  = @()  
        $connectivityGroup.Add($connectivityGroupItem)   

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub]]$hubList  = @() 
        $hub = New-AzNetworkManagerHub -ResourceId "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/hub" -ResourceType "Microsoft.Network/virtualNetworks" 
        $hubList.Add($hub)

        New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -Name $connectivityConfigurationName -NetworkManagerName $networkManagerName -ConnectivityTopology "HubAndSpoke" -Hub $hublist -AppliesToGroup $connectivityGroup -DeleteExistingPeering 

        $connConfig = Get-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $connectivityConfigurationName 
        Assert-NotNull $connConfig;
        Assert-AreEqual $connectivityConfigurationName $connConfig.Name;
        Assert-AreEqual "HubAndSpoke" $connConfig.ConnectivityTopology;
        Assert-AreEqual $networkGroup.Id $connConfig.AppliesToGroups[0].NetworkGroupId;
        Assert-AreEqual "None"  $connConfig.AppliesToGroups[0].GroupConnectivity;
        Assert-AreEqual "True"  $connConfig.AppliesToGroups[0].IsGlobal;
        Assert-AreEqual "False"  $connConfig.AppliesToGroups[0].UseHubGateway;
        Assert-AreEqual "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/hub"  $connConfig.Hubs[0].ResourceId;
        Assert-AreEqual "Microsoft.Network/virtualNetworks" $connConfig.Hubs[0].ResourceType;
        Assert-AreEqual "False"  $connConfig.IsGlobal;
        Assert-AreEqual "True"  $connConfig.DeleteExistingPeering;

        $connConfig.DisplayName = "Sample Config Name"
        $newConnConfig = Set-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkManagerConnectivityConfiguration $connConfig
        Assert-NotNull $newConnConfig;
        Assert-AreEqual "Sample Config Name" $newConnConfig.DisplayName;
        Assert-AreEqual $connectivityConfigurationName $newConnConfig.Name;


        [System.Collections.Generic.List[string]]$configids  = @()
        $configids.Add($newConnConfig.Id);
        [System.Collections.Generic.List[String]]$regions = @()  
        $regions.Add($rglocation)
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "Connectivity" 
        #Start-Sleep -Seconds 600
         
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
        Assert-AreEqual "True"   $activeConnectivityConfig.Value[0].AppliesToGroups[0].IsGlobal;
        Assert-AreEqual "False"   $activeConnectivityConfig.Value[0].AppliesToGroups[0].UseHubGateway;
        Assert-AreEqual "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/hub"   $activeConnectivityConfig.Value[0].Hubs[0].ResourceId;
        Assert-AreEqual "Microsoft.Network/virtualNetworks"  $activeConnectivityConfig.Value[0].Hubs[0].ResourceType;
        Assert-AreEqual "False"   $activeConnectivityConfig.Value[0].IsGlobal;
        Assert-AreEqual "True"   $activeConnectivityConfig.Value[0].DeleteExistingPeering;

        $vnet = "testvnet"
        $vnetRG = "ANMRG3495"
        $effectiveConnectivityConfig = Get-AzNetworkManagerEffectiveConnectivityConfigurationList -VirtualNetworkName $vnet -ResourceGroupName $vnetRG
        Assert-NotNull $effectiveConnectivityConfig;
        Assert-AreEqual  $newConnConfig.Id $effectiveConnectivityConfig.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveConnectivityConfig.Value[0].ConfigurationGroups[0].Id;
        Assert-AreEqual "HubAndSpoke" $effectiveConnectivityConfig.Value[0].ConnectivityTopology
        Assert-AreEqual $networkGroup.Id $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].NetworkGroupId;
        Assert-AreEqual "None"   $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].GroupConnectivity;
        Assert-AreEqual "True"   $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].IsGlobal;
        Assert-AreEqual "False"   $effectiveConnectivityConfig.Value[0].AppliesToGroups[0].UseHubGateway;
        Assert-AreEqual "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/hub"   $effectiveConnectivityConfig.Value[0].Hubs[0].ResourceId;
        Assert-AreEqual "Microsoft.Network/virtualNetworks"  $effectiveConnectivityConfig.Value[0].Hubs[0].ResourceType;
        Assert-AreEqual "False"   $effectiveConnectivityConfig.Value[0].IsGlobal;
        Assert-AreEqual "True"   $effectiveConnectivityConfig.Value[0].DeleteExistingPeering;

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "Connectivity" 
        #Start-Sleep -Seconds 600

        $job = Remove-AzNetworkManagerConnectivityConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $connectivityConfigurationName -PassThru -Force -AsJob;
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
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $SecurityConfigurationName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName = Get-ResourceName
    $rglocation = "centraluseuap"
    

    try{
        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52")
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("SecurityAdmin");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        $groupmem = New-AzNetworkManagerGroupMembersItem -ResourceId "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/pstestvnet"
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerGroupMembersItem]]$groupMembers  = @()
        $groupMembers.Add($groupmem)
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -GroupMember $groupMembers -MemberType "Microsoft.Network/VirtualNetwork" -DisplayName "DISplayName" -Description "SampleConfigDESCRIption"

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -DisplayName "DISplayName" -Description "DESCription" -DeleteExistingNSG
        
        $securityConfig = Get-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName 
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;

        $securityConfig.DisplayName = "sample Config DisplayName"
        $securityConfig = Set-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkManagerSecurityAdminConfiguration $securityConfig
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual "sample Config DisplayName" $securityConfig.DisplayName;

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)

        New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 

        $ruleCollection = Get-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual  $networkGroup.Id $ruleCollection.AppliesToGroups[0].NetworkGroupId;

        $ruleCollection.DisplayName = "Sample rule Collection displayName"
        $ruleCollection.Description = "Sample rule Collection Description"
        $ruleCollection = Set-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -NetworkManagerSecurityAdminRuleCollection $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Sample rule Collection displayName" $ruleCollection.DisplayName;
 
        $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
        $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 

        [System.Collections.Generic.List[string]]$sourcePortList = @()
        $sourcePortList.Add("100")
        [System.Collections.Generic.List[String]]$destinationPortList = @()
        $destinationPortList.Add("99");
        New-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -DisplayName "DISPLay" -Description "Description" -Protocol  "TCP" -Direction "Inbound" -Access "Allow" -Priority 100 -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -Source $sourceAddressPrefix -Destination $destinationAddressPrefix 

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

        $adminRule.DisplayName = "Sample Rule Name"
        $newAdminRule = Set-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -SecurityAdminRule $adminRule
        Assert-NotNull $newAdminRule;
        Assert-AreEqual "Sample Rule Name" $newAdminRule.DisplayName;
        Assert-AreEqual $RuleName $newAdminRule.Name;

        [System.Collections.Generic.List[string]]$configids  = @()
        $configids.Add($securityConfig.Id);
        [System.Collections.Generic.List[String]]$regions = @()  
        $regions.Add($rglocation)
        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -ConfigurationId $configids -CommitType "SecurityAdmin" 
        #Start-Sleep -Seconds 600
         
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
        Assert-AreEqual $securityConfig.DisplayName $activeSecurityAdminRule.Value[0].ConfigurationDisplayName;
        Assert-AreEqual $securityConfig.Description $activeSecurityAdminRule.Value[0].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.DisplayName $activeSecurityAdminRule.Value[0].RuleCollectionDisplayName;
        Assert-AreEqual $ruleCollection.Description $activeSecurityAdminRule.Value[0].RuleCollectionDescription;

        Assert-AreEqual "TCP" $activeSecurityAdminRule.Value[0].Protocol 
        Assert-AreEqual "Inbound" $activeSecurityAdminRule.Value[0].Direction 
        Assert-AreEqual "Allow" $activeSecurityAdminRule.Value[0].Access 
        Assert-AreEqual 100 $activeSecurityAdminRule.Value[0].Priority

        Assert-AreEqual "100" $activeSecurityAdminRule.Value[0].SourcePortRanges[0] 
        Assert-AreEqual "99" $activeSecurityAdminRule.Value[0].DestinationPortRanges[0]
        Assert-AreEqual "10.0.0.1" $activeSecurityAdminRule.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $activeSecurityAdminRule.Value[0].Sources[0].AddressPrefix

        $effectiveSecurityAdminRule = Get-AzNetworkManagerEffectiveSecurityAdminRuleList  -VirtualNetworkName "pstestvnet" -ResourceGroupName "ANMRG3495"
        Assert-NotNull $effectiveSecurityAdminRule;
        Assert-AreEqual  $newAdminRule.Id $effectiveSecurityAdminRule.Value[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRule.Value[0].RuleGroups[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRule.Value[0].RuleCollectionAppliesToGroups[0].NetworkGroupId;
       

        Assert-AreEqual $securityConfig.DisplayName $effectiveSecurityAdminRule.Value[0].ConfigurationDisplayName;
        Assert-AreEqual $securityConfig.Description $effectiveSecurityAdminRule.Value[0].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.DisplayName $effectiveSecurityAdminRule.Value[0].RuleCollectionDisplayName;
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
        #Start-Sleep -Seconds 600

        $job = Remove-AzNetworkManagerSecurityAdminRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityAdminConfigurationName $SecurityConfigurationName -Name $RuleCollectionName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -PassThru -Force -AsJob;
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
Tests creating/getting/deleting new simple public networkmanager security User Configuration/RuleCollection/Rule
#>
function Test-NetworkManagerSecurityUserRuleCRUD
{
    # Setup
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $SecurityConfigurationName = Get-ResourceName
    $RuleCollectionName = Get-ResourceName
    $RuleName = Get-ResourceName
    $rglocation = "centraluseuap"
    

    try{

        #Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        [System.Collections.Generic.List[string]]$group  = @()
        $group.Add("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52")
        [System.Collections.Generic.List[String]]$access  = @()
        $access.Add("SecurityUser");
        $scope = New-AzNetworkManagerScope -Subscription $group
        New-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        $networkManager = Get-AzNetworkManager -ResourceGroupName $rgname -Name $networkManagerName
        Assert-NotNull $networkManager;
        Assert-AreEqual $networkManagerName $networkManager.Name;
        Assert-AreEqual $rglocation $networkManager.Location;

        $groupmem = New-AzNetworkManagerGroupMembersItem -ResourceId "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/pstestvnet"
        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerGroupMembersItem]]$groupMembers  = @()
        $groupMembers.Add($groupmem)
        New-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName -GroupMember $groupMembers -MemberType "Microsoft.Network/VirtualNetwork" -DisplayName "DISplayName" -Description "SampleDESCRIption"

        $networkGroup = Get-AzNetworkManagerGroup -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $networkGroupName

        New-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -DisplayName "DISplayName" -Description "DESCription" -DeleteExistingNSG
        
        $securityConfig = Get-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName 
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;

        $securityConfig.DisplayName = "sample DisplayName"
        $securityConfig = Set-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -NetworkManagerSecurityUserConfiguration $securityConfig
        Assert-NotNull $securityConfig;
        Assert-AreEqual $SecurityConfigurationName $securityConfig.Name;
        Assert-AreEqual "sample DisplayName" $securityConfig.DisplayName;

        [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem]]$configGroup  = @() 
        $groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId $networkGroup.Id
        $configGroup.Add($groupItem)

        New-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName -AppliesToGroup $configGroup 

        $ruleCollection = Get-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName -Name $RuleCollectionName
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual  $networkGroup.Id $ruleCollection.AppliesToGroups[0].NetworkGroupId;

        $ruleCollection.DisplayName = "Sample displayName"
        $ruleCollection = Set-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityConfigurationName -NetworkManagerSecurityUserRuleCollection $ruleCollection
        Assert-NotNull $ruleCollection;
        Assert-AreEqual $RuleCollectionName $ruleCollection.Name;
        Assert-AreEqual "Sample displayName" $ruleCollection.DisplayName;
 
        $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
        $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 

        [System.Collections.Generic.List[string]]$sourcePortList = @()
        $sourcePortList.Add("100")
        [System.Collections.Generic.List[String]]$destinationPortList = @()
        $destinationPortList.Add("99");
        New-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -ConfigName $SecurityConfigurationName  -RuleCollectionName $RuleCollectionName -Name $RuleName -DisplayName "DISPLay" -Description "Description" -Protocol  "TCP" -Direction "Inbound"  -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -Source $sourceAddressPrefix -Destination $destinationAddressPrefix 

        $UserRule = Get-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName
        Assert-NotNull $UserRule
        Assert-AreEqual $RuleName $UserRule.Name 
        Assert-AreEqual "TCP" $UserRule.Protocol 
        Assert-AreEqual "Inbound" $UserRule.Direction

        Assert-AreEqual "100" $UserRule.SourcePortRanges[0]
        Assert-AreEqual "99" $UserRule.DestinationPortRanges[0] 
        Assert-AreEqual "Internet" $UserRule.Sources[0].AddressPrefix
        Assert-AreEqual "10.0.0.1" $UserRule.Destinations[0].AddressPrefix
        

        $UserRule.DisplayName = "Sample Config Rule Name"
        $newUserRule = Set-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -SecurityUserRule $UserRule
        Assert-NotNull $newUserRule;
        Assert-AreEqual "Sample Config Rule Name" $newUserRule.DisplayName;
        Assert-AreEqual $RuleName $newUserRule.Name;

        $job = Remove-AzNetworkManagerSecurityUserRule -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityConfigurationName -RuleCollectionName $RuleCollectionName -Name $RuleName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerSecurityUserRuleCollection -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -SecurityUserConfigurationName $SecurityConfigurationName -Name $RuleCollectionName -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removeResult = $job | Receive-Job;

        $job = Remove-AzNetworkManagerSecurityUserConfiguration -ResourceGroupName $rgname -NetworkManagerName $networkManagerName -Name $SecurityConfigurationName -PassThru -Force -AsJob;
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