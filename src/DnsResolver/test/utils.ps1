."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\stringExtensions.ps1"

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    Import-Module -Name Az.Resources

    Select-AzSubscription -SubscriptionObject (Get-AzSubscription -SubscriptionId ea40042d-63d8-4d02-9261-fb31450e6c67)

    Register-AzResourceProvider -ProviderNamespace Microsoft.Network
    $subscriptionId = (Get-AzContext).Subscription.Id

    write-host "subscriptionId" $subscriptionId

    $env.SubscriptionId = $subscriptionId

    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    write-host "creating test resource group..."
    $resourceGroupName = "powershelldnsresolvertestrg" + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $resourceGroupName -Location eastus2 -SubscriptionId ea40042d-63d8-4d02-9261-fb31450e6c67
    $env.Add("ResourceGroupName", $resourceGroupName)

    $null = $env.Add("DnsResolverNamePrefix", "psdnsresolvername");
    $null = $env.Add("VirtualNetworkNamePrefix", "psvirtualnetworkname");
    $null = $env.Add("InboundEndpointNamePrefix", "psinboundendpointname");
    $null = $env.Add("SubnetNamePrefix", "pssubnetname");
    $null = $env.Add("InboundEnpointNamePrefix", "psinboundendpointname");
    $null = $env.Add("OutboundEndpointNamePrefix", "psoutboundendpointname");
    $null = $env.Add("DnsForwardingRulesetNamePrefix", "psdnsforwardingrulesetname");


    $null = $env.Add("SuccessProvisioningState", "Succeeded");
    $null = $env.Add("ResourceLocation", "eastus2");
    $null = $env.Add("MalformedVirtualNetworkErrorMessage", "Resource ID is not a valid virtual network resource ID");
    $null = $env.Add("AddressPrefix", "40.121.0.0/16");
    $null = $env.Add("LocationForVirtualNetwork", "eastus2");
    
    $nrpSimulatorUri = [System.Environment]::GetEnvironmentVariable('NRP_SIMULATOR_URI')

    if($nrpSimulatorUri -ne $null){
        $null = $env.Add("NRP_SIMULATOR_URI", $nrpSimulatorUri);
    }

    # Provison of virtual network and generating DNS Resolver name.
    # New-cmdlet uses 0 - 12
    # Get-cmdlet uses 13 - 21
    # Remove-cmdlet uses 22-32
    # Patch 33 - 38
    # New IE - 38 - 45
    # Patch IE - 46 - 49
    # Get IE 50 - 60
    # Remove IE 61 - 62
    $dnsResolverNameEnvKeyPrefix = "DnsResolverName"
    $virtualNetworkIdEnvKeyPrefix = "VirtualNetworkId"
    $subnetIdEnvKeyPrefix = "SubnetId"
    $inboundEndpointNameEnvKeyPrefix = "InboundEnpointName"
    $outboundEndpointNameEnvKeyPrefix = "OutboundEndpointName"
    $dnsForwardingRulesetNameEnvKeyPrefix = "DnsForwardingRulesetName"
    For($i=0; $i -le 70; $i++){
        $dnsResolverNameEnvKey = $dnsResolverNameEnvKeyPrefix + $i
        $dnsResolverName = $env.DnsResolverNamePrefix + $i + (RandomString -allChars $false -len 6)
        $null = $env.Add($dnsResolverNameEnvKey, $dnsResolverName);

        $inboundEndpointNameEnvKey = $inboundEndpointNameEnvKeyPrefix + $i
        $inboundEndpointName = $env.InboundEnpointNamePrefix + $i + (RandomString -allChars $false -len 6)
        $null = $env.Add($inboundEndpointNameEnvKey, $inboundEndpointName);

        $outboundEndpointNameEnvKey = $outboundEndpointNameEnvKeyPrefix + $i
        $outboundEndpointName = $env.OutboundEndpointNamePrefix + $i + (RandomString -allChars $false -len 6)
        $null = $env.Add($outboundEndpointNameEnvKey, $outboundEndpointName);

        $dnsForwardingRulesetNameEnvKey = $dnsForwardingRulesetNameEnvKeyPrefix + $i
        $dnsForwardingRulesetName = $env.DnsForwardingRulesetNamePrefix + $i + (RandomString -allChars $false -len 6)
        $null = $env.Add($dnsForwardingRulesetNameEnvKey, $dnsForwardingRulesetName);

        $virtualNetworkIdEnvKey = $virtualNetworkIdEnvKeyPrefix + $i
        $virtualNetworkName = $env.VirtualNetworkNamePrefix + $i + (RandomString -allChars $false -len 6)
        $virtualNetworkId = (CreateVirtualNetwork -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName).id
        $null = $env.Add($virtualNetworkIdEnvKey, $virtualNetworkId);

        $subnetIdEnvKey = $subnetIdEnvKeyPrefix + $i
        $subnetName = $env.SubnetNamePrefix + $i + (RandomString -allChars $false -len 6)
        $subnetId = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $null = $env.Add($subnetIdEnvKey, $subnetId);
    }

    # 
    $dnsResolverName = $env.DnsResolverName60
    $virtualNetworkId = $env.VirtualNetworkId60
    New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
    $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
    $numberOfInboundEndpointForGet = 3
    $inboundEndpointNamePrefixForGet = "inboundEndpointNameForGet"
    $null = $env.Add("NumberOfInboundEndpointForGet", $numberOfInboundEndpointForGet);
    $null = $env.Add("DnsResolverNameForInboundEndpointGet", $dnsResolverName);
    $null = $env.Add("InboundEndpointNamePrefixForGet", $inboundEndpointNamePrefixForGet);
    New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
    For($i=0; $i -lt $numberOfInboundEndpointForGet; $i++){
        $subnetName = "subnetNameForGet" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $privateIp = RandomIp
        $inboundEndpointName = "inboundEndpointNameForGet" + (RandomString -allChars $false -len 6)
        $null = $env.Add("InboundEndpointNamePrefixForGet" + $i, $inboundEndpointName);
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid
        write-host "creating test Inbound Endpoint for get ...name = "  + $inboundEndpointName
        # New-AzDnsResolverInboundEndpoint -DnsResolverName $dnsResolverName -Name $inboundEndpointName -ResourceGroupName $env.ResourceGroupName -IPConfiguration $ipConfiguration
    }

    # 
    $dnsResolverName = $env.DnsResolverName61
    $virtualNetworkId = $env.VirtualNetworkId61
    New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation -SubscriptionId $env.SubscriptionId
    $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
    $numberOfResources = 2
    $outboundEndpointNamePrefixForGet = "outboundEndpointNameForGet"
    $null = $env.Add("NumberOfResources", $numberOfResources);
    $null = $env.Add("DnsResolverNameForOutboundEndpointGet", $dnsResolverName);
    $null = $env.Add("OutboundEndpointNamePrefixForGet", $outboundEndpointNamePrefixForGet);
    $null = $env.Add("VirtualNetworkForGet", $virtualNetworkName);
    New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation -SubscriptionId $env.SubscriptionId
    For($i=0; $i -lt $numberOfResources; $i++){
        $subnetName = "subnetNameForGet" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $privateIp = RandomIp
        $outboundEndpointName = "outboundEndpointNameForGet" + (RandomString -allChars $false -len 6)
        $null = $env.Add("OutboundEndpointNameForGet" + $i, $outboundEndpointName);
        $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId $subnetid
        write-host "creating test Outbound Endpoint for get ...subnetId = "  + $subnetid
        write-host "creating test Outbound Endpoint for get ...ipCongif = "  + $ipConfiguration
        write-host "creating test Outbound Endpoint for get ...name = "  + $outboundEndpointName
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $null = $env.Add("ForwardingRulesetForGet" + $i, $dnsForwardingRulesetName);
        New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}
    }
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean resources you create for testing
    #Remove-AzResourceGroup -Name $env.ResourceGroupName
}

