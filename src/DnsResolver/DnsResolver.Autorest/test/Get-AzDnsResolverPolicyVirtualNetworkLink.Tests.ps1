if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverPolicyVirtualNetworkLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverPolicyVirtualNetworkLink' {
    It 'Gets a virtual network link by name, expected virtual network link returned' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinknameafa9789a";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinknameafa9789a";
        $virtualNetworkName = "psvirtualnetworkforlinknameafa9789a";
        $resourceGroupName = "powershell-test-rg-debug-get";
        $location = "westus2";
        $subscriptionId = "91ab65d2-c73f-4768-89d0-b061815f258b";
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT
        $dnsResolverPolicyLink = Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName

        # ASSERT
        $dnsResolverPolicyLink | Should -Not -BeNullOrEmpty
    }

    It 'List virtual network links, expected virtual network links returned' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinkname7sadjfa";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinkname7sadjfa";
        $virtualNetworkName = "psvirtualnetworkforlinkname7sadjfa";
        $resourceGroupName = "powershell-test-rg-debug-get";
        $location = "westus2";
        $subscriptionId = "91ab65d2-c73f-4768-89d0-b061815f258b";
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT
        $dnsResolverPolicyLinks = Get-AzDnsResolverPolicyVirtualNetworkLink -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName

        # ASSERT
        $dnsResolverPolicyLinks.Count | Should -BeGreaterThan 0
    }
}
