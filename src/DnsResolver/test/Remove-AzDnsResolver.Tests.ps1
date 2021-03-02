$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDnsResolver' {
    It 'Delete an existing DNS Resolver by name, expect DNS Resolver deleted' -skip {
        $dnsResolverName = $env.VirtualNetworkId22
        $virtualNetworkId = $env.VirtualNetworkId22
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName
        {Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver via identity, expect DNS Resolver deleted' -skip {
        $dnsResolverName = $env.VirtualNetworkId23
        $virtualNetworkId = $env.VirtualNetworkId23
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        $resolverObject = (Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName)
        Remove-AzDnsResolver -InputObject $resolverObject
        {Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver by name and IfMatch success, expect DNS Resolver deleted' -skip {
        $dnsResolverName = $env.VirtualNetworkId24
        $virtualNetworkId = $env.VirtualNetworkId24
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -IfMatch $resolver.Etag
        {Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver by name and IfMatch wildcard success, expect DNS Resolver deleted' -skip {
        $dnsResolverName = $env.VirtualNetworkId25
        $virtualNetworkId = $env.VirtualNetworkId25
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $virtualNetworkId -Location $env.ResourceLocation
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -IfMatch *
        {Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver by name and IfMatch failure, expect DNS Resolver not deleted' -skip {
        $dnsResolverName = $env.VirtualNetworkId26
        $virtualNetworkId = $env.VirtualNetworkId27
        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId  $virtualNetworkId -Location $env.ResourceLocation
        {Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $env.ResourceGroupName -IfMatch (RandomString -allChars $false -len 6)} | Should -Throw "is invalid"
        {Get-AzDnsResolver -Name $dnsResolverName  -ResourceGroupName $env.ResourceGroupName} | Should -BeSuccessfullyCreated
    }

}
