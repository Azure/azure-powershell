."$PSScriptRoot\testDataGenerator.ps1"

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    Import-Module -Name Az.Resources
    $subscriptionId = (Get-AzContext).Subscription.Id
    $env.SubscriptionId = $subscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    $rstr1 = RandomString -allChars $false -len 6
    write-host "creating test resource group..."
    #$resourceGroupName = "powershelldnsresolvertestrg" + $rstr1
    $resourceGroupName = "powershelldnsresolvertestrg" + "localtest"
    New-AzResourceGroup -Name $resourceGroupName -Location westus2
    $env.Add("ResourceGroupName", $resourceGroupName)

    $dnsResolverNamePrefix = "psdnsresolvername"
    $dnsResolverNameEnvKeyPrefix = "DnsResolverName"
    $virtualNetworkNamePrefix = "psvirtualnetworkname"
    $virtualNetworIdEnvKeyPrefix = "VirtualNetworkId"

    For($i=0; $i -le 20; $i++){
        $dnsResolverName = $dnsResolverNamePrefix + $i + (RandomString -allChars $false -len 6)
        $dnsResolverNameEnvKey = $dnsResolverNameEnvKeyPrefix + $i
        $virtualNetworkName = $virtualNetworkNamePrefix + $i + (RandomString -allChars $false -len 6)
        $virtualNetworkIdEnvKey = $virtualNetworIdEnvKeyPrefix + $i
        $virtualNetworkId = (GetNrpMockVirtualNetwork -subscriptionId  $subscriptionId -resourceGroupName $resourceGroupName -virtualNetworkName $virtualNetworkName -NrpSimulatorRootUri "https://westus2.test.azuremresolver.net:9002").id
        $null = $env.Add($dnsResolverNameEnvKey, $dnsResolverName);
        $null = $env.Add($virtualNetworkIdEnvKey, $virtualNetworkId);
    }
    $null = $env.Add("SuccessProvisioningState", "Succeeded");
    $null = $env.Add("ResourceLocation", "westus2");
    $null = $env.Add("MalformedVirtualNetworkErrorMessage", "Resource ID is not a valid virtual network resource ID");


    $tag = @{
        key0 = "value0";
        key1 = "value1"
    }

    $tagForUpdate=@{
        CA = "California";
        NY = "New York";
       "IL" = "Illinois";
       "NH" = "New Hampshire"
     }

    $null = $env.Add("Tag", $tags);
    $null = $env.Add("TagForUpdate", $tagForUpdate);

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.ResourceGroupName
}

