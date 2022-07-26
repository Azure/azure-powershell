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

    $cmdletData = Get-Command $cmdletName;
    Assert-NotNull $cmdletData;
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") };
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") };
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.","";
    return $cmdletReturnTypes -contains $realReturnType;
}

<#
.SYNOPSIS
Test creating new PrivateLinkService using minimal set of parameters
#>
function Test-PrivateLinkServiceCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rname = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateLinkServices" "westcentralus";
    # Dependency parameters
    $IpConfigurationName = "IpConfigurationName";
    $vnetName = Get-ResourceName;
    $ilbFrontName = "LB-Frontend";
    $ilbBackendName = "LB-Backend";
    $ilbName = Get-ResourceName;

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location;

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24";
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24";
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"; 
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet;

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $ilbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id;
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $ilbBackendName;
        $job = New-AzLoadBalancer -ResourceGroupName $rgname -Name $ilbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -AsJob;
        $job | Wait-Job
        $ilbcreate = $job | Receive-Job

        # Verfify if load balancer is created successfully
        Assert-NotNull $ilbcreate;
        Assert-AreEqual $ilbName $ilbcreate.Name;
        Assert-AreEqual (Normalize-Location $location) $ilbcreate.Location;
        Assert-AreEqual "Succeeded" $ilbcreate.ProvisioningState

        # Create required dependencies
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2];
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $ilbName | Get-AzLoadBalancerFrontendIpConfig
        
        # Create PrivateLinkService
        $job = New-AzPrivateLinkService -ResourceGroupName $rgName -Name $rname -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -AsJob;
        $job | Wait-Job
        $plscreate = $job | Receive-Job
        
        $vPrivateLinkService = Get-AzPrivateLinkService -Name $rname -ResourceGroupName $rgName
        
        # Verification
        Assert-NotNull $vPrivateLinkService;
        Assert-AreEqual $rname $vPrivateLinkService.Name;
        Assert-NotNull $vPrivateLinkService.IpConfigurations;
        Assert-True { $vPrivateLinkService.IpConfigurations.Length -gt 0 };
        Assert-AreEqual "Succeeded" $vPrivateLinkService.ProvisioningState

        # Get all PrivateLinkServices in resource group
        $listPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName $rgname;
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription
        $listPrivateLinkService = Get-AzPrivateLinkService;
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription wildcard for resource group
        $listPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName "*";
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription wildcard for name
        $listPrivateLinkService = Get-AzPrivateLinkService -Name "*";
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Get all PrivateLinkServices in subscription wildcard for both resource group and name
        $listPrivateLinkService = Get-AzPrivateLinkService -ResourceGroupName "*" -Name "*";
        Assert-NotNull ($listPrivateLinkService | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $rname });

        # Remove PrivateLinkService
        $job = Remove-AzPrivateLinkService -ResourceGroupName $rgname -Name $rname -PassThru -Force -AsJob;
        $job | Wait-Job;
        $removePrivateLinkService = $job | Receive-Job;
        Assert-AreEqual true $removePrivateLinkService;

        $list = Get-AzPrivateLinkService -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
} 

