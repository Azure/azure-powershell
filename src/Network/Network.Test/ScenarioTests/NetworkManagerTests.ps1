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
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
    $managementGroupId = "/providers/Microsoft.Management/managementGroups/PowerShellTest"

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
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"

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
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
    $vnetId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnet"

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
    # Please pre create vnet and hub vnet before running test in live mode, also please update subscriptionId and uncomment 10 mins sleep code
    $rgName = Get-ResourceGroupName
    $networkManagerName = Get-ResourceName
    $networkGroupName = Get-ResourceName
    $staticMemberName = Get-ResourceName
    $connectivityConfigurationName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
    $vnetId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnet"
    $hubId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub" 
    $vnet = "powerShellTestVnet"
    $vnetRG = "jaredgorthy-PowerShellTestResources"
    
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

        Start-TestSleep -Seconds 60

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

        $effectiveConnectivityConfig = Get-AzNetworkManagerEffectiveConnectivityConfiguration -VirtualNetworkName $vnet -VirtualNetworkResourceGroupName $vnetRG
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

        Start-TestSleep -Seconds 60

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
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
    $vnetId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnet"
    $vnetName = "powerShellTestVnet"
    $vnetRG = "jaredgorthy-PowerShellTestResources"

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
        Assert-AreEqual "10.0.0.1" $activeSecurityAdminRule.Value[0].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $activeSecurityAdminRule.Value[0].Sources[0].AddressPrefix

        $effectiveSecurityAdminRuleList = Get-AzNetworkManagerEffectiveSecurityAdminRule  -VirtualNetworkName $vnetName -VirtualNetworkResourceGroupName $vnetRG
        Assert-NotNull $effectiveSecurityAdminRuleList;

        <#
        # Network manager at AVNM testing MG will apply rules on this vnet; extract the rule this test has applied
        [Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseAdminRule]$effectiveSecurityAdminRule = $null
        foreach ($rule in $effectiveSecurityAdminRuleList)
        {
            Write-Host rule.Id
            if ($rule.Id -eq $newAdminRule.Id)
            {
                $effectiveSecurityAdminRule = $rule;
                break;
            }
        }
        Assert-NotNull $effectiveSecurityAdminRule;
        #>

        Assert-AreEqual  $newAdminRule.Id $effectiveSecurityAdminRuleList.Value[3].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRuleList.Value[3].RuleGroups[0].Id;
        Assert-AreEqual  $networkGroup.Id $effectiveSecurityAdminRuleList.Value[3].RuleCollectionAppliesToGroups[0].NetworkGroupId;
       

        Assert-AreEqual $securityConfig.Description $effectiveSecurityAdminRuleList.Value[3].ConfigurationDescription;
        Assert-AreEqual $ruleCollection.Description $effectiveSecurityAdminRuleList.Value[3].RuleCollectionDescription;

        Assert-AreEqual "TCP" $effectiveSecurityAdminRuleList.Value[3].Protocol 
        Assert-AreEqual "Inbound" $effectiveSecurityAdminRuleList.Value[3].Direction 
        Assert-AreEqual "Allow" $effectiveSecurityAdminRuleList.Value[3].Access 
        Assert-AreEqual 100 $effectiveSecurityAdminRuleList.Value[3].Priority

        Assert-AreEqual "100" $effectiveSecurityAdminRuleList.Value[3].SourcePortRanges[0] 
        Assert-AreEqual "99" $effectiveSecurityAdminRuleList.Value[3].DestinationPortRanges[0]
        Assert-AreEqual "10.0.0.1" $effectiveSecurityAdminRuleList.Value[3].Destinations[0].AddressPrefix
        Assert-AreEqual "Internet" $effectiveSecurityAdminRuleList.Value[3].Sources[0].AddressPrefix

        Deploy-AzNetworkManagerCommit -ResourceGroupName $rgname -Name $networkManagerName -TargetLocation $regions -CommitType "SecurityAdmin" 

        Start-TestSleep -Seconds 60

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
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"

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
    $networkManagerId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/networkManagers/PowerShellTestNM-DO-NOT-DELETE"

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
    $networkManagerId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/networkManagers/PowerShellTestNM-DO-NOT-DELETE"
    $managementGroupId = "PowerShellTestNMConection"

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
    $subscriptionId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
    $vnetId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnet"

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