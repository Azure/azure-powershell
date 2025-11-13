."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\outboundEndpointAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedOutboundEndpoint' -Test $Function:BeSuccessfullyCreatedOutboundEndpoint

if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverOutboundEndpoint'))
{
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
}

function CreateOutboundEndpoint([String]$OutboundEndpointName, [String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
    {
        $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
        $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
    }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
    
    Start-Sleep -Seconds 5
    New-AzDnsResolverOutboundEndpoint -DnsResolverName $DnsResolverName -Name $OutboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME -SubnetId $subnetId -Location $LOCATION
}

Describe 'Get-AzDnsResolverOutboundEndpoint' {
    It 'Get single outbound endpoint by name, expect outbound endpoint by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername212";
        $outboundEndpointName =  "psoutboundendpointname212";
        $virtualNetworkName = "psvirtualnetworkname212";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;

        CreateOutboundEndpoint -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $outboundEndpoint =  Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $outboundEndpoint | Should -BeSuccessfullyCreatedOutboundEndpoint

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }

    It 'List Outbound Endpoints under a DNS Resolver name, expected exact number of outbound endpoints retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername222";
        $outboundEndpointName =  "psoutboundendpointname222";
        $virtualNetworkName = "psvirtualnetworkname222";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
        $subnetId = $virtualNetworkId + "/subnets/" + $SUBNET_NAME;

        CreateOutboundEndpoint -OutboundEndpointName $outboundEndpointName -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 
        
        # ACT
        $outboundEndpoints =  Get-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $outboundEndpoints.Count | Should -Be "1"

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }
}