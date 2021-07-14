."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\forwardingRulesetAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreatedDnsForwardingRuleset' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameForwardingRulesetAsExpected' -Test $Function:BeSameAsExpected

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)){
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverDnsForwardingRuleset.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath){
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolverDnsForwardingRuleset'{
    It 'Update DNS forwarding ruleset with no change, expect DNS forwarding ruleset not changed' -skip {
        $dnsResolverName = $env.DnsResolverName24
        $virtualNetworkId = $env.VirtualNetworkId24
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        Update-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 0
    }

    It 'Update DNS forwarding ruleset with new metaddata expect DNS forwarding ruleset updated' -skip {
        $dnsResolverName = $env.DnsResolverName25
        $virtualNetworkId = $env.VirtualNetworkId25
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Tag $metadata
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }

    It 'Update DNS forwarding ruleset with new metadata via identity, expect DNS forwarding ruleset updated' -skip {
        $dnsResolverName = $env.DnsResolverName26
        $virtualNetworkId = $env.VirtualNetworkId26
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        $inputObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject.Id -Tag $metadata
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }

    It 'Update DNS forwarding ruleset with new metadata via identity and IfMatch matches, expect DNS forwarding ruleset updated' -skip {
        $dnsResolverName = $env.DnsResolverName27
        $virtualNetworkId = $env.VirtualNetworkId27
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        $inputObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject.Id -Tag $metadata -IfMatch $ruleset.Etag
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }

    
    It 'Update DNS forwarding ruleset with new metadata via identity and IfMatch not match, expect DNS forwarding ruleset not updated' -skip {
        $dnsResolverName = $env.DnsResolverName28
        $virtualNetworkId = $env.VirtualNetworkId28
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $outboundEndpointName = "outbound"
        $virtualNetworkName = ExtractArmResourceName -ResourceId $virtualNetworkId
        $subnetName = "subnetNameForRemove" + (RandomString -allChars $false -len 6)
        $subnetid = (CreateSubnet -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -VirtualNetworkName $virtualNetworkName -SubnetName $subnetName).id
        $outboundEndpoint = New-AzDnsResolverOutboundEndpoint -DnsResolverName $dnsResolverName -Name $outboundEndpointName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -SubnetId $subnetid
        $dnsForwardingRulesetName = "forwardingRulesetForGet" + (RandomString -allChars $false -len 6)
        $ruleset = New-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -DnsResolverOutboundEndpoint  @{id = $outboundEndpoint.Id;}

        $inputObject = (Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName)
        $metadata  = GetRandomHashtable -size 2
        Update-AzDnsResolverDnsForwardingRuleset -InputObject $inputObject.Id -Tag $metadata -IfMatch $ruleset.Etag
        $retrievedDnsForwardingRuleset = Get-AzDnsResolverDnsForwardingRuleset -Name $dnsForwardingRulesetName -ResourceGroupName $env.ResourceGroupName
        $retrievedDnsForwardingRuleset | Should -BeSameForwardingRulesetAsExpected $inputObject
        $retrievedDnsForwardingRuleset.Metadata.Count | Should -Be 3
    }
}
