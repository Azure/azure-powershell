."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\outboundEndpointAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedOutboundEndpoint' -Test $Function:BeSuccessfullyCreatedOutboundEndpoint

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverOutboundEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function CreateOutboundEndpoint([String]$OutboundEndpointName, [String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
            $subnet = CreateSubnet -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
        }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
    
    New-AzDnsResolverOutboundEndpoint -DnsResolverName $DnsResolverName -Name $OutboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION
}

Describe 'Get-AzDnsResolverOutboundEndpoint' {
    It 'Get single outbound endpoint by name, expect outbound endpoint by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername21";
        $outboundEndpointName =  "psoutboundendpointname21";
        $virtualNetworkName = "psvirtualnetworkname21";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;

        CreateOutboundEndpoint -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $outboundEndpoint =  Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint
    }

    It 'List Outbound Endpoints under a DNS Resolver name, expected exact number of outbound endpoints retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername22";
        $outboundEndpointName =  "psoutboundendpointname22";
        $virtualNetworkName = "psvirtualnetworkname22";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets" + $SUBNET_NAME;

        CreateOutboundEndpoint -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 
        
        # ACT
        $outboundEndpoints =  Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $outboundEndpoints.Count | Should -Be "1"
    }
}