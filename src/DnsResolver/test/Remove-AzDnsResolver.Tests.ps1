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
        New-AzDnsResolver -Name $env.DnsResolverName22 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId22 -Location $env.ResourceLocation
        Remove-AzDnsResolver -Name $env.DnsResolverName22 -ResourceGroupName $env.ResourceGroupName
        Get-AzDnsResolver -Name $env.DnsResolverName22  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver via identity, expect DNS Resolver deleted' -skip {
        New-AzDnsResolver -Name $env.DnsResolverName23 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId23 -Location $env.ResourceLocation
        $resolverObject = (Get-AzDnsResolver -Name $env.DnsResolverName23  -ResourceGroupName $env.ResourceGroupName)
        Remove-AzDnsResolver -InputObject $resolverObject
        {Get-AzDnsResolver -Name $env.DnsResolverName23  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver by name and IfMatch success, expect DNS Resolver deleted' -skip {
        New-AzDnsResolver -Name $env.DnsResolverName22 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId22 -Location $env.ResourceLocation
        Remove-AzDnsResolver -Name $env.DnsResolverName22 -ResourceGroupName $env.ResourceGroupName -IfMatch $resolver.Etag
        {Get-AzDnsResolver -Name $env.DnsResolverName22  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }

    It 'Delete an existing DNS Resolver by name and IfMatch wildcard success, expect DNS Resolver deleted' -skip {
        New-AzDnsResolver -Name $env.DnsResolverName22 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId22 -Location $env.ResourceLocation
        Remove-AzDnsResolver -Name $env.DnsResolverName22 -ResourceGroupName $env.ResourceGroupName -IfMatch *
        {Get-AzDnsResolver -Name $env.DnsResolverName22  -ResourceGroupName $env.ResourceGroupName} | Should -Throw 'was not found.'
    }



    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
