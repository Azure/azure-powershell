."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameAsExpected' -Test $Function:BeSameAsExpected
Add-AssertionOperator -Name 'BeSameDnsResolverCollectionAsExpected' -Test $Function:BeSameDnsResolverCollectionAsExpected

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

Describe 'Get-AzDnsResolver' {
    $totalDnsResolversInRgCount = 0
    It 'Get single DNS Resolver by name, expect DNS Resolver retrieved' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName16 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId16 -Location $env.ResourceLocation
        $resolver | Should -BeSuccessfullyCreated
        $retrievedResolver = Get-AzDnsResolver -Name $env.DnsResolverName16  -ResourceGroupName $env.ResourceGroupName
        $retrievedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
    }

    It 'Get single DNS Resolver via identity, expect DNS Resolver retrieved'-skip{
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName16 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId16 -Location $env.ResourceLocation
        $resolverObject = (Get-AzDnsResolver -Name $env.DnsResolverName16  -ResourceGroupName $env.ResourceGroupName)
        $retrievedResolverViaIdentity = Get-AzDnsResolver -InputObject $resolverObject
        $retrievedResolverViaIdentity | Should -BeSameAsExpected -ExpectedValue $resolver
    }

    It 'Get single non-existent DNS Resolver by name, expect failure' -skip{
        $randomDnsResolverName = RandomString -allChars $false -len 6
        {$retrievedResolver = Get-AzDnsResolver -Name $randomDnsResolverName  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
        
    }

    It 'List DNS Resolvers in the resource group, expect resolvers retrieved' -skip{
        $resolver0 = New-AzDnsResolver -Name $env.DnsResolverName13 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId13 -Location $env.ResourceLocation
        $resolver1 = New-AzDnsResolver -Name $env.DnsResolverName14 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId14 -Location $env.ResourceLocation
        $resolver2 = New-AzDnsResolver -Name $env.DnsResolverName15 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId15 -Location $env.ResourceLocation
        $resolvers = Get-AzDnsResolver -ResourceGroupName $env.ResourceGroupName
        $resolvers.Count | Should -Be 3
    }

    It 'List DNS Resolvers in the Subscription' -skip {
        $resolver0 = New-AzDnsResolver -Name $env.DnsResolverName13 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId13 -Location $env.ResourceLocation
        $resolver1 = New-AzDnsResolver -Name $env.DnsResolverName14 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId14 -Location $env.ResourceLocation
        $resolvers = Get-AzDnsResolver
        $resolvers.Count | Should -BeGreaterOrEqual 2
    }

    It 'List DNS Resolvers in the Subscription with top parameter, expect specified number of resolvers retrieved.' {
        $resolver0 = New-AzDnsResolver -Name $env.DnsResolverName13 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId13 -Location $env.ResourceLocation
        $resolver1 = New-AzDnsResolver -Name $env.DnsResolverName14 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId14 -Location $env.ResourceLocation
        $resolver2 = New-AzDnsResolver -Name $env.DnsResolverName15 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId15 -Location $env.ResourceLocation
        $resolvers = Get-AzDnsResolver -Top 3
        $resolvers.Count | Should -Be 3
    }

    BeforeEach {
        $resolvers = Get-AzDnsResolver -ResourceGroupName $env.ResourceGroupName
        foreach ($resolver in $resolvers) {
            Remove-AzDnsResolver -InputObject $resolver 
        }
        
    }
}
