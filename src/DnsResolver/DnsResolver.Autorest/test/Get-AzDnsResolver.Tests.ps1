."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"
."$PSScriptRoot\stringExtensions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function CreateDnsResolver([String]$DnsResolverName, [String]$VirtualNetworkName)
{
    if ($TestMode -eq "Record")
        {
            $virtualNetwork = CreateVirtualNetwork -SubscriptionId $SUBSCRIPTION_ID -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkName $VirtualNetworkName;
        }

    New-AzDnsResolver -Name $DnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION
}

Describe 'Get-AzDnsResolver' {
    It 'Get single DNS resolver by name, expect DNS resolver by name retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername62";
        $virtualNetworkName = "psvirtualnetworkname62";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        CreateDnsResolver -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 

        # ACT
        $dnsResolver =  Get-AzDnsResolver -DnsResolverName $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolver | Should -BeSuccessfullyCreated
    }

    It 'List DNS resolvers in a resource group, expected least number of DNS resolvers retrieved' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername63";
        $virtualNetworkName = "psvirtualnetworkname63";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        CreateDnsResolver -DnsResolverName $dnsResolverName -VirtualNetworkName $virtualNetworkName 
        
        # ACT
        $dnsResolvers =  Get-AzDnsResolver -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
    }
}