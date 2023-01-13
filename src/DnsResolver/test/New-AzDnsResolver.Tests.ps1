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
    It 'Create DNS resolver with new virtual network' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername0j0cdzg";
        $resourceGroupName = "powershell-test-rg-debug";
        $virtualNetworkId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg-debug/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname0879evh";
        $location = "westus2";

        # ACT
        $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $resourceGroupName -VirtualNetworkId $virtualNetworkId -Location $location

        # ASSERT
        $resolver | Should -BeSuccessfullyCreated
        $resolver.VirtualNetworkId | Should -Be $virtualNetworkId 
    }

    It 'Create DNS resolver with a malformed virtual network ARM ID' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername1uerapj";
        $resourceGroupName = "powershell-test-rg-debug";
        $malformedVirtualNetworkArmId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname1dkijv7";
        $location = "westus2";
        
        # ACT,ASSERT
        {New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $resourceGroupName -VirtualNetworkId $malformedVirtualNetworkArmId -Location $location }| Should -Throw
    }

    It 'Create DNS resolver with a new virtual network' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername2zpuk2x";
        $resourceGroupName = "powershell-test-rg-debug";
        $virtualNetworkId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg-debug/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname28oq6tl";
        $location = "westus2";
        $tag = GetRandomHashtable -size 2

        # ACT
         $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $resourceGroupName -VirtualNetworkId $virtualNetworkId -Location $location -Tag $tag

        # ASSERT
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.VirtualNetworkId | Should -Be $virtualNetworkId
        $resolver.Tag.Count | Should -Be $tag.Count
    }

    It 'Create DNS resolver with a non-existent virtual network' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername3142sgr";
        $resourceGroupName = "powershell-test-rg-debug";
        $virtualNetworkId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg-debug/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname28oq6tl";
        $location = "westus2";
        $nonExistentVirtualNetwork = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname9aywbo511111"

        # ACT, ASSERT
        {New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $resourceGroupName -VirtualNetworkId $nonExistentVirtualNetwork -Location $location }| Should -Throw
    }

    It 'Update DNS Resolver with new tags.' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername4c7glpm";
        $resourceGroupName = "powershell-test-rg-debug";
        $virtualNetworkId = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg-debug/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname4mox6wf";
        $location = "westus2";

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $resourceGroupName -VirtualNetworkId $virtualNetworkId -Location $location
        $tag = GetRandomHashtable -size 2

        # ACT
        $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $resourceGroupName -VirtualNetworkId $virtualNetworkId -Location $location -Tag $tag

        # ASSERT
        $resolver.ProvisioningState  | Should -Be "Succeeded"
        $resolver.Tag.Count | Should -Be $tag.Count
    }
}
