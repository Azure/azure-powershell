."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsResolver' {
    It 'Create DNS resolver with new virtual network' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName0 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId0 -Location $env.ResourceLocation
        $resolver | Should -BeSuccessfullyCreated
        $resolver.VirtualNetworkId | Should -Be $env.VirtualNetworkId0 
    }

    It 'Create DNS resolver with a malformed virtual network arm id'-skip{
        $malformedVirtualNetworkArmId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname1dkijv7"
         {New-AzDnsResolver -Name $env.DnsResolverName1 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $malformedVirtualNetworkArmId -Location $env.ResourceLocation }| Should -Throw 'Unparseable resource ID'
    }

    It 'Create DNS resolver with a new virtual network' -skip {
        $tag = GetRandomHashtable -size 2
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName2 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId2 -Location $env.ResourceLocation -Tag $tag
        $resolver.ProvisioningState | Should -Be $env.SuccessProvisioningState
        $resolver.VirtualNetworkId | Should -Be $env.VirtualNetworkId2
        $resolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Create DNS resolver with a non-existant virtual network' -skip {
        $nonExistantVirtualNetwork = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname9aywbo511111"
        {New-AzDnsResolver -Name $env.DnsResolverName3 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $nonExistantVirtualNetwork -Location $env.ResourceLocation }| Should -Throw 'DNS resolver not found in database'
    }

    It 'Update DNS Resolver with new tags.' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName4 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId4 -Location $env.ResourceLocation
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $tag = GetRandomHashtable -size 2
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName4 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId4 -Location $env.ResourceLocation -Tag $tag
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update DNS Resolver with new tags IfMatch wildcard success' -skip{
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName5 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId5 -Location $env.ResourceLocation
        $tag = GetRandomHashtable -size 2
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName5 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId5 -Location $env.ResourceLocation -Tag $tag -IfMatch * 
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update a non-existant DNS Resolver with new tags IfMatch wildcard success' -skip{
        $nonExistantResolverName = RandomString -allChars $false -len 6
        {New-AzDnsResolver -Name $nonExistantResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId5 -Location $env.ResourceLocation -IfMatch *} | Should -Throw 'DNS resolver not found in database'
    }

    It 'Update DNS Resolver with new tags and IfMatch wildcard failure, expect DNS Resolver not updated' -skip{
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName6 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId6 -Location $env.ResourceLocation
        $tag = GetRandomHashtable -size 2
        Write-Host $resolver.Etag
        $ifMatchString = RandomGUID
        {$resolver = New-AzDnsResolver -Name $env.DnsResolverName6 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId6 -Location $env.ResourceLocation -Tag $tag -IfMatch $ifMatchString} | Should -Throw "The format of value"
    }

    It 'Update DNS Resolver with new tags and IfMatch success, expect DNS Resolver updated' -skip{
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName7 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId7 -Location $env.ResourceLocation
        $tag = GetRandomHashtable -size 2
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName7 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId7 -Location $env.ResourceLocation -Tag $tag -IfMatch $resolver.Etag
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update DNS Resolver with no change, expect DNS Resolver not updated.' -skip{
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName8 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId8 -Location $env.ResourceLocation
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName8 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId8 -Location $env.ResourceLocation
        $resolver.VirtualNetworkId | Should -Be $env.VirtualNetworkId8
        $resolver.Tag.Count | Should -Be 0
    }

    It 'Update DNS Resolver by removing tags and IfMatch success, expect DNS Resolver updated' -skip{
        $tag = GetRandomHashtable -size 5
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName9 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId9 -Location $env.ResourceLocation -Tag $tag
        $expectedTagCount = 0
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName9 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId9 -Location $env.ResourceLocation -IfMatch $resolver.Etag
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $expectedTagCount
    }

    It 'Create DNS Resolver IfNoneMatch wildcard, expect DNS Resolver created' -skip{
        $tag = GetRandomHashtable -size 5
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName10 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId10 -Location $env.ResourceLocation -Tag $tag -IfNoneMatch *
        $resolver.ProvisioningState | Should -Be $env.SuccessProvisioningState
        $resolver.VirtualNetworkId | Should -Be $env.VirtualNetworkId10 
    }
}
