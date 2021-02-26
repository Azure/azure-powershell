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
    It 'Create DNS Resolver with a new virtual network' {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName0 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId0 -Location $env.ResourceLocation
        $resolver.ProvisioningState | Should -Be $env.SuccessProvisioningState
        $resolver.VirtualNetworkId | Should -Be $env.VirtualNetworkId0 
    }

    It 'Create DNS Resolver with a new virtual network and tags' {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName1 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId1 -Location $env.ResourceLocation -Tag $env.Tag
        $resolver.VirtualNetworkId | Should -Be $env.VirtualNetworkId1
        $resolver.ProvisioningState | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.Tag.Count
    }

    It 'Update DNS Resolver with new tags' {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName2 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId1 -Location $env.ResourceLocation -Tag $env.Tag
        $resolver.VirtualNetworkId   | Should -Be $env.VirtualNetwork2
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.Tag.Count
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName2 -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -Tag $env.TagForUpdate
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.TagForUpdate.Count
    }

    It 'Update DNS Resolver with new tags and IfMatch wildcard, expect DNS Resolver updated.' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName03 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetwork3 -Location $env.ResourceLocation -Tag $env.Tag
        $resolver.VirtualNetworkId   | Should -Be $env.VirtualNetwork3
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.Tag.Count
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName03 -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -Tag $env.TagForUpdate -IfMatch *
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.TagForUpdate.Count
    }

    It 'Update DNS Resolver with new tags and IfMatch success, expect DNS Resolver updated.' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName04 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetwork4 -Location $env.ResourceLocation -Tag $env.Tag
        $resolver.VirtualNetworkId   | Should -Be $env.VirtualNetwork4
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.Tag.Count
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName04 -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -Tag $env.TagForUpdate -IfMatch resolver.Etag
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.TagForUpdate.Count
    }

    It 'Update DNS Resolver with new tags and IfMatch not success, expect DNS Resolver not updated.' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName05 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetwork5 -Location $env.ResourceLocation -Tag $env.Tag
        $resolver.VirtualNetworkId   | Should -Be $env.VirtualNetwork5
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.Tag.Count
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName05 -ResourceGroupName $env.ResourceGroupName -Location $env.ResourceLocation -Tag $env.TagForUpdate -IfMatch resolver.Etag
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $env.TagForUpdate.Count
    }

    It 'Create DNS Resolver with a malformed virtual netwrok' -skip {
       { New-AzDnsResolver -Name $env.DnsResolverName02 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.MalformedVirtualNetwork0 -Location $env.ResourceLocation -Tag $env.Tag } | Should -Throw 
    }

    It 'Create DNS Resolver with a non-existent virtual netwrok' -skip {
        {New-AzDnsResolver -Name $env.DnsResolverName02 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.NonExistentVirtualNetwork -Location $env.ResourceLocation -Tag $env.Tag }| Should -Be "abc"
    }


}
