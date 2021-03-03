."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameAsExpected' -Test $Function:BeSameAsExpected

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolver' {
    It 'Update DNS Resolver by adding tag, expect resolver updated' {
        $dnsResolverName = $env.DnsResolverName33
        $virtualNetworkId = $env.VirtualNetworkId33
        $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $tag  = GetRandomHashtable -size 5
        $updatedResolver = Update-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -Tag $tag

        $resolver | Should -BeSuccessfullyCreated
        $updatedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
        $updatedResolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update DNS Resolver by adding tag via identity, expect resolver updated' {
        $dnsResolverName = $env.DnsResolverName34
        $virtualNetworkId = $env.VirtualNetworkId34
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $resolver = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        $tag  = GetRandomHashtable -size 5
        $updatedResolver = Update-AzDnsResolver -InputObject $resolver  -Tag $tag
        
        $resolver | Should -BeSuccessfullyCreated
        $updatedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
        $updatedResolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update DNS Resolver by adding tag via identity IfMatch wildcard success, expect resolver updated' {
        $dnsResolverName = $env.DnsResolverName35
        $virtualNetworkId = $env.VirtualNetworkId35
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $resolver = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        $tag  = GetRandomHashtable -size 5
        $updatedResolver = Update-AzDnsResolver -InputObject $resolver -Tag $tag -IfMatch *
        
        $resolver | Should -BeSuccessfullyCreated
        $updatedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
        $updatedResolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update DNS Resolver by adding tag via identity IfMatch matches etag, expect resolver updated' {
        $dnsResolverName = $env.DnsResolverName36
        $virtualNetworkId = $env.VirtualNetworkId36
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $resolver = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        $tag  = GetRandomHashtable -size 5
        $updatedResolver = Update-AzDnsResolver -InputObject $resolver -Tag $tag -IfMatch $resolver.Etag
        
        $resolver | Should -BeSuccessfullyCreated
        $updatedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
        $updatedResolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Update DNS Resolver by adding tag IfMatch not match, expect resolver not updated' {
        $dnsResolverName = $env.DnsResolverName36
        $virtualNetworkId = $env.VirtualNetworkId36
        $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation

        $tag  = GetRandomHashtable -size 5
        $etag = (RandomString -allChars $false -len 10) 
        {Update-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -Tag $tag -IfMatch $etag} | Should -Throw "is invalid"

        $retrievedResolver = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        $retrievedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
        $retrievedResolver.Tag.Count | Should -Be 0
    }

    It 'Update DNS Resolver by adding tag via identity IfMatch not match , expect resolver not updated' {
        $dnsResolverName = $env.DnsResolverName37
        $virtualNetworkId = $env.VirtualNetworkId37
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $resolver = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        $tag  = GetRandomHashtable -size 5
        $etag = (RandomString -allChars $false -len 10)
        {Update-AzDnsResolver -InputObject $resolver -Tag $tag -IfMatch $etag} | Should -Throw "is invalid"

        $retrievedResolver = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        $retrievedResolver | Should -BeSameAsExpected -ExpectedValue $resolver
        $retrievedResolver.Tag.Count | Should -Be 0
    }
}