<#
.SYNOPSIS
Test operation for PrivateEndpointConnection.
#>
function Test-PrivateEndpointConnectionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rname = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/privateLinkServices" "eastus2";
    # Dependency parameters
    $IpConfigurationName = "IpConfigurationName";
    $vnetName = Get-ResourceName;
    $ilbFrontName = "LB-Frontend";
    $ilbBackendName = "LB-Backend";
    $ilbName = Get-ResourceName;

    $serverName = Get-ResourceName
    $serverLogin = "testusername"
    <#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
    $serverPassword = "t357ingP@s5w0rd!Sec"
    $credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
    $databaseName = "mySampleDatabase"
    $peName = "mype"
    $subId = getSubscription

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location;

        if ((Get-NetworkTestMode) -ne 'Playback')
        {
            # Create Sql Storage Account
            $server = New-AzSqlServer -ResourceGroupName $rgname `
                -ServerName $serverName `
                -Location $location `
                -SqlAdministratorCredentials $credentials

            $database = New-AzSqlDatabase  -ResourceGroupName $rgname `
                -ServerName $serverName `
                -DatabaseName $databaseName `
                -RequestedServiceObjectiveName "Basic" `
                -Edition "Basic"

            $sqlResourceId = $server.ResourceId
        }
        else
        {
            $sqlResourceId = "/subscriptions/$subId/resourceGroups/$rgname/providers/Microsoft.Sql/servers/$serverName"
        }

        # Create Private Endpoint
        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name peSubnet -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name "vnetPE" -ResourceGroupName $rgname -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet

        $plsConnection= New-AzPrivateLinkServiceConnection -Name plsConnection -PrivateLinkServiceId  $sqlResourceId -GroupId 'sqlServer'
        $privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $peName -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $plsConnection -ByManualRequest

        # Get Private Endpoint Connection
        $pecGet = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $sqlResourceId
        Assert-NotNull $pecGet;
        Assert-AreEqual "Pending" $pecGet.PrivateLinkServiceConnectionState.Status

        # Approve Private Endpoint Connection
        $pecApprove = Approve-AzPrivateEndpointConnection -ResourceId $pecGet.Id
        Assert-NotNull $pecApprove;
        Assert-AreEqual "Approved" $pecApprove.PrivateLinkServiceConnectionState.Status

        Start-TestSleep 20000

        # Remove Private Endpoint Connection
        $pecRemove = Remove-AzPrivateEndpointConnection -ResourceId $pecGet.Id -PassThru -Force
        Assert-AreEqual true $pecRemove

        Start-TestSleep 15000

        # Get Private Endpoint Connection again
        $pecGet2 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $sqlResourceId
        Assert-Null($pecGet2)

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test operation for StoragePrivateEndpoint.
#>
function Test-StoragePrivateEndpoint
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $location = Get-ProviderLocation "Microsoft.Network/privateLinkServices" "eastus";
    $peName = "mype";
    $storageAccount = "xdmsa2";
    $subId = getSubscription

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location;
        New-AzStorageAccount -ResourceGroupName $rgname -AccountName $storageAccount -Location $location -SkuName Standard_GRS

        $resourceId = "/subscriptions/$subId/resourceGroups/$rgname/providers/Microsoft.Storage/storageAccounts/$storageAccount";

        $peSubnet = New-AzVirtualNetworkSubnetConfig -Name peSubnet -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
        $vnetPE = New-AzVirtualNetwork -Name "vnetPE" -ResourceGroupName $rgname -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet
        
        $plsConnection= New-AzPrivateLinkServiceConnection -Name plsConnection -PrivateLinkServiceId  $resourceId -GroupId 'blob'
        $privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $peName -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $plsConnection -ByManualRequest

        $pecGet = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
        Assert-NotNull $pecGet;
        Assert-AreEqual "Pending" $pecGet.PrivateLinkServiceConnectionState.Status

        # Approve Private Endpoint Connection
        $pecApprove = Approve-AzPrivateEndpointConnection -ResourceId $pecGet.Id
        Assert-NotNull $pecApprove;
        Assert-AreEqual "Approved" $pecApprove.PrivateLinkServiceConnectionState.Status

        Start-TestSleep 20000

        # Remove Private Endpoint Connection
        $pecRemove = Remove-AzPrivateEndpointConnection -ResourceId $pecGet.Id -PassThru -Force
        Assert-AreEqual true $pecRemove

        Start-TestSleep 15000

        # Get Private Endpoint Connection again
        $pecGet2 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
        Assert-Null($pecGet2)

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test creating a private link service in an edge zone. Subscriptions need to be explicitly whitelisted for access to edge zones.
#>
function Test-PrivateLinkServiceInEdgeZone
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "westus"
    # Dependency parameters
    $IpConfigurationName = "IpConfigurationName"
    $vnetName = Get-ResourceName
    $ilbFrontName = "LB-Frontend"
    $ilbBackendName = "LB-Backend"
    $ilbName = Get-ResourceName
    $edgeZone = "microsoftlosangeles1"

    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        # Create Virtual networks
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name "frontendSubnet" -AddressPrefix "10.0.1.0/24"
        $backendSubnet = New-AzVirtualNetworkSubnetConfig -Name "backendSubnet" -AddressPrefix "10.0.2.0/24"
        $otherSubnet = New-AzVirtualNetworkSubnetConfig -Name "otherSubnet" -AddressPrefix "10.0.3.0/24" -PrivateLinkServiceNetworkPoliciesFlag "Disabled"
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet,$otherSubnet -EdgeZone $edgeZone

        # Create LoadBalancer
        $frontendIP = New-AzLoadBalancerFrontendIpConfig -Name $ilbFrontName -PrivateIpAddress "10.0.1.5" -SubnetId $vnet.subnets[0].Id
        $beaddresspool= New-AzLoadBalancerBackendAddressPoolConfig -Name $ilbBackendName
        $ilbcreate = New-AzLoadBalancer -ResourceGroupName $rgname -Name $ilbName -Location $location -FrontendIpConfiguration $frontendIP -BackendAddressPool $beaddresspool -Sku "Standard" -EdgeZone $edgeZone

        # Verfify if load balancer is created successfully
        Assert-NotNull $ilbcreate
        Assert-AreEqual $ilbName $ilbcreate.Name
        Assert-AreEqual (Normalize-Location $location) $ilbcreate.Location
        Assert-AreEqual "Succeeded" $ilbcreate.ProvisioningState

        # Create required dependencies
        $IpConfiguration = New-AzPrivateLinkServiceIpConfig -Name $IpConfigurationName -PrivateIpAddress 10.0.3.5 -Subnet $vnet.subnets[2]
        $LoadBalancerFrontendIpConfiguration = Get-AzLoadBalancer -Name $ilbName | Get-AzLoadBalancerFrontendIpConfig

        # Create PrivateLinkService
        New-AzPrivateLinkService -ResourceGroupName $rgName -Name $rname -Location $location -IpConfiguration $IpConfiguration -LoadBalancerFrontendIpConfiguration $LoadBalancerFrontendIpConfiguration -EdgeZone $edgeZone
        $vPrivateLinkService = Get-AzPrivateLinkService -Name $rname -ResourceGroupName $rgName

        Assert-AreEqual $vPrivateLinkService.ExtendedLocation.Name $edgeZone
        Assert-AreEqual $vPrivateLinkService.ExtendedLocation.Type "EdgeZone"
    }
    catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]
    {
        Assert-NotNull { $_.Exception.Message -match 'Resource type .* does not support edge zone .* in location .* The supported edge zones are .*' }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test operation for ResourceManagerPrivateEndpoint.
#>
function Test-ResourceManagerPrivateEndpoint
{
    # Setup
    $rgname = "testPS"
    $rmplname = "RMPL"
    $location = "eastus"
    $sub = getSubscription
    # Dependency parameters
    $IpConfigurationName = "IpConfigurationName"
    $vnetName = Get-ResourceName
    $plsConnectionName = Get-ResourceName
    $endpointName = Get-ResourceName

    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        #Create ResourceManagementPrivateLink
        #$rmpl = New-AzResourceManagementPrivateLink -ResourceGroupName $rgName -Name $rmplname -Location $location

        $rmplid = "/subscriptions/$sub/resourceGroups/$rgname/providers/Microsoft.Authorization/resourceManagementPrivateLinks/$rmplname"
        $PrivateLinkResource = Get-AzPrivateLinkResource -PrivateLinkResourceId $rmplid

        #Vnet Configuration
        $SubnetConfig = New-AzVirtualNetworkSubnetConfig -Name "Subnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
        $VNet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $SubnetConfig

        # Create Private Endpoint
        $PLSConnection = New-AzPrivateLinkServiceConnection -Name $plsConnectionName -PrivateLinkServiceId $rmplid -GroupId "ResourceManagement"
        $privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $rgName -Name $endpointName -Location $location -Subnet $VNet.subnets[0] -PrivateLinkServiceConnection $PLSConnection -ByManualRequest

        $pecGet = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $rmplid
        Assert-NotNull $pecGet;
        Assert-AreEqual "Pending" $pecGet.PrivateLinkServiceConnectionState.Status

        # Approve Private Endpoint Connection
        $pecApprove = Approve-AzPrivateEndpointConnection -ResourceId $pecGet.Id
        Assert-NotNull $pecApprove;
        Start-TestSleep 15000
        $pecApprove = Get-AzPrivateEndpointConnection -ResourceId $pecGet.Id
        Assert-AreEqual "Approved" $pecApprove.PrivateLinkServiceConnectionState.Status

        # Remove Private Endpoint Connection
        $pecRemove = Remove-AzPrivateEndpointConnection -ResourceId $pecGet.Id -PassThru -Force
        Assert-AreEqual true $pecRemove
    }
    finally
    {
        #Cleanup
        Clean-ResourceGroup $rgname;
    }
}