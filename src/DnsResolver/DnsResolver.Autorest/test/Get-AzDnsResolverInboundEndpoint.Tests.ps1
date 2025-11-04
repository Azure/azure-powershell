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
        $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
        $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
    }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
    
    Start-Sleep -Seconds 5
    $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnetId 
    New-AzDnsResolverInboundEndpoint -DnsResolverName $DnsResolverName -Name $InboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -IPConfiguration $ipConfiguration -Location $LOCATION
}

Describe 'Get-AzDnsResolverInboundEndpoint' {
    It 'Get single inbound endpoint by name, expect inbound endpoint by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername172";
        $inboundEndpointName =  "psinboundendpointname172";
        $virtualNetworkName = "psvirtualnetworkname172";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;

        CreateInboundEndpoint -InboundEndpointName $inboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $inboundEndpoint =  Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $inboundEndpoint | Should -BeSuccessfullyCreatedInboundEndpoint

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
    }

    It 'List Inbound Endpoints under a DNS Resolver name, expected exact number of inbound endpoints retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername182";
        $inboundEndpointName =  "psinboundendpointname182";
        $virtualNetworkName = "psvirtualnetworkname182";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;

        CreateInboundEndpoint -InboundEndpointName $inboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 
        
        # ACT
        $inboundEndpoints =  Get-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $inboundEndpoints.Count | Should -Be "1"

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
    }
}