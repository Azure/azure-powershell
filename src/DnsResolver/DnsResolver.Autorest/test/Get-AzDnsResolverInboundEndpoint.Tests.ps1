."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\inboundEndpointAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedInboundEndpoint' -Test $Function:BeSuccessfullyCreatedInboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverInboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function CreateInboundEndpoint([String]$InboundEndpointName, [String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
        }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
    
    $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnetId 
    New-AzDnsResolverInboundEndpoint -DnsResolverName $DnsResolverName -Name $InboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -IPConfiguration $ipConfiguration -Location $LOCATION
}

Describe 'Get-AzDnsResolverInboundEndpoint' {
    It 'Get single inbound endpoint by name, expect inbound endpoint by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername17";
        $inboundEndpointName =  "psinboundendpointname17";
        $virtualNetworkName = "psvirtualnetworkname17";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;

        CreateInboundEndpoint -InboundEndpointName $inboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $inboundEndpoint =  Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $inboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint
    }

    It 'List Inbound Endpoints under a DNS Resolver name, expected exact number of inbound endpoints retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername18";
        $inboundEndpointName =  "psinboundendpointname18";
        $virtualNetworkName = "psvirtualnetworkname18";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;

        CreateInboundEndpoint -InboundEndpointName $inboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 
        
        # ACT
        $inboundEndpoints =  Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $inboundEndpoints.Count | Should -Be "1"
    }
}