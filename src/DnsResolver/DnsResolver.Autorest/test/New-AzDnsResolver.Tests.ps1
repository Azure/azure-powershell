."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated

if(($null -eq $TestName) -or ($TestName -contains 'New-AzDnsResolver'))
{
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
}

Describe 'New-AzDnsResolver' {
    It 'Create DNS resolver with new virtual network' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername0j0cdzg";
        $virtualNetworkName = "psvirtualnetworkforresolvername0j0cdzg";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        # ACT
        $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $location

        # ASSERT
        $resolver | Should -BeSuccessfullyCreated
        $resolver.VirtualNetworkId | Should -Be $virtualNetworkId

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }

    It 'Create DNS resolver with a malformed virtual network ARM ID' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername1uerapj";
        $malformedVirtualNetworkArmId = "/subscriptions/91ab65d2-c73f-4768-89d0-b061815f258b/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname1dkijv7";
        
        # ACT,ASSERT
        {New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $malformedVirtualNetworkArmId -Location $location }| Should -Throw
    }

    It 'Create DNS resolver with a new virtual network' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername2zpuk2x";
        $tag = GetRandomHashtable -size 2
        $virtualNetworkName = "psvirtualnetworkforresolvername0j0fasg";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        # ACT
         $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $location -Tag $tag

        # ASSERT
        $resolver.ProvisioningState | Should -Be "Succeeded"
        $resolver.VirtualNetworkId | Should -Be $virtualNetworkId
        $resolver.Tag.Count | Should -Be $tag.Count
        
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }

    It 'Create DNS resolver with a non-existent virtual network' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername3142sgr";
        $virtualNetworkId = "/subscriptions/91ab65d2-c73f-4768-89d0-b061815f258b/resourceGroups/powershell-test-rg-debug/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname28oq6tl";
        $nonExistentVirtualNetwork = "/subscriptions/91ab65d2-c73f-4768-89d0-b061815f258b/resourceGroups/powershelldnsresolvertestrglocaltest/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname9aywbo511111"

        # ACT, ASSERT
        {New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $nonExistentVirtualNetwork -Location $location }| Should -Throw
    }

    It 'Update DNS Resolver with new tags.' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername4c7glpm";
        $virtualNetworkName = "psvirtualnetworkforresolvername0j8sfdzg";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $location
        $tag = GetRandomHashtable -size 2

        # ACT
        $resolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $location -Tag $tag

        # ASSERT
        $resolver.ProvisioningState  | Should -Be "Succeeded"
        $resolver.Tag.Count | Should -Be $tag.Count

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        if ($TestMode -eq "Record")
        {
            Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        }
    }
}
