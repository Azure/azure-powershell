$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzDnsResolver' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update DNS Resolver with new tags.' -skip {
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName10 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId10 -Location $env.ResourceLocation
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $tag = GetRandomHashtable -size 2
        $resolver = New-AzDnsResolver -Name $env.DnsResolverName10 -ResourceGroupName $env.ResourceGroupName -VirtualNetworkId $env.VirtualNetworkId10 -Location $env.ResourceLocation -Tag $tag
        $resolver.ProvisioningState  | Should -Be $env.SuccessProvisioningState
        $resolver.Tag.Count | Should -Be $tag.Count
    }
}
